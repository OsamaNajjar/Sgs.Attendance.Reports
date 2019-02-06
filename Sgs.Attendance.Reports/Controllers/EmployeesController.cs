﻿using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sgs.Attendance.Reports.Logic;
using Sgs.Attendance.Reports.Models;
using Sgs.Attendance.Reports.Services;
using Sgs.Attendance.Reports.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sgs.Attendance.Reports.Controllers
{
    public class EmployeesController : BaseController
    {
        private readonly EmployeesCalendarsManager _employeesCalendarsManager;
        private readonly EmployeesExcusesManager _employeesExcusesManager;
        private readonly IErpManager _erpManager;

        public EmployeesController(EmployeesCalendarsManager employeesCalendarsManager
            , EmployeesExcusesManager employeesExcusesManager
            ,IErpManager erpManager,IMapper mapper, ILogger<EmployeesController> logger)
            : base(mapper, logger)
        {
            _employeesCalendarsManager = employeesCalendarsManager;
            _employeesExcusesManager = employeesExcusesManager;
            _erpManager = erpManager;
        }

        private async Task<List<EmployeeInfoViewModel>> setupEmployeesInfo(IEnumerable<EmployeeInfoViewModel> employeesInfoList,DateTime setupDate)
        {
            try
            {
                var ids = employeesInfoList.Select(e => e.EmployeeId).ToList();

                var employeesCalenars = await _employeesCalendarsManager.GetAll(c => ids.Contains(c.EmployeeId) && setupDate >= c.StartDate
                    && ( !c.EndDate.HasValue || setupDate <= c.EndDate.Value)).AsNoTracking().ToListAsync();

                foreach (var empInfo in employeesInfoList)
                {
                    var defaultCalendar = employeesCalenars.FirstOrDefault(c => c.EmployeeId == empInfo.EmployeeId && !c.EndDate.HasValue);
                    var employeeCalendar = employeesCalenars.FirstOrDefault(c => c.EmployeeId == empInfo.EmployeeId && c.EndDate.HasValue);

                    defaultCalendar = defaultCalendar ?? new EmployeeCalendar
                    {
                        AttendanceProof = AttendanceProof.RequiredInOut,
                        ContractWorkTime = ContractWorkTime.ShiftA
                    };

                    empInfo.AttendanceProof = employeeCalendar?.AttendanceProof ?? defaultCalendar.AttendanceProof;
                    empInfo.ContractWorkTime = employeeCalendar?.ContractWorkTime ?? defaultCalendar.ContractWorkTime;
                    empInfo.Note = employeeCalendar?.Note ?? defaultCalendar.Note;

                }

                return employeesInfoList.ToList() ;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<JsonResult> GetDepartmentEmployees([DataSourceRequest] DataSourceRequest request, string deptCode)
        {
            if (string.IsNullOrWhiteSpace(deptCode))
            {
                return Json(new List<object>() { });
            }

            var allDataList = await _erpManager.GetDepartmentEmployeesInfo(deptCode);

            var ids = allDataList.Select(e => e.EmployeeId).ToList();

            var employeesCalenars = await _employeesCalendarsManager.GetAll(e => ids.Contains(e.EmployeeId)).AsNoTracking().ToListAsync();

            foreach (var calendar in employeesCalenars)
            {
                var dat = allDataList.First(d => d.EmployeeId == calendar.EmployeeId);
                dat.AttendanceProof = calendar.AttendanceProof;
                dat.Note = calendar.Note;
            }
            
            allDataList = await setupEmployeesInfo(allDataList.OrderBy(d => d.DepartmentName),DateTime.Now);

            var result = allDataList.ToTreeDataSourceResult(request,
                e => e.EmployeeId,
                e => e.ReportToId,
                e => e);

            return Json(result);
        }
    }
}

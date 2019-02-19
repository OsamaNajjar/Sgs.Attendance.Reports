﻿using Sameer.Shared;
using System;

namespace Sgs.Attendance.Reports.ViewModels
{
    public class WorkShiftViewModel
    {
        public int Id { get; set; }

        public string ShiftType => !IsDayOff ? "عمل" : "إجازة";
        public string ShiftTypeInRamadan
        {
            get
            {
                if(!IsDayOffInRamadan.HasValue)
                {
                    return ShiftType;
                }
                else
                {
                    return !IsDayOffInRamadan.Value ? "عمل" : "إجازة";
                }
            }
        }

        public int ShiftOrder { get; set; }

        public int ShiftRepeat { get; set; }

        public double? ShiftStart { get; set; }

        public TimeSpan? ShiftStartTime
        {
            get
            {
                return ShiftStart.HasValue ? ShiftStart.Value.ConvertToTime() : default(TimeSpan);
            }
            set
            {
                ShiftStart = value.HasValue ? value.Value.ConvertToDouble() : default(double?);
            }
        }

        public double? ShiftEnd { get; set; }

        public TimeSpan? ShiftEndTime
        {
            get
            {
                return ShiftEnd.HasValue ? ShiftEnd.Value.ConvertToTime() : default(TimeSpan);
            }
            set
            {
                ShiftEnd = value.HasValue ? value.Value.ConvertToDouble() : default(double?);
            }
        }

        public double? ShiftDuration
        {
            get
            {
                if (!ShiftStart.HasValue || !ShiftEnd.HasValue)
                {
                    return null;
                }

                if (ShiftStart.Value < ShiftEnd.Value)
                {
                    return ShiftEnd.Value - ShiftStart.Value;
                }
                else if (ShiftStart.Value > ShiftEnd.Value)
                {
                    return ShiftEnd + (24d - ShiftStart);
                }
                else
                {
                    return 24;
                }
            }
        }

        public TimeSpan? ShiftDurationTime => ShiftDuration.HasValue ?
            ShiftDuration.Value.ConvertToTime() : new TimeSpan(0,0,0);

        public double? ShiftStartInRamadan { get; set; }

        public double? StartInRamadan => ShiftStartInRamadan ?? ShiftStart;

        public TimeSpan? ShiftStartTimeInRamadan
        {
            get
            {
                return ShiftStartInRamadan.HasValue ? ShiftStartInRamadan.Value.ConvertToTime() : default(TimeSpan);
            }
            set
            {
                ShiftStartInRamadan = value.HasValue ? value.Value.ConvertToDouble() : default(double?);
            }
        }

        public TimeSpan? StartTimeInRamadan => ShiftStartTimeInRamadan ?? ShiftStartTime;

        public double? ShiftEndInRamadan { get; set; }

        public double? EndInRamadan => ShiftEndInRamadan ?? ShiftEnd;

        public TimeSpan? ShiftEndTimeInRamadan
        {
            get
            {
                return ShiftEndInRamadan.HasValue ? ShiftEndInRamadan.Value.ConvertToTime() : default(TimeSpan);
            }
            set
            {
                ShiftEndInRamadan = value.HasValue ? value.Value.ConvertToDouble() : default(double?);
            }
        }

        public TimeSpan? EndTimeInRamadan => ShiftEndTimeInRamadan ?? ShiftEndTime;

        public double? ShiftDurationInRamadan
        {
            get
            {
                double? start = ShiftStartInRamadan ?? ShiftStart;

                double? end = ShiftEndInRamadan ?? ShiftEnd;

                if (!start.HasValue || !end.HasValue)
                {
                    return null;
                }

                if (start.Value < end.Value)
                {
                    return end.Value - start.Value;
                }
                else if (start.Value > end.Value)
                {
                    return end + (24d - start);
                }
                else
                {
                    return 24;
                }
            }
        }

        public TimeSpan? ShiftDurationTimeInRamadan => ShiftDurationInRamadan.HasValue ?
            ShiftDurationInRamadan.Value.ConvertToTime() : new TimeSpan(0, 0, 0);

        public bool IsDayOff { get; set; }

        public string DayOffDescription { get; set; }

        public bool? IsDayOffInRamadan { get; set; }

        public bool dayOffInRamadan => IsDayOffInRamadan.HasValue ?
            IsDayOffInRamadan.Value : IsDayOff;

        public string DayOffDescriptionInRamadan { get; set; }

        public string OffDescriptionInRamadan
        {
            get
            {
                if(dayOffInRamadan)
                {
                    return !string.IsNullOrWhiteSpace(DayOffDescriptionInRamadan) ? DayOffDescriptionInRamadan : DayOffDescription;
                }
                return "";
            }
        }

        public int WorkCalendarId { get; set; }

        public string WorkCalendarName { get; set; }

        public string WorkTimeName { get; set; }

    }
}

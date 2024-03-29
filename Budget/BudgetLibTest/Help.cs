﻿using System;
using System.Collections.Generic;

namespace BudgetLibTest
{
    public class Help
    {
        public static Dictionary<string, int> GetDaysInMonth(DateTime startDate, DateTime endDate)
        {
            Dictionary<string, int> lookup = new Dictionary<string, int>();
            if (startDate.Year == endDate.Year && startDate.Month == endDate.Month)
            {
                lookup.Add(startDate.ToString("yyyyMM"), (endDate - startDate).Days + 1);
                return lookup;
            }

            var start = new DateTime(startDate.Year, startDate.Month, 1);
            while (start <= endDate)
            {
                var days = DateTime.DaysInMonth(start.Year, start.Month);
                if (start.Month == startDate.Month && start.Year == startDate.Year)
                {
                    days = days - startDate.Day + 1;
                }
                if (start.Month == endDate.Month && start.Year == endDate.Year)
                {
                    days = endDate.Day;
                }

                lookup[start.ToString("yyyyMM")] = days;

                start = start.AddMonths(1);
            }

            return lookup;
        }
    }
}
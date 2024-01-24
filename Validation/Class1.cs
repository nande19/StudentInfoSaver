using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validation
{
    public class Validations
    {
        // Validate the course Module, year mark, and registered date using a validation class (DLL)
        public static bool IsStudentNumberValid(string Code)
        {
            string pattern = @"^[sS][tT]\d{8}$";
            return Regex.IsMatch(Code, pattern);
        }

        public static bool IsValidModuleCode(string Code)
        {
            // It should consist of 4 capital letters followed by 4 numbers
            string pattern = "^[A-Z]{4}[0-9]{4}$";
            return Regex.IsMatch(Code, pattern);
        }

        public static bool IsValidYearMark(string Mark)
        {
            // Check if the year mark is a valid integer between 0 and 100
            if (int.TryParse(Mark, out int mark))
            {
                return mark >= 0 && mark <= 100;
            }
            return false;
        }

        public static bool IsValidRegistrationDate(string date)
        {
            // Check if the registration date is a valid date within the specified range
            if (DateTime.TryParse(date, out DateTime registrationDate))
            {
                DateTime minDate = new DateTime(2018, 1, 1);
                DateTime maxDate = new DateTime(2023, 3, 28);

                return registrationDate >= minDate && registrationDate <= maxDate;
            }
            return false;
        }
            public static bool IsDateFormatValid(string dateString)
            {
                DateTime date;
                if (DateTime.TryParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return true; // The dateString is a valid date in "yyyy-MM-dd" format
                }
                else
                {
                    return false; // The dateString is not a valid date in the specified format
                }
            }

        }
    }

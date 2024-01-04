using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace VOVO
{
    internal class ValidityCheck
    {
        public string phoneNumber { set; get; }

        public bool IsPhoneNumberValid(string phn_num)
        {
            if (phn_num.Length == 10)
            {
                // Use Regex pattern matching to validate phone number format
                string phnNumPattern = @"^\d{10}$";

                // Validate phone number and email format
                // If phone number is valied then return true otherwise false
                return Regex.IsMatch(phn_num, phnNumPattern);
            }
            return false;
        }

        public bool IsEmailValid(string email)
        {
            // Use Regex pattern matching to validate email format
            string emailFormatPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Validate email format
            // If email is valied then return true otherwise false
            return Regex.IsMatch(email, emailFormatPattern);
        }

        // Method to check if a string contains any non-numeric characters or special characters
        public bool IsNotNumberOrSpecialCharacter(string input)
        {
            // Regular expression pattern to match non-numeric characters and special characters
            string pattern = @"[^0-9a-zA-Z]";

            // Create a Regex object and check if the input matches the pattern
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        public bool IsDOBValid(string dob)
        {

            // Date format
            string dateFormat = "dd/MM/yyyy";

            // Parse the date string using the specified format
            DateTime parsedDate;
            return DateTime.TryParseExact(dob, dateFormat, null, System.Globalization.DateTimeStyles.None, out parsedDate);

        }

        private bool TImeValidityCheck(string time)
        {
            // Define the regular expression pattern for the time format "hh:mm:ss"
            string pattern = @"^([01]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$";

            // Create a Regex object with the pattern
            Regex regex = new Regex(pattern);

            // Use the Regex.Match method to check if the time string matches the pattern
            Match match = regex.Match(time);

            // Return true if the time string matches the pattern, otherwise return false
            return match.Success;
        }
        public bool IsTimeValid(string time)
        {
            return TImeValidityCheck(time);
        }
    }
}

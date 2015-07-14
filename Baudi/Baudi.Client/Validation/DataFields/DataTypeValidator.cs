using System.Text.RegularExpressions;

namespace Baudi.Client.ViewModels.Validation.DataFields
{
    public class DataTypeValidator
    {
        /// <summary>
        ///     Method which checks whether the given string matches the alphabetic character with: space seperator and - and .
        /// </summary>
        /// <param name="dataString"> String data to check</param>
        /// <returns>Bool value - true if correct </returns>
        public bool IsAlphabeticStringCorrect(string dataString)
        {
            var regexResult = Regex.Match(dataString, AlphabeticPattern, RegexOptions.IgnoreCase);
            if (regexResult.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Method which checks whether the given string matches the postal code pattern
        /// </summary>
        /// <param name="dataString"> String data to check</param>
        /// <returns>Bool value - true if correct</returns>
        public bool IsPostalCodeStringCorrect(string dataString)
        {
            var regexResult = Regex.Match(dataString, PostalCodePattern, RegexOptions.IgnoreCase);
            if (regexResult.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Method which checks whether the given string matches the numeric string with: space seperator and + and \
        /// </summary>
        /// <param name="dataString">String data to check</param>
        /// <returns>Bool value - true if correct</returns>
        public bool IsNumericStringCorrect(string dataString)
        {
            var regexResult = Regex.Match(dataString, NumericPattern, RegexOptions.IgnoreCase);
            if (regexResult.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Method which checks whether the given string matches the PESEL pattern
        /// </summary>
        /// <param name="dataString">String data to check</param>
        /// <returns>Bool value - true if correct</returns>
        public bool IsPESELStringCorrect(string dataString)
        {
            var regexResult = Regex.Match(dataString, PESELPattern, RegexOptions.IgnoreCase);
            if (regexResult.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Method which checks whether the given string matches the NIP pattern
        /// </summary>
        /// <param name="dataString">String data to check</param>
        /// <returns>Bool value - true if correct</returns>
        public bool IsNIPStringCorrect(string dataString)
        {
            var regexResult = Regex.Match(dataString, NIPPattern, RegexOptions.IgnoreCase);
            if (regexResult.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Method which checks whether the given string matches the double data: digits and , and . and space seperator
        /// </summary>
        /// <param name="dataString">String data to check</param>
        /// <returns>Bool value - true if correct</returns>
        public bool IsDoubleStringCorrect(string dataString)
        {
            var regexResult = Regex.Match(dataString, DoublePattern, RegexOptions.IgnoreCase);
            if (regexResult.Success)
            {
                return true;
            }
            return false;
        }

        #region Patterns

        /// <summary>
        ///     Allowed characters in alphabetic string
        /// </summary>
        private readonly string AlphabeticPattern = @"([a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŻĄĆ\- \.x]+)";

        private readonly string PostalCodePattern = @"^\d{2}-\d{3}$";
        private readonly string NumericPattern = @"([\+0-9 \\]+)";
        private readonly string PESELPattern = @"^\d{11}$";
        private readonly string NIPPattern = @"^\d{3}-\d{3}-\d{2}-\d{2}$";
        private readonly string DoublePattern = @"([0-9\,\. ]+)";

        #endregion
    }
}
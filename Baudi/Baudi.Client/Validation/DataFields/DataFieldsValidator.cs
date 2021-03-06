﻿using System;

namespace Baudi.Client.ViewModels.Validation.DataFields
{
    public class DataFieldsValidator : DataTypeValidator
    {
        /// <summary>
        ///     Exception message's new line seperator - chanege if needed
        /// </summary>
        private readonly string _lineSeperator = Environment.NewLine;

        public bool IsSalaryCorrect(string salary, ref string exceptionMessage)
        {
            if (!IsDoubleStringCorrect(salary))
            {
                exceptionMessage += "Niepoprawnie podano pensje" + _lineSeperator;
                return false;
            }
            return true;
        }

        public bool IsCostValueCorrect(string costValue, ref string exceptionMessage)
        {
            if (!IsDoubleStringCorrect(costValue))
            {
                exceptionMessage += "Niepoprawnie podano wartość kosztów" + _lineSeperator;
                return false;
            }
            return true;
        }

        #region Personal information

        /// <summary>
        ///     Method which checks whether the given string matches the field name
        /// </summary>
        /// <param name="name"> String value to check</param>
        /// <param name="exceptionMessage">Method will add note to exception message when name is not correct</param>
        /// <returns>Bool value - true if correct</returns>
        public bool IsNameCorrect(string name, ref string exceptionMessage)
        {
            if (!IsAlphabeticStringCorrect(name))
            {
                exceptionMessage += "Niepoprawnie podano imię" + _lineSeperator;
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Method which checks whether the given string matches the field surname
        /// </summary>
        /// <param name="surname">String value to check</param>
        /// <param name="exceptionMessage">Method will add note to exception message when name is not correct</param>
        /// <returns>Bool value - true if correct</returns>
        public bool IsSurnameCorrect(string surname, ref string exceptionMessage)
        {
            if (!IsAlphabeticStringCorrect(surname))
            {
                exceptionMessage += "Niepoprawnie podano nazwisko" + _lineSeperator;
                return false;
            }
            return true;
        }

        public bool IsTelephoneCorrect(string telefon, ref string exceptionMessage)
        {
            if (!IsNumericStringCorrect(telefon))
            {
                exceptionMessage += "Niepoprawnie podano numer telefonu" + _lineSeperator;
                return false;
            }
            return true;
        }

        public bool IsPESELCorrect(string PESEL, ref string exceptionMessage)
        {
            if (!IsPESELStringCorrect(PESEL))
            {
                exceptionMessage += "Niepoprawnie podano PESEL" + _lineSeperator;
                return false;
            }
            return true;
        }

        public bool IsOwnerCorrect(string owner, ref string exceptionMessage)
        {
            if (!IsAlphabeticStringCorrect(owner))
            {
                exceptionMessage += "Niepoprawnie podano nazwę właściciela" + _lineSeperator;
                return false;
            }
            return true;
        }

        public bool IsNIPCorrect(string NIP, ref string exceptionMessage)
        {
            if (!IsNIPStringCorrect(NIP))
            {
                exceptionMessage += "Niepoprawnie podano NIP" + _lineSeperator;
                return false;
            }
            return true;
        }

        #endregion

        #region Address information

        public bool IsCityCorrect(string city, ref string exceptionMessage)
        {
            if (!IsAlphabeticStringCorrect(city))
            {
                exceptionMessage += "Niepoprawnie podano nazwę miejscowości" + _lineSeperator;
                return false;
            }
            return true;
        }

        public bool IsPostalCodeCorrect(string postalCode, ref string exceptionMessage)
        {
            if (!IsPostalCodeStringCorrect(postalCode))
            {
                exceptionMessage += "Niepoprawnie podano imię" + _lineSeperator;
                return false;
            }
            return true;
        }

        public bool IsStreetCorrect(string street, ref string exceptionMessage)
        {
            if (!IsAlphabeticStringCorrect(street))
            {
                exceptionMessage += "Niepoprawnie podano nazwę ulicy" + _lineSeperator;
                return false;
            }
            return true;
        }

        public bool IsHouseNumberCorrect(string houseNumber, ref string exceptionMessage)
        {
            if (!IsNumericStringCorrect(houseNumber))
            {
                exceptionMessage += "Niepoprawnie podano numer mieszkania" + _lineSeperator;
                return false;
            }
            return true;
        }

        public bool IsLocalNumberCorrect(string localNumber, ref string exceptionMessage)
        {
            if (!IsNumericStringCorrect(localNumber))
            {
                exceptionMessage += "Niepoprawnie podano numer lokalu" + _lineSeperator;
                return false;
            }
            return true;
        }

        #endregion
    }
}
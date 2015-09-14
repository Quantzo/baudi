using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace Baudi.Client.Converters
{
    /// <summary>
    ///     Bool to text converter
    /// </summary>>
    public class EnumDescriptionConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value produced by the binding source.</param><param name="targetType">The type of the binding target property.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var myEnum = (Enum) value;
            var description = GetEnumDescription(myEnum);
            return description;
        }

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value that is produced by the binding target.</param><param name="targetType">The type to convert to.</param><param name="parameter">The converter parameter to use.</param><param name="culture">The culture to use in the converter.</param>
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
        /// <summary>
        /// Get enum description
        /// </summary>
        /// <returns>
        /// Enum description 
        /// </returns>
        /// <param name="enumObj">Enum object</param>
        private string GetEnumDescription(Enum enumObj)
        {
            var fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

            var attribArray = fieldInfo.GetCustomAttributes(false);

            if (attribArray.Length == 0)
            {
                return enumObj.ToString();
            }
            var attrib = attribArray[0] as DescriptionAttribute;
            return attrib.Description;
        }
    }
}
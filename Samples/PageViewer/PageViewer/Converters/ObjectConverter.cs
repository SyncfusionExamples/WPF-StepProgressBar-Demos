namespace PageViewer
{
    using System;
    using System.Windows.Data;

    /// <summary>
    /// Represents the converter class.
    /// </summary>
    public class ObjectConverter : IMultiValueConverter
    {
        /// <summary>
        ///  Converts the button and frame as value. 
        /// </summary>
        /// <param name="values">values.</param>
        /// <param name="targetType">target type.</param>
        /// <param name="parameter">parameter.</param>
        /// <param name="culture">culture.</param>
        /// <returns>converted value.</returns>
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return values.Clone();
        }

        /// <summary>
        /// Convert back to the converter.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="targetTypes">target types.</param>
        /// <param name="parameter">parameter.</param>
        /// <param name="culture">culture.</param>
        /// <returns>converted value.</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

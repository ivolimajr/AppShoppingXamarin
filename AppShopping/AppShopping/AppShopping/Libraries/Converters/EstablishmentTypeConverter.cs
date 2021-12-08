using AppShopping.Libraries.Enums;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace AppShopping.Libraries.Converters
{
    public class EstablishmentTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            EstablishmentType type = (EstablishmentType)value;

            return (type == EstablishmentType.STORE) ? "Loja" : "Restaurante";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

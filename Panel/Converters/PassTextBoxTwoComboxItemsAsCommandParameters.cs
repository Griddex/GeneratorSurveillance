﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Panel.Converters
{
    class PassTextBoxTwoComboxItemsAsCommandParameters : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new Tuple<TextBox, ComboBoxItem, ComboBoxItem>((TextBox)values[0], (ComboBoxItem)values[1], (ComboBoxItem)values[2]);
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}

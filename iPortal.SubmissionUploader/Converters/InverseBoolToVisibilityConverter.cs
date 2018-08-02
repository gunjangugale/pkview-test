﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace iPortal.SubmissionUploader.Converters
{
    /// <summary>
    /// Convert the inverse of a boolean state to a visibility value
    /// </summary>
    public sealed class InverseBoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

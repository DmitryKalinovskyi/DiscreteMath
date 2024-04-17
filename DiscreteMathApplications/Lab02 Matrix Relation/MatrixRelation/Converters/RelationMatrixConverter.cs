using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MatrixRelation.Converters
{
    public class RelationMatrixConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is long[,] matrix)
            {
                var contentBuilder = new StringBuilder();

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    string row = "";
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j != 0)
                            row += "&";

                        row += matrix[i, j];
                    }

                    if (i != 0)
                        contentBuilder.Append("\\\\");

                    contentBuilder.Append(row);

                }

                var content = contentBuilder.ToString();

                return $"R = \\matrix{{{content}}}";
            }

            return @"R =\matrix{}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

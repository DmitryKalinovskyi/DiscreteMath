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
            if (value is double[,] matrix)
            {
                var contentBuilder = new StringBuilder();

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    string row = "";
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if(j > 0)
                            row += "&";

                        if (i == 0 && j == 0)
                        {
                            row += "a/b";
                        }
                        else
                        if(j == 0)
                        {
                            row += $"a_{{{i}}}({matrix[i, j]})";
                        }
                        else if(i == 0)
                        {
                            row += $"b_{{{j}}}({matrix[i, j]})";
                        }
                        else
                        {
                            row += matrix[i, j];
                        }
                    }

                    if (i != 0)
                        contentBuilder.Append("\\\\");

                    contentBuilder.Append(row);

                }

                var content = contentBuilder.ToString();
                var result = $"R = \\matrix{{{content}}}";
                return result;
            }

            return @"R =\matrix{}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

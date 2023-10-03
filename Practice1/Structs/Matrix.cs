using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
   /// <summary>
   /// Класс, описывающий матрицу.
   /// </summary>
   public class Matrix
   {
      // Значения матрицы.
      private double[,] _values;

      /// <summary>
      /// Конструктор матрицы.
      /// </summary>
      /// <param name="_sizeI">Количество элементов по I.</param>
      /// <param name="_sizeJ">Количество элементов по J.</param>
      public Matrix(int _sizeI, int _sizeJ)
      {
         _values = new double[_sizeI, _sizeJ];
      }

      // Удалить!
      public Matrix(double[,] values)
      {
         _values = values;
      }

      public double this[int i, int j]
      {
         get => _values[i, j];
         set => _values[i, j] = value;
      }

      public Vector GaussSolver(Vector v)
      {

         // Прямой ход.
         for (int row = 0; row < v.Size; row++)
         {
            for (int col = row; col < v.Size; col++)
            {
               var k = _values[col, row];
               for (int i = row; i < v.Size; i++)
                  _values[col, i] /= k;
               v[col] /= k;

               if (col != row)
               {
                  for (int i = row; i < v.Size; i++)
                     _values[col, i] -= _values[row, i];
                  v[col] -= v[row];
               }
            }
         }

         // Обратный ход.
         for (int row = v.Size - 1; row > 0; row--)
         {
            for (int col = row; col > 0; col--)
            {
               var k = -1.0 * _values[col - 1, row];

               for (int i = row; i < v.Size; i++)
                  _values[row, i] *= k;
               v[row] *= k;

               for (int i = 0; i < v.Size; i++)
                  _values[col - 1, i] += _values[row, i];
               v[col - 1] += v[row];

               for (int i = row; i < v.Size; i++)
                  _values[row, i] /= k;
               v[row] /= k;

            }
         }
         return v;
      }
   }
}

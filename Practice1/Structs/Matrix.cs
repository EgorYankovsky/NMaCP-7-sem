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

      public int Size { get; set; }

      /// <summary>
      /// Конструктор матрицы.
      /// </summary>
      /// <param name="_sizeI">Количество элементов по I.</param>
      /// <param name="_sizeJ">Количество элементов по J.</param>
      public Matrix(int _sizeI, int _sizeJ)
      {
         Size = _sizeI;
         _values = new double[_sizeI, _sizeJ];
      }

      // Удалить!
      public Matrix(double[,] values)
      {
         Size = 3;
         _values = values;
      }

      internal void Copy(Matrix m)
      {
         for (int i = 0; i < m.Size; i++)
            for (int j = 0; j < m.Size; j++)
               this[i, j] = m[i, j];
      }

      public double this[int i, int j]
      {
         get => _values[i, j];
         set => _values[i, j] = value;
      }
   }
}

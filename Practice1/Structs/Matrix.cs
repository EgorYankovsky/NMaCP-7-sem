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

      public double this[int i, int j]
      {
         get => _values[i, j];
         set => _values[i, j] = value;
      }

      /// <summary>
      /// Генерация матрицы.
      /// </summary>
      internal void Generate()
      {
         // Code here.
      }
   }
}

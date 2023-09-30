using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
   public class Matrix
   {
      private double[,] _values;

      public Matrix(int _sizeI, int _sizeJ)
      {
         _values = new double[_sizeI, _sizeJ];
      }

      public double this[int i, int j]
      {
         get => _values[i, j];
         set => _values[i, j] = value;
      }
   }
}

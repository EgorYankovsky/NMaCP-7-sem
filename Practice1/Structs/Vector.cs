using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
   public class Vector
   {
      private double[] _values;

      public int Size => _values.Length;

      public Vector(int _size)
      {
         _values = new double[_size];
      }

      public double this[int i]
      {
         get => _values[i];
         set => _values[i] = value;
      }
   }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
   /// <summary>
   /// Класс, описывающий вектор.
   /// </summary>
   public class Vector
   {
      // Значения вектора.
      private double[] _values;

      // Размер вектора.
      public int Size => _values.Length;

      /// <summary>
      /// Конструктор вектора.
      /// </summary>
      /// <param name="_size">Значение размера.</param>
      public Vector(int _size)
      {
         _values = new double[_size];
      }

      // Удалить!
      public Vector(double[] values)
      {
         _values = values;
      }

      public double this[int i]
      {
         get => _values[i];
         set => _values[i] = value;
      }

      /// <summary>
      /// Сгенерировать вектор.
      /// </summary>
      internal void Generate()
      {
         // Code here.
      }

      public override string ToString()
      {
         string ans = "";
         foreach (double v in _values)
            ans += $"{v:E15}\n";
         return ans;
      }
   }
}
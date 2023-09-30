using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
   /// <summary>
   /// Статический класс метода Гаусса-Ньютона.
   /// </summary>
   public static class GaussNewtone
   {
      // Точность.
      private const double _accuracy = 1e-15;

      /// <summary>
      /// Функция, вычисляющая расстояние между двумя точкаим.
      /// </summary>
      /// <param name="a">Точка А.</param>
      /// <param name="b">Точка В.</param>
      /// <returns>Расстояние r.</returns>
      private static double Distance(Point a, Point b) =>
         Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y) + (a.Z - b.Z) * (a.Z - b.Z));

      /// <summary>
      /// Функция, вычисляющая функционал.
      /// </summary>
      /// <param name="_s">Синтетические данные.</param>
      /// <param name="_p">Потенциальные данные.</param>
      /// <returns>Число.</returns>
      private static double Phi(double[] _s, double[] _p)
      {
         double ans = 0;
         for (int i = 0; i < _s.Length; i++)
            ans += Math.Pow((_p[i] - _s[i]) / _s[i], 2);
         return ans;
      }

      /// <summary>
      /// Решалка.
      /// </summary>
      /// <param name="_M">Матрица СЛАУ.</param>
      /// <param name="_V">Вектор правой части.</param>
      /// <param name="_I">Сила тока.</param>
      /// <param name="_sigma">Сигма реальная.</param>
      /// <param name="_sigma_0">Сигма эмперическая.</param>
      /// <param name="_springs">Источники.</param>
      /// <param name="_recivers">Приемники.</param>
      /// <returns>Вектор решения.</returns>
      public static Vector Solve(Matrix _M, Vector _V, double _I, double _sigma, double _sigma_0,
         Line[] _springs, Line[] _recivers)
      {
         var x = new Vector(_V.Size);
         double[] _potentials = new double[_springs.Length];
         double[] _synthetic = new double[_recivers.Length];

         // Генерируем синтетические данные.
         for (int i = 0; i < _recivers.Length; i++)
            for (int j = 0; j < _springs.Length; j++)
               _synthetic[i] += 0.5 * _I * ((1 / Distance(_recivers[i].A, _springs[j].B) - 1 / Distance(_recivers[i].A, _springs[j].A)) 
                  - (1 / Distance(_recivers[i].B, _springs[j].B) - 1 / Distance(_recivers[i].B, _springs[j].A))) / (Math.PI * _sigma);

         // Генерируем эмперические данные.
         for (int i = 0; i < _recivers.Length; i++)
            for (int j = 0; j < _springs.Length; j++)
               _potentials[i] += 0.5 * _I * ((1 / Distance(_recivers[i].A, _springs[j].B) - 1 / Distance(_recivers[i].A, _springs[j].A))
                  - (1 / Distance(_recivers[i].B, _springs[j].B) - 1 / Distance(_recivers[i].B, _springs[j].A))) / (Math.PI * _sigma_0);

         int iter = 0;
         double kek = Phi(_synthetic, _potentials);
         Console.WriteLine($"{iter} {_sigma_0:E15} {kek:E15}");
         while (kek >= _accuracy)
         {
            // Code here,
            iter++;
         }
         _M = new Matrix(0, 0);
         return x;
      }

   }
}

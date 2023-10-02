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

      private const double _PI_2 = 0.10132118364233778;

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
      /// <param name="_p">Эмперические данные.</param>
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
      /// <param name="_realI">Сила тока реальная.</param>
      /// <param name="_psevdoI">Сила тока эмперическая.</param>
      /// <param name="_sigma">Сигма реальная.</param>
      /// <param name="_springs">Источники.</param>
      /// <param name="_recivers">Приемники.</param>
      /// <returns>Вектор решения.</returns>
      public static Vector Solve(Matrix _M, Vector _V, double[] _realI, double[] _psevdoI, double _sigma,
         Line[] _springs, Line[] _recivers)
      {
         var x = new Vector(_V.Size);
         double[] _potentials = new double[_springs.Length];
         double[] _synthetic = new double[_recivers.Length];

         // Генерируем синтетические данные.
         for (int i = 0; i < _recivers.Length; i++)
         {
            for (int j = 0; j < _springs.Length; j++)
               _synthetic[i] += 0.5 * _realI[j] * ((1 / Distance(_recivers[i].A, _springs[j].B) - 1 / Distance(_recivers[i].A, _springs[j].A))
                  - (1 / Distance(_recivers[i].B, _springs[j].B) - 1 / Distance(_recivers[i].B, _springs[j].A))) / (Math.PI * _sigma);
         }
         // Генерируем эмперические данные.
         for (int i = 0; i < _recivers.Length; i++)
            for (int j = 0; j < _springs.Length; j++)
               _potentials[i] += 0.5 * _psevdoI[j] * ((1 / Distance(_recivers[i].A, _springs[j].B) - 1 / Distance(_recivers[i].A, _springs[j].A))
                  - (1 / Distance(_recivers[i].B, _springs[j].B) - 1 / Distance(_recivers[i].B, _springs[j].A))) / (Math.PI * _sigma);

         int iter = 0;
         double kek = Phi(_synthetic, _potentials);
         while (kek >= _accuracy)
         {
            Console.WriteLine($"{iter} {_potentials[0]:E15} {_potentials[1]:E15} {_potentials[2]:E15} {kek:E15}");

            // Генерация матрицы и вектора.
            for (int q = 0; q < _recivers.Length; q++)
            {
               for (int s = 0; s < _springs.Length; s++)
               {
                  for (int i = 0; i < _recivers.Length; i++)
                  {
                     double w = 1 / _synthetic[i];
                     _M[q, s] += 0.25 * _PI_2 * w * w * ((1 / Distance(_recivers[q].A, _springs[i].B) - 1 / Distance(_recivers[q].A, _springs[i].A))
                  - (1 / Distance(_recivers[q].B, _springs[i].B) - 1 / Distance(_recivers[q].B, _springs[i].A))
                  * (((1 / Distance(_recivers[s].A, _springs[i].B) - 1 / Distance(_recivers[s].A, _springs[i].A))
                  - (1 / Distance(_recivers[s].B, _springs[i].B) - 1 / Distance(_recivers[s].B, _springs[i].A))))) / _sigma;
                  }
               }
            }


            for (int q = 0; q < _recivers.Length; q++)
            {
               for (int i = 0; i < _recivers.Length; i++)
               {
                  double w = 1 / _synthetic[i];
                  _V[q] += -1.0 * w * w * ((1 / Distance(_recivers[q].A, _springs[i].B) - 1 / Distance(_recivers[q].A, _springs[i].A))
                  - (1 / Distance(_recivers[q].B, _springs[i].B) - 1 / Distance(_recivers[q].B, _springs[i].A))) * (_potentials[i] - _synthetic[i]);
               }
            }

            x = _M.GaussSolver(_V);

            // Code here.
            kek = Phi(_synthetic, _potentials);
            iter++;
         }
         return x;
      }
   }
}


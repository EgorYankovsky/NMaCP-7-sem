namespace Practice1;

/// <summary>
/// Статический класс метода Гаусса-Ньютона.
/// </summary>
public static class GaussNewtone
{
   // Точность.
   private const double _accuracy = 1e-15;

   // Максимальное количество итераций.
   private const double _maxIter = 100;

   /// <summary>
   /// Функция, вычисляющая расстояние между двумя точкаим.
   /// </summary>
   /// <param name="a">Точка А.</param>
   /// <param name="b">Точка В.</param>
   /// <returns>Расстояние r.</returns>
   private static double Distance(Point a, Point b) =>
      Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.Z - a.Z, 2));

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
   /// <param name="_realI">Сила тока реальная.</param>
   /// <param name="_psevdoI">Сила тока эмперическая.</param>
   /// <param name="_sigma">Сигма реальная.</param>
   /// <param name="_springs">Источники.</param>
   /// <param name="_recivers">Приемники.</param>
   /// <returns>Вектор решения.</returns>
   public static Vector Solve(double[] _realI, double[] _psevdoI, double _sigma,
      Line[] _springs, Line[] _recivers)
   {
      // Решение.
      Vector? x;

      // Потенциалы и синтетические данные.
      double[] _potentials = new double[_springs.Length];
      double[] _synthetic = new double[_recivers.Length];

      // Генерируем синтетические данные.
      for (int i = 0; i < _recivers.Length; i++)
      {
         for (int j = 0; j < _springs.Length; j++)
            _synthetic[i] += _realI[j] * 
                 (1.0 / Distance(_recivers[i].A, _springs[j].B) - 1.0 / Distance(_recivers[i].A, _springs[j].A)
               - (1.0 / Distance(_recivers[i].B, _springs[j].B) - 1.0 / Distance(_recivers[i].B, _springs[j].A)));
         _synthetic[i] *= 1 / (2 * Math.PI * _sigma);
      }

      // Генерируем потенциалы.
      for (int i = 0; i < _recivers.Length; i++) 
      {
         for (int j = 0; j < _springs.Length; j++)
            _potentials[i] += _psevdoI[j] *
              (1.0 / Distance(_recivers[i].A, _springs[j].B) - 1.0 / Distance(_recivers[i].A, _springs[j].A)
            - (1.0 / Distance(_recivers[i].B, _springs[j].B) - 1.0 / Distance(_recivers[i].B, _springs[j].A)));
         _potentials[i] /= 2 * Math.PI * _sigma;
      }


      // Генерация матрицы и вектора.

      // Матрица и вектор для решения СЛАУ.
      var _M = new Matrix(_springs.Length, _springs.Length);
      var _V = new Vector(_springs.Length);

      // Генерация матрицы.
      for (int q = 0; q < _recivers.Length; q++)
      {
         for (int s = 0; s < _springs.Length; s++)
         {
            for (int i = 0; i < _recivers.Length; i++)
            {
               var w = 1.0 / _synthetic[i];
               _M[q, s] += w * w *
                   ((1.0 / Distance(_recivers[i].A, _springs[q].B) - 1.0 / Distance(_recivers[i].A, _springs[q].A)
                  - (1.0 / Distance(_recivers[i].B, _springs[q].B) - 1.0 / Distance(_recivers[i].B, _springs[q].A)))
                  * (1.0 / Distance(_recivers[i].A, _springs[s].B) - 1.0 / Distance(_recivers[i].A, _springs[s].A)
                  - (1.0 / Distance(_recivers[i].B, _springs[s].B) - 1.0 / Distance(_recivers[i].B, _springs[s].A))));
            }
            _M[q, s] *= 1.0 / (4 * Math.PI * Math.PI * _sigma * _sigma);
         }
      }

      // Генерация вектора.
      for (int q = 0; q < _recivers.Length; q++)
      {
         for (int i = 0; i < _recivers.Length; i++)
         {
            var w = 1.0 / _synthetic[i];
            _V[q] -= w * w *
                (1 / Distance(_recivers[i].A, _springs[q].B) - 1 / Distance(_recivers[i].A, _springs[q].A)
              - (1 / Distance(_recivers[i].B, _springs[q].B) - 1 / Distance(_recivers[i].B, _springs[q].A)))
              * (_potentials[i] - _synthetic[i]);
         }
         _V[q] *= 0.5 / (Math.PI * _sigma);
      }


      // Непросредственно решалка.
      int iter = 0;
      double kek = Phi(_synthetic, _potentials);
      Console.WriteLine($" i |{"сила тока 1", 25} |{"сила тока 2",25} |{"сила тока 3",25} |{"значение функционала",25}");
      for (int i = 0; i < 110; i++)
         Console.Write("-");
      Console.WriteLine();
      do
      {
         double _reg = 1e-16;
         // Выводим на экран значения сил тока (из итерационного процесса) для каждого электорда и значение функционала.
         Console.WriteLine($"{iter, 2} |{_psevdoI[0], 25:E15} |{_psevdoI[1], 25:E15} |{_psevdoI[2], 25:E15} |{kek, 25:E15}");

         Matrix __M = new(3, 3);
         Vector __V = new(3);
         __M.Copy(_M);
         __V.Copy(_V);

         // Решаем методом Гаусса.
         x = Gauss.Solve(__M, __V);

         // Регуляризация Тихонова.
         while (x is null)
         {
            for (int i = 0; i < _V.Size; i++)
            {
               __M[i, i] += _reg;
               __V[i] -= _reg * (_psevdoI[i] - _realI[i]);
            }
            x = Gauss.Solve(__M, __V);
            _reg *= 2.0;
         }

         // Перегенерация данных, после нахождения решения.
         for (int i = 0; i < _recivers.Length; i++)
         {
            _psevdoI[i] += x[i];
            _potentials[i] = 0;
            for (int j = 0; j < _springs.Length; j++)
               _potentials[i] += _psevdoI[j] *
                 (1.0 / Distance(_recivers[i].A, _springs[j].B) - 1.0 / Distance(_recivers[i].A, _springs[j].A)
               - (1.0 / Distance(_recivers[i].B, _springs[j].B) - 1.0 / Distance(_recivers[i].B, _springs[j].A)));
            _potentials[i] /= 2 * Math.PI * _sigma;
         }

         for (int q = 0; q < _recivers.Length; q++)
         {
            _V[q] = 0;
            for (int i = 0; i < _springs.Length; i++)
            {
               var w = 1.0 / _synthetic[i];
               _V[q] -= w * w *
                   (1 / Distance(_recivers[i].A, _springs[q].B) - 1 / Distance(_recivers[i].A, _springs[q].A)
                 - (1 / Distance(_recivers[i].B, _springs[q].B) - 1 / Distance(_recivers[i].B, _springs[q].A)))
                 * (_potentials[i] - _synthetic[i]);
            }
            _V[q] *= 0.5 / (Math.PI * _sigma);
         }

         iter++;

         // Вычисляем значение функционала.
         kek = Phi(_synthetic, _potentials);
      } while (kek >= _accuracy && iter < _maxIter);

      Console.WriteLine("\n\n\nОтвет:");
      Console.WriteLine($" i |{"сила тока 1", 25} |{"сила тока 2",25} |{"сила тока 3",25} |{"значение функционала",25}");
      for (int i = 0; i < 110; i++)
         Console.Write("-");
            
      Console.WriteLine($"\n{iter,2} |{_psevdoI[0],25:E15} |{_psevdoI[1],25:E15} |{_psevdoI[2],25:E15} |{kek,25:E15}");
      Console.WriteLine($"\nXX |{Math.Abs(_psevdoI[0] - _realI[0]),25:E15} |{Math.Abs(_psevdoI[1] - _realI[1]),25:E15} |{Math.Abs(_psevdoI[2] - _realI[2]),25:E15} |{kek,25:E15}");


      for (int i = 0; i < _potentials.Length; i++)
         x[i] += _synthetic[i];
      return x;
   }
}
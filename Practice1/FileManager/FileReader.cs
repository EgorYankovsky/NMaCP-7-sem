using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
   /// <summary>
   /// Статический класс чтения данных из файла
   /// </summary>
   public static class FileReader
   {
      // Полный путь до входного файла (поменять)
      private const string InputPath = @"../Data/Input.txt";

      /// <summary>
      /// Метод, считывающий данные из входного файла
      /// </summary>
      /// <param name="_sigma">Удельная электрическая проводимость</param>
      /// <param name="_sigma_0">Начальная удельная электрическая проводимость (вероятно не нужна)</param>
      /// <param name="_reciversAmount">Количество приемников</param>
      /// <param name="_springsAmount">Количество источников</param>
      /// <param name="_recivers">Приемники</param>
      /// <param name="_springs">Источники</param>
      public static void ReadData(out double[] _realI, out double[] _psevdoI, out double _sigma,
                                 out int _reciversAmount, out int _springsAmount,
                                 out Line[] _recivers, out Line[] _springs)
      {
         string[] data;

         using var sr = new StreamReader(InputPath);
         _sigma = double.Parse(sr.ReadLine());

         _reciversAmount = int.Parse(sr.ReadLine());
         _recivers = new Line[_reciversAmount];
         for (int i = 0; i < _reciversAmount; i++)
            _recivers[i] = new Line(sr.ReadLine());

         _springsAmount = int.Parse(sr.ReadLine());
         _springs = new Line[_springsAmount];
         for (int i = 0; i < _springsAmount; i++)
            _springs[i] = new Line(sr.ReadLine());

         _realI = sr.ReadLine().Split().Select(double.Parse).ToArray();
         _psevdoI = sr.ReadLine().Split().Select(double.Parse).ToArray();
      }
   }
}

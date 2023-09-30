using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
   /// <summary>
   /// Статический класс, чтения данных из файла
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
      public static void ReadData(out double _sigma, out double _sigma_0,
                                 out int _reciversAmount, out int _springsAmount,
                                 out int[,] _recivers, out int[,] _springs)
      {
         string[] data;

         using var sr = new StreamReader(InputPath);
         _sigma = double.Parse(sr.ReadLine());
         _sigma_0 = double.Parse(sr.ReadLine());
            
         _reciversAmount = int.Parse(sr.ReadLine());
         _recivers = new int[_reciversAmount, 6];
         for (int i = 0; i < _reciversAmount; i++)
         {
            data = sr.ReadLine().Split(" ").ToArray();
            for (int j = 0; j < 6; j++)
               _recivers[i, j] = int.Parse(data[j]);
         }

         _springsAmount = int.Parse(sr.ReadLine());
         _springs = new int[_springsAmount, 6];
         for (int i = 0; i < _springsAmount; i++)
         {
            data = sr.ReadLine().Split(" ").ToArray();
            for (int j = 0; j < 6; j++)
               _springs[i, j] = int.Parse(data[j]);
         }
      }
   }
}

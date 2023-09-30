using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
   /// <summary>
   /// Класс, записывающий полученные данные в файл
   /// </summary>
   public static class FileWriter
   {
      // Полный путь конечного файла
      const string Path = @"../Data/Input.txt";
      
      /// <summary>
      /// Метод, записывающий полученные данные в файл
      /// </summary>
      public static void WriteData()
      {
         using var sw = new StreamWriter(Path);
      }
   }
}

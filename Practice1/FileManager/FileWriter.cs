namespace Practice1;

/// <summary>
/// Класс, записывающий полученные данные в файл.
/// </summary>
public static class FileWriter
{
   // Полный путь конечного файла.
   const string Path = @"../Data/Output.txt";
   
   /// <summary>
   /// Метод, записывающий полученные данные в файл.
   /// </summary>
   public static void WriteData(Vector x)
   {
      using var sw = new StreamWriter(Path);
      sw.WriteLine(x);
   }
}

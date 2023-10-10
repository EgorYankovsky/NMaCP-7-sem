namespace Practice1;

/// <summary>
/// Структура, определяющая линию источника или электрода.
/// </summary>
public struct Line
{
   // Первая точка.
   public Point A { get; set; }

   // Вторая точка.
   public Point B { get; set; }

   /// <summary>
   /// Конструктор на основании строки из файла.
   /// </summary>
   /// <param name="str">Строка из файла.</param>
   public Line(string str)
   {
      double[] kek = str.Split(" ").Select(double.Parse).ToArray();
      A = new Point(kek[0], kek[1], kek[2]);
      B = new Point(kek[3], kek[4], kek[5]);
   }
}

namespace Practice1;

/// <summary>
/// Структура, определяющая точку линии.
/// </summary>
public struct Point
{
   // Координата по Х.
   public double X { get; set; }

   // Координата по Y.
   public double Y { get; set; }

   // Координата по Z.
   public double Z { get; set; }

   /// <summary>
   /// Конструктор на основании трех значений координат.
   /// </summary>
   /// <param name="X">Значение по X.</param>
   /// <param name="Y">Значение по Y.</param>
   /// <param name="Z">Значение по Z.</param>
   public Point(double X, double Y, double Z)
   {
      this.X = X;
      this.Y = Y;
      this.Z = Z;
   }
}

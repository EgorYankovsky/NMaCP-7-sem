namespace Practice1;

public static class Gauss
{
   public static Vector? Solve(Matrix A, Vector b)
   {
      Matrix _A = new(3, 3);
      Vector _b = new(3);
      _A.Copy(A);
      _b.Copy(b);

      // Прямой ход.
      for (int row = 0; row < _b.Size; row++)
      {
         for (int col = row; col < _b.Size; col++)
         {
            var k = _A[col, row];
            
            if (k == 0) return null;
            
            for (int i = row; i < _b.Size; i++)
               _A[col, i] /= k;
            _b[col] /= k;

            if (col != row)
            {
               for (int i = row; i < _b.Size; i++)
                  _A[col, i] -= _A[row, i];
               _b[col] -= _b[row];
            }
         }
      }

      // Обратный ход.
      for (int row = _b.Size - 1; row > 0; row--)
      {
         for (int col = row; col > 0; col--)
         {
            var k = -1.0 * _A[col - 1, row];

            for (int i = row; i < _b.Size; i++)
               _A[row, i] *= k;
            _b[row] *= k;

            for (int i = 0; i < _b.Size; i++)
               _A[col - 1, i] += _A[row, i];
            _b[col - 1] += _b[row];

            for (int i = row; i < _b.Size; i++)
               _A[row, i] /= k;
            _b[row] /= k;

         }
      }

      return _b;
   }
}

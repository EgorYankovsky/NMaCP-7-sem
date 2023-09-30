using Practice1;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

double sigma = 0;
double sigma_0 = 0;
int reciverAmount = 0;
int springAmount = 0;
int[,] recivers;
int[,] springs;


FileReader.ReadData(out sigma, out sigma_0, out reciverAmount,
                    out springAmount, out recivers, out springs);



FileWriter.WriteData();
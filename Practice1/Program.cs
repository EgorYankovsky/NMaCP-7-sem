using Practice1;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

double[] realI;
double[] psevdoI;
double sigma;
int reciverAmount;
int springAmount;
Line[] recivers;
Line[] springs;


FileReader.ReadData(out realI, out psevdoI, out sigma, out reciverAmount,
                    out springAmount, out recivers, out springs);

FileWriter.WriteData(GaussNewtone.Solve(realI, psevdoI, sigma, springs, recivers));
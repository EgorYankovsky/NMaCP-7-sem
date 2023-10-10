using Practice1;
using System.ComponentModel.DataAnnotations;
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

//Matrix M = new Matrix(new double[,] { { 0.01, 0.03, 0.17 }, { 0.65, 0.08, 0.13 }, { 0.001, 0.03, 1.66 } });
//Vector v = new Vector(new double[] { 0.039, 0.164, 0.3352 });
//var x = Gauss.Solve(M, v);
//for (int i = 0; i < x.Size; i++)
//  Console.WriteLine($"{x[i]:E15}");

FileWriter.WriteData(GaussNewtone.Solve(realI, psevdoI, sigma, springs, recivers));
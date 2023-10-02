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

var A = new Matrix(springAmount, reciverAmount);
var b = new Vector(springAmount);

//FileWriter.WriteData(GaussNewtone.Solve(A, b, realI, psevdoI, sigma, springs, recivers));
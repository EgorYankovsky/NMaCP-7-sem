using Practice1;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

double I;
double sigma;
double sigma_0;
int reciverAmount;
int springAmount;
Line[] recivers;
Line[] springs;


FileReader.ReadData(out I, out sigma, out sigma_0, out reciverAmount,
                    out springAmount, out recivers, out springs);

var A = new Matrix(springAmount, reciverAmount);
var b = new Vector(springAmount);

FileWriter.WriteData(GaussNewtone.Solve(A, b, I, sigma, sigma_0, springs, recivers));
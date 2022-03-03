// See https://aka.ms/new-console-template for more information
using System.Linq;

var list = new List<string>() { "ASUS", "Acer", "BenQ", "Toshiba", "Dell" };
var temp = list.Select(x => x.ToString()).Contains("Acer");
var temp2 = list.Select(x => x.ToString()).Contains("Dell");
var temp3 = temp && temp2;

Console.WriteLine(temp3);
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace romannumbers
{
    internal class RomanNumber : ICloneable, IComparable
    {
     private string Rom;

     private readonly ushort[] number = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

     private ushort Arab;

     private readonly string[] symbol = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

public RomanNumber(ushort n)//Конструктор получает число n, которое должен представлять объект класса в римской записи
  {
     if (n <= 0)
       throw new RomanNumberException("\n Значение > 0.\n ");
     else
      {
       this.Arab = n;
       this.Rom = "";
      }
  }

public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2)//Сложение римских чисел
  {
     return new RomanNumber((ushort)(n1.Arab + n2.Arab));
  }

public static RomanNumber Sub(RomanNumber? n1, RomanNumber? n2)//Вычитание римских чисел
  {
     if (0 >= n1.Arab - n2.Arab)
       throw new RomanNumberException("\n Значение вычитания <= 0.\n");
     else
       return new RomanNumber((ushort)(n1.Arab - n2.Arab));
  }

public static RomanNumber Mul(RomanNumber? n1, RomanNumber? n2)//Умножение римских чисел
  {
     return new RomanNumber((ushort)(n1.Arab * n2.Arab));
  }

public static RomanNumber Div(RomanNumber? n1, RomanNumber? n2)//Целочисленное деление римских чисел
  {
     if ((n1.Arab / n2.Arab) <= 0)
       throw new RomanNumberException("\n Значение деления <= 0. \n ");
     else
       return new RomanNumber((ushort)(n1.Arab / n2.Arab));
  }

public override string ToString() //Возвращает строковое представление римского числа
  {
     ushort temp = this.Arab;
     this.Rom = "";
     for (int i = 0; i < 13; i++)
        {
          while (temp >= number[i])
          {
            this.Rom = this.Rom + symbol[i];
            temp -= number[i];
          }
        }
       return this.Rom;
   }

public object Clone() // Реализация интерфейса IClonable
  {
     return new RomanNumber(this.Arab);
  }

public int CompareTo(object? obj) // Реализация интерфейса IComparable
  {
     if (obj is RomanNumber number)
       return Arab.CompareTo(number.Arab);
     else
       throw new ArgumentException();
  }
 }
}
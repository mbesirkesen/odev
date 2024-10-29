using System;
using System.Collections.Generic;
using System.Text;
//muhammed beşir kesen
/*Kullanıcının girdiği matematiksel ifadeyi (örneğin, 3 + 4 * 2 / (1 - 5) ^ 2 ^ 3) işlem
önceliklerine göre çözümleyen bir program yazın. Program, sonucu yazdırmadan önce
ifadenin çözüm sürecini açıklamalıdır (hangi işlemlerin hangi sırayla yapıldığını
gösterin).*/
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Matematiksel ifadeyi girin :");
        string ifade = Console.ReadLine();

        Stack<double> sayilar = new Stack<double>();
        Stack<char> islemler = new Stack<char>();

        for (int i = 0; i < ifade.Length; i++)
        {
            if (char.IsDigit(ifade[i]))
            {
                StringBuilder sb = new StringBuilder();

                while (i < ifade.Length && (char.IsDigit(ifade[i]) || ifade[i] == '.'))
                {
                    sb.Append(ifade[i]);
                    i++;
                }

                double sayi = double.Parse(sb.ToString());
                sayilar.Push(sayi);
                i--; // Doğru pozisyona ayarlıyoruz
            }
            else if (ifade[i] == '(')
            {
                islemler.Push(ifade[i]);
            }
            else if (ifade[i] == ')')
            {
                while (islemler.Count > 0 && islemler.Peek() != '(')
                {
                    char operatör = islemler.Pop();
                    double sag = sayilar.Pop();
                    double sol = sayilar.Pop();

                    double sonuc = 0;
                    if (operatör == '+') sonuc = sol + sag;
                    else if (operatör == '-') sonuc = sol - sag;
                    else if (operatör == '*') sonuc = sol * sag;
                    else if (operatör == '/') sonuc = sol / sag;
                    else if (operatör == '^') sonuc = Math.Pow(sol, sag);

                    Console.WriteLine($"İşlem: {sol} {operatör} {sag} = {sonuc}");
                    sayilar.Push(sonuc);
                }
                islemler.Pop(); // '(' operatörünü çıkarıyoruz
            }
            else if (IsOperator(ifade[i]))
            {
                while (islemler.Count > 0 && Öncelik(ifade[i]) <= Öncelik(islemler.Peek()))
                {
                    char operatör = islemler.Pop();
                    double sag = sayilar.Pop();
                    double sol = sayilar.Pop();

                    double sonuc = 0;
                    if (operatör == '+') sonuc = sol + sag;
                    else if (operatör == '-') sonuc = sol - sag;
                    else if (operatör == '*') sonuc = sol * sag;
                    else if (operatör == '/') sonuc = sol / sag;
                    else if (operatör == '^') sonuc = Math.Pow(sol, sag);

                    Console.WriteLine($"İşlem: {sol} {operatör} {sag} = {sonuc}");
                    sayilar.Push(sonuc);
                }
                islemler.Push(ifade[i]);
            }
        }

        while (islemler.Count > 0)
        {
            char operatör = islemler.Pop();
            double sag = sayilar.Pop();
            double sol = sayilar.Pop();

            double sonuc = 0;
            if (operatör == '+') sonuc = sol + sag;
            else if (operatör == '-') sonuc = sol - sag;
            else if (operatör == '*') sonuc = sol * sag;
            else if (operatör == '/') sonuc = sol / sag;
            else if (operatör == '^') sonuc = Math.Pow(sol, sag);

            Console.WriteLine($"İşlem: {sol} {operatör} {sag} = {sonuc}");
            sayilar.Push(sonuc);
        }

        Console.WriteLine($"Sonuç: {sayilar.Pop()}");
    }

    static int Öncelik(char operatör)
    {
        if (operatör == '+' || operatör == '-') return 1;
        if (operatör == '*' || operatör == '/') return 2;
        if (operatör == '^') return 3;
        return 0;
    }

    static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
    }
}

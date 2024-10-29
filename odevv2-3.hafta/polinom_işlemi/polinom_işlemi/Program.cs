using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
/*Kullanıcıdan iki polinom girmesini isteyin (örneğin, 2x^2 + 3x - 5 ve x^2 - 4).
Program, bu iki polinomu toplayıp ve çıkararak sonuçları göstermelidir. Kullanıcı,
exit yazarak işlemi sonlandırana kadar yeni polinomlar girmeye devam etsin.*/
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Polinomları toplamak ve çıkarmak için polinom girin. 'exit' yazarak çıkabilirsiniz.");

        while (true)
        {
            Console.Write("Birinci polinom: ");
            string polinom1 = Console.ReadLine();
            if (polinom1.ToLower() == "exit") break;

            Console.Write("İkinci polinom: ");
            string polinom2 = Console.ReadLine();
            if (polinom2.ToLower() == "exit") break;

            var sonucToplama = PolinomTopla(polinom1, polinom2);
            var sonucCikarma = PolinomCikar(polinom1, polinom2);

            Console.WriteLine($"Toplama Sonucu: {sonucToplama}");
            Console.WriteLine($"Çıkarma Sonucu: {sonucCikarma}");
        }
    }

    static string PolinomTopla(string p1, string p2)
    {
        return PolinomIslem(p1, p2, true);
    }

    static string PolinomCikar(string p1, string p2)
    {
        return PolinomIslem(p1, p2, false);
    }

    static string PolinomIslem(string p1, string p2, bool toplama)
    {
        var terimler = new Dictionary<int, int>();

        // Polinomları birleştir
        foreach (var polinom in new[] { p1, p2 })
        {
            var matches = Regex.Matches(polinom, @"([+-]?\d*)x\^(\d+)|([+-]?\d*)x|([+-]?\d+)");

            foreach (Match match in matches)
            {
                int coef = 0;
                int derece = 0;

                if (match.Groups[1].Success) // x^n durumu
                {
                    coef = match.Groups[1].Value == "" || match.Groups[1].Value == "+" ? 1 :
                            match.Groups[1].Value == "-" ? -1 : int.Parse(match.Groups[1].Value);
                    derece = int.Parse(match.Groups[2].Value);
                }
                else if (match.Groups[3].Success) // x durumu
                {
                    coef = match.Groups[3].Value == "" || match.Groups[3].Value == "+" ? 1 :
                            match.Groups[3].Value == "-" ? -1 : int.Parse(match.Groups[3].Value);
                    derece = 1;
                }
                else if (match.Groups[4].Success) // Sabit terim durumu
                {
                    coef = int.Parse(match.Groups[4].Value);
                    derece = 0;
                }

                if (toplama)
                {
                    if (terimler.ContainsKey(derece))
                        terimler[derece] += coef;
                    else
                        terimler[derece] = coef;
                }
                else // Çıkarma
                {
                    if (terimler.ContainsKey(derece))
                        terimler[derece] -= coef;
                    else
                        terimler[derece] = -coef;
                }
            }
        }

        // Sonucu oluştur
        List<string> sonuc = new List<string>();
        foreach (var terim in terimler)
        {
            if (terim.Value != 0)
            {
                string coefStr = terim.Value > 0 ? $"+{terim.Value}" : $"{terim.Value}";
                if (terim.Key == 0)
                    sonuc.Add(coefStr);
                else if (terim.Key == 1)
                    sonuc.Add($"{coefStr}x");
                else
                    sonuc.Add($"{coefStr}x^{terim.Key}");
            }
        }

        return string.Join(" ", sonuc).TrimStart('+', ' ');
    }
}

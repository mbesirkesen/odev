using System;
using System.Collections.Generic;
//muhammed beşir
/*Kullanıcıdan bir dizi tamsayı alın ve bu dizideki ardışık sayı gruplarını tespit eden bir
program yazın. Örneğin, 1, 2, 3, 5, 6, 7, 10 dizisi için program, 1-3 ve 5-7 gruplarını
döndürmelidir. Kullanıcı 0 girene kadar sayıları almaya devam etsin.*/

class Program
{
    static void Main(string[] args)
    {
        List<int> sayilar = new List<int>();
        Boolean mami = true;
        int i = 0;
        // Kullanıcıdan tamsayıları alma
        Console.WriteLine("0'i tuslarsaniz biter ve gruplar ekrana yazdırlır baslayalim ^_^");
        while (mami)
        {
            
           Console.Write("bir sayi  girin :");
           int n = int.Parse(Console.ReadLine());
            if (n<0)
            {
                Console.WriteLine("Lütfen geçerli bir tamsayı girin.");
            }

            if (n == 0) { mami = false; break; }
         
            sayilar.Add(n);
            i++;
        }

        // Ardışık grupları bulma
        sayilar.Sort(); // Sayıları sıralama
        List<string> gruplar = new List<string>();

        if (i > 0)
        {
            List<int> grup = new List<int> { sayilar[0] };

            for (int j = 1; j < sayilar.Count; j++)
            {
                if (sayilar[j] == sayilar[j - 1] + 1) // Ardışık kontrolü
                {
                    grup.Add(sayilar[j]);
                }
                else
                {
                    if (grup.Count > 1)
                    {
                        gruplar.Add($"{grup[0]}-{grup[^1]}"); // Grup aralığını ekle
                    }
                    grup = new List<int> { sayilar[j] };
                }
            }

            // Son grubu ekleme
            if (grup.Count > 1)
            {
                gruplar.Add($"{grup[0]}-{grup[^1]}");
            }
           
        }

        // Sonucu yazdırma
        Console.WriteLine("Ardışık grup aralıkları: " + string.Join(", ", gruplar));
        Console.ReadKey();
    }
}


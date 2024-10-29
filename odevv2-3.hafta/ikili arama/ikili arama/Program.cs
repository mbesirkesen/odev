using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Kullanıcıdan bir dizi tam sayı alın ve bu sayıları sıralayın. Ardından, kullanıcıdan bir
sayı alın ve bu sayının dizide olup olmadığını ikili arama algoritması ile kontrol edin.*/

namespace ikili_arama
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.Write("lütfen dizinin boyutunu belirleyin :");
            int n = int.Parse(Console.ReadLine());
            int[] sayilar = new int[n] ;

            for (int i = 0; i < n; i++)
            {
                Console.Write("bir sayi giriniz :");
                int k = int.Parse(Console.ReadLine());
                sayilar[i] = k;
            }
            Array.Sort(sayilar);
            Console.Write("simdi dizide aranacak sayiyi girin :");
            int sayi = int.Parse(Console.ReadLine());
            int min = 0, max = n - 1,flag=0;
            while (min<=max)
            {   
                int orta = min + (max - min) / 2;
                if (sayilar[orta]==sayi)
                {
                    flag = 1;
                    break;
                }
                if (sayilar[orta] < sayi)
                {
                    min = orta + 1;
                }
                else
                {
                    max = orta - 1;
                }

            }
            if (flag==1)
            {
                Console.WriteLine("yazdıgınız sayi dizide bulunuyor :)");
            }
            else
            {
                Console.WriteLine("yazdıgınız sayi dizide bulunamadı :(");
            }
            Console.ReadKey();
        }

    }
}

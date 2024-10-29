using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
//MUHAMMED BEŞİR KESEN GURURLA SUNAR ;)
/*Kullanıcıdan pozitif tam sayılar alarak, bu sayıların ortalamasını ve medyanını
hesaplayan bir program yazın. Kullanıcı 0 girene kadar sayıları almaya devam etsin. 0
girildiğinde ortalamayı ve medyanı gösterin.*/

namespace calısma
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sayilar = new List<int>();
            int medyan = 0, i=0;
            double ortalama = 0.00, toplam = 0.00;
            Boolean mami = true;
            Console.WriteLine("siz 0 girince program sonlanır ve çıktıları alırsınız başlayalım!!");
            while (mami) {
                Console.Write("lütfen bir sayi giriniz :");
                int n = int.Parse(Console.ReadLine());
                if (n == 0) { mami = false; break; }
                if (n > 0) {
                    sayilar.Add(n);
                    toplam += n;
                    i++;
                }
                else { Console.WriteLine("Lütfen pozitif bir tam sayı girin ^_^ ");}
            }
            ortalama = ((float)(toplam / i));
            sayilar.Sort();
            if(i%2 == 0) {medyan=(sayilar[i/2]+sayilar[(i/2)+1])/2; }
            else { medyan=sayilar[(i/2)+1]; }
            Console.WriteLine("ortalama :"+ortalama);
            Console.WriteLine("medyan :"+medyan);
            Console.ReadKey();
        }
    }
}
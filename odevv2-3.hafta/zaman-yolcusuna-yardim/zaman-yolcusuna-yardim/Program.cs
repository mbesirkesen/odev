using System;
using System.Collections.Generic;
/*Bir grup bilim insanı, insanları zamanda geriye götürebilecek bir cihaz geliştirdi.
Ancak bu cihazı kullanmak için doğru tarih ve saat koordinatlarını çözmek gerekiyor.
Cihazın çalışma mantığına göre, tarihin gün, ay ve yıl bileşenleri birbiriyle
matematiksel olarak ilişkilendirilmiş durumda. Bir zaman yolcusu, geçmişe gitmek
için cihazı kullanmak istiyor, ancak cihazın gideceği tarihi doğru bir şekilde çözmesi
gerekiyor. Bilim insanları bu zaman yolcusuna cihazın algoritmasını anlaması için
bazı ipuçları verdi:
i. Gün, ay ve yıl ilişkisi: Cihaz yalnızca belirli tarih formatında çalışıyor. Bir
tarih (gün, ay, yıl) cihazın kabul edeceği formattaysa, zamanda yolculuk
mümkün oluyor. Kabul edilen formattaki bir tarihin, aşağıdaki koşullara
uyması gerekiyor:
 Gün sayısı asal sayı olmalı.
 Ay sayısının tüm basamaklarının toplamı çift olmalı.
 Yıl sayısı ise şu özelliğe sahip olmalı: Yıl sayısını oluşturan rakamlar
toplamı, o yılın dörtte birinden küçük olmalı.

ii. Algoritmik zorluklar: Zaman yolcusu, 2000 ile 3000 yılları arasında bir
tarihe gitmek istiyor. Ona cihazın kabul ettiği tüm uygun tarihleri listeleyen bir
algoritma yazması gerektiği söyleniyor. Ancak milyonlarca olası tarih
kombinasyonu olduğu için, algoritmanın verimli çalışması gerekiyor.
iii. Ek koşullar: Zaman yolcusunun yalnızca geleceğe gitmesine izin veriliyor.
Bu yüzden algoritma, şu andan sonraki bir tarihe odaklanmalı.
iv. Görev: Zaman yolcusuna yardım etmek için bir algoritma yaz. Bu algoritma,
belirlenen tarihler aralığında cihazın kabul edeceği tüm geçerli tarihleri
listelemelidir. Her tarih, gün, ay ve yıl formatında olmalı. Cihazın kabul ettiği
tarihler listeye eklenmelidir.*/

class Program
{
    static void Main(string[] args)
    {
        DateTime simdikiTarih = DateTime.Now;
        List<string> uygunTarihler = new List<string>();

        for (int yil = 2000; yil <= 3000; yil++)
        {
            for (int ay = 1; ay <= 12; ay++)
            {
                int gunSayisi = DateTime.DaysInMonth(yil, ay);
                for (int gun = 1; gun <= gunSayisi; gun++)
                {
                    DateTime tarih = new DateTime(yil, ay, gun);
                    if (tarih > simdikiTarih && GeçerliTarih(gun, ay, yil))
                    {
                        uygunTarihler.Add(tarih.ToString("dd/MM/yyyy"));
                    }
                }
            }
        }

        Console.WriteLine("Cihazın kabul ettiği tarihler:");
        foreach (string tarih in uygunTarihler)
        {
            Console.WriteLine(tarih);
        }
    }

    static bool GeçerliTarih(int gun, int ay, int yil)
    {
        return IsAsal(gun) && IsCiftToplam(ay) && IsYilUygun(yil);
    }

    static bool IsAsal(int sayi)
    {
        if (sayi <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(sayi); i++)
        {
            if (sayi % i == 0) return false;
        }
        return true;
    }

    static bool IsCiftToplam(int sayi)
    {
        int toplam = 0;
        while (sayi > 0)
        {
            toplam += sayi % 10;
            sayi /= 10;
        }
        return toplam % 2 == 0;
    }

    static bool IsYilUygun(int yil)
    {
        int toplam = 0;
        int tempYil = yil;
        while (tempYil > 0)
        {
            toplam += tempYil % 10;
            tempYil /= 10;
        }
        return toplam < (yil / 4);
    }
}

using System;
using System.Text;
/*Bir casus örgütü, düşmanlarının mesajlarını çözmelerini zorlaştırmak için son derece
karmaşık bir şifreleme sistemi geliştirdi. Bu şifreleme sistemi, mesajların belirli
kurallara göre dönüştürüldüğü bir dizi adımdan oluşuyor. Göreviniz, bu sistemi
çözerek şifrelenmiş bir mesajın orijinal haline ulaşmaktır. Sistemin çalışma şekli şu
kurallara dayanmaktadır:
i. Adım 1 - Fibonacci Dönüşümü: Mesajın her bir karakteri ASCII değerine
dönüştürülür. Daha sonra her karakterin ASCII değeri, o karakterin
pozisyonuna göre bir Fibonacci sayısıyla çarpılır. Mesajdaki karakterlerin
sırası 1&#39;den başlar. Yani ilk karakter, Fibonacci(1), ikinci karakter
Fibonacci(2) ile çarpılır ve bu işlem tüm karakterler için devam eder.
Fibonacci serisi: 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, ...
ii. Adım 2 - Modüler Çözümleme: Fibonacci ile çarpılan her bir ASCII değeri,
bir mod işlemine tabi tutulur. Mod işlemi şu şekilde çalışır:
o Eğer karakterin pozisyonu asal bir sayıysa, o karakterin değeri 100&#39;e
bölümünden kalan alınır.
o Eğer pozisyon asal değilse, karakterin değeri 256&#39;ya bölümünden kalan
alınır.

iii. Adım 3 - Şifreleme: Elde edilen her mod sonucu, tekrar bir ASCII karakterine
dönüştürülür ve yeni şifreli mesaj oluşturulur.
iv. Görev: Size şifrelenmiş bir mesaj verilecektir. Bu mesajın çözülmesi ve
orijinal haline geri dönülmesi gerekmektedir. Ancak şifreleme işlemi sırasında
kullanılan Fibonacci dönüşümünü ve modüler çözümlemeyi tersine
çevirmelisiniz. Görev, bu algoritmayı çözerek mesajı orijinaline döndürmektir.*/
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Şifrelenmiş mesajı girin: ");
        string encryptedMessage = Console.ReadLine();

        string originalMessage = DecryptMessage(encryptedMessage);
        Console.WriteLine("Orijinal mesaj: " + originalMessage);
    }

    static string DecryptMessage(string encryptedMessage)
    {
        StringBuilder originalMessage = new StringBuilder();
        int length = encryptedMessage.Length;

        for (int i = 0; i < length; i++)
        {
            char encryptedChar = encryptedMessage[i];
            int position = i + 1; // Pozisyon 1'den başlar
            int modValue = IsPrime(position) ? 100 : 256; // Asal kontrolü

            int asciiValue = (int)encryptedChar;
            int originalAsciiValue;

            // Fibonacci sayısını hesapla
            int fib = Fibonacci(position);

            // Orijinal ASCII değerini bul
            if (asciiValue < modValue)
            {
                originalAsciiValue = asciiValue * fib;
            }
            else
            {
                originalAsciiValue = (asciiValue + modValue) * fib;
            }

            // ASCII değerini karaktere çevir
            originalMessage.Append((char)originalAsciiValue);
        }

        return originalMessage.ToString();
    }

    static int Fibonacci(int n)
    {
        if (n <= 2) return 1;
        int a = 1, b = 1;
        for (int i = 3; i <= n; i++)
        {
            int temp = a + b;
            a = b;
            b = temp;
        }
        return b;
    }

    static bool IsPrime(int numera)
    {
        if (numera <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(numera); i++)
        {
            if (numera % i == 0) return false;
        }
        return true;
    }
}


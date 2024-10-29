using System;
using System.Collections.Generic;
/*Gizemli bir adada, her yıl sadece bir kez açılan efsanevi bir kapı vardır. Bu kapı,
adanın merkezindeki bir tapınağa götürür. Ancak tapınağa ulaşmak için, kapının
açılacağı en uygun zamanı bulmanız gerekmektedir. Kapı, belirli bir dizilimdeki
sayılarla kilitlenmiştir ve sadece bu dizilimi doğru çözenler kapıyı açabilir.
Bu dizilim, bir dizi sayı ve operatörlerden oluşmaktadır, ancak bu diziyi çözmek için
belirli kurallar vardır. Diziyi doğru çözmek, sadece operatörlerin doğru sıralamasıyla
mümkündür ve bu sıralama, sayılar arasındaki ilişkileri çözmeyi gerektirir. Adadaki
en büyük bilge, bu diziyi çözebilecek tek kişi olduğunu söylese de çok fazla
kombinasyon ve olasılık olduğu için kesin bir çözüm yoktur.
Görev: Adadaki tapınağın kapısını açmak için belirli bir sayı dizisinin içerisindeki
operatörlerin doğru sıralamasını bulmanız gerekmektedir. Ancak operatörlerin her biri
belirli bir kurala göre hareket eder:
i. Her sayı, bir diğer sayıya bağlanmak zorundadır.
ii. Operatörler sadece toplama (+), çıkarma (-), çarpma (*) veya bölme (/) olabilir.
iii. Ancak her adımda bir sayı veya operatör eklerken belirli şartlara göre hareket
etmelisiniz. Örneğin:
o Bir operatör eklediğinizde, en az bir sayıyı işlem görmüş hale getirmeniz gerekir.
o İki operatör ardışık eklenemez.
o Sonuç her zaman sıfırdan büyük olmalıdır.*/

class Program
{
    static void Main(string[] args)
    {
        // Sayı dizisi tanımlayın
        Console.Write("sayi dizisinin buyuklugunu giriniz :");
        int ap=int.Parse(Console.ReadLine());
        double[] numbers = new double[ap];
        for (int i = 0; i < numbers.Length; i++) {
            Console.Write("lutfen dizi icin eleman girin :");
            numbers[i] = int.Parse(Console.ReadLine()); 
                }
        char[] operators = { '+', '-', '*', '/' }; // Kullanılabilecek operatörler

        // Tüm olasılıkları hesapla
        List<string> expressions = GenerateExpressions(numbers, operators);

        Console.WriteLine("Geçerli ifadeler:");
        foreach (var expression in expressions)
        {
            Console.WriteLine(expression);
        }
    }

    static List<string> GenerateExpressions(double[] numbers, char[] operators)
    {
        List<string> validExpressions = new List<string>();

        // Tüm kombinasyonları denemek için döngü kullanın
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < operators.Length; j++)
            {
                // İlk sayı
                double currentValue = numbers[i];
                string expression = numbers[i].ToString();

                // Diğer sayıları ekleyerek ifadeleri oluştur
                for (int k = 0; k < numbers.Length; k++)
                {
                    if (k != i)
                    {
                        char op = operators[j];
                        expression += $" {op} {numbers[k]}";

                        // Hesaplama yap
                        currentValue = Calculate(currentValue, numbers[k], op);

                        // Sonucun geçerli olup olmadığını kontrol et
                        if (currentValue > 0)
                        {
                            validExpressions.Add(expression);
                        }
                    }
                }
            }
        }

        return validExpressions;
    }

    static double Calculate(double a, double b, char op)
    {
        return op switch
        {
            '+' => a + b,
            '-' => a - b,
            '*' => a * b,
            '/' => a / b,
            _ => 0,
        };
    }
}

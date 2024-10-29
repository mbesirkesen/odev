using System;
using System.Text;
/*Bir grup uzay madencisi, zengin maden yataklarına sahip bir asteroide iniş yaptı.
Ancak asteroitteki madenlerin dağılımı oldukça düzensiz ve tehlikeli yollar içeriyor.
Maden yataklarına ulaşmak için madencilerin dikkatlice bir yol planlaması gerekiyor.
Asteroit, NxN boyutlarında bir ızgara olarak modellenmiş durumda. Her hücre bir
koordinata karşılık geliyor ve madenciler bu koordinatlar üzerinden maden toplamak
zorunda. Asteroit üzerindeki maden toplama sistemi şu şekilde işliyor:
i. Enerji harcama: Her hücrede belirli bir enerji tüketimi var. Madenciler bir
hücreden diğerine geçerken belirli bir enerji harcarlar. Ancak bazı hücreler
daha fazla enerji harcatır çünkü bu hücrelerde engeller, çukurlar veya volkanik

aktiviteler olabilir. Enerji tüketimi, her hücrede farklı olup pozitif tam sayılar
ile ifade edilmiştir.
ii. Kısıtlamalar: Madenciler bir hücreden sadece sağa, aşağıya veya çapraz
sağa aşağıya (diyagonal) hareket edebilirler. Geriye dönüş yoktur, bu yüzden
planlamada bu sınırlamalara uymak zorundadırlar.
iii. Hedef: Madenciler, (0, 0) noktasından başlayarak (N-1, N-1) noktasındaki en
değerli madeni çıkartmak istiyorlar. Ancak bunu yaparken harcayacakları
toplam enerji miktarını en az seviyede tutmaları gerekiyor.
iv. Görev: Bir algoritma yazarak madencilerin (0, 0) noktasından başlayarak (N-
1, N-1) noktasına kadar olan en az enerji harcayan yolu bulmalısınız. Enerji
maliyeti bir 2D matriste verilecektir. Bu matrisin her hücresi, o hücrede
harcanacak enerji miktarını göstermektedir.*/

class Program
{
    static void Main(string[] args)
    {
        // Enerji tüketimi matrisini tanımlayın
        Console.Write("matris botunu tuslayınn (NxN):");
        int n=int.Parse(Console.ReadLine());
        int[,] energyMatrix =new int[n,n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) { 
                Console.Write("lutfen bir sayi tuslainiz");
                int pepe = int.Parse(Console.ReadLine());
                energyMatrix[i,j] = pepe;
            }
        }


       int mami = energyMatrix.GetLength(0);
        int minEnergy = FindMinEnergyPath(energyMatrix,mami);

        Console.WriteLine("En az enerji harcayan yolun maliyeti: " + minEnergy);
    }

    static int FindMinEnergyPath(int[,] energyMatrix, int mami)
    {
        int[,] dp = new int[mami, mami];

        // Başlangıç hücresinin enerjisi
        dp[0, 0] = energyMatrix[0, 0];

        // İlk satırı doldur
        for (int j = 1; j < mami; j++)
        {
            dp[0, j] = dp[0, j - 1] + energyMatrix[0, j];
        }

        // İlk sütunu doldur
        for (int i = 1; i < mami; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + energyMatrix[i, 0];
        }

        // Matrisin geri kalanını doldur
        for (int i = 1; i < mami; i++)
        {
            for (int j = 1; j < mami; j++)
            {
                int fromLeft = dp[i, j - 1]; // soldan gelen enerji
                int fromAbove = dp[i - 1, j]; // yukarıdan gelen enerji
                int fromDiagonal = dp[i - 1, j - 1]; // çaprazdan gelen enerji

                dp[i, j] = energyMatrix[i, j] + Math.Min(fromLeft, Math.Min(fromAbove, fromDiagonal));
            }
        }

        // (N-1, N-1) hücresine ulaşmak için gereken minimum enerji
        return dp[mami - 1, mami - 1];
    }
}

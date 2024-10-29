using System;
using System.Collections.Generic;
/*labirentin içinde kayboldu. Şehre ulaşabilmek için bu labirentin doğru yollarını
çözmeniz gerekiyor. Labirent, MxN boyutlarında bir ızgaradır ve her hücrede bir
"kapı " bulunur.Kapılar, sadece belirli matematiksel kuralları karşılayan

koordinatlarda açılabilir. Eğer bir kapı açılabiliyorsa o hücreye geçiş mümkündür,
aksi takdirde o hücreye girmek imkansızdır. Şehir haritası şu şekilde tanımlanmıştır:
i.Labirentteki bir hücreye ancak şu şartlar sağlanırsa girebilirsiniz:
o Hücrenin x ve y koordinatlarının her iki basamağı da asal sayı olmalıdır.
o Eğer hem x hem de y koordinatlarının toplamı, x ve y koordinatlarının çarpımına
bölünebiliyorsa, kapı açılacaktır.
ii. Şehir, labirentin sağ alt köşesinde (M-1, N-1) konumunda bulunmaktadır.
Yolculuğunuz labirentin sol üst köşesinden (0, 0) başlayacaktır. Eğer şehre
ulaşamazsanız, kaybolursunuz.
iii. Görev: Labirenti çözmek için bir algoritma yazmanız gerekiyor. Bu
algoritma, belirlenen koşullara göre hangi hücrelere gidilebileceğini
belirleyecek ve başlangıç noktasından hedef noktaya ulaşabilecek bir yol
bulup bulamayacağını kontrol edecektir. Eğer bir yol bulabiliyorsanız, yolun
adımlarını listeleyin. Eğer hiçbir yol yoksa, " Şehir kayboldu!"çıktısını verin.*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Zarva şehrine ulaşmak için labirentteki yolu buluyoruz...");
        Console.Write("satir sayisini tusalyiniz :");
        int M = int.Parse(Console.ReadLine()); // Labirentin satır sayısı
        Console.Write("sütun sayisini tusalyiniz :");
        int N = int.Parse(Console.ReadLine()); // Labirentin sütun sayısı
        bool[,] visited = new bool[M, N];

        
        if (FindPath(0, 0, M, N, visited, new List<string>()))
        {
            Console.WriteLine("Şehir bulundu!");
        }
        else
        {
            Console.WriteLine("Şehir kayboldu!");
        }
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static bool CanEnterCell(int x, int y)
    {
        return IsPrime(x) && IsPrime(y) && (x + y) % (x * y) == 0;
    }

    static bool FindPath(int x, int y, int M, int N, bool[,] visited, List<string> path)
    {
        // Hedef hücre kontrolü
        if (x == M - 1 && y == N - 1)
        {
            path.Add($"({x}, {y})");
            Console.WriteLine("Yol: " + string.Join(" -> ", path));
            return true;
        }

        // Sınır kontrolü
        if (x < 0 || x >= M || y < 0 || y >= N || visited[x, y] || !CanEnterCell(x, y))
        {
            return false;
        }

        // Hücreyi ziyaret ettik
        visited[x, y] = true;
        path.Add($"({x}, {y})");

        // Komşu hücrelere git
        bool found = FindPath(x + 1, y, M, N, visited, path) ||  // Aşağı
                     FindPath(x - 1, y, M, N, visited, path) ||  // Yukarı
                     FindPath(x, y + 1, M, N, visited, path) ||  // Sağa
                     FindPath(x, y - 1, M, N, visited, path);     // Sola

        // Geri dönüyoruz
        if (!found)
        {
            path.RemoveAt(path.Count - 1);
        }

        visited[x, y] = false; // Ziyareti geri al
        return found;
    }
}

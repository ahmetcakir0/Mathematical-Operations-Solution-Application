using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematik_Problemleri_Çözüm
{
    class MatematikSinavi
    {
        static readonly Random rnd = new Random();
        static int dogruSayisi = 0;
        static int yanlisSayisi = 0;
        const int TOPLAM_SORU = 10;

        static void Main()
        {
            try
            {
                Console.WriteLine("Matematik Sınavına Hoş Geldiniz!");
                Console.WriteLine($"Toplam {TOPLAM_SORU} soru sorulacaktır.");
                Console.WriteLine("Her soruyu cevapladıktan sonra Enter tuşuna basın.");
                Console.WriteLine("---------------------------------------------");

                for (int i = 1; i <= TOPLAM_SORU; i++)
                {
                    SoruSor(i);
                }

                SinavSonuclariniGoster();

                Console.WriteLine("\n=============================================");
                Console.WriteLine("PROGRAMI KAPATMAK İÇİN 'ENTER' TUŞUNA BASINIZ!");
                Console.WriteLine("=============================================\n");

                while (true)
                {
                    if (Console.ReadLine() != null)
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata oluştu: {ex.Message}");
                Console.WriteLine("\nProgramı kapatmak için Enter'a basın...");
                Console.ReadLine();
            }
        }

        static void SoruSor(int soruNo)
        {
            int islemTuru = rnd.Next(4);
            int sayi1, sayi2;
            double dogruCevap;
            string islemIsareti;

            switch (islemTuru)
            {
                case 0:
                    sayi1 = rnd.Next(1, 101);
                    sayi2 = rnd.Next(1, 101);
                    dogruCevap = sayi1 + sayi2;
                    islemIsareti = "+";
                    break;
                case 1:
                    sayi1 = rnd.Next(1, 101);
                    sayi2 = rnd.Next(1, sayi1);
                    dogruCevap = sayi1 - sayi2;
                    islemIsareti = "-";
                    break;
                case 2:
                    sayi1 = rnd.Next(1, 13);
                    sayi2 = rnd.Next(1, 13);
                    dogruCevap = sayi1 * sayi2;
                    islemIsareti = "*";
                    break;
                default:
                    sayi2 = rnd.Next(1, 13);
                    sayi1 = sayi2 * rnd.Next(1, 13);
                    dogruCevap = sayi1 / sayi2;
                    islemIsareti = "/";
                    break;
            }

            Console.Write($"\nSoru {soruNo}: {sayi1} {islemIsareti} {sayi2} = ");

            if (double.TryParse(Console.ReadLine(), out double kullaniciCevap))
            {
                if (Math.Abs(kullaniciCevap - dogruCevap) < 0.01)
                {
                    Console.WriteLine("Tebrikler! Doğru cevap!");
                    dogruSayisi++;
                }
                else
                {
                    Console.WriteLine($"Yanlış cevap. Doğru cevap: {dogruCevap}");
                    yanlisSayisi++;
                }
            }
            else
            {
                Console.WriteLine($"Geçersiz giriş! Doğru cevap: {dogruCevap}");
                yanlisSayisi++;
            }
        }

        static void SinavSonuclariniGoster()
        {
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("SINAV SONUÇLARI:");
            Console.WriteLine($"Toplam Soru: {TOPLAM_SORU}");
            Console.WriteLine($"Doğru Sayısı: {dogruSayisi}");
            Console.WriteLine($"Yanlış Sayısı: {yanlisSayisi}");
            double basariOrani = (double)dogruSayisi / TOPLAM_SORU * 100;
            Console.WriteLine($"Başarı Oranı: %{basariOrani:F2}");

            if (basariOrani >= 90)
                Console.WriteLine("Mükemmel bir performans!");
            else if (basariOrani >= 70)
                Console.WriteLine("İyi bir performans!");
            else if (basariOrani >= 50)
                Console.WriteLine("Ortalama bir performans. Biraz daha çalışmalısın.");
            else
                Console.WriteLine("Daha fazla pratik yapmalısın.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace TestTuzish
{
    public class TestYechish
    {
        public void TestYech()
        {

            Console.WriteLine("Qaysi fandan test yechmoqchisiz (tartib raqamini yozish yetarli)");
            Console.WriteLine("Ro'yxat:");
            string[] FayllarRoyxati = Directory.GetFiles("E:\\Fanlardan Testlar");
            int Tr = 1;
            foreach(var file in  FayllarRoyxati)
            {
                string s=file.Replace("E:\\Fanlardan Testlar\\", "");
                Console.WriteLine("{0} : {1}",Tr,s);
                Tr++;
            }
            Tr = 1;
            string FaylManzili = FayllarRoyxati[0];
            int EnterTr = Convert.ToInt32(Console.ReadLine());
            foreach (var file in FayllarRoyxati)
            {
                if (Tr == EnterTr)
                {
                    FaylManzili = file;
                    break;
                }
                Tr++;
            }
            string[] AllData = File.ReadAllLines(FaylManzili);
            int savolSoni = Convert.ToInt32(AllData[0].Trim());
            int variantSoni = Convert.ToInt32(AllData[2].Trim());
            int birSavol = 1 + variantSoni;
            string Toplovchi = "";
            List<string> Testlar = new List<string>();
            //for (int i = 0; i < AllData.Length;i++) Console.Write(AllData[i]);
            for (int i = 4; i < AllData.Length; i++)
            {
                if (AllData[i].StartsWith("-------------------------------"))
                {
                    Testlar.Add(Toplovchi);
                    Toplovchi = "";
                }
                else
                {
                    Toplovchi+= AllData[i];
                }
            }
            string[,] BulinganTestlar = new string[savolSoni,birSavol];
            int savolSana = 0;
            Console.WriteLine(Testlar.Count);
            for (int i = 0; i < Testlar.Count; i++)
            {
                if(i%birSavol == 0 && i!=0)  savolSana++;
                BulinganTestlar[savolSana,i % birSavol ] = Testlar[i];
                
            }
            string AniqJavoblar="";
            string OquvchiningJavoblari = "";
            for (int i = 0; i < savolSoni; i++)
            {
                Console.WriteLine(BulinganTestlar[i,0]);
                for (int j = 1; j < birSavol; j++)
                {
                    if ((int)BulinganTestlar[i, j][0] < 91)
                    {
                        AniqJavoblar += BulinganTestlar[i, j][0];
                    }
                    Console.WriteLine("{0}    {1}",(char)(64+j),BulinganTestlar[i, j].Substring(1));
                }
                Console.Write("Javobingizni kiriting : ");
                string OquvchiJavobi = Console.ReadLine().ToUpper();
                OquvchiningJavoblari += OquvchiJavobi;
            }
            Console.WriteLine("O'quvchining javoblari");
            Console.WriteLine(OquvchiningJavoblari);
            Console.WriteLine("haqiqiy Javoblar");
            Console.WriteLine(AniqJavoblar);
        }


        

    }
}

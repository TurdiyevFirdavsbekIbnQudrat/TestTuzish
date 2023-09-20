using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTuzish
{
    public class TestniTuzish
    {
        public void TestTuzuvchi() 
        {
            Console.WriteLine("Qaysi fandan test tuzmoqchisiz");
            string FanNomi = Console.ReadLine();
            string PapkaNomi = "E:\\Fanlardan Testlar";
            DirectoryInfo newFilePath;
            if (Directory.Exists(PapkaNomi) != true)
            {
                newFilePath = Directory.CreateDirectory(PapkaNomi);
            }
            string FanNomivaManzil = String.Format("{0}\\{1}.txt", PapkaNomi, FanNomi);
            string path = FanNomivaManzil;
           //  Console.WriteLine(FanNomivaManzil);
            FileStream YaratilganFanNomi;
            do
            {
                if (File.Exists(FanNomivaManzil) != true)
                {
                    YaratilganFanNomi = File.Create(FanNomivaManzil);
                    YaratilganFanNomi.Close();
                    break;
                }
                else
                {
                    Console.WriteLine("Bu Fayl borligi sababli boshqa fayl nomi tanlang : ");
                    FanNomi = Console.ReadLine();

                }
            } while (true);


            Console.WriteLine("Savollar soni");
            int SavolSoni = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Variantlar soni");
            int VariantSoni = Convert.ToInt32(Console.ReadLine());

            string sAvoLsonlari = SavolSoni.ToString() + "\n------------------------------------------\n";
            string VariantMiqdori = VariantSoni.ToString() + "\n------------------------------------------\n";
            File.WriteAllText(path, sAvoLsonlari);
            File.AppendAllText(path, VariantMiqdori);
            for (int i = 1; i <= SavolSoni; i++)
            {
                Console.Write("{0}-Savol: ", i);
                string savol = Console.ReadLine();
                Console.WriteLine("Javoblar");
                string[] Javoblar = new string[VariantSoni];

                for (int j = 1; j <= VariantSoni; j++)
                {
                    Console.Write("{0} - variant : ",(char)(j+64));
                    string javobQismi = Console.ReadLine();
                    Javoblar[j - 1] = javobQismi;
                }

                Console.Write("To'g'ri Javobni kiriting (ingliz harfida): ");
                string AniqJavob = Console.ReadLine();
                File.AppendAllText(FanNomivaManzil, savol);
                File.AppendAllText(FanNomivaManzil, "\n------------------------------------------\n");

                for (int j = 0; j < VariantSoni; j++)
                {
                    if (AniqJavob.Equals((char)(j + 65) + "") == true || AniqJavob.Equals((char)(j + 97) + "") == true)
                    {
                        File.AppendAllText(FanNomivaManzil, (char)(j + 65) + Javoblar[j]);
                        File.AppendAllText(FanNomivaManzil, "\n------------------------------------------\n");
                    }
                    else
                    {
                        File.AppendAllText(FanNomivaManzil, (char)(j + 97) + Javoblar[j]);
                        File.AppendAllText(FanNomivaManzil, "\n------------------------------------------\n");
                    }
                }
            }

        }
    }
}

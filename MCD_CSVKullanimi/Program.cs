using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MCD_CSVKullanimi
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Musteri> Musterilerim = new List<Musteri>();

            for (int i = 0; i < 50; i++)
            {
                Musteri temp = new Musteri();
                temp.ID = i.ToString();
                temp.Isim = FakeData.NameData.GetFirstName();
                temp.Soyisim = FakeData.NameData.GetSurname();
                temp.EmailAdres = $"{temp.Isim}.{temp.Soyisim}@{FakeData.NetworkData.GetDomain()}";
                temp.TelefonNumarasi = FakeData.NumberData.GetNumber().ToString();

                Musterilerim.Add(temp);
            }


            //Dosyadan Okuma
            StreamReader SR = new StreamReader(@"C:\CSV\musteri.csv");
            CsvHelper.CsvReader Reader = new CsvHelper.CsvReader(SR);
            List<Musteri> OkunanData = Reader.GetRecords<Musteri>().ToList();

            foreach (var musteri in OkunanData)
            {
                Console.WriteLine(musteri.ID + ";" + musteri.Isim + ";" + musteri.Soyisim + ";" + musteri.EmailAdres + ";" + musteri.TelefonNumarasi);
                Console.WriteLine("");
            }


            #region Yazdırma İşlemi
            //StreamWriter SW = new StreamWriter(@"C:\CSV\musteri.csv");
            //CsvHelper.CsvWriter write = new CsvHelper.CsvWriter(SW);
            //write.WriteHeader(typeof(Musteri));
            //write.NextRecord();

            //foreach (Musteri item in Musterilerim)
            //{
            //    write.WriteRecord(item);
            //    write.NextRecord();
            //}

            //SW.Close();
            #endregion
            SR.Close();

            Console.ReadKey();
        }
    }
}

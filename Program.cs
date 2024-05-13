using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biljka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StablastaBiljka s1 = new StablastaBiljka("Drvo Akacije", true, 5.0f, DateTime.Parse("11/07/2024"));
            StablastaBiljka s2 = new StablastaBiljka("Drvo Tresnje", true, 3.0f, DateTime.Parse("11/06/2024"));
            StablastaBiljka s3 = new StablastaBiljka("Drvo Banane", true, 5.0f, DateTime.Today);
            SaksijastaBiljka b1 = new SaksijastaBiljka("Ghost Pepper", false, 1.0f, 0.5f, 1000);
            SaksijastaBiljka b2 = new SaksijastaBiljka("Suncokret", false, 1.0f, 0.5f, 750);
            SaksijastaBiljka b3 = new SaksijastaBiljka("Bobanova", true, 1.0f, 0.5f, 800);
            BotanickaBasta basta = new BotanickaBasta("Bobanova Basta", 100, 80);
            basta.Add(s1);
            basta.Add(s2);
            basta.Add(s3);
            basta.Add(b1);
            basta.Add(b2);
            basta.Add(b3);/*
            s1.ZapisiUFajl("drvoAkacije.bin");
            StablastaBiljka st = new StablastaBiljka();
            st.UpisiUObjekat("drvoAkacije.bin");*/
            try
            {
                basta.Sort();
                basta.ZapisiUFaj("bastica.bin");/*
                basta.IzbacitiVisakBiljaka();*/
                BotanickaBasta basta1 = new BotanickaBasta();
                basta1.UpisiUObjekat("bastica.bin");
            }
            catch (NedovoljnaRaznovrsnost e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

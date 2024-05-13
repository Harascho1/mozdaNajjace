using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Biljka
{
    internal class BotanickaBasta
    {
        #region Atributi
        string nazivBaste;
        int posetiociNaDan;
        float cenaUlaznice;
        List<Biljka> listaBiljaka;
        #endregion
        #region Konstruktori
        public BotanickaBasta() 
        {
            listaBiljaka = new List<Biljka>();
        }
        public BotanickaBasta(string nazivBaste, int posetiociNaDan, float cenaUlaznice)
        {
            this.listaBiljaka = new List<Biljka>();
            this.nazivBaste = nazivBaste;
            this.posetiociNaDan = posetiociNaDan;
            this.cenaUlaznice = cenaUlaznice;
        }
        #endregion
        #region Properties
        public float DnevnaZarada
        {
            get
            {
                return cenaUlaznice * posetiociNaDan;
            }
        }
        public float DnevniTrosak
        {
            get
            {
                float suma = 0.0f;
                foreach (Biljka biljka in listaBiljaka)
                {
                    suma += biljka.CenaOdrzavanja();
                }
                return suma;
            }
        }
        #endregion
        #region Metode
        public void Add(Biljka biljka)
        {
            listaBiljaka.Add(biljka);
        }
        public void IzbacitiVisakBiljaka()
        {
            while(this.DnevniTrosak <= this.DnevnaZarada)
                foreach (Biljka biljka in listaBiljaka)
                    if (biljka.DaLiJeVisegodisnja)
                    {
                        listaBiljaka.Remove(biljka);
                        break;
                    }
        }
        public void Sort()
        {
            listaBiljaka.Sort();
        }
        public void ProveriRaznovrsnost()
        {
            bool flag1 = false, flag2 = false;
            foreach (Biljka biljka in listaBiljaka)
            {
                if(biljka.GetType().ToString() == "StabljastaBiljka")
                    flag1 = true;
                if(biljka.GetType().ToString() == "SaksijastaBiljka")
                    flag2 = true;
            }
            if(flag1 && flag2)
            {
                return;
            }
            else
            {
                throw new NedovoljnaRaznovrsnost("NEMA RAZLICITIH BILJAKA");
            }
        }
        public void ZapisiUFaj(string imeFajla)
        {
            try
            {
                FileStream fs = new FileStream(Path.Combine(Environment.CurrentDirectory, imeFajla), FileMode.Create);
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    
                    bw.Write(nazivBaste);
                    bw.Write(posetiociNaDan);
                    bw.Write(cenaUlaznice);
                    foreach (Biljka biljka in listaBiljaka)
                    {
                        bw.Write(biljka.GetType().ToString());
                        biljka.ZapisiUFajl(bw);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpisiUObjekat(string imeFajla)
        {
            try
            {
                FileStream fs = new FileStream(Path.Combine(Environment.CurrentDirectory, imeFajla), FileMode.Open);
                using (BinaryReader br = new BinaryReader(fs))
                {
                    nazivBaste = br.ReadString();
                    posetiociNaDan = br.ReadInt32();
                    cenaUlaznice = br.ReadSingle();
                    while(br.BaseStream.Position < br.BaseStream.Length)
                    {
                        string izvedenObjekat = br.ReadString();
                        if (izvedenObjekat == "Biljka.StablastaBiljka")
                        {
                            Biljka b = new StablastaBiljka();
                            b.UpisiUObjekat(br);
                            Add(b);
                        }
                        else
                        {
                            Biljka b = new SaksijastaBiljka();
                            b.UpisiUObjekat(br);
                            Add(b);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}

using System;
using System.IO;

namespace Biljka
{
    abstract class Biljka : IComparable<Biljka>
    {
        protected string nazivBiljke;
        protected bool daLiJeVisegodisnja;
        protected float kolicinaVode;
        #region Konstruktori
        public Biljka() { }
        public Biljka(string nazivBiljke, bool daLiJeVisegodisnja, float kolicinaVode)
        {
            this.nazivBiljke = nazivBiljke;
            this.daLiJeVisegodisnja = daLiJeVisegodisnja;
            this.kolicinaVode = kolicinaVode;
        }
        #endregion
        #region Properties
        public bool DaLiJeVisegodisnja
        {
            get
            {
                return daLiJeVisegodisnja;
            }
        }
        #endregion
        #region Metode
        public abstract float CenaOdrzavanja();
        
        public void ZapisiUFajl(string imeFajla)
        {
            try
            {
                FileStream fs = new FileStream(Path.Combine(Environment.CurrentDirectory, imeFajla), FileMode.Truncate);
                BinaryWriter bw = new BinaryWriter(fs);
                ZapisiUFajl(bw);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }
        public void UpisiUObjekat(string imeFajla)
        {
            try
            {
                FileStream fs = new FileStream(Path.Combine(Environment.CurrentDirectory, imeFajla), FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                UpisiUObjekat(br);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public virtual void ZapisiUFajl(BinaryWriter bw)
        {
            bw.Write(nazivBiljke.ToString());
            bw.Write(daLiJeVisegodisnja);
            bw.Write(kolicinaVode);
        }
        public virtual void UpisiUObjekat(BinaryReader br)
        {
            nazivBiljke = br.ReadString();
            daLiJeVisegodisnja = br.ReadBoolean();
            kolicinaVode = br.ReadSingle();
        }
        public int CompareTo(Biljka other)
        {
            return this.kolicinaVode.CompareTo(other.kolicinaVode) ;
        }
        #endregion
    }
}

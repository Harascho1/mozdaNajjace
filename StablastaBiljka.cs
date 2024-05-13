using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biljka
{
    internal class StablastaBiljka : Biljka
    {
        DateTime datumPresadjivanja;

        public StablastaBiljka() : base() { }
        public StablastaBiljka(string nazivBiljke, bool daLiJeVisegodisnja, float kolicinaVode, DateTime datumPresadjivanja) 
            : base(nazivBiljke, daLiJeVisegodisnja, kolicinaVode)
        {
            this.datumPresadjivanja = datumPresadjivanja;
        }

        public override float CenaOdrzavanja()
        {
            float cena = kolicinaVode * 100;
            if(datumPresadjivanja == DateTime.Now) { return cena + 2000; }
            return cena;

        }
        
        public override void ZapisiUFajl(BinaryWriter bw)
        {
            base.ZapisiUFajl(bw);
            bw.Write(datumPresadjivanja.ToString());
        }
        public override void UpisiUObjekat(BinaryReader br)
        {
            base.UpisiUObjekat(br);
            datumPresadjivanja = DateTime.Parse(br.ReadString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Biljka
{
    internal class SaksijastaBiljka : Biljka
    {
        #region Atributi
        float kolicinaDJubriva;
        float cenaDJubriva;
        #endregion
        public SaksijastaBiljka() : base() { }
        public SaksijastaBiljka(string nazivBiljke, bool daLiJeVisegodisnja, float kolicinaVode, float kolicinaDJubriva, float cenaDJubriva) : base(nazivBiljke, daLiJeVisegodisnja, kolicinaVode)
        {
            this.kolicinaDJubriva = kolicinaDJubriva;
            this.cenaDJubriva = cenaDJubriva;
        }

        public override float CenaOdrzavanja()
        {
            float rezultat = kolicinaVode * 10 + kolicinaDJubriva * cenaDJubriva;
            if(daLiJeVisegodisnja) return rezultat * 1.1f;
            return rezultat;
        }

        public override void ZapisiUFajl(BinaryWriter bw)
        {
            base.ZapisiUFajl(bw);
            bw.Write(kolicinaDJubriva);
            bw.Write(cenaDJubriva);
        }
        public override void UpisiUObjekat(BinaryReader br)
        {
            base.UpisiUObjekat(br);
            kolicinaDJubriva = br.ReadSingle();
            cenaDJubriva = br.ReadSingle();
        }

    }
}

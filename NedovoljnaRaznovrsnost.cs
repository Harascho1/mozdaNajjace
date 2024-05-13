using System;

namespace Biljka
{
    internal class NedovoljnaRaznovrsnost : Exception
    {
        public NedovoljnaRaznovrsnost() : base() { }
        public NedovoljnaRaznovrsnost(string message) : base(message) { }
    }
}

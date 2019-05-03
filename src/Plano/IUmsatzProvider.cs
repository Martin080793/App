using System;
using System.Collections.Generic;
using System.Text;

namespace Plano
{
    public interface IUmsatzProvider
    {
        List<Umsatz> Umsätze { get; set; }
        void umsatzHinzufügen(Umsatz umsatz);
        void umsatzVerändern(Umsatz umsatz);
        void umsatzLöschen(Umsatz umsatz);
    }
}

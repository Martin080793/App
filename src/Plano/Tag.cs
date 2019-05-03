using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plano
{
    public class Tag
    {
        private readonly IUmsatzProvider _umsatzProvider;

        public Tag(IUmsatzProvider umsatzProvider)
        {
            _umsatzProvider = umsatzProvider;
            HeutigeUmsätze = _umsatzProvider.Umsätze.Where(u => u.Datum == DateTime.Today).ToList();
        }

        public List<Umsatz> HeutigeUmsätze
        {
            get;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoreFederazione
{
    public class Statistiche
    {
        private Dictionary<Associato, List<string>> _associati;

        public Dictionary<Associato, List<string>> Associati
        {
            get { return _associati; }
            set { _associati = value; }
        }

        public Statistiche(Dictionary<Associato, List<string>> associati)
        {
            _associati = associati;
        }

        public HashSet<Associato> ElencoSociMaggiorenni()
        {
            var risultato = from a in _associati
                         where a.Key.DataDiNascita <= DateOnly.FromDateTime(DateTime.Now).AddYears(-18)
                         select a;

            return risultato as HashSet<Associato>;
        }

        public HashSet<Associato> ElencoSociMinorenni()
        {
            var risultato = from a in _associati
                            where a.Key.DataDiNascita >= DateOnly.FromDateTime(DateTime.Now).AddYears(-18)
                            select a;

            return risultato as HashSet<Associato>;
        }

        public int NumeroTotaleSoci()
        {
            var risultato = from a in _associati
                            select a;

            return (risultato as HashSet<Associato>).Count;
        }

        
        public int NumeroTotaleAssociazioni()
        {
            var risultato = from a in _associati
                            select a.Key.AssociazioniDiAppartenenza;

            return (risultato as HashSet<string>).Count;
        }
        

        public int ElencoAssociatiConPiuAssociazioni()
        {
            var risultato = from a in _associati
                            where a.Key.AssociazioniDiAppartenenza.Count() > 1
                            select a;

            return (risultato as HashSet<Associato>).Count;
        }

        public HashSet<Associato> ElencoAssociatiConRinnovoInScadenza()
        {
            var risultato = from a in _associati
                            where a.Key.DataDiRinnovo.AddYears(1) <= DateOnly.FromDateTime(DateTime.Now) || a.Key.DataDiRinnovo.AddYears(1) <= DateOnly.FromDateTime(DateTime.Now).AddMonths(1)
                            select a;

            return risultato as HashSet<Associato>;
        }

        public HashSet<Associato> ElencoSociMaggiorenniLambda()
        {
            var risultato = _associati
                            .Where(a => a.Key.DataDiNascita <= DateOnly.FromDateTime(DateTime.Now).AddYears(-18))
                            .OrderBy(a => a.Key.Nome);

            return risultato as HashSet<Associato>;
        }

        public HashSet<Associato> ElencoSociMinorenniLambda()
        {
            var risultato = _associati
                            .Where(a => a.Key.DataDiNascita >= DateOnly.FromDateTime(DateTime.Now).AddYears(-18))
                            .Order();

            return risultato as HashSet<Associato>;
        }

        public int NumeroTotaleSociLamda()
        {
            var risultato = _associati
                            .Order();

            return (risultato as HashSet<Associato>).Count;
        }


        public int NumeroTotaleAssociazioniLambda()
        {
            var risultato = _associati
                            .Where(a => a.Key.AssociazioniDiAppartenenza != null)
                            .Order();

            return (risultato as HashSet<string>).Count;
        }


        public int ElencoAssociatiConPiuAssociazioniLambda()
        {
            var risultato = _associati
                            .Where(a => a.Key.AssociazioniDiAppartenenza.Count() > 1)
                            .Order();

            return (risultato as HashSet<Associato>).Count;
        }

        public HashSet<Associato> ElencoAssociatiConRinnovoInScadenzaLambda()
        {
            var risultato = _associati
                            .Where(a => a.Key.DataDiRinnovo.AddYears(1) <= DateOnly.FromDateTime(DateTime.Now) || a.Key.DataDiRinnovo.AddYears(1) <= DateOnly.FromDateTime(DateTime.Now).AddMonths(1))
                            .Order();

            return risultato as HashSet<Associato>;
        }
    }
}

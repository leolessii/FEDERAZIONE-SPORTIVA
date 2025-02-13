using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFederazione
{
    public class Associato
    {
        private string _nome;
        private string _cognome;
        private DateOnly _dataDiNascita;
        private DateOnly _dataDirinnovo;
        private List<string> _associazioniDiAppartenenza;

        public string Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Nome Associato");
                }
                _nome = value;
            }
        }

        public string Cognome
        {
            get { return _cognome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Cognome Associato");
                }
                _cognome = value;
            }
        }

        public DateOnly DataDiNascita
        {
            get { return _dataDiNascita; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Data di nascita");
                }
                _dataDiNascita = value;
            }
        }

        public DateOnly DataDiRinnovo
        {
            get { return _dataDirinnovo; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Data di rinnovo");
                }
                _dataDirinnovo = value;
            }
        }

        public List<string> AssociazioniDiAppartenenza
        {
            get { return _associazioniDiAppartenenza; }
            set { }
        }
        
        public Associato(string nome, string cognome, DateOnly dataDiNascita, DateOnly dataDirinnovo)
        {
            _nome = nome;
            _cognome = cognome;
            _dataDiNascita = dataDiNascita;
            _dataDirinnovo = dataDirinnovo;
        }

        public Associato()
        {
            
        }

        public override bool Equals(object? obj)
        {
            if(obj != null)
            {
                Associato associato = (obj as Associato)!;
                if (associato.Nome == Nome && associato.Cognome == Cognome && associato.DataDiNascita == DataDiNascita)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}

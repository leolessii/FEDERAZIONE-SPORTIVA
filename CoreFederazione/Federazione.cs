namespace CoreFederazione
{
    public class Federazione
    {
        private string _nome;
        private Dictionary<Associato, List<string>> _associati;
        private XML _xml;
        private Statistiche _statistiche;

        public string Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrEmpty(_nome)) throw new ArgumentException("nome associazione");
                _nome = value;
            }
        }

        public Dictionary<Associato, List<string>> Associati
        {
            get { return _associati; }
            set { _associati = value; }
        }

        public XML Xml
        {
            get { return _xml; }
            set { _xml = value; }
        }

        public Statistiche Statistiche
        {
            get { return _statistiche; }
            set { _statistiche = value;  }
        }

        public Federazione(string nome)
        {
            _nome = nome;
            _associati = new Dictionary<Associato, List<string>>();
            _xml = new XML();
        }

        public void ImportaSoci(string path)
        {
            _associati = _xml.LeggiSoci(path);
            _statistiche = new Statistiche(_associati);
        }

        public void EsportaSoci()
        {
            _xml.ScriviAssociati(_associati);
        }
    }
}

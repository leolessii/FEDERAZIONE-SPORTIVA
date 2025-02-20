namespace CoreFederazione
{
    public class Federazione
    {
        private string _nome;
        private Dictionary<Associato, List<string>> _associati;
        private XML _xml;

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

        public Federazione(string nome)
        {
            _nome = nome;
            _associati = new Dictionary<Associato, List<string>>();
            _xml = new XML();
        }

        public void ImportaSoci(string path)
        {
            _associati = _xml.LeggiSoci(path);
        }

        public void EsportaSoci()
        {
            _xml.ScriviAssociati(_associati);
        }
    }
}

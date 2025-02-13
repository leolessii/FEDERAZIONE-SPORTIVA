namespace CoreFederazione
{
    public class Federazione
    {
        private HashSet<Associato> _associati;

        public HashSet<Associato> Associati
        {
            get { return _associati; }
            set { _associati = value; }
        }

        public Federazione()
        {
            _associati = new HashSet<Associato>();
        }
    }
}

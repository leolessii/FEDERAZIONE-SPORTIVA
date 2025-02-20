using CoreFederazione;

namespace ConsoleFederazione
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Federazione federazione = new Federazione("nome");
            federazione.ImportaSoci("C:\\Users\\Leonardo.Lessi\\Documents\\Federazione-Sportiva\\ConsoleFederazione\\bin\\Debug\\net8.0\\XML");

            foreach(Associato a in federazione.Associati.Keys)
            {
                Console.WriteLine(a);
                foreach(string s in a.AssociazioniDiAppartenenza)
                {
                    Console.WriteLine(s);
                }
            }

            federazione.EsportaSoci();
        }
    }
}

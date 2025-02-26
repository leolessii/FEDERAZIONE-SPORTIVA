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

            foreach(Associato a in federazione.Associati.Keys)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("esportazione completata");

            Console.WriteLine("visualizzare l'elenco dei soci maggiorenni");
            var elenco = federazione.Statistiche.ElencoSociMaggiorenni();
            foreach(Associato a in elenco)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("visualizzare l'elenco dei soci minorenni");
            elenco = federazione.Statistiche.ElencoSociMinorenni();
            foreach (Associato a in elenco)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("visualizzare il numero totale di soci");
            var numero = federazione.Statistiche.NumeroTotaleSoci();
            Console.WriteLine(numero.ToString());
            
            Console.WriteLine("visualizzare il numero totale di associazioni");
            numero = federazione.Statistiche.NumeroTotaleAssociazioni();
            Console.WriteLine(numero.ToString());

            Console.WriteLine("visualizzare quanti soci sono tesserati per più di una associazione");
            numero = federazione.Statistiche.ElencoAssociatiConPiuAssociazioni();
            Console.WriteLine(numero.ToString());

            Console.WriteLine("visualizzare l'elenco dei soci con rinnovo in scadenza (scaduto o che scade entro 1 mese)");
            elenco = federazione.Statistiche.ElencoAssociatiConRinnovoInScadenza();
            foreach (Associato a in elenco)
            {
                Console.WriteLine(a);
            }
        }
    }
}

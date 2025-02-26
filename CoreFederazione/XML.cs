using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoreFederazione
{
    public class XML
    {
        public XML() { }

        private HashSet<Associato> LeggiSociDaFileSingolo(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            
            XmlNodeList associazione = doc.GetElementsByTagName("soci");
            HashSet<Associato> associati = new HashSet<Associato>();
            foreach(XmlNode socio in associazione)
            {
                string nome = socio["nome"]!.Value!;
                string cognome = socio["cognome"]!.Value!;
                string dataDiNascita = socio["data_nascita"]!.Value!;
                string dataDiRinnovo = socio["data_rinnovo"]!.Value!;
                
                Associato associato = new Associato(nome, cognome, DateOnly.FromDateTime(Convert.ToDateTime(dataDiNascita)), DateOnly.FromDateTime(Convert.ToDateTime(dataDiRinnovo)));
                associato.AssociazioniDiAppartenenza.Add(associazione.InnerText);
                associati.Add(associato);
            }

            return associati;
        }

        public Dictionary<Associato, List<string>> LeggiSoci(string path)
        {
            Dictionary<Associato, List<string>> associati = new Dictionary<Associato, List<string>>();

            foreach(string filePath in Directory.GetFiles(path))
            {
                HashSet<Associato> Soci = LeggiSociDaFileSingolo(filePath);
                {
                    foreach(Associato socio in Soci)
                    {
                        Associato? socioPreso;
                        if(Soci.TryGetValue(socio, out socioPreso))  //cerca se socio è gia esistente e se lo è lo inserisce in socioPreso
                        {
                            socioPreso.AssociazioniDiAppartenenza.Add(socio.AssociazioniDiAppartenenza[0]);
                            associati.Add(socioPreso, socioPreso.AssociazioniDiAppartenenza);
                        }
                        else
                        {
                            associati.Add(socio, socio.AssociazioniDiAppartenenza);
                        }
                    }
                }
            }

            return associati;
        }

        public void ScriviAssociati(Dictionary<Associato, List<string>> associati)
        {
            string path = "Associati.xml";

            XmlDocument doc = new XmlDocument();
            XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(decl);

            XmlElement root = doc.CreateElement("soci");
            root.SetAttribute("soci", string.Empty);
            doc.AppendChild(root);

            foreach (Associato socio in associati.Keys)
            {
                XmlElement Socio = doc.CreateElement("socio");
                Socio.SetAttribute("socio", string.Empty);
                root.AppendChild(Socio);

                XmlElement Associazioni = doc.CreateElement("associazioni");
                Associazioni.SetAttribute("associazioni", string.Empty);
                Socio.AppendChild(Associazioni);

                foreach (string associazione in socio.AssociazioniDiAppartenenza)
                {
                    XmlElement Associazione = doc.CreateElement("associazione");
                    Associazione.InnerText = associazione;
                    Associazioni.AppendChild(Associazione);
                }

                XmlElement Nome = doc.CreateElement("nome");
                Nome.InnerText = socio.Nome;
                Socio.AppendChild(Nome);

                XmlElement Cognome = doc.CreateElement("cognome");
                Cognome.InnerText = socio.Cognome;
                Socio.AppendChild(Cognome);

                XmlElement DataDiNascita = doc.CreateElement("data_nascita");
                DataDiNascita.InnerText = socio.DataDiNascita.ToString();
                Socio.AppendChild(DataDiNascita);

                XmlElement DataDiRinnovo = doc.CreateElement("data_rinnovo");
                DataDiRinnovo.InnerText = socio.DataDiRinnovo.ToString();
                Socio.AppendChild(DataDiRinnovo);
            }

            doc.Save("Associati.xml");
        }
    }
}

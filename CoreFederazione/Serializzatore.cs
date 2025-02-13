using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoreFederazione
{
    public class Serializzatore
    {
        public Serializzatore() { }

        public HashSet<Associato> LeggiSociDaFileSingolo(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(path);
            XmlNode associazione = doc.FirstChild;
            HashSet<Associato> associati = new HashSet<Associato>();
            foreach(XmlNode node in associazione.ChildNodes)
            {
                string nome = node["nome"]!.Value!;
                string cognome = node["cognome"]!.Value!;
                string dataDiNascita = node["data_nascita"]!.Value!;
                string dataDiRinnovo = node["data_rinnovo"]!.Value!;

                Associato associato = new Associato(nome, cognome, DateOnly.FromDateTime(Convert.ToDateTime(dataDiNascita)), DateOnly.FromDateTime(Convert.ToDateTime(dataDiRinnovo)));
                associato.AssociazioniDiAppartenenza.Add(associazione.InnerText);
                associati.Add(associato);
            }

            return associati;
        }

        public void LeggiSoci(string path)
        {
            Federazione federazione = new Federazione();

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
                            federazione.Associati.Add(socioPreso);
                        }
                        else
                        {
                            federazione.Associati.Add(socio);
                        }
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Lab6
{
    /// <summary>   (Serializable) Lista Zespolow. </summary>
    ///
    /// <remarks>   284099, 2016-12-19. </remarks>

    [Serializable]
    [XmlRoot("lista zespolow")]
    public class ListaZespolow : Zespol
    {
        /// <summary>   Pobiera lub ustawia Liste Zespolow. </summary>
        ///
        /// <value> Lista Zespolow. </value>

        public List<Zespol> listaZespolow { get; set; }

        /// <summary>   Kontruktor domyslny. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>

        public ListaZespolow()
        {
            this.listaZespolow = new List<Zespol>();
        }

        /// <summary>   Metoda wypisujaca Liste Zespolow. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <returns>   String opisujacy obecny obiekt. </returns>

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            foreach (Zespol element in this.listaZespolow)
            {
                sb.AppendLine("Zespol: " + element.nazwa);
                sb.AppendLine("Kierownik: " + element.kierownik.ToString());
                for (int i = 0; i < element.liczbaCzlonkow; i++)
                {
                    if (element.czlonkowie.ElementAt(i) != null)
                    {
                        sb.AppendLine(element.czlonkowie.ElementAt(i).ToString());
                    }
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>   Dodaje Zespol do listy. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="z">    Zespol do dodania. </param>

        public void dodajZespol(Zespol z)
        {
            listaZespolow.Add(z);
        }

        /// <summary>   Usuwa Zespol z listy. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="z">    Zespol do usuniecia. </param>

        public void usunZespol(Zespol z)
        {
            listaZespolow.Remove(z);
        }

        /// <summary>   Zapisuje Liste Zespolow binarnie. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="nPliku">   Nazwa pliku. </param>

        public void ListaZapiszBIN(string nPliku)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(nPliku, FileMode.Create);
            bf.Serialize(fs, this);
            fs.Close();
        }

        /// <summary>   Odczytuje Liste Zespolow z pliku binarnego. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="nPliku">   Nazwa pliku. </param>
        ///
        /// <returns>   Obiekt. </returns>

        public Object ListaOdczytajBIN(string nPliku)
        {
            Zespol zespol = new Zespol();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(nPliku, FileMode.Open, FileAccess.Read);
            zespol = bf.Deserialize(fs) as Zespol;
            fs.Close();
            return zespol;
        }

        /// <summary>   Zapisuje Liste Zespolow do pliku XML. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="nPliku">   Nazwa pliku. </param>

        public void ListaZapiszXML(string nPliku)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ListaZespolow));
            StreamWriter sw = new StreamWriter(nPliku);
            serializer.Serialize(sw, this);
            sw.Close();
        }

        /// <summary>   Odczytuje Liste Zespolow z pliku XML. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="nPliku">   Nazwa pliku. </param>
        ///
        /// <returns>   Obiekt. </returns>

        public Object ListaOdczytajXML(string nPliku)
        {
                Zespol zespol = new Zespol();
                TextReader tr = new StreamReader(nPliku);
                XmlSerializer serializer = new XmlSerializer(typeof(ListaZespolow));
                zespol = (Zespol)serializer.Deserialize(tr);
                tr.Close();
                return zespol;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;

namespace Lab6
{
    /// <summary>   (Serializable) Zespol. </summary>
    ///
    /// <remarks>   284099, 2016-12-19. </remarks>

    [Serializable]
    [XmlRoot("Zespol")]
    public class Zespol:ICloneable,IZapisywalna,IEquatable<Zespol>
    {
        /// <summary>   Pobiera lub ustawia identyfikator Zespolu. </summary>
        ///
        /// <value> Identyfikator Zespolu. </value>

        public int ZespolId { get; set; }

        /// <summary>   Pobiera lub ustawia Kierownika. </summary>
        ///
        /// <value> Kierownik. </value>

        public virtual KierownikZespolu kierownik { get; set; }

        /// <summary>   Pobiera lub ustawia Czlonkow. </summary>
        ///
        /// <value> Czlonkowie. </value>

        public virtual List<CzlonekZespolu> czlonkowie { get; set; }

        /// <summary>   Pobiera lub ustawia Nazwe. </summary>
        ///
        /// <value> Nazwa. </value>

        public string nazwa { get; set; }

        /// <summary>   Pobiera lub ustawia Liczbe Czlonkow. </summary>
        ///
        /// <value> Liczba Czlonkow. </value>

        public int liczbaCzlonkow { get; set; }
        /// <summary>   Nazwa pliku. </summary>
        [NonSerialized]
        [XmlIgnore]
        public string plik = "zespol.txt";

        /// <summary>   Konstruktor domyslny. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>

        public Zespol()
        {
            this.liczbaCzlonkow = 0;
            this.kierownik = null;
            this.nazwa = null;
            this.czlonkowie = new List<CzlonekZespolu>();
        }

        /// <summary>   Kontruktor parametryczy. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="n">    Nazwa zespolu. </param>
        /// <param name="k">    KierownikZespolu. </param>

        public Zespol(string n, KierownikZespolu k)
            :this()
        {
            this.nazwa = n;
            this.kierownik = k;
        }

        /// <summary>   Dodaje czlonka do Zespolu. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="c">    CzlonekZespolu. </param>

        public void dodajCzlonka(CzlonekZespolu c)
        {
            czlonkowie.Add(c);
            liczbaCzlonkow++;
        }

        /// <summary>   Tworzy nowa referencje do obecnego obiektu. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <returns>   Nowy obiekt, ktory jest kopia obecnego. </returns>

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>   Sortuje Liste Czlonkow. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>

        public void sortuj()
        {
            czlonkowie.Sort();
        }

        /// <summary>   Zwraca stringa, ktory reprezentuje obecny obiekt. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <returns>   String, reprezentujacy obecny obiekt. </returns>

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("Zespol: " + this.nazwa);
            sb.AppendLine("Kierownik: " + this.kierownik.ToString());
            for(int i = 0; i<this.liczbaCzlonkow; i++)
            {
                if (this.czlonkowie.ElementAt(i) != null)
                {
                    sb.AppendLine(this.czlonkowie.ElementAt(i).ToString());
                }
            }
            return sb.ToString();
        }

        /// <summary>   Kopiuje zespol. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <returns>   Zespol. </returns>

        public Zespol Kopiuj()
        {
            Zespol Kopia = (Zespol)this.Clone();
            Kopia.czlonkowie = new List<CzlonekZespolu>(this.czlonkowie);
            return Kopia;
        }

        /// <summary>   Zapisuje Zespol do pliku binarnego. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="nPliku">   Nazwa pliku. </param>

        public void zapiszBIN(string nPliku)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(nPliku, FileMode.Create);
            bf.Serialize(fs, this);
            fs.Close();
        }

        /// <summary>   Odczytuje Zespol z pliku binarnego. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="nPliku">   Nazwa pliku. </param>
        ///
        /// <returns>   Obiekt. </returns>

        public Object OdczytajBIN(string nPliku)
        {
            Zespol zespol = new Zespol();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(nPliku, FileMode.Open, FileAccess.Read);
            zespol = bf.Deserialize(fs) as Zespol;
            fs.Close();
            return zespol;
        }

        /// <summary>   Zapisuje Zespol do pliku XML. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="nPliku">   Nazwa pliku. </param>

        public void ZapiszXML(string nPliku)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Zespol));
                StreamWriter sw = new StreamWriter(nPliku);
                serializer.Serialize(sw, this);
                sw.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>   Odczytuje Zespol z pliku XML. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="nPliku">   Nazwa pliku. </param>
        ///
        /// <returns>   Obiekt. </returns>

        public Object OdczytajXML(string nPliku)
        {
            Zespol zespol = new Zespol();
            TextReader tr = new StreamReader(nPliku);
            XmlSerializer serializer = new XmlSerializer(typeof(Zespol));
            zespol = (Zespol)serializer.Deserialize(tr);
            tr.Close();
            return zespol;
        }

        /// <summary>
        ///     Sprawdza, czy obiekt obecny jest identyczny z innym obiektem.
        /// </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="zespolinny">   Zespol do porownania z obecnym Zespolem. </param>
        ///
        /// <returns>
        ///     True jeżeli obiekt jest identyczny z <paramref name="zespolinny" />
        ///      parametrem; w innym wypadku - False.
        /// </returns>

        public bool Equals(Zespol zespolinny)
        {
            if(this.liczbaCzlonkow == zespolinny.liczbaCzlonkow)
            {
                if (this.kierownik.CompareTo(zespolinny.kierownik) == 0)
                {
                    if (this.nazwa.CompareTo(zespolinny.nazwa) == 0)
                    {
                        bool zgodnosc = true;
                        for (int i = 0; i < this.liczbaCzlonkow; i++)
                        {
                            if (this.czlonkowie.ElementAt<CzlonekZespolu>(i).CompareTo(zespolinny.czlonkowie.ElementAt<CzlonekZespolu>(i)) == 0)
                            {
                                //Console.WriteLine("tak");
                            }
                            else
                            {
                                zgodnosc = false;
                            }
                        }
                        return zgodnosc;
                    }
                    return false;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>   Zapisuje Zespol do bazy. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>

        public void ZapiszDoBazy()
        {
            using (var db = new Lab8_model())
            {
                try
                {
                    db.Zespol.Add(this);
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>   Wypisuje Zespol z bazy. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>

        public void WypiszZBazy()
        {
            using (var db = new Lab8_model())
            {
                foreach (Zespol z in db.Zespol)
                {
                    Console.WriteLine(z.ToString());
                }
            }
        }
    }
}

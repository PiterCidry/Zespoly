using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Lab6
{
    /// <summary>   Osoba. </summary>
    ///
    /// <remarks>   284099, 2016-12-19. </remarks>

    [Serializable]
    public abstract class Osoba
    {
        /// <summary>   imie. </summary>
        private string imie;
        /// <summary>   nazwisko. </summary>
        private string nazwisko;
        /// <summary>   data urodzenia. </summary>
        private DateTime dataUrodzenia;
        /// <summary>   data ur string. </summary>
        private string dataUrString;
        /// <summary>   pesel. </summary>
        private string PESEL;
        /// <summary>   plec. </summary>
        private Plcie plec;

        /// <summary>   Pobiera lub ustawia imie. </summary>
        ///
        /// <value> imie. </value>

        public string Imie
        {
            get
            {
                return this.imie;
            }
            set
            {
                this.imie = value;
            }
        }

        /// <summary>   Pobiera lub ustawia nazwisko. </summary>
        ///
        /// <value> nazwisko. </value>

        public string Nazwisko
        {
            get
            {
                return this.nazwisko;
            }
            set
            {
                this.nazwisko = value;
            }
        }

        /// <summary>   Pobiera lub ustawia date urodzenia. </summary>
        ///
        /// <value> data urodzenia. </value>

        [XmlIgnore]
        public DateTime DataUrodzenia
        {
            get
            {
                return this.dataUrodzenia;
            }
            set
            {
                this.dataUrodzenia = value;
            }
        }

        /// <summary>   Pobiera lub ustawia Date urodzenia z parsowaniem. </summary>
        ///
        /// <value> data ur. </value>

        public string DataUr
        {
            get
            {
                return this.dataUrodzenia.ToString("yyyy/MM/dd");
            }
            set
            {
                try
                {
                    this.dataUrodzenia = DateTime.Parse(value);
                }
                catch
                {
                   Console.WriteLine("zle wprowadzono date urodzenia!");
                }
            }
        }

        /// <summary>   Pobiera lub ustawia pesel. </summary>
        ///
        /// <value> pesel. </value>

        [XmlAttribute]
        public string Pesel
        {
            get
            {
                return this.PESEL;
            }
            set
            {
                this.PESEL = value;
            }
        }

        /// <summary>   Pobiera lub ustawia plec. </summary>
        ///
        /// <value> plec. </value>

        public Plcie Plec
        {
            get
            {
                return this.plec;
            }
            set
            {
                this.plec = value;
            }
        }

        /// <summary>   Metoda ustawiajaca pesel i sprawdzajaca poprawnosc. Musi byc zakomentowana dla ulatwienia
        ///             dzialania i testowania. Metoda sprawdzana i dzialajaca. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <exception cref="WrongPESELException">  Wyjatek wyrzucany jezeli nie jest poprawny nr PESEL. </exception>
        ///
        /// <param name="pesel">    pesel. </param>
        ///
        /// <returns>   string. </returns>

        public string setPESEL(string pesel)
        {
            string pattern = @"^\d{11}$";
            Regex rgx = new Regex(pattern);
            Match sprawdzenie = rgx.Match(pesel);
            if (sprawdzenie.Success)
            {
                string dataurodzenia = dataUrodzenia.ToString("yyyyMMdd");
                dataurodzenia.ToCharArray();
                string[] dataurodzeniatab = new string[6];
                for (int i = 0, j = 2; j < 8; i++, j++)
                {
                    dataurodzeniatab[i] = dataurodzenia[j].ToString();
                }
                pesel.ToCharArray();
                string[] peseltab = new string[11];
                for (int i = 0; i < 11; i++)
                {
                    peseltab[i] = pesel[i].ToString();
                }

                for (int i = 0; i < dataurodzeniatab.Length; i++)
                {
                    if (peseltab[i] == dataurodzeniatab[i])
                    {
                        continue;
                    }
                    else
                    {
                        throw new WrongPESELException("Podany numer PESEL jest niezgodny z data urodzenia!");
                    }
                }

                int[] mnozniki = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                int sum = 0;
                for (int i = 0; i < mnozniki.Length; i++)
                {
                    sum += mnozniki[i] * int.Parse(peseltab[i]);
                }
                int kontrolna = (sum % 10);
                int kontrolna2 = (10 - kontrolna);
                int kontrolna3 = (kontrolna2 % 10);
                if (peseltab[10] != kontrolna3.ToString())
                {
                    throw new WrongPESELException("Podany numer PESEL ma nieprawidlowa sume kontrolna!");
                }

                if((int.Parse(peseltab[9]) % 2) == 0)
                {
                    if (plec.ToString() == "M")
                    {
                        throw new WrongPESELException("Podany numer PESEL nie jest zgodny z plcia!");
                    }
                }
                else if((int.Parse(peseltab[9]) % 2) != 0)
                {
                    if (plec.ToString() == "K")
                    {
                        throw new WrongPESELException("Podany numer PESEL nie jest zgodny z plcia!");
                    }
                }

                return pesel;
            }
            else
            {
                throw new WrongPESELException("Podany numer PESEL ma niewlasciwa dlugosc!");
            }
        }

        /// <summary>   Konstruktor domyslny. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>

        public Osoba()
        {
            imie = null;
            nazwisko = null;
            dataUrodzenia = DateTime.MinValue;
            PESEL = "00000000000";
        }

        /// <summary>   Konstruktor parametryczny. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="imie">     imie. </param>
        /// <param name="nazwisko"> nazwisko. </param>

        public Osoba(string imie, string nazwisko)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
        }

        /// <summary>   Konstruktor parametryczny. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="imie">             imie. </param>
        /// <param name="nazwisko">         nazwisko. </param>
        /// <param name="dataurodzenia">    data urodzenia. </param>
        /// <param name="pesel">            pesel. </param>
        /// <param name="plec">             plec. </param>

        public Osoba(string imie, string nazwisko, string dataurodzenia, string pesel, Plcie plec)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.DataUrodzenia = DateTime.ParseExact(dataurodzenia, "yyyy-MM-dd", CultureInfo.CurrentCulture);
            this.Pesel = pesel;
            this.Plec = plec;
        }

        /// <summary>   Metoda zwracajaca wiek osoby. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <returns>   Integer. </returns>

        public int wiek()
        {
            int y = DateTime.Now.Year - dataUrodzenia.Year;
            int startMonth = dataUrodzenia.Month;
            int endMonth = DateTime.Now.Month;
            if (endMonth < startMonth)
            {
                return y - 1;
            }
            if (endMonth > startMonth)
            {
                return y;
            }
            return (DateTime.Now.Day < dataUrodzenia.Day ? y - 1 : y);
        }

        /// <summary>   Metoda opisujaca osobe jako string. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <returns>   String reprezentujacy obecny obiekt. </returns>

        public override string ToString()
        {
            return ("PESEL " + PESEL + " " + imie + " " + nazwisko);
        }
    }
}
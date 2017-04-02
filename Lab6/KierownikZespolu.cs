using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>   (Serializable) Kierownik Zespolu. </summary>
    ///
    /// <remarks>   284099, 2016-12-19. </remarks>

    [Serializable]
    public class KierownikZespolu : Osoba,ICloneable
    {
        /// <summary>   Pobiera lub ustawia identyfikator Kierownika Zespolu. </summary>
        ///
        /// <value> Identyfikator Kierownika Zespolu. </value>

        public int KierownikZespoluId { get; set; }

        /// <summary>   Konstruktor domyslny. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>

        public KierownikZespolu()
        { 
        }

        /// <summary>   Konstruktor parametryczny. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="imie">             imie </param>
        /// <param name="nazwisko">         nazwisko </param>
        /// <param name="dataurodzenia">    data urodzenia </param>
        /// <param name="pesel">            pesel </param>
        /// <param name="plec">             plec </param>

        public KierownikZespolu(string imie, string nazwisko, string dataurodzenia, string pesel, Plcie plec)
            : base(imie, nazwisko, dataurodzenia, pesel, plec)
        {
        }

        /// <summary>   Tworzy nowy obiekt, ktory jest kopia obecnej instancji. </summary>
        ///
        /// <remarks>   284099, 2016-12-19.  </remarks>
        ///
        /// <returns>   Nowy obiekt, ktory jest kopia obecnego. </returns>

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        ///     Porównuje obecny obiekt do innego obiektu aby ustalic ich porzadek.
        /// </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="obj">  Obiekt do porownania. </param>
        ///
        /// <returns>
        ///     Ujemna wartosc jezeli mniejszy, zero gry rowne, wieksza od 0 gdy wiekszy.
        /// </returns>

        public int CompareTo(object obj)
        {
            KierownikZespolu c = obj as KierownikZespolu;
            if (c != null)
            {
                if (this.Nazwisko.CompareTo(c.Nazwisko) != 0)
                {
                    return this.Nazwisko.CompareTo(c.Nazwisko);
                }
                else
                {
                    return this.Imie.CompareTo(c.Imie);
                }
            }
            else
            {
                return 0;
            }
        }
    }
}

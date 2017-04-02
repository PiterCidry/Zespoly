using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>   (Serializable) Klasa CzlonekZespolu </summary>
    ///
    /// <remarks>   284099, 2016-12-19 </remarks>

    [Serializable]
    public class CzlonekZespolu:Osoba,IComparable,ICloneable
    {
        /// <summary>   Pobiera lub ustawia identyfikator Czlonka Zespolu </summary>
        ///
        /// <value> Identyfikator Czlonka Zespolu </value>

        public int CzlonekZespoluId { get; set; }

        /// <summary>   Pobiera lub ustawia identyfikator Zespolu </summary>
        ///
        /// <value> Identyfikator Zespolu </value>

        public int ZespolId { get; set; }

        /// <summary>   Pobiera lub ustawia Zespol </summary>
        ///
        /// <value> Zespol </value>

        public virtual Zespol Zespol { get; set; }

        /// <summary>   Konstruktor domyslny </summary>
        ///
        /// <remarks>   284099, 2016-12-19 </remarks>

        public CzlonekZespolu()
        {
        }

        /// <summary>   Konstruktor parametryczny </summary>
        ///
        /// <remarks>   284099, 2016-12-19 </remarks>
        ///
        /// <param name="imie">             imie </param>
        /// <param name="nazwisko">         nazwisko </param>
        /// <param name="dataurodzenia">    data urodzenia </param>
        /// <param name="pesel">            pesel </param>
        /// <param name="plec">             plec </param>

        public CzlonekZespolu(string imie, string nazwisko, string dataurodzenia, string pesel,  Plcie plec)
            : base(imie, nazwisko, dataurodzenia, pesel, plec)
        {
        }

        /// <summary>   Tworzy nowy obiekt, ktory jest kopia obecnej instancji. </summary>
        ///
        /// <remarks>   284099, 2016-12-19 </remarks>
        ///
        /// <returns>   Nowy obiekt, ktory jest kopia obecnego. </returns>

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        ///     Porownuje obecna instancje obiektu z inna instancja obiektu tego samego typu i zwraca
        ///     integer ktory pokazuje czy obecna instancja poprzedza, nastepuje albo wystepuje na
        ///     tej samej pozycji w porzadku sortujacym jak inny obiekt.
        /// </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="obj">  Obiekt, ktory chcemy porownac </param>
        ///
        /// <returns>
        ///     Wartosc ktora pokazuje relatywny porzadek obiektow porownywanych. Wartosc zwracana ma nastepujace
        ///     znaczenia: Mniejsza od zera znaczy, ze obecna instancja wyprzedza
        ///     <paramref name="obj" />
        ///      w porzadku sortujacym. Zero znaczy, ze jest na tej samej pozycji co
        ///      <paramref name="obj" />
        ///     . Wiecej niz zero oznacz, ze obecna instancja nestpuje po <paramref name="obj" />
        ///      w porzadku sortujacym.
        /// </returns>

        public int CompareTo(object obj)
        {
            CzlonekZespolu c = obj as CzlonekZespolu;
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

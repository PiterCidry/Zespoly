using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>   Interface for zapisywalna </summary>
    ///
    /// <remarks>   284099, 2016-12-19 </remarks>

    interface IZapisywalna
    {
        /// <summary>   Zapisz binarnie </summary>
        ///
        /// <param name="nPliku">   Nazwa pliku </param>

        void zapiszBIN(string nPliku);

        /// <summary>   Odczytaj binarnie </summary>
        ///
        /// <param name="nPliku">   Nazwa pliku </param>
        ///
        /// <returns>   Obiekt </returns>

        Object OdczytajBIN(string nPliku);

        /// <summary>   Zapisz XML </summary>
        ///
        /// <param name="nPliku">   Nazwa pliku </param>

        void ZapiszXML(string nPliku);

        /// <summary>   Odczytaj XML </summary>
        ///
        /// <param name="nPliku">   Nazwa pliku </param>
        ///
        /// <returns>  Obiekt </returns>

        Object OdczytajXML(string nPliku);
    }
}

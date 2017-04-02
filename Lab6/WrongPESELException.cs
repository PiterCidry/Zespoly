using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab6
{
    /// <summary>   (Serializable) Wyjatek dla nieprawidlowych nr pesel. </summary>
    ///
    /// <remarks>   284099, 2016-12-19. </remarks>

    [Serializable]
    public class WrongPESELException : System.ApplicationException
    {
        /// <summary>   Konstruktor domyslny. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>

        public WrongPESELException() : base() { }

        /// <summary>   Konstruktor parametryczny. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>
        ///
        /// <param name="message">  Wiadomosc do wyswietlenia. </param>

        public WrongPESELException(string message) : base(message) { }
    }
}

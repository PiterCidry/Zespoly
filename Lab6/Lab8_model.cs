namespace Lab6
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>   Model danych. </summary>
    ///
    /// <remarks>   284099, 2016-12-19. </remarks>

    public class Lab8_model : DbContext
    {
        /// <summary>   Konstruktor domyslny. </summary>
        ///
        /// <remarks>   284099, 2016-12-19. </remarks>

        public Lab8_model()
            : base("name=Lab8_model")
        {

        }

        /// <summary>   Pobiera lub ustawia Zespol. </summary>
        ///
        /// <value> Zespol. </value>

        public virtual DbSet<Zespol> Zespol { get; set; }

        /// <summary>   Pobiera lub ustawia Czlonkow Zespolu. </summary>
        ///
        /// <value> Czlonkowie Zespolu. </value>

        public virtual DbSet<CzlonekZespolu> CzlonkowieZespolu { get; set; }

        /// <summary>   Pobiera lub ustawia Kierownika Zespolu. </summary>
        ///
        /// <value> Kierownik Zespolu. </value>

        public virtual DbSet<KierownikZespolu> KierownikZespolu { get; set; }
    }
}

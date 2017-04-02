using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Lab6
{
    public enum Plcie
    {
        [XmlEnum]K,
        [XmlEnum]M,
    };
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test: \n");
            KierownikZespolu mojKierownik = new KierownikZespolu("Marek", "Kowalski", "1992-08-16", "92081612255", Plcie.M);
            Zespol mojZespol = new Zespol("GrupaIT", mojKierownik);
            CzlonekZespolu c1 = new CzlonekZespolu("Beata", "Nowak", "1992-10-22", "92102201347", Plcie.K);
            CzlonekZespolu c2 = new CzlonekZespolu("Adam", "Nowak", "1992-10-22", "92101551347", Plcie.M);
            CzlonekZespolu c3 = new CzlonekZespolu("Witold", "Adamski", "1992-10-22", "92101513347", Plcie.M);
            mojZespol.dodajCzlonka(c1);
            mojZespol.dodajCzlonka(c2);
            mojZespol.dodajCzlonka(c3);
            Console.WriteLine(mojZespol.ToString());
            
            mojZespol.zapiszBIN("ZespolBIN.bin");
            Zespol mojZespol2 = new Zespol();
            mojZespol2 = (Zespol)mojZespol2.OdczytajBIN("ZespolBIN.bin");
            Console.WriteLine("Zespol po odczytaniu z pliku binarnego: \n");
            Console.WriteLine(mojZespol2.ToString());

            mojZespol.ZapiszXML("zespol.xml");
            Zespol mojZespol4 = new Zespol();
            mojZespol4 = (Zespol)mojZespol4.OdczytajXML("zespol.xml");
            Console.WriteLine("Zespol po odczytaniu z pliku xml: \n");
            Console.WriteLine(mojZespol4.ToString());

            mojZespol.sortuj();
            Console.WriteLine("Zespol po sortowaniu: \n");
            Console.WriteLine(mojZespol.ToString());
            
            Zespol mojZespol3 = mojZespol.Kopiuj();
            CzlonekZespolu c4 = new CzlonekZespolu("Adam", "Kot", "1992-10-22", "91022013347", Plcie.M);
            mojZespol3.dodajCzlonka(c4);
            mojZespol3.nazwa = "Grupa 2";
            Console.WriteLine("Zespol po kopiowaniu i dodaniu czlonka: \n");
            Console.WriteLine(mojZespol3.ToString());

            ListaZespolow lista = new ListaZespolow();
            lista.dodajZespol(mojZespol);
            lista.dodajZespol(mojZespol3);
            Console.WriteLine("Lista Zespolow:\n");
            Console.WriteLine(lista.ToString());
            
            lista.ListaZapiszXML("lista.xml");
            lista.ListaZapiszBIN("lista.bin");
            ListaZespolow lista2 = new ListaZespolow();
            lista2 = (ListaZespolow)lista2.ListaOdczytajBIN("lista.bin");
            Console.WriteLine("Lista zespolow po odczytaniu z pliku bin: \n\n" + lista2.ToString());
            ListaZespolow lista3 = new ListaZespolow();
            lista3 = (ListaZespolow)lista3.ListaOdczytajXML("lista.xml");
            Console.WriteLine("Lista zespolow po odczytaniu z plikku xml: \n\n" + lista3.ToString());

            //mojZespol3.ZapiszDoBazy();
            //Console.WriteLine("Zespoly po wypisaniu z bazy:\n");
            //mojZespol.WypiszZBazy();
            Console.ReadKey();
        }
    }
}

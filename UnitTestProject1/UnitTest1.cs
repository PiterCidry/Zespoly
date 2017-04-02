using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab6;
using System.Diagnostics;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestKostruktoraKierownik()
        {
            KierownikZespolu k1 = new KierownikZespolu("Jack", "Richards", "1990-10-20", "90102052154", Plcie.M);
            Assert.AreEqual("Richards", k1.Nazwisko);
        }
        [TestMethod]
        public void TestKonstruktoraZespol()
        {
            string nazwa = "zespoltestowy1";
            Zespol z1 = new Zespol(nazwa, new KierownikZespolu());
            Assert.AreEqual(nazwa, z1.nazwa);
        }
        [TestMethod]
        public void TestLicznika()
        {
            Zespol z2 = new Zespol("nazwa", new KierownikZespolu());
            z2.dodajCzlonka(new CzlonekZespolu());
            Assert.IsTrue(z2.liczbaCzlonkow == 1);
        }
        [TestMethod]
        public void TestCompareTo()
        {
            CzlonekZespolu cz1 = new CzlonekZespolu("Jan", "Nowak", "1990-01-01", "90010123456", Plcie.M);
            CzlonekZespolu cz2 = new CzlonekZespolu("Adam", "Nowak", "1992-05-12", "92051212345", Plcie.M);
            int expected = 1;
            int actual = cz1.CompareTo(cz2);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestDateTime()
        {   
            CzlonekZespolu cz1 = new CzlonekZespolu("Jan", "Kowalski", "aaaa", "00000000000", Plcie.M);
        }
        [TestMethod]
        [ExpectedException(typeof(WrongPESELException))] //Aby test zadzialal potrzeba zmienic konstruktor w klasie osoba na metode sprawdzajaca PESEL zamiast wpisywania peselu z marszu. Ale jezeli sie to zrobi to wszystkie osoby nie maja poprawnych peseli bo nie zwracalismy na to wczesniej uwagi na zajeciach.
        public void TestPesel()
        {
            CzlonekZespolu cz1 = new CzlonekZespolu("Piotr", "Gretszel", "1996-06-30", "1525", Plcie.M);
        }
        [TestMethod]
        public void TestKopiowaniaZespolow()
        {
            Zespol z1 = new Zespol("Testowy", new KierownikZespolu("Jan", "Nowak", "1996-06-30", "12345678912", Plcie.M));
            z1.dodajCzlonka(new CzlonekZespolu("Barbara", "Kowalska", "1996-06-30", "12345678901", Plcie.K));
            Zespol z2 = z1.Kopiuj();
            Assert.ReferenceEquals(z1, z2);
            Assert.IsTrue(z1.Equals(z2));

            Zespol z3 = (Zespol)z1.Clone();
            Assert.ReferenceEquals(z1, z3);
            Assert.IsTrue(z1.Equals(z3));
        }
    }
}

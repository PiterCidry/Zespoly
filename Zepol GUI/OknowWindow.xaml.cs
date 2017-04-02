using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lab6;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Zepol_GUI
{
    /// <summary>
    /// Interaction logic for OknowWindow.xaml
    /// </summary>
    public partial class OknowWindow : Window
    {
        Lab6.Osoba osoba;
        public OknowWindow()
        {
            InitializeComponent();
        }
        public OknowWindow(Osoba osoba):this()
        {
            InitializeComponent();
            this.osoba = osoba;
            if (osoba.Pesel != "00000000000")
            {
                textBox_Pesel.Text = osoba.Pesel;
                textBox_Imie.Text = osoba.Imie;
                textBox_Nazwisko.Text = osoba.Nazwisko;
                textBox_DataUr.Text = osoba.DataUr;
            }
        }
        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if ((textBox_Pesel.Text == "") || (textBox_Imie.Text == "") || (textBox_Nazwisko.Text == ""))
            {
                MessageBox.Show("Złe dane!");
                return;
            }
            this.osoba.Pesel = textBox_Pesel.Text;
            this.osoba.Imie = textBox_Imie.Text;
            this.osoba.Nazwisko = textBox_Nazwisko.Text;
            string pattern = @"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$";
            Regex rgx = new Regex(pattern);
            Match sprawdzenie = rgx.Match(textBox_DataUr.Text);
            if (sprawdzenie.Success)
            {
                this.osoba.DataUr = textBox_DataUr.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Źle wpisano datę urodzenia!\nPoprawny format: yyyy-MM-dd");
            }
            
        }
        private void textBox_Imie_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void textBox_DataUr_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void textBox_Nazwisko_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void textBox_Pesel_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab6;
using System.Collections.ObjectModel;

namespace Zepol_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Zespol zespol = new Zespol();
        ObservableCollection<CzlonekZespolu> lista;
        public MainWindow()
        {
            InitializeComponent();
            string path = @"C:\Users\kasia\Documents\Studia\Semestr 3\Programowanie Obiektowe\Zadania\Lab6\Lab6\bin\Debug\zespol.xml";
            zespol = (Zespol)zespol.OdczytajXML(path);
            lista = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
            listBox_czlonkowie.ItemsSource = lista;
            textBox_nazwa.Text = zespol.nazwa;
            textBox_kierownik.Text = zespol.kierownik.ToString();
        }
        private void button_dodaj_Click(object sender, RoutedEventArgs e)
        {
            CzlonekZespolu cz = new CzlonekZespolu();
            OknowWindow okno = new OknowWindow(cz);
            okno.ShowDialog();
            if (cz.Imie == null && cz.Nazwisko == null && cz.Pesel == "00000000000" && cz.DataUrodzenia == DateTime.MinValue)
            {
                MessageBox.Show("Nic nie dodano!");
            }
            else
            {
                zespol.dodajCzlonka(cz);
                lista.Add(cz);
            }
        }
        private void button_zmien_Click(object sender, RoutedEventArgs e)
        {
            OknowWindow okno = new OknowWindow(zespol.kierownik);
            okno.ShowDialog();
            textBox_kierownik.Text = zespol.kierownik.ToString();
        }
        private void button_usun_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = listBox_czlonkowie.SelectedIndex;
            try
            {
                lista.RemoveAt(zaznaczony);
                zespol.czlonkowie.RemoveAt(zaznaczony);
                zespol.liczbaCzlonkow--;
            }
            catch(System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nic nie zaznaczono!");
            }
        }
        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if(result == true)
            {
                string filename = dlg.FileName;
                zespol = (Zespol)zespol.OdczytajXML(filename);
                lista = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
                listBox_czlonkowie.ItemsSource = lista;
                textBox_kierownik.Text = zespol.kierownik.ToString();
            }
        }
        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                zespol.nazwa = textBox_nazwa.Text;
                zespol.ZapiszXML(filename);    
            }
        }
        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\kasia\Documents\Studia\Semestr 3\Programowanie Obiektowe\Zadania\Lab6\Lab6\bin\Debug\zespol.xml";
            Zespol zespol2 = new Zespol();
            zespol2 = (Zespol)zespol2.OdczytajXML(path);
            if (zespol.Equals(zespol2))
            {
                Environment.Exit(0);
            }
            else
            {
                if(MessageBox.Show("Zapisac do pliku XML?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    Nullable<bool> result = dlg.ShowDialog();
                    if (result == true)
                    {
                        string filename = dlg.FileName;
                        zespol.nazwa = textBox_nazwa.Text;
                        zespol.ZapiszXML(filename);
                    }
                }
                Environment.Exit(0);
            }
        }
        private void button_zmien2_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = listBox_czlonkowie.SelectedIndex;
            try
            {
                OknowWindow okno = new OknowWindow(lista.ElementAt<CzlonekZespolu>(zaznaczony));
                okno.ShowDialog();
                lista = new ObservableCollection<CzlonekZespolu>(zespol.czlonkowie);
                listBox_czlonkowie.ItemsSource = lista;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nic nie zaznaczono!");
            }
            
        }
        private void textBox_kierownik_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void listBox_czlonkowie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

using Projekat_B_Dnevnik_ishrane.models;
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

namespace Projekat_B_Dnevnik_ishrane.views
{
  /// <summary>
  /// Interaction logic for ViewUserWindow.xaml
  /// </summary>
  public partial class ViewUserWindow : Window
  {
    private Window previousWindow;
    private string name;
    private string surname;
    private int yearOfBirth;
    private dbModel dnevnikIshraneEntities = new dbModel();
    public ViewUserWindow(string name,string surname,int yearOfBirth,Window previousWindow)
    {
      this.name = name;
      this.surname = surname;
      this.yearOfBirth = yearOfBirth;
      this.previousWindow = previousWindow;
      Properties.Settings.Default.ColorMode = MainWindow.theme;
      this.Resources.MergedDictionaries.Add(MainWindow.resourceDictionary);
      InitializeComponent();
      initializeFields();
    }
    private void initializeFields()
    {
      korisnik k = dnevnikIshraneEntities.korisniks.Where(elem => elem.Ime.Equals(name) && elem.Prezime.Equals(surname) && elem.Godiste.Equals(yearOfBirth)).FirstOrDefault();
      nameTextBox.Text = k.Ime;
      surnameTextBox.Text = k.Prezime;
      yearTextBox.Text = k.Godiste.ToString();
      usernameTextBox.Text = k.KorisnickoIme;
      passwordBox.Password = k.Lozinka;
    }

    private void goBack(object sender, MouseButtonEventArgs e)
    {
      this.Hide();
      previousWindow.Show();
    }
  }
}

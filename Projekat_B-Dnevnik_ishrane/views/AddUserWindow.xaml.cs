using Dnevnik_ishrane.exceptions;
using MySql.Data.MySqlClient;
using Projekat_B_Dnevnik_ishrane.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
  /// Interaction logic for AddUserWindow.xaml
  /// </summary>
  public partial class AddUserWindow : Window
  {
    private int coachId;
    private dbModel dnevnikIshraneEntities = new dbModel();
    private string action;
    private dynamic ime;
    private dynamic prezime;
    private dynamic godiste;
    private UsersWindow previousWindow;

    public AddUserWindow(int coachId, string action, UsersWindow previousWindow)
    {
      this.coachId = coachId;
      this.previousWindow = previousWindow;
      this.action = action;
      Properties.Settings.Default.ColorMode = MainWindow.theme;
      this.Resources.MergedDictionaries.Add(MainWindow.resourceDictionary);
      InitializeComponent();
    }

    public AddUserWindow(int coachId, string action, dynamic ime, dynamic prezime, dynamic godiste, UsersWindow usersWindow)
    {
      Properties.Settings.Default.ColorMode = MainWindow.theme;
      this.Resources.MergedDictionaries.Add(MainWindow.resourceDictionary);
      InitializeComponent();
      this.action = action;
      this.ime = ime;
      this.prezime = prezime;
      this.godiste = godiste;
      this.previousWindow = usersWindow;
      NameTextBox.Text = ime;
      SurnameTextBox.Text = prezime;
      YearOfBirthTextBox.Text = godiste.ToString();
    }

    private void CreateButtonClick(object sender, RoutedEventArgs e)
    {
      try
      {
        if (action.Equals("add"))
          addUser();
        else
          updateUser();

      }
      catch (NotAllTextFieldsFilledException ex)
      {
        errorTextBlock.Text = "Popunite sva tekstualna polja i pokušajte ponovo.";
      }

      this.Hide();
      previousWindow.initializeDataGrid();
      previousWindow.Show();

    }

    private void updateUser()
    {
      var texts = new[]
    {
                NameTextBox,
                SurnameTextBox,
                YearOfBirthTextBox,
                UsernameTextBox
            };
      for (int j = 0; j < texts.Length; j++)
      {
        if (String.IsNullOrEmpty(texts[j].Text))
        {
          throw new NotAllTextFieldsFilledException();
        }
      }
      if (PasswordTextBox.Password == "")
      {
        throw new NotAllTextFieldsFilledException();
      }
      if (areCredentialsInUsage(UsernameTextBox.Text, PasswordTextBox.Password))
      {
        errorTextBlock.Text = "Kombinacija korisničkog imena i lozinke je zauzeta.";
        return;
      }
      var korisnik = new korisnik()
      {
        idKORISNIK=findId(ime,prezime,godiste),
        Ime = NameTextBox.Text,
        Prezime = SurnameTextBox.Text,
        Godiste = Convert.ToInt32(YearOfBirthTextBox.Text),
        KorisnickoIme = UsernameTextBox.Text,
        Lozinka = PasswordTextBox.Password.ToString(),
        Tema = "candy"
      };
      MessageBox.Show(korisnik.idKORISNIK.ToString());
      kandidat kandidat = dnevnikIshraneEntities.kandidats.Where(elem => elem.KORISNIK_idKORISNIK == korisnik.idKORISNIK).FirstOrDefault();
      dnevnikIshraneEntities.kandidats.Remove(kandidat);
      int id = findId(ime, prezime, godiste);
      var user = dnevnikIshraneEntities.korisniks.Single(k => k.idKORISNIK == id);
      dnevnikIshraneEntities.korisniks.Remove(user);
      dnevnikIshraneEntities.SaveChanges();
      dnevnikIshraneEntities.korisniks.Add(korisnik);
      MessageBox.Show(korisnik.idKORISNIK.ToString());
      var new_candidate = new kandidat()
      {
        KORISNIK_idKORISNIK = korisnik.idKORISNIK,
        TRENER_KORISNIK_idKORISNIK = coachId
      };
      dnevnikIshraneEntities.kandidats.Add(new_candidate);
      dnevnikIshraneEntities.SaveChanges();
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
    private void addUser()
    {
      var texts = new[]
     {
                NameTextBox,
                SurnameTextBox,
                YearOfBirthTextBox,
                UsernameTextBox
            };
      for (int j = 0; j < texts.Length; j++)
      {
        if (String.IsNullOrEmpty(texts[j].Text))
        {
          throw new NotAllTextFieldsFilledException();
        }
      }
      if (PasswordTextBox.Password == "")
      {
        throw new NotAllTextFieldsFilledException();
      }
      if (areCredentialsInUsage(UsernameTextBox.Text, PasswordTextBox.Password))
      {
        errorTextBlock.Text = "Kombinacija korisničkog imena i lozinke je zauzeta.";
        return;
      }
    
      var korisnik = new korisnik()
      { 
        Ime = NameTextBox.Text,
        Prezime = SurnameTextBox.Text,
        Godiste = Convert.ToInt32(YearOfBirthTextBox.Text),
        KorisnickoIme = UsernameTextBox.Text,
        Lozinka = PasswordTextBox.Password.ToString(),
        Tema = "candy"
      };
      dnevnikIshraneEntities.korisniks.Add(korisnik);
      dnevnikIshraneEntities.SaveChanges();
      var kandidat = new kandidat()
      {
        KORISNIK_idKORISNIK = korisnik.idKORISNIK,
        TRENER_KORISNIK_idKORISNIK = coachId
      };
        dnevnikIshraneEntities.kandidats.Add(kandidat);
      dnevnikIshraneEntities.SaveChanges();
    }

    private int findId(string name, string surname, int year)
    {
      korisnik k = dnevnikIshraneEntities.korisniks.Where(elem => elem.Ime.Equals(name) && elem.Prezime.Equals(surname) && elem.Godiste.Equals(year)).FirstOrDefault();
      if (k != null)
        return k.idKORISNIK;
      return 0;
    }

    private int findNextId()
    {
      korisnik k = dnevnikIshraneEntities.korisniks.ToList().LastOrDefault();
      if (k != null)
        return k.idKORISNIK+1;
      return 0;
    }

      private bool areCredentialsInUsage(string text, string password)
      {
        korisnik k = dnevnikIshraneEntities.korisniks.Where(elem => elem.KorisnickoIme.Equals(text) && elem.Lozinka.Equals(password)).FirstOrDefault();
        if (k != null)
        {
          return true;
        }
        return false;
      }
    }
}

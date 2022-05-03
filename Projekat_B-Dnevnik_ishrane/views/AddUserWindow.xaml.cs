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
      this.coachId = coachId;
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
        if(MainWindow.language.Equals("Serbian"))
        errorTextBlock.Text = "Popunite sva tekstualna polja i pokušajte ponovo.";
        else
        errorTextBlock.Text = "Fill in all text fields and try again.";
      }

      

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
        if(MainWindow.language.Equals("Serbian"))
        errorTextBlock.Text = "Kombinacija korisničkog imena i lozinke je zauzeta.";
        else
        errorTextBlock.Text = "The combination of username and password is already in usage.";
        return;
      }
        int id = findId(ime, prezime, godiste);
        korisnik oldUser=dnevnikIshraneEntities.korisniks.Where(elem => elem.idKORISNIK == id).FirstOrDefault();
        oldUser.Aktivan = 0;
        dnevnikIshraneEntities.korisniks.Add(oldUser);
        dnevnikIshraneEntities.Entry(oldUser).State = System.Data.Entity.EntityState.Modified;
        dnevnikIshraneEntities.SaveChanges();
      var korisnik = new korisnik()
      {
        
        Ime = NameTextBox.Text,
        Prezime = SurnameTextBox.Text,
        Godiste = Convert.ToInt32(YearOfBirthTextBox.Text),
        KorisnickoIme = UsernameTextBox.Text,
        Lozinka = PasswordTextBox.Password.ToString(),
        Aktivan = 1
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

      this.Hide();
      previousWindow.initializeDataGrid();
      previousWindow.Show();
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
          if(MainWindow.language.Equals("Serbian"))
          errorTextBlock.Text = "Popunite sva tekstualna polja.";
          else
          errorTextBlock.Text = "Fill in all text fields.";
          return;
        }
      }
      if (PasswordTextBox.Password == "")
      {
        if (MainWindow.language.Equals("Serbian"))
          errorTextBlock.Text = "Popunite sva tekstualna polja.";
        else
          errorTextBlock.Text = "Fill in all text fields.";
        return;
      }
      if (areCredentialsInUsage(UsernameTextBox.Text, PasswordTextBox.Password))
      {
        if (MainWindow.language.Equals("Serbian"))
          errorTextBlock.Text = "Kombinacija korisničkog imena i lozinke je zauzeta.";
        else
          errorTextBlock.Text = "The combination of username and password is already in usage.";
        return;
      }
      try
      {
        var korisnik = new korisnik()
        {
          Ime = NameTextBox.Text,
          Prezime = SurnameTextBox.Text,
          Godiste = Convert.ToInt32(YearOfBirthTextBox.Text),
          KorisnickoIme = UsernameTextBox.Text,
          Lozinka = PasswordTextBox.Password.ToString(),
          Aktivan = 1
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

        this.Hide();
        previousWindow.initializeDataGrid();
        previousWindow.Show();
      }
      catch(Exception ex)
      {
        if (MainWindow.language.Equals("Serbian"))
          errorTextBlock.Text = "U polje godište unesite brojnu vrijednost i pokušajte ponovo.";
        else
          errorTextBlock.Text = "Enter a numeric value in the field year of birth and try again.";
        return;
      }
    }

    private int findId(string name, string surname, int year)
    {
      korisnik k = dnevnikIshraneEntities.korisniks.Where(elem => elem.Ime.Equals(name) && elem.Prezime.Equals(surname) && elem.Godiste.Equals(year) && elem.Aktivan==1).FirstOrDefault();
      if (k != null)
        return k.idKORISNIK;
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

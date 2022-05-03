using Dnevnik_ishrane.exceptions;
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
  /// Interaction logic for WeightWindow.xaml
  /// </summary>
  public partial class WeightWindow : Window
  {
    private int userId;
    private dbModel dnevnikIshraneEntites = new dbModel();
    private Window previousWindow;
    private string action;
    private DateTime selectedDateTime;
    private MeasurementWindow measurementWindow;
    private string v;

    public WeightWindow(int userId,Window previousWindow,string action,DateTime dateTime)
    {
      this.previousWindow = previousWindow;
      this.userId = userId;
      this.action = action;
      this.selectedDateTime = dateTime;
      Properties.Settings.Default.ColorMode = MainWindow.theme;
      this.Resources.MergedDictionaries.Add(MainWindow.resourceDictionary);
      InitializeComponent();
    }

    public WeightWindow(int userId, MeasurementWindow measurementWindow, string action)
    {
      this.userId = userId;
      this.measurementWindow = measurementWindow;
      this.action = action;
      Properties.Settings.Default.ColorMode = MainWindow.theme;
      this.Resources.MergedDictionaries.Add(MainWindow.resourceDictionary);
      InitializeComponent();
    }

    private void saveMeasurement(object sender, RoutedEventArgs e)
    {
      var texts = new[]
      {
        nameTextBox,
        surnameTextBox,
        yearOfBirthTextBox,
        weightTextBox
      };
      for (int j = 0; j < texts.Length; j++)
      {
        if (String.IsNullOrEmpty(texts[j].Text))
        {
          if (MainWindow.language.Equals("Serbian"))
            errorTextBlock.Text = "Popunite sva tekstualna polja.";
          else
            errorTextBlock.Text = "Fill in all text fields.";
          return;
        }
      }
      try {
        var measurement = new mjerenje()
        {
          TRENER_KORISNIK_idKORISNIK = userId,
          KANDIDAT_KORISNIK_idKORISNIK = findCandidateId(nameTextBox.Text, surnameTextBox.Text, yearOfBirthTextBox.Text),
          Tezina = Decimal.Parse(weightTextBox.Text),
          DatumVrijeme = DateTime.UtcNow
        };
        korisnik user = dnevnikIshraneEntites.korisniks.Where(elem => elem.idKORISNIK == measurement.KANDIDAT_KORISNIK_idKORISNIK).FirstOrDefault();
        if (measurement.KANDIDAT_KORISNIK_idKORISNIK != 0 && user.Aktivan != 0)
        {
          if (action.Equals("update"))
          {
            var old_measurement = dnevnikIshraneEntites.mjerenjes.
              Where(elem => elem.KANDIDAT_KORISNIK_idKORISNIK == measurement.KANDIDAT_KORISNIK_idKORISNIK && elem.TRENER_KORISNIK_idKORISNIK == measurement.TRENER_KORISNIK_idKORISNIK && elem.DatumVrijeme.Equals(selectedDateTime)).FirstOrDefault();
            if (old_measurement != null)
            {
              dnevnikIshraneEntites.mjerenjes.Remove(old_measurement);
            }
          }
          dnevnikIshraneEntites.mjerenjes.Add(measurement);
          dnevnikIshraneEntites.SaveChanges();
          if (MainWindow.language.Equals("Serbian"))
            errorTextBlock.Text = "Uspješno sačuvano.";
          else
            errorTextBlock.Text = "Saved successfully.";
        }
        else
        {
          if (MainWindow.language.Equals("Serbian"))
            errorTextBlock.Text = "Nije pronadjen nijedan kandidat sa navedenim imenom,prezimenom i godištem.";
          else
            errorTextBlock.Text = "There is no candidate with specified name,surname and year of birth.";
        }
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

    private int findCandidateId(string text1, string text2, string text3)
    {
      korisnik candidate = dnevnikIshraneEntites.korisniks.Where(elem => elem.Ime.Equals(text1) && elem.Prezime.Equals(text2) && elem.Godiste.ToString().Equals(text3)).FirstOrDefault();
      if (candidate != null)
      {
        return candidate.idKORISNIK;
      }
      return 0;
    }

    private void cancel(object sender, MouseButtonEventArgs e)
    {
      this.Hide();
      new MeasurementWindow(userId,previousWindow).Show();
    }
  }
}

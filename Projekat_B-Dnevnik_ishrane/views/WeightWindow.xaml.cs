using Dnevnik_ishrane.exceptions;
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
    private dnevnik_ishrane_db_Entities dnevnikIshraneEntites = new dnevnik_ishrane_db_Entities();
    private Window previousWindow;
    public WeightWindow(int userId,Window previousWindow)
    {
      this.previousWindow = previousWindow;
      this.userId = userId;
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
          errorTextBlock.Text = "Popunite sva tekstualna polja.";
          return;
        }
      }

      var measurement = new mjerenje()
      {
        TRENER_KORISNIK_idKORISNIK = userId,
        KANDIDAT_KORISNIK_idKORISNIK = findCandidateId(nameTextBox.Text, surnameTextBox.Text, yearOfBirthTextBox.Text),
        Tezina = Decimal.Parse(weightTextBox.Text),
        DatumVrijeme = DateTime.UtcNow
      };
      if (measurement.KANDIDAT_KORISNIK_idKORISNIK != 0)
      {
        var old_measurement = dnevnikIshraneEntites.mjerenjes.
          Where(elem => elem.KANDIDAT_KORISNIK_idKORISNIK == measurement.KANDIDAT_KORISNIK_idKORISNIK && elem.TRENER_KORISNIK_idKORISNIK == measurement.TRENER_KORISNIK_idKORISNIK).FirstOrDefault();
        if (old_measurement!=null)
        {
          dnevnikIshraneEntites.mjerenjes.Remove(old_measurement);
        }
        dnevnikIshraneEntites.mjerenjes.Add(measurement);
        dnevnikIshraneEntites.SaveChanges();
        errorTextBlock.Text = "Uspješno sačuvano.";
      }
      else
      {
        errorTextBlock.Text = "Nije pronadjen nijedan kandidat sa navedenim imenom,prezimenom i godištem.";
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
      new MeasurementWindow(userId).Show();
    }
  }
}

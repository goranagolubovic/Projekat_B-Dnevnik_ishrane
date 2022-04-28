using Projekat_B_Dnevnik_ishrane.db_views;
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
  /// Interaction logic for MeasurementWindow.xaml
  /// </summary>
  public partial class MeasurementWindow : Window
  {
    private int userId;
    private List<MeasurementView> listOfMeasurements = new List<MeasurementView>();
    private dbModel dnevnikIshraneEntities = new dbModel();
    private Window previousWindow;

    public MeasurementWindow(int userId,Window previousWindow)
    {
      Properties.Settings.Default.ColorMode = MainWindow.theme;
      this.Resources.MergedDictionaries.Add(MainWindow.resourceDictionary);
      InitializeComponent();
      this.userId = userId;
      this.previousWindow = previousWindow;
      initializeDataGrid();
      
    }
    private void initializeDataGrid()
    {
      if (MainWindow.checkIfUserIsCandidate(userId))
      {
        addWeightCanvas.Visibility = Visibility.Hidden;
        dataGridViewMeasurementPlan.Columns[4].Visibility = Visibility.Hidden;
        dataGridViewMeasurementPlan.Columns[5].Visibility = Visibility.Hidden;
        dataGridViewMeasurementPlan.Columns[6].Visibility = Visibility.Hidden;
        dataGridViewMeasurementPlan.Columns[7].Visibility = Visibility.Hidden;
        dataGridViewMeasurementPlan.Columns[8].Visibility = Visibility.Hidden;
        listOfMeasurements = dnevnikIshraneEntities.mjerenjes.Join(
    dnevnikIshraneEntities.korisniks, m => m.TRENER_KORISNIK_idKORISNIK, k => k.idKORISNIK, (m, k) =>
    new MeasurementView
    {
      DateAndTime = m.DatumVrijeme,
      Id = m.KANDIDAT_KORISNIK_idKORISNIK,
      SurnameOfTrener = k.Prezime,
      NameOfTrener = k.Ime,
      Weight = m.Tezina
    })
      .Where(elem => elem.Id == userId).ToList();
      }
      else
      {
        dataGridViewMeasurementPlan.Columns[0].Visibility = Visibility.Hidden;
        dataGridViewMeasurementPlan.Columns[1].Visibility = Visibility.Hidden;
        listOfMeasurements = dnevnikIshraneEntities.mjerenjes.Join(
dnevnikIshraneEntities.korisniks, m => m.KANDIDAT_KORISNIK_idKORISNIK, k => k.idKORISNIK, (m, k) =>
new MeasurementView
{
  DateAndTime = m.DatumVrijeme,
  Id = m.TRENER_KORISNIK_idKORISNIK,
  SurnameOfCandidate = k.Prezime,
  NameOfCandidate = k.Ime,
  YearOfBirth=k.Godiste,
  Weight = m.Tezina,
  CandidateActive=k.Aktivan
})
  .Where(elem => elem.Id == userId && elem.CandidateActive==1).ToList();
      }
      var list = new List<dynamic>();
      foreach (var elem in listOfMeasurements)
      {
        list.Add(new
        {
          ImeTrenera = elem.NameOfTrener,
          PrezimeTrenera = elem.SurnameOfTrener,
          DatumVrijeme = elem.DateAndTime,
          Tezina = elem.Weight,
          Godiste=elem.YearOfBirth,
          ImeKandidata = elem.NameOfCandidate,
          PrezimeKandidata = elem.SurnameOfCandidate

        });
      }
      dataGridViewMeasurementPlan.ItemsSource = list;
    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext;
      DateTime selectedDateTime = dataRowView.DatumVrijeme;
      WeightWindow window = new WeightWindow(userId,this,"update",selectedDateTime);
      this.Hide();
      window.nameTextBox.Text = dataRowView.ImeKandidata;
      window.surnameTextBox.Text = dataRowView.PrezimeKandidata;
      window.yearOfBirthTextBox.Text = dataRowView.Godiste.ToString();
      window.nameTextBox.IsReadOnly = true;
      window.surnameTextBox.IsReadOnly = true;
      window.yearOfBirthTextBox.IsReadOnly = true;
      window.weightTextBox.Text =dataRowView.Tezina.ToString();
      window.Show();
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext;
      string nameOfCandidate = dataRowView.ImeKandidata;
      string surnameOfCandidate = dataRowView.PrezimeKandidata;
      decimal weight = System.Convert.ToDecimal(dataRowView.Tezina);
      DateTime dateTime = dataRowView.DatumVrijeme;
      int idCandidate = findIdCandidate(nameOfCandidate, surnameOfCandidate);
      DateTime date = dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);
      mjerenje measurement = dnevnikIshraneEntities.mjerenjes.Where(elem => elem.DatumVrijeme.Equals(dateTime) && elem.TRENER_KORISNIK_idKORISNIK==userId && elem.KANDIDAT_KORISNIK_idKORISNIK==idCandidate).First();
      dnevnikIshraneEntities.mjerenjes.Remove(measurement);
      dnevnikIshraneEntities.SaveChanges();
      initializeDataGrid();
    }

    private int findIdCandidate(string nameOfCandidate, string surnameOfCandidate)
    {
      int active = 1;
      korisnik k = dnevnikIshraneEntities.korisniks.Where(elem => elem.Ime.Equals(nameOfCandidate) && elem.Prezime.Equals(surnameOfCandidate) && elem.Aktivan==active).FirstOrDefault();
      if (k != null)
        return k.idKORISNIK;
      return 0;
    }

    private void dataGridViewDietPlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void addWeight(object sender, MouseButtonEventArgs e)
    {
      Window window = new WeightWindow(userId,this,"add");
      this.Hide();
      window.Show();
    }

    private void goBack(object sender, MouseButtonEventArgs e)
    {
      this.Hide();
      if (MainWindow.checkIfUserIsCandidate(userId))
      {
        KandidatWindow window = new KandidatWindow(userId,dnevnikIshraneEntities);
        window.Show();
      }
      else
      {
        TrenerWindow window = new TrenerWindow(userId, dnevnikIshraneEntities);
        window.Show();
      }
    }
  }
}

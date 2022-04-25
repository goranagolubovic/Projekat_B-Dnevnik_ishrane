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

    public MeasurementWindow(int userId)
    {
      InitializeComponent();
      this.userId = userId;
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
  Weight = m.Tezina
})
  .Where(elem => elem.Id == userId).ToList();
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
      WeightWindow window = new WeightWindow(userId,this);
      this.Hide();
      dynamic dataRowView = ((Button)e.Source).DataContext;
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
      MeasurementView measurementView = dnevnikIshraneEntities.mjerenjes.Join(
    dnevnikIshraneEntities.korisniks, m => m.KANDIDAT_KORISNIK_idKORISNIK, k => k.idKORISNIK, (m, k) =>
    new MeasurementView
    {
      DateAndTime = m.DatumVrijeme,
      Id = m.KANDIDAT_KORISNIK_idKORISNIK,
      NameOfCandidate=k.Ime,
      SurnameOfCandidate=k.Prezime,
      Weight=m.Tezina
    })
      .Where(elem => elem.Weight == weight && elem.NameOfCandidate.Equals(nameOfCandidate) && elem.SurnameOfCandidate.Equals(surnameOfCandidate)).First();

      mjerenje measurement = dnevnikIshraneEntities.mjerenjes.Where(elem => elem.KANDIDAT_KORISNIK_idKORISNIK == measurementView.Id && elem.TRENER_KORISNIK_idKORISNIK==userId).First();
      dnevnikIshraneEntities.mjerenjes.Remove(measurement);
      dnevnikIshraneEntities.SaveChanges();
      initializeDataGrid();
    }

    private void dataGridViewDietPlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void addWeight(object sender, MouseButtonEventArgs e)
    {
      Window window = new WeightWindow(userId,this);
      this.Hide();
      window.Show();
    }
  }
}

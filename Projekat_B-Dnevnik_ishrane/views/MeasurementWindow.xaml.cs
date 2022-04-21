using Projekat_B_Dnevnik_ishrane.db_views;
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
    private int candidateId;
    private List<MeasurementView> listOfMeasurements = new List<MeasurementView>();
    private dnevnik_ishrane_db_Entities dnevnikIshraneEntities = new dnevnik_ishrane_db_Entities();

    public MeasurementWindow(int candidateId)
    {
      InitializeComponent();
      this.candidateId = candidateId;
      listOfMeasurements = dnevnikIshraneEntities.mjerenjes.Join(
  dnevnikIshraneEntities.korisniks, m => m.TRENER_KORISNIK_idKORISNIK, k => k.idKORISNIK, (m, k) =>
  new MeasurementView
  {
    DateAndTime = m.DatumVrijeme,
    IdCandidate = m.KANDIDAT_KORISNIK_idKORISNIK,
    SurnameOfTrener = k.Prezime,
    NameOfTrener = k.Ime,
    Weight =m.Tezina
  })
    .Where(elem => elem.IdCandidate == candidateId).ToList();

      var list = new List<dynamic>();
      foreach (var elem in listOfMeasurements)
      {
          list.Add(new
          {
            ImeTrenera = elem.NameOfTrener,
            PrezimeTrenera = elem.SurnameOfTrener,
            DatumVrijeme = elem.DateAndTime,
            Tezina=elem.Weight

          });
      }
      dataGridViewMeasurementPlan.ItemsSource = list;
      if (MainWindow.checkIfUserIsCandidate(candidateId))
      {

        dataGridViewMeasurementPlan.Columns[4].Visibility = Visibility.Hidden;
        dataGridViewMeasurementPlan.Columns[5].Visibility = Visibility.Hidden;
        dataGridViewMeasurementPlan.Columns[6].Visibility = Visibility.Hidden;
        dataGridViewMeasurementPlan.Columns[7].Visibility = Visibility.Hidden;
      }
    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {

    }

    private void dataGridViewDietPlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
  }
}

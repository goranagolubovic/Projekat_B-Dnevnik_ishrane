using Projekat_B_Dnevnik_ishrane.db_views;
using Projekat_B_Dnevnik_ishrane.models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
  /// Interaction logic for MealsWindow.xaml
  /// </summary>
  public partial class MealsWindow : Window
  {
    private int candidateId;
    public static double sumOfKcals=0.0;
    private dbModel dnevnikIshraneEntities = new dbModel();
    private List<ObrokView> breakfastOfCanidate = new List<ObrokView>();
    private List<ObrokView> lunchOfCandidate = new List<ObrokView>();
    private List<ObrokView> dinnerOfCanidate = new List<ObrokView>();
    private List<ObrokView> snackOfCanidate = new List<ObrokView>();
    public MealsWindow(int candidateId,string action)
    {
      sumOfKcals = 0.0;
      this.candidateId = candidateId;
      Properties.Settings.Default.ColorMode = MainWindow.theme;
      this.Resources.MergedDictionaries.Add(MainWindow.resourceDictionary);
      InitializeComponent();
      initializeBreakfastGrid();
      initializeLunchGrid();
      initializeDinnerGrid();
      initializeSnackGrid();
    }

    private void initializeLunchGrid()
    {
      lunchOfCandidate = dnevnikIshraneEntities.obroks.Join(
dnevnikIshraneEntities.namirnicas, o => o.NAMIRNICA_idNAMIRNICA, n => n.idNAMIRNICA, (o, n) =>
new ObrokView
{
 Date = o.Datum,
 IdCandidate = o.KANDIDAT_KORISNIK_idKORISNIK,
 TypeOfMeal = o.TipObroka,
 NameOfFoodStuff = n.Naziv,
 KcalFoodStuff = (double)(n.KalorijskaVrijednost / 100 * o.Kolicina)
})
 .Where(elem => elem.IdCandidate == candidateId && elem.TypeOfMeal.Equals("ručak")).ToList();

      var list = new List<dynamic>();
      foreach (var elem in lunchOfCandidate)
      {
        if (elem.Date.Equals(DateTime.UtcNow.Date))
        {
            sumOfKcals += elem.KcalFoodStuff;
          list.Add(new
          {
            Namirnica = elem.NameOfFoodStuff,
            kcal = elem.KcalFoodStuff,
          });
        }
      }
      totalyKcals.Text = sumOfKcals.ToString();
      dataGridLunch.ItemsSource = list;
    }
    private void initializeDinnerGrid()
    {
  dinnerOfCanidate = dnevnikIshraneEntities.obroks.Join(
dnevnikIshraneEntities.namirnicas, o => o.NAMIRNICA_idNAMIRNICA, n => n.idNAMIRNICA, (o, n) =>
new ObrokView
{
  Date = o.Datum,
  IdCandidate = o.KANDIDAT_KORISNIK_idKORISNIK,
  TypeOfMeal = o.TipObroka,
  NameOfFoodStuff = n.Naziv,
  KcalFoodStuff = (double)(n.KalorijskaVrijednost / 100 * o.Kolicina)
})
 .Where(elem => elem.IdCandidate == candidateId && elem.TypeOfMeal.Equals("večera")).ToList();

      var list = new List<dynamic>();
      foreach (var elem in dinnerOfCanidate)
      {
        if (elem.Date.Equals(DateTime.UtcNow.Date))
        {
            sumOfKcals += elem.KcalFoodStuff;
          list.Add(new
          {
            Namirnica = elem.NameOfFoodStuff,
            kcal = elem.KcalFoodStuff,
          });
        }
      }
      totalyKcals.Text = sumOfKcals.ToString();
      dataGridDinner.ItemsSource = list;
    }
    private void initializeSnackGrid()
    {
      snackOfCanidate = dnevnikIshraneEntities.obroks.Join(
dnevnikIshraneEntities.namirnicas, o => o.NAMIRNICA_idNAMIRNICA, n => n.idNAMIRNICA, (o, n) =>
new ObrokView
{
  Date = o.Datum,
  IdCandidate = o.KANDIDAT_KORISNIK_idKORISNIK,
  TypeOfMeal = o.TipObroka,
  NameOfFoodStuff = n.Naziv,
  KcalFoodStuff = (double)(n.KalorijskaVrijednost / 100 * o.Kolicina)
})
 .Where(elem => elem.IdCandidate == candidateId && elem.TypeOfMeal.Equals("užina")).ToList();

      var list = new List<dynamic>();
      foreach (var elem in snackOfCanidate)
      {
        if (elem.Date.Equals(DateTime.UtcNow.Date))
        {
            sumOfKcals += elem.KcalFoodStuff;
          list.Add(new
          {
            Namirnica = elem.NameOfFoodStuff,
            kcal = elem.KcalFoodStuff,
          });
        }
      }
      totalyKcals.Text = sumOfKcals.ToString();
      dataGridSnack.ItemsSource = list;
    }
    private void initializeBreakfastGrid()
    {
      breakfastOfCanidate = dnevnikIshraneEntities.obroks.Join(
  dnevnikIshraneEntities.namirnicas, o => o.NAMIRNICA_idNAMIRNICA, n => n.idNAMIRNICA, (o, n) =>
  new ObrokView
  {
    Date = o.Datum,
    IdCandidate = o.KANDIDAT_KORISNIK_idKORISNIK,
    TypeOfMeal = o.TipObroka,
    NameOfFoodStuff = n.Naziv,
    KcalFoodStuff = (double)(n.KalorijskaVrijednost / 100 * o.Kolicina)
  })
    .Where(elem => elem.IdCandidate == candidateId && elem.TypeOfMeal.Equals("doručak")).ToList();

      var list = new List<dynamic>();
      foreach (var elem in breakfastOfCanidate)
      {
        if (elem.Date.Equals(DateTime.UtcNow.Date))
        {
            sumOfKcals += elem.KcalFoodStuff;
          list.Add(new
          {
            Namirnica = elem.NameOfFoodStuff,
            kcal = elem.KcalFoodStuff,
          });
        }
      }
      totalyKcals.Text = sumOfKcals.ToString();
      dataGridBreakfast.ItemsSource = list;
    }
    private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {

    }

    private void ScrollBar_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
    {

    }

    private void addBreakfast(object sender, RoutedEventArgs e)
    {
      Window window = new FoodStuffWindow(candidateId,"doručak");
      this.Hide();
      window.Show();
    }

    private void btnUpdateBreakfast_Click(object sender, RoutedEventArgs e)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext;
      string name = dataRowView.Namirnica;
      Window window = new FoodStuffDetailsWindow(name,candidateId,"doručak","update");
      this.Hide();
      window.Show();
    }

    private void btnDeleteBreakfast_Click(object sender, RoutedEventArgs e)
    {
      deleteMeal(e,"doručak");
      sumOfKcals = 0.0;
      initializeBreakfastGrid();
      initializeLunchGrid();
      initializeSnackGrid();
      initializeDinnerGrid();
    }

    private void dataGridViewExercisePlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void addLunch(object sender, RoutedEventArgs e)
    {
      Window window = new FoodStuffWindow(candidateId, "ručak");
      this.Hide();
      window.Show();
    }

    private void addDinner(object sender, RoutedEventArgs e)
    {
      Window window = new FoodStuffWindow(candidateId, "večera");
      this.Hide();
      window.Show();
    }

    private void addSnack(object sender, RoutedEventArgs e)
    {
      Window window = new FoodStuffWindow(candidateId, "užina");
      this.Hide();
      window.Show();
    }

    private void btnDeleteSnack_Click(object sender, RoutedEventArgs e)
    {
      deleteMeal(e,"užina");
      sumOfKcals = 0.0;
      initializeBreakfastGrid();
      initializeLunchGrid();
      initializeSnackGrid();
      initializeDinnerGrid();
    }
    private void deleteMeal(RoutedEventArgs e,string typeOfMeal)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext;
      string name = dataRowView.Namirnica;
      ObrokView obrokView = dnevnikIshraneEntities.obroks.Join(
    dnevnikIshraneEntities.namirnicas, o => o.NAMIRNICA_idNAMIRNICA, n => n.idNAMIRNICA, (o, n) =>
    new ObrokView
    {
      Date = o.Datum,
      IdCandidate = o.KANDIDAT_KORISNIK_idKORISNIK,
      TypeOfMeal = o.TipObroka,
      NameOfFoodStuff = n.Naziv,
      KcalFoodStuff = (double)(n.KalorijskaVrijednost / 100 * o.Kolicina),
      IdFoodStuff = n.idNAMIRNICA
    })
      .Where(elem => elem.NameOfFoodStuff == name).First();

      obrok meal = dnevnikIshraneEntities.obroks.Where(elem => elem.NAMIRNICA_idNAMIRNICA == obrokView.IdFoodStuff && elem.TipObroka.Equals(typeOfMeal)).First();
      dnevnikIshraneEntities.obroks.Remove(meal);
      dnevnikIshraneEntities.SaveChanges();
    }

    private void btnUpdateSnack_Click(object sender, RoutedEventArgs e)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext;
      string name = dataRowView.Namirnica;
      Window window = new FoodStuffDetailsWindow(name, candidateId, "užina", "update");
      this.Hide();
      window.Show();
    }

    private void btnDeleteDinner_Click(object sender, RoutedEventArgs e)
    {
      deleteMeal(e,"večera");
      sumOfKcals = 0.0;
      initializeBreakfastGrid();
      initializeLunchGrid();
      initializeSnackGrid();
      initializeDinnerGrid();
    }

    private void btnUpdateDinner_Click(object sender, RoutedEventArgs e)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext;
      string name = dataRowView.Namirnica;
      Window window = new FoodStuffDetailsWindow(name, candidateId, "večera", "update");
      this.Hide();
      window.Show();
    }

    private void btnDeleteLunch_Click(object sender, RoutedEventArgs e)
    {
      deleteMeal(e,"ručak");
      sumOfKcals = 0.0;
      initializeBreakfastGrid();
      initializeLunchGrid();
      initializeSnackGrid();
      initializeDinnerGrid();
    }

    private void btnUpdateLunch_Click(object sender, RoutedEventArgs e)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext;
      string name = dataRowView.Namirnica;
      Window window = new FoodStuffDetailsWindow(name, candidateId, "ručak", "update");
      this.Hide();
      window.Show();
    }
  }
}

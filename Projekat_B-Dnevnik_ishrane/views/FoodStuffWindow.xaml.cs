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
  /// Interaction logic for FoodStuffWindow.xaml
  /// </summary>
  public partial class FoodStuffWindow : Window
  {
    private List<string> listOfFoodStuffs = new List<string>();
    private dbModel dnevnikIshraneEntities = new dbModel();
    private string nameOfSelectedFoodStuff;
    private int candidateId;
    private string typeOfMeal;
    private Window previousWindow;

    public FoodStuffWindow(int candidateId,string typeOfMeal,Window previousWindow)
    {
      Properties.Settings.Default.ColorMode = MainWindow.theme;
      this.Resources.MergedDictionaries.Add(MainWindow.resourceDictionary);
      InitializeComponent();
      this.candidateId = candidateId;
      this.typeOfMeal = typeOfMeal;
      this.previousWindow = previousWindow;
      listOfFoodStuffs = dnevnikIshraneEntities.namirnicas.Select(e => e.Naziv).ToList();
      var list = new List<dynamic>();
      foreach (var elem in listOfFoodStuffs)
      {
        int idFoodStuff = findFoodStuffId(elem);
        DateTime date = DateTime.Now.Date;
        obrok meal = dnevnikIshraneEntities.obroks.Where(e => e.NAMIRNICA_idNAMIRNICA == idFoodStuff && e.KANDIDAT_KORISNIK_idKORISNIK == candidateId && e.TipObroka == typeOfMeal && e.Datum.Equals(date)).FirstOrDefault();
        if (meal==null)
        list.Add(new
        {
          Namirnica = elem
        }) ;
        
      }
      dataGridFoodStuff.ItemsSource = list;
    }

    private void btnChoose_Click(object sender, RoutedEventArgs e)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext;
      string name = dataRowView.Namirnica;
      Window window = new FoodStuffDetailsWindow(name,candidateId,typeOfMeal,"add",previousWindow);
      this.Hide();
      window.Show();
    }
    private int findFoodStuffId(string name)
    {
      int id = 0;
      namirnica n = dnevnikIshraneEntities.namirnicas.Where(elem => elem.Naziv.Equals(name)).FirstOrDefault();
      if (n != null)
      {
        id = n.idNAMIRNICA;
      }
      return id;
    }
    private void dataGridViewFoodStuff_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void search(object sender, MouseButtonEventArgs e)
    {
      listOfFoodStuffs = dnevnikIshraneEntities.namirnicas.Select(n => n.Naziv).Where(elem => elem.Equals(searchTextBox.Text)).ToList();
      var list = new List<dynamic>();
      foreach (var elem in listOfFoodStuffs)
      {
        int idFoodStuff = findFoodStuffId(elem);
        DateTime date = DateTime.Now.Date;
        obrok meal = dnevnikIshraneEntities.obroks.Where(el => el.NAMIRNICA_idNAMIRNICA == idFoodStuff && el.KANDIDAT_KORISNIK_idKORISNIK == candidateId && el.TipObroka == typeOfMeal && el.Datum.Equals(date)).FirstOrDefault();
        if (meal == null)
          list.Add(new
        {
          Namirnica = elem
        });

      }
      dataGridFoodStuff.ItemsSource = list;
    }

    private void goBack(object sender, MouseButtonEventArgs e)
    {
      this.Hide();
      previousWindow.Show();
    }

    private void searchTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
      if (string.IsNullOrEmpty(searchTextBox.Text))
      {
        searchTextBox.Visibility = System.Windows.Visibility.Collapsed;
        watermarkSearchTextBox.Visibility = Visibility.Visible;
      }
    }

    private void watermakSearchTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
      watermarkSearchTextBox.Visibility = Visibility.Collapsed;
      searchTextBox.Visibility = System.Windows.Visibility.Visible;
      searchTextBox.Focus();
    }
  }
}

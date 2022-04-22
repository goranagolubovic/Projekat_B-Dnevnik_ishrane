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
    private dnevnik_ishrane_db_Entities dnevnikIshraneEntities = new dnevnik_ishrane_db_Entities();
    private string nameOfSelectedFoodStuff;
    private int candidateId;
    private string typeOfMeal;
    public FoodStuffWindow(int candidateId,string typeOfMeal)
    {
      InitializeComponent();
      this.candidateId = candidateId;
      this.typeOfMeal = typeOfMeal;
      listOfFoodStuffs = dnevnikIshraneEntities.namirnicas.Select(e => e.Naziv).ToList();
      var list = new List<dynamic>();
      foreach (var elem in listOfFoodStuffs)
      {
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
      Window window = new FoodStuffDetailsWindow(name,candidateId,typeOfMeal,"add");
      this.Hide();
      window.Show();
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
        list.Add(new
        {
          Namirnica = elem
        });

      }
      dataGridFoodStuff.ItemsSource = list;
    }
  }
}

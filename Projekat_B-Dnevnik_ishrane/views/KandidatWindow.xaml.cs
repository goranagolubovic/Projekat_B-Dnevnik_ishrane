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

namespace Projekat_B_Dnevnik_ishrane
{
  /// <summary>
  /// Interaction logic for KanidatWindow.xaml
  /// </summary>
  public partial class KandidatWindow : Window
  {
  
    private int candidateId = -1;
    private dnevnik_ishrane_db_Entities dnevnikIshraneEntities;
    private List<PlanIshraneView> listOfDietPlans = new List<PlanIshraneView>();
    public KandidatWindow(int candidateId,dnevnik_ishrane_db_Entities dnevnikIshraneEntities)
    {
      this.dnevnikIshraneEntities = dnevnikIshraneEntities;
      this.candidateId = candidateId;
      InitializeComponent();
    }

    private void ReviewDietPlanButton_Click(object sender, RoutedEventArgs e)
    {
      DietPlanWindow window = new DietPlanWindow(candidateId);
      this.Hide();
      window.Show();
    }


    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Exercise_Plan_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Meals_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Measurement_Click(object sender, RoutedEventArgs e)
    {

    }
  }
}

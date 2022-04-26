using Projekat_B_Dnevnik_ishrane.db_views;
using Projekat_B_Dnevnik_ishrane.models;
using Projekat_B_Dnevnik_ishrane.views;
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
    private dbModel dnevnikIshraneEntities;
    private List<PlanView> listOfDietPlans = new List<PlanView>();
    public KandidatWindow(int candidateId,dbModel dnevnikIshraneEntities)
    {
      this.dnevnikIshraneEntities = dnevnikIshraneEntities;
      this.candidateId = candidateId;
      Properties.Settings.Default.ColorMode = MainWindow.theme;
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
      Application.Current.Shutdown();
    }

    private void Exercise_Plan_Click(object sender, RoutedEventArgs e)
    {
      Window window=new ExercisePlanWindow(candidateId);
      this.Hide();
      window.Show();
    }

    private void Meals_Click(object sender, RoutedEventArgs e)
    {
      Window window = new MealsWindow(candidateId,"add");
      this.Hide();
      window.Show();
    }

    private void Measurement_Click(object sender, RoutedEventArgs e)
    {
      Window window = new MeasurementWindow(candidateId);
      this.Hide();
      window.Show();
    }
  }
}

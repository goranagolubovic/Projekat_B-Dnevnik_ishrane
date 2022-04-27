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

namespace Projekat_B_Dnevnik_ishrane.views
{
  
  public partial class TrenerWindow : Window
  {

    private int coachId = -1;
    private dbModel dnevnikIshraneEntities;
    private List<PlanView> listOfDietPlans = new List<PlanView>();
    public TrenerWindow(int coachId, dbModel dnevnikIshraneEntities)
    {
      this.dnevnikIshraneEntities = dnevnikIshraneEntities;
      this.coachId = coachId;
      Properties.Settings.Default.ColorMode = MainWindow.theme;
      this.Resources.MergedDictionaries.Add(MainWindow.resourceDictionary);
      InitializeComponent();
    }

    private void ReviewDietPlanButton_Click(object sender, RoutedEventArgs e)
    {
      DietPlanWindow window = new DietPlanWindow(coachId);
      this.Hide();
      window.Show();
    }


    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }

    private void Exercise_Plan_Click(object sender, RoutedEventArgs e)
    {
      Window window = new ExercisePlanWindow(coachId);
      this.Hide();
      window.Show();
    }

    /*private void Canidate_Click(object sender, RoutedEventArgs e)
    {
      Window window = new MealsWindow(candidateId, "add");
      this.Hide();
      window.Show();
    }*/

    private void Measurement_Click(object sender, RoutedEventArgs e)
    {
      Window window = new MeasurementWindow(coachId);
      this.Hide();
      window.Show();
    }

    private void Candidate_Click(object sender, RoutedEventArgs e)
    {
      UsersWindow window = new UsersWindow(coachId,this);
      this.Hide();
      window.Show();
    }
  }
}

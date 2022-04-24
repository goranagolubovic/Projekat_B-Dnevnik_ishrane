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
  /// Interaction logic for UsersWindow.xaml
  /// </summary>
  public partial class UsersWindow : Window
  {
    private Window previousWindow;
    private int coachId;
    private dnevnik_ishrane_db_Entities dnevnikIshraneEntities = new dnevnik_ishrane_db_Entities();
    public UsersWindow(int coachId,Window previousWindow)
    {
      this.coachId = coachId;
      this.previousWindow = previousWindow;
      InitializeComponent();
      initializeDataGrid();
    }

    private void initializeDataGrid()
    {
      /*List<korisnik>listOfUsers = dnevnikIshraneEntities.korisniks.Join(
       dnevnikIshraneEntities.korisniks, pi => pi.TRENER_KORISNIK_idKORISNIK, k => k.idKORISNIK, (pi, k) =>
       new PlanView
       {
         DateAndTime = pi.DatumVrijeme,
         IdCandidate = pi.KANDIDAT_KORISNIK_idKORISNIK,
         SurnameOfTrener = k.Prezime,
         NameOfTrener = k.Ime,
         IdPlan = pi.idPLAN_VJEZBANJA
       })
         .Where(elem => elem.IdCandidate == userId).ToList();

      var list = new List<dynamic>();
      for (int i = 0; i < listOfExercisePlans.Count; i++)
      {// i%7 da ne prikazuje za svaki dan posebno jedan te isti plan
        if ((listOfExercisePlans[i].IdPlan % 7) == 0)
        {
          list.Add(new
          {
            ImeTrenera = listOfExercisePlans[i].NameOfTrener,
            PrezimeTrenera = listOfExercisePlans[i].SurnameOfTrener,
            DatumVrijeme = listOfExercisePlans[i].DateAndTime

          });
        }
      }
      dataGridViewUser.ItemsSource = list;*/

    }

    private void btnView_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }

    private void Previous_Window_Click(object sender, RoutedEventArgs e)
    {
      this.Hide();
      previousWindow.Show();
    }
  }
}

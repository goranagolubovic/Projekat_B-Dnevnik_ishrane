using MySql.Data.MySqlClient;
using Projekat_B_Dnevnik_ishrane.db_views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
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
  /// Interaction logic for DietPlanWindow.xaml
  /// </summary>
  public partial class DietPlanWindow : Window
  {
    private  DateTime selectedDateAndTime;
    private string selectedNameOfTrener;
    private  string selectedSurnameOfTrener;
    private int candidateId;
    private List<PlanIshraneView> listOfDietPlans = new List<PlanIshraneView>();
    private dnevnik_ishrane_db_Entities dnevnikIshraneEntities = new dnevnik_ishrane_db_Entities();
    public DietPlanWindow(int candidateId)
    {
      this.candidateId = candidateId;
      InitializeComponent();

      listOfDietPlans = dnevnikIshraneEntities.plan_ishrane.Join(
     dnevnikIshraneEntities.korisniks, pi => pi.TRENER_KORISNIK_idKORISNIK, k => k.idKORISNIK, (pi, k) =>
     new PlanIshraneView
     {
       DateAndTime = pi.DatumVrijeme,
       IdCandidate = pi.KANDIDAT_KORISNIK_idKORISNIK,
       SurnameOfTrener = k.Prezime,
       NameOfTrener = k.Ime,
       IdDietPlan = pi.idPLAN_ISHRANE
     })
       .Where(elem => elem.IdCandidate == candidateId).ToList();

      var list = new List<dynamic>();
      int previousId = 0;
      foreach (var elem in listOfDietPlans)
      {// i%7 da ne prikazuje za svaki dan posebno jedan te isti plan
        if (previousId!=elem.IdDietPlan)
        {
          list.Add(new
          {
            ImeTrenera = elem.NameOfTrener,
            PrezimeTrenera = elem.SurnameOfTrener,
            DatumVrijeme = elem.DateAndTime

          });
        }
        previousId = elem.IdDietPlan;
      }
      dataGridViewDietPlan.ItemsSource = list;
      if (MainWindow.checkIfUserIsCandidate(candidateId))
      {

        dataGridViewDietPlan.Columns[3].Visibility = Visibility.Hidden;
        dataGridViewDietPlan.Columns[4].Visibility = Visibility.Hidden;
        dataGridViewDietPlan.Columns[6].Visibility = Visibility.Hidden;
        dataGridViewDietPlan.Columns[7].Visibility = Visibility.Hidden;
      }
    }



    /*private void btnDelete_Click(object sender, EventArgs e)
    {

    }*/

    private void btnView_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        dynamic dataRowView = ((Button)e.Source).DataContext;
        string name = dataRowView.ImeTrenera;
        string surname = dataRowView.PrezimeTrenera;
        DateTime dateAndTime = dataRowView.DatumVrijeme;
        selectedNameOfTrener = name;
        selectedSurnameOfTrener = surname;
        selectedDateAndTime = dateAndTime;
        this.Hide();
        Window dietPlanScheduleWindow = new DietPlanScheduleWindow(candidateId,selectedDateAndTime,selectedNameOfTrener,selectedSurnameOfTrener);
        dietPlanScheduleWindow.Show();


      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message.ToString());
      }
    }

    private void dataGridViewDietPlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Previous_Window_Click(object sender, RoutedEventArgs e)
    {
        this.Hide();
        if (MainWindow.checkIfUserIsCandidate(candidateId))
        {
          KandidatWindow kandidatWindow = new KandidatWindow(candidateId,dnevnikIshraneEntities);
          kandidatWindow.Show();
        }
        else
        {
          TrenerWindow trenerWindow = new TrenerWindow();
          trenerWindow.Show();
        }
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
    /*private void btnDelete_Click(object sender, RoutedEventArgs e)
{
dynamic dataRowView = ((Button)e.Source).DataContext;
try
{
string vrijeme = dataRowView.Vrijeme;
string DELETE_QUERY = "DELETE from plan_ishrane where KANDIDAT_KORISNIK_idKorisnika='" + getCandidateId(dataRowView.Ime, dataRowView.Prezime) + "' and Datum='" + dataRowView.Datum + "' and Vrijeme='" + vrijeme + "'";
MySqlCommand find = new MySqlCommand(DELETE_QUERY, DatabaseConnection.Instance.mySqlConnection);
find.Prepare();
find.ExecuteNonQuery();
this.Hide();
DietPlanWindow dw = new DietPlanWindow();
dw.Show();
}
catch (Exception ex)
{
MessageBox.Show(ex.Message.ToString());
}
}

public static string getCandidateId(String name, String surname)
{
int candidateId = 0;
string FINDID_QUERY = "SELECT KORISNIK_idKorisnika FROM osnovni_podaci Where Ime='" + name + "'and Prezime='" + surname + "'";
MySqlCommand find = new MySqlCommand(FINDID_QUERY, DatabaseConnection.Instance.mySqlConnection);
MySqlDataReader readUsers = find.ExecuteReader();
while (readUsers.Read())
{
candidateId = readUsers.GetInt32(0);
}
readUsers.Close();
return candidateId.ToString();
}

private void btnUpdate_Click(object sender, RoutedEventArgs e)
{
try
{
dynamic dataRowView = ((Button)e.Source).DataContext;
string name = dataRowView.Ime;
string surname = dataRowView.Prezime;
string date = dataRowView.Datum;
string time = dataRowView.Vrijeme;
selectedName = name;
selectedSurname = surname;
selectedDate = date;
selectedTime = time;
this.Hide();
Window updateDietPlanWindow = new UpdateWindow("dietPlan");
updateDietPlanWindow.Show();


}
catch (Exception ex)
{
MessageBox.Show(ex.Message.ToString());
}
}


private void Previous_Window_Click(object sender, RoutedEventArgs e)
{
this.Hide();
if (MainWindow.checkIfUserIsCandidate(MainWindow.idLoginUser))
{
KandidatWindow kandidatWindow = new KandidatWindow();
kandidatWindow.Show();
}
else
{
TrenerWindow trenerWindow = new TrenerWindow();
trenerWindow.Show();
}
}

private void Exit_Click(object sender, RoutedEventArgs e)
{
Application.Current.Shutdown();
}*/
  }
}


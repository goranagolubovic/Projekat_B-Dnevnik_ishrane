using Dnevnik_ishrane.views;
using MySql.Data.MySqlClient;
using Projekat_B_Dnevnik_ishrane.db_views;
using Projekat_B_Dnevnik_ishrane.views;
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
    private int userId;
    private List<PlanView> listOfDietPlans = new List<PlanView>();
    private dnevnik_ishrane_db_Entities dnevnikIshraneEntities = new dnevnik_ishrane_db_Entities();
    public DietPlanWindow(int userId)
    {
      this.userId = userId;
      InitializeComponent();
      initializeDataGrid();
    }

    private void initializeDataGrid()
    {
      if (MainWindow.checkIfUserIsCandidate(userId))
      {
        listOfDietPlans = dnevnikIshraneEntities.plan_ishrane.Join(
       dnevnikIshraneEntities.korisniks, pi => pi.TRENER_KORISNIK_idKORISNIK, k => k.idKORISNIK, (pi, k) =>
       new PlanView
       {
         DateAndTime = pi.DatumVrijeme,
         IdCandidate = pi.KANDIDAT_KORISNIK_idKORISNIK,
         SurnameOfTrener = k.Prezime,
         NameOfTrener = k.Ime,
         IdPlan = pi.idPLAN_ISHRANE
       })
         .Where(elem => elem.IdCandidate == userId).ToList();

        var list = new List<dynamic>();
        int previousId = 0;
        foreach (var elem in listOfDietPlans)
        {// i%7 da ne prikazuje za svaki dan posebno jedan te isti plan
          if (previousId != elem.IdPlan)
          {
            list.Add(new
            {
              ImeTrenera = elem.NameOfTrener,
              PrezimeTrenera = elem.SurnameOfTrener,
              DatumVrijeme = elem.DateAndTime

            });
          }
          previousId = elem.IdPlan;
        }
        dataGridViewDietPlan.ItemsSource = list;

        addingDietPlan.Visibility = Visibility.Hidden;
        dataGridViewDietPlan.Columns[3].Visibility = Visibility.Hidden;
        dataGridViewDietPlan.Columns[4].Visibility = Visibility.Hidden;
        dataGridViewDietPlan.Columns[6].Visibility = Visibility.Hidden;
        dataGridViewDietPlan.Columns[7].Visibility = Visibility.Hidden;
      }
      else
      {
        listOfDietPlans = dnevnikIshraneEntities.plan_ishrane.Join(
    dnevnikIshraneEntities.korisniks, pi => pi.KANDIDAT_KORISNIK_idKORISNIK, k => k.idKORISNIK, (pi, k) =>
    new PlanView
    {
      DateAndTime = pi.DatumVrijeme,
      IdCandidate = pi.KANDIDAT_KORISNIK_idKORISNIK,
      IdCoach = pi.TRENER_KORISNIK_idKORISNIK,
      SurnameOfCandidate = k.Prezime,
      NameOfCandidate = k.Ime,
      IdPlan = pi.idPLAN_ISHRANE
    })
      .Where(elem => elem.IdCoach == userId).ToList();

        var list = new List<dynamic>();
        int previousId = 0;
        foreach (var elem in listOfDietPlans)
        {// i%7 da ne prikazuje za svaki dan posebno jedan te isti plan
          if (previousId != elem.IdPlan)
          {
            list.Add(new
            {
              ImeKandidata = elem.NameOfCandidate,
              PrezimeKandidata = elem.SurnameOfCandidate,
              DatumVrijeme = elem.DateAndTime

            });
          }
          previousId = elem.IdPlan;
        }
        dataGridViewDietPlan.ItemsSource = list;

        dataGridViewDietPlan.Columns[0].Visibility = Visibility.Hidden;
        dataGridViewDietPlan.Columns[1].Visibility = Visibility.Hidden;
      }
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {

      dynamic dataRowView = ((Button)e.Source).DataContext;      string nameOfCandidate = dataRowView.ImeKandidata;
      string surnameOfCandidate = dataRowView.PrezimeKandidata;
      DateTime dateTime =Convert.ToDateTime(dataRowView.DatumVrijeme);
      List< PlanView> listOfPlanViews = dnevnikIshraneEntities.plan_ishrane.Join(
    dnevnikIshraneEntities.korisniks, pi => pi.KANDIDAT_KORISNIK_idKORISNIK, k => k.idKORISNIK, (pi, k) =>
    new PlanView
    {
      DateAndTime = pi.DatumVrijeme,
      IdCoach = pi.TRENER_KORISNIK_idKORISNIK,
      IdCandidate=k.idKORISNIK,
      NameOfCandidate = k.Ime,
      SurnameOfCandidate = k.Prezime,
      IdPlan=pi.idPLAN_ISHRANE
    })
      .Where(elem => elem.IdCoach == userId && elem.NameOfCandidate.Equals(nameOfCandidate) && elem.SurnameOfCandidate.Equals(surnameOfCandidate)).ToList();
      DateTime date = dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);
      List<PlanView> planForSelectedDateTime = listOfPlanViews.Where(elem => elem.DateAndTime.Date.AddHours(elem.DateAndTime.Hour).AddMinutes(elem.DateAndTime.Minute).Equals(date)).ToList();
      foreach(var elem in planForSelectedDateTime) {
        plan_ishrane dietPlan = dnevnikIshraneEntities.plan_ishrane.Where(el => el.idPLAN_ISHRANE == elem.IdPlan).First();
        dnevnikIshraneEntities.plan_ishrane.Remove(dietPlan);
        dnevnikIshraneEntities.SaveChanges();
      }
      initializeDataGrid();
    }

    private void btnView_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        dynamic dataRowView = ((Button)e.Source).DataContext;
        DateTime dateAndTime = dataRowView.DatumVrijeme;
        selectedDateAndTime = dateAndTime;
        Window dietPlanScheduleWindow = new DietPlanScheduleWindow(selectedDateAndTime,userId,this);
        this.Hide();
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
      dynamic dataRowView = ((Button)e.Source).DataContext;
      DateTime selectedDateAndTime = dataRowView.DatumVrijeme;
      string selectedNameOfCandidate = dataRowView.ImeKandidata;
      string selectedSurnameOfCandidate = dataRowView.PrezimeKandidata;
      Window window = new UpdateWindow(userId,"dietPlan",selectedDateAndTime,selectedNameOfCandidate,selectedSurnameOfCandidate);
      this.Hide();
      window.Show();
    }


    private void Previous_Window_Click(object sender, RoutedEventArgs e)
    {
        this.Hide();
        if (MainWindow.checkIfUserIsCandidate(userId))
        {
          KandidatWindow kandidatWindow = new KandidatWindow(userId,dnevnikIshraneEntities);
          kandidatWindow.Show();
        }
        else
        {
        TrenerWindow trenerWindow = new TrenerWindow(userId, dnevnikIshraneEntities);
          trenerWindow.Show();
        }
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }

    private void addDietPlan(object sender, MouseButtonEventArgs e)
    {

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


using MySql.Data.MySqlClient;
using Projekat_B_Dnevnik_ishrane.db_views;
using System;
using System.Collections.Generic;
using System.Data;
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
  /// Interaction logic for ExercisePlanWindow.xaml
  /// </summary>
  public partial class ExercisePlanWindow : Window
  {
    private DateTime selectedDateAndTime;
    private string selectedNameOfTrener;
    private string selectedSurnameOfTrener;
    private int candidateId;
    private List<PlanView> listOfDietPlans = new List<PlanView>();
    private dnevnik_ishrane_db_Entities dnevnikIshraneEntities = new dnevnik_ishrane_db_Entities();
    public ExercisePlanWindow(int candidateId)
    {
      this.candidateId = candidateId;
      InitializeComponent();

      listOfDietPlans = dnevnikIshraneEntities.plan_vjezbanja.Join(
     dnevnikIshraneEntities.korisniks, pi => pi.TRENER_KORISNIK_idKORISNIK, k => k.idKORISNIK, (pi, k) =>
     new PlanView
     {
       DateAndTime = pi.DatumVrijeme,
       IdCandidate = pi.KANDIDAT_KORISNIK_idKORISNIK,
       SurnameOfTrener = k.Prezime,
       NameOfTrener = k.Ime,
       IdPlan = pi.idPLAN_VJEZBANJA
     })
       .Where(elem => elem.IdCandidate == candidateId).ToList();

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
      dataGridViewExercisePlan.ItemsSource = list;
      if (MainWindow.checkIfUserIsCandidate(candidateId))
      {

        dataGridViewExercisePlan.Columns[3].Visibility = Visibility.Hidden;
        dataGridViewExercisePlan.Columns[4].Visibility = Visibility.Hidden;
        dataGridViewExercisePlan.Columns[6].Visibility = Visibility.Hidden;
        dataGridViewExercisePlan.Columns[7].Visibility = Visibility.Hidden;
      }
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {

    }

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
        Window window = new ExercisePlanScheduleWindow(selectedDateAndTime, selectedNameOfTrener, selectedSurnameOfTrener, this);
        this.Hide();
        window.Show();


      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message.ToString());
      }
    }

    private void Previous_Window_Click(object sender, RoutedEventArgs e)
    {
      this.Hide();
      if (MainWindow.checkIfUserIsCandidate(candidateId))
      {
        KandidatWindow kandidatWindow = new KandidatWindow(candidateId, dnevnikIshraneEntities);
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


    /*private void BtnDelete_Click(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }
    private void btnView_Click(object sender, RoutedEventArgs e)
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
        Window exercisePlanScheduleWindow = new ExercisePlanScheduleWindow();
        exercisePlanScheduleWindow.Show();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message.ToString());
      }


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
        Window updateWindow = new UpdateWindow("exercisePlan");
        updateWindow.Show();


      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message.ToString());
      }
    }
    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext;
      try
      {
        string vrijeme = dataRowView.Vrijeme;
        string DELETE_QUERY = "DELETE from plan_vjezbanja where KANDIDAT_KORISNIK_idKorisnika='" + getCandidateId(dataRowView.Ime, dataRowView.Prezime) + "' and Datum='" + dataRowView.Datum + "' and Vrijeme='" + vrijeme + "'";
        MySqlCommand find = new MySqlCommand(DELETE_QUERY, DatabaseConnection.Instance.mySqlConnection);
        find.Prepare();
        find.ExecuteNonQuery();
        this.Hide();
        ExercisePlanWindow ew = new ExercisePlanWindow();
        ew.Show();
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

    private void dataGridViewExercisePlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

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
    private void dataGridViewExercisePlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
  }
  }



using Dnevnik_ishrane.views;
using MySql.Data.MySqlClient;
using Projekat_B_Dnevnik_ishrane.db_views;
using Projekat_B_Dnevnik_ishrane.models;
using Projekat_B_Dnevnik_ishrane.views;
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
    private int userId;
    private List<PlanView> listOfExercisePlans = new List<PlanView>();
    private dbModel dnevnikIshraneEntities = new dbModel();
    public ExercisePlanWindow(int candidateId)
    {
      this.userId = candidateId;
      Properties.Settings.Default.ColorMode = MainWindow.theme;
      this.Resources.MergedDictionaries.Add(MainWindow.resourceDictionary);
      InitializeComponent();
      initializeDataGrid();
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext; string nameOfCandidate = dataRowView.ImeKandidata;
      string surnameOfCandidate = dataRowView.PrezimeKandidata;
      DateTime dateTime = Convert.ToDateTime(dataRowView.DatumVrijeme);
      List<PlanView> listOfPlanViews = dnevnikIshraneEntities.plan_vjezbanja.Join(
    dnevnikIshraneEntities.korisniks, pi => pi.KANDIDAT_KORISNIK_idKORISNIK, k => k.idKORISNIK, (pi, k) =>
    new PlanView
    {
      DateAndTime = pi.DatumVrijeme,
      IdCoach = pi.TRENER_KORISNIK_idKORISNIK,
      IdCandidate = k.idKORISNIK,
      NameOfCandidate = k.Ime,
      SurnameOfCandidate = k.Prezime,
      IdPlan = pi.idPLAN_VJEZBANJA,
      CandidateActive=k.Aktivan
    })
      .Where(elem => elem.IdCoach == userId && elem.NameOfCandidate.Equals(nameOfCandidate) && elem.SurnameOfCandidate.Equals(surnameOfCandidate) && elem.CandidateActive==1).ToList();
      DateTime date = dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);
      List<PlanView> planForSelectedDateTime = listOfPlanViews.Where(elem => elem.DateAndTime.Date.AddHours(elem.DateAndTime.Hour).AddMinutes(elem.DateAndTime.Minute).Equals(date)).ToList();
      foreach (var elem in planForSelectedDateTime)
      {
        plan_vjezbanja exercisePlan = dnevnikIshraneEntities.plan_vjezbanja.Where(el => el.idPLAN_VJEZBANJA == elem.IdPlan).First();
        dnevnikIshraneEntities.plan_vjezbanja.Remove(exercisePlan);
        dnevnikIshraneEntities.SaveChanges();
      }
      initializeDataGrid();
    }

    private void initializeDataGrid()
    {
      if (MainWindow.checkIfUserIsCandidate(userId))
      {
        listOfExercisePlans = dnevnikIshraneEntities.plan_vjezbanja.Join(
       dnevnikIshraneEntities.korisniks, pi => pi.TRENER_KORISNIK_idKORISNIK, k => k.idKORISNIK, (pi, k) =>
       new PlanView
       {
         DateAndTime = pi.DatumVrijeme,
         IdCandidate = pi.KANDIDAT_KORISNIK_idKORISNIK,
         SurnameOfTrener = k.Prezime,
         NameOfTrener = k.Ime,
         IdPlan = pi.idPLAN_VJEZBANJA,
         CandidateActive=k.Aktivan
       })
         .Where(elem => elem.IdCandidate == userId && elem.CandidateActive==1).ToList();

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
        dataGridViewExercisePlan.ItemsSource = list;

        addingExercise.Visibility = Visibility.Hidden;
        dataGridViewExercisePlan.Columns[3].Visibility = Visibility.Hidden;
        dataGridViewExercisePlan.Columns[4].Visibility = Visibility.Hidden;
        dataGridViewExercisePlan.Columns[6].Visibility = Visibility.Hidden;
        dataGridViewExercisePlan.Columns[7].Visibility = Visibility.Hidden;
      }
      else
      {
        listOfExercisePlans = dnevnikIshraneEntities.plan_vjezbanja.Join(
    dnevnikIshraneEntities.korisniks, pi => pi.KANDIDAT_KORISNIK_idKORISNIK, k => k.idKORISNIK, (pi, k) =>
    new PlanView
    {
      DateAndTime = pi.DatumVrijeme,
      IdCandidate = pi.KANDIDAT_KORISNIK_idKORISNIK,
      IdCoach = pi.TRENER_KORISNIK_idKORISNIK,
      SurnameOfCandidate = k.Prezime,
      NameOfCandidate = k.Ime,
      IdPlan = pi.idPLAN_VJEZBANJA,
      CandidateActive=k.Aktivan
    })
      .Where(elem => elem.IdCoach == userId && elem.CandidateActive==1).ToList();

        var list = new List<dynamic>();
        int previousId = 0;
        for (int i = 0; i < listOfExercisePlans.Count; i++)
        {// i%7 da ne prikazuje za svaki dan posebno jedan te isti plan
          if ((listOfExercisePlans[i].IdPlan % 7) == 0)
          {
            list.Add(new
            {
              ImeKandidata = listOfExercisePlans[i].NameOfCandidate,
              PrezimeKandidata = listOfExercisePlans[i].SurnameOfCandidate,
              DatumVrijeme = listOfExercisePlans[i].DateAndTime

            });
          }
        }
        dataGridViewExercisePlan.ItemsSource = list;

        dataGridViewExercisePlan.Columns[0].Visibility = Visibility.Hidden;
        dataGridViewExercisePlan.Columns[1].Visibility = Visibility.Hidden;
      }
    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext;
      DateTime selectedDateAndTime = dataRowView.DatumVrijeme;
      string selectedNameOfCandidate = dataRowView.ImeKandidata;
      string selectedSurnameOfCandidate = dataRowView.PrezimeKandidata;
      Window window = new PlanWindow(userId, "exercisePlan", selectedDateAndTime, selectedNameOfCandidate, selectedSurnameOfCandidate);
      this.Hide();
      window.Show();
    }

    private void btnView_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        dynamic dataRowView = ((Button)e.Source).DataContext;
        DateTime dateAndTime = dataRowView.DatumVrijeme;
        selectedDateAndTime = dateAndTime;
        Window window = new ExercisePlanScheduleWindow(selectedDateAndTime, userId, this);
        this.Hide();
        window.Show();


      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message.ToString());
      }
    }

 

  


    private void dataGridViewExercisePlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void addExercisePlan(object sender, MouseButtonEventArgs e)
    {
      this.Hide();
      Window window = new PlanWindow(userId, "exercisePlan");
      window.Show();
    }

    private void Previous_Window_Click(object sender, MouseButtonEventArgs e)
    {
      this.Hide();
      if (MainWindow.checkIfUserIsCandidate(userId))
      {
        KandidatWindow kandidatWindow = new KandidatWindow(userId, dnevnikIshraneEntities);
        kandidatWindow.Show();
      }
      else
      {
        TrenerWindow trenerWindow = new TrenerWindow(userId, dnevnikIshraneEntities);
        trenerWindow.Show();
      }
    }

    private void Exit_Click(object sender, MouseButtonEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
  }



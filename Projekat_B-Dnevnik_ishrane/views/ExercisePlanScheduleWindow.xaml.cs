using MySql.Data.MySqlClient;
using Projekat_B_Dnevnik_ishrane.models;
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
  /// Interaction logic for ExercisePlanScheduleWindow.xaml
  /// </summary>
  public partial class ExercisePlanScheduleWindow : Window
  {
    private static dbModel dnevnikIshraneEntities = new dbModel();
    private List<plan_vjezbanja> selectedExercisePlan = new List<plan_vjezbanja>();
    private DateTime selectedDateTime;
    private int userId;
    private Window previousWindow;
    public ExercisePlanScheduleWindow(DateTime selectedDateTime,int userId, Window previousWindow)
    {

      this.selectedDateTime = selectedDateTime;
      this.userId = userId;
      this.previousWindow = previousWindow;
      Properties.Settings.Default.ColorMode = MainWindow.theme;
      this.Resources.MergedDictionaries.Add(MainWindow.resourceDictionary);
      InitializeComponent();
      InitializeFields();

    }

    private void InitializeFields()
    {
      DateTime date1 = selectedDateTime.Date.AddHours(selectedDateTime.Hour).AddMinutes(selectedDateTime.Minute);
      List<plan_vjezbanja>listExercisePlan = dnevnikIshraneEntities.plan_vjezbanja
        .Where(el => el.KANDIDAT_KORISNIK_idKORISNIK == userId || el.TRENER_KORISNIK_idKORISNIK == userId).ToList();
      List<plan_vjezbanja>selectedExercisePlan = listExercisePlan.Where(el => el.DatumVrijeme.Date.AddHours(el.DatumVrijeme.Hour).AddMinutes(el.DatumVrijeme.Minute).Equals(date1)).ToList();
      plan_vjezbanja mondayExercisePlan = selectedExercisePlan.Where(elem => elem.Dan.Equals("ponedjeljak")).First();
      if (mondayExercisePlan.Opis.Contains(","))
      {
        string[] mondayGroup = mondayExercisePlan.Opis.Split(',');
        for (int i = 0; i < mondayGroup.Length; i++)
        {
          MondayTextBlock.Text += mondayGroup[i] + "\n";
        }

      }
      else
      {
        MondayTextBlock.Text = mondayExercisePlan.Opis;
      }


      plan_vjezbanja tuesdayExercisePlan = selectedExercisePlan.Where(elem => elem.Dan.Equals("utorak")).First();
      if (tuesdayExercisePlan.Opis.Contains(","))
      {
        string[] tuesdayGroup = tuesdayExercisePlan.Opis.Split(',');
        for (int i = 0; i < tuesdayGroup.Length; i++)
        {
          TuesdayTextBlock.Text += tuesdayGroup[i] + "\n";
        }

      }
      else
      {
        TuesdayTextBlock.Text = tuesdayExercisePlan.Opis;
      }


      plan_vjezbanja wednesdayExercisePlan = selectedExercisePlan.Where(elem => elem.Dan.Equals("srijeda")).First();
      if (wednesdayExercisePlan.Opis.Contains(","))
      {
        string[] wednesdayGroup = wednesdayExercisePlan.Opis.Split(',');
        for (int i = 0; i < wednesdayGroup.Length; i++)
        {
          WednesdayTextBlock.Text += wednesdayGroup[i] + "\n";
        }

      }
      else
      {
        WednesdayTextBlock.Text = wednesdayExercisePlan.Opis;
      }


      plan_vjezbanja thuersdayExercisePlan = selectedExercisePlan.Where(elem => elem.Dan.Equals("četvrtak")).First();
      if (thuersdayExercisePlan.Opis.Contains(","))
      {
        string[] thuersdayGroup = thuersdayExercisePlan.Opis.Split(',');
        for (int i = 0; i < thuersdayGroup.Length; i++)
        {
          ThuersdayTextBlock.Text += thuersdayGroup[i] + "\n";
        }

      }
      else
      {
        ThuersdayTextBlock.Text = thuersdayExercisePlan.Opis;
      }


      plan_vjezbanja fridayExercisePlan = selectedExercisePlan.Where(elem => elem.Dan.Equals("petak")).First();
      if (fridayExercisePlan.Opis.Contains(","))
      {
        string[] fridayGroup = fridayExercisePlan.Opis.Split(',');
        for (int i = 0; i < fridayGroup.Length; i++)
        {
          FridayTextBlock.Text += fridayGroup[i] + "\n";
        }

      }
      else
      {
        FridayTextBlock.Text = fridayExercisePlan.Opis;
      }
      plan_vjezbanja saturdayExercisePlan = selectedExercisePlan.Where(elem => elem.Dan.Equals("subota")).First();
      if (saturdayExercisePlan.Opis.Contains(","))
      {
        string[] saturdayGroup = saturdayExercisePlan.Opis.Split(',');
        for (int i = 0; i < saturdayGroup.Length; i++)
        {
          SaturdayTextBlock.Text += saturdayGroup[i] + "\n";
        }

      }
      else
      {
        SaturdayTextBlock.Text = saturdayExercisePlan.Opis;
      }
      plan_vjezbanja sundayExercisePlan = selectedExercisePlan.Where(elem => elem.Dan.Equals("nedjelja")).First();
      if (sundayExercisePlan.Opis.Contains(","))
      {
        string[] sundayGroup = sundayExercisePlan.Opis.Split(',');
        for (int i = 0; i < sundayGroup.Length; i++)
        {
          SundayTextBlock.Text += sundayGroup[i] + "\n";
        }

      }
      else
      {
        SundayTextBlock.Text = sundayExercisePlan.Opis;
      }
    }


    private void Previous_Window_Click(object sender, MouseButtonEventArgs e)
    {
      this.Hide();
      previousWindow.Show();
    }
  }
}

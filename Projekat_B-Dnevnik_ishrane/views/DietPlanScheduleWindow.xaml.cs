using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using Projekat_B_Dnevnik_ishrane.models;

namespace Projekat_B_Dnevnik_ishrane
{
  /// <summary>
  /// Interaction logic for DietPlanScheduleWindow.xaml
  /// </summary>
  public partial class DietPlanScheduleWindow : Window
  {
    private static dbModel dnevnikIshraneEntities = new dbModel();
    private List<plan_ishrane> listDietPlan = new List<plan_ishrane>();
    private List<plan_ishrane> selectedDietPlan = new List<plan_ishrane>();
    private DateTime selectedDateTime;
    private Window previousWindow;
    private int userId;
    public DietPlanScheduleWindow(DateTime selectedDateTime,int userId,Window previousWindow)
    {

      this.selectedDateTime = selectedDateTime;
      this.previousWindow = previousWindow;
      this.userId = userId;
      Properties.Settings.Default.ColorMode = MainWindow.theme;
      InitializeComponent();
      InitializeFields();

    }

    private void InitializeFields()
    {
      DateTime date1 = selectedDateTime.Date.AddHours(selectedDateTime.Hour).AddMinutes(selectedDateTime.Minute);
      listDietPlan = dnevnikIshraneEntities.plan_ishrane
        .Where(el=> el.KANDIDAT_KORISNIK_idKORISNIK==userId || el.TRENER_KORISNIK_idKORISNIK == userId).ToList();
      selectedDietPlan = listDietPlan.Where(el => el.DatumVrijeme.Date.AddHours(el.DatumVrijeme.Hour).AddMinutes(el.DatumVrijeme.Minute).Equals(date1)).ToList();
      plan_ishrane mondayDietPlan = selectedDietPlan.Where(elem => elem.Dan.Equals("ponedjeljak")).First();
      if (mondayDietPlan.Opis.Contains(","))
      {
        string[] mondayGroup = mondayDietPlan.Opis.Split(',');
        for (int i = 0; i < mondayGroup.Length; i++)
        {
          MondayTextBlock.Text += mondayGroup[i] + "\n";
        }

      }
      else
      {
        MondayTextBlock.Text = mondayDietPlan.Opis;
      }


      plan_ishrane tuesdayDietPlan = selectedDietPlan.Where(elem => elem.Dan.Equals("utorak")).First();
      if (tuesdayDietPlan.Opis.Contains(","))
      {
        string[] tuesdayGroup = tuesdayDietPlan.Opis.Split(',');
        for (int i = 0; i < tuesdayGroup.Length; i++)
        {
          TuesdayTextBlock.Text += tuesdayGroup[i] + "\n";
        }

      }
      else
      {
        TuesdayTextBlock.Text = tuesdayDietPlan.Opis;
      }


      plan_ishrane wednesdayDietPlan = selectedDietPlan.Where(elem => elem.Dan.Equals("srijeda")).First();
      if (wednesdayDietPlan.Opis.Contains(","))
      {
        string[] wednesdayGroup = wednesdayDietPlan.Opis.Split(',');
        for (int i = 0; i < wednesdayGroup.Length; i++)
        {
          WednesdayTextBlock.Text += wednesdayGroup[i] + "\n";
        }

      }
      else
      {
        WednesdayTextBlock.Text = wednesdayDietPlan.Opis;
      }


      plan_ishrane thuersdayDietPlan = selectedDietPlan.Where(elem => elem.Dan.Equals("četvrtak")).First();
      if (thuersdayDietPlan.Opis.Contains(","))
      {
        string[] thuersdayGroup = thuersdayDietPlan.Opis.Split(',');
        for (int i = 0; i < thuersdayGroup.Length; i++)
        {
          ThuersdayTextBlock.Text += thuersdayGroup[i] + "\n";
        }

      }
      else
      {
        ThuersdayTextBlock.Text = thuersdayDietPlan.Opis;
      }


      plan_ishrane fridayDietPlan = selectedDietPlan.Where(elem => elem.Dan.Equals("petak")).First();
      if (fridayDietPlan.Opis.Contains(","))
      {
        string[] fridayGroup = fridayDietPlan.Opis.Split(',');
        for (int i = 0; i < fridayGroup.Length; i++)
        {
          FridayTextBlock.Text += fridayGroup[i] + "\n";
        }

      }
      else
      {
        FridayTextBlock.Text = fridayDietPlan.Opis;
      }
      plan_ishrane saturdayDietPlan = selectedDietPlan.Where(elem => elem.Dan.Equals("subota")).First();
      if (saturdayDietPlan.Opis.Contains(","))
      {
        string[] saturdayGroup = saturdayDietPlan.Opis.Split(',');
        for (int i = 0; i < saturdayGroup.Length; i++)
        {
          SaturdayTextBlock.Text += saturdayGroup[i] + "\n";
        }

      }
      else
      {
        SaturdayTextBlock.Text = saturdayDietPlan.Opis;
      }
      plan_ishrane sundayDietPlan = selectedDietPlan.Where(elem => elem.Dan.Equals("nedjelja")).First();
      if (sundayDietPlan.Opis.Contains(","))
      {
        string[] sundayGroup = sundayDietPlan.Opis.Split(',');
        for (int i = 0; i < sundayGroup.Length; i++)
        {
          SundayTextBlock.Text += sundayGroup[i] + "\n";
        }

      }
      else
      {
        SundayTextBlock.Text = sundayDietPlan.Opis;
      }
    }


    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Previous_Window_Click(object sender, RoutedEventArgs e)
    {
      this.Hide();
      previousWindow.Show();
    }
  }
}

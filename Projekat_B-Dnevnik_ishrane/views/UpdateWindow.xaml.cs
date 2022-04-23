
using Dnevnik_ishrane.exceptions;
using MySql.Data.MySqlClient;
using Projekat_B_Dnevnik_ishrane;
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

namespace Dnevnik_ishrane.views
{
  /// <summary>
  /// Interaction logic for UpdateWindow.xaml
  /// </summary>
  public partial class UpdateWindow : Window
  {
    private string whatIsUpdating;
    private int userId;
    private DateTime selectedDateTime;
    private string selectedNameOfCandidate;
    private string selectedSurnameOfCandidate;
    private dnevnik_ishrane_db_Entities dnevnikIshraneEntities = new dnevnik_ishrane_db_Entities();
    private string[] days = { "ponedjeljak", "utorak", "srijeda", "četvrtak", "petak", "subota", "nedjelja" };
    public UpdateWindow(int userId,string whatIsUpdating,DateTime selectedDateTime,string selectedName,string selectedSurname)
    {
      this.whatIsUpdating = whatIsUpdating;
      this.userId = userId;
      this.selectedNameOfCandidate = selectedName;
      this.selectedSurnameOfCandidate = selectedSurname;
      this.selectedDateTime = selectedDateTime;
      InitializeComponent();
      initializeTextFields(whatIsUpdating);
    }

    private void initializeTextFields(string whatIsUpdating)
    {
      if (whatIsUpdating == "exercisePlan")
      {
        initializeFieldsExercisePlan();
      }
      else
      {
        InitializeFieldsDietPlan();
      }
    }
    private void initializeFieldsExercisePlan()
    {
      var texts = new[]
   {
                MondayTextBox,
                TuesdayTextBox,
                WednesdayTextBox,
                ThuersdayTextBox,
                FridayTextBox,
                SaturdayTextBox,
                SundayTextBox
            };
      for (int j = 0; j < texts.Length; j++)
      {
        string content = "";
        string opis = exercisePlanForConcretDay(userId, selectedDateTime, days[j]);
        if (opis.Contains(","))
        {
          string[] opisGroup = opis.Split(',');
          for (int i = 0; i < opisGroup.Length; i++)
          {
            content += opisGroup[i] + Environment.NewLine;
          }
        }
        else
        {
          content = opis;
        }
        texts[j].Text = content;
      }
    }
    private void InitializeFieldsDietPlan()
    {
      var texts = new[]
      {
                MondayTextBox,
                TuesdayTextBox,
                WednesdayTextBox,
                ThuersdayTextBox,
                FridayTextBox,
                SaturdayTextBox,
                SundayTextBox
            };
      for (int j = 0; j < texts.Length; j++)
      {
        string content = "";
        string opis = dietPlanForConcretDay(userId, selectedDateTime, days[j]);
        if (opis.Contains(","))
        {
          string[] opisGroup = opis.Split(',');
          for (int i = 0; i < opisGroup.Length; i++)
          {
            content += opisGroup[i] + Environment.NewLine;
          }
        }
        else
        {
          content = opis;
        }
          texts[j].Text = content;   
      }
    }

    private string exercisePlanForConcretDay(int userId, DateTime selectedDateTime,string day)
    {
      List<plan_vjezbanja> list = dnevnikIshraneEntities.plan_vjezbanja.Where(e => e.Dan.Equals(day) && e.TRENER_KORISNIK_idKORISNIK == userId).ToList();
      foreach (var elem in list)
      {
        DateTime date1 = elem.DatumVrijeme.Date.AddHours(elem.DatumVrijeme.Hour).AddMinutes(elem.DatumVrijeme.Minute);
        DateTime date2 = selectedDateTime.Date.AddHours(selectedDateTime.Hour).AddMinutes(selectedDateTime.Minute);
        if (date1.Equals(date2))
        {
          return elem.Opis;
        }
      }
      return "no content";
    }
    private void SaveButtonClick(object sender, RoutedEventArgs e)
    {
       
        if ("dietPlan".Equals(whatIsUpdating))
        {
        updateDietPlanForConcretDay();
          this.Hide();
          DietPlanWindow dw = new DietPlanWindow(userId);
          dw.Show();
        }
        else
        {
        updateExercisePlanForConcretDay();
          this.Hide();
          ExercisePlanWindow ew = new ExercisePlanWindow(userId);
          ew.Show();
        }
    }

    private void updateDietPlanForConcretDay()
    {
      var texts = new[]
         {
                MondayTextBox,
                TuesdayTextBox,
                WednesdayTextBox,
                ThuersdayTextBox,
                FridayTextBox,
                SaturdayTextBox,
                SundayTextBox
            };
      for (int j = 0; j < texts.Length; j++)
      {
        if (String.IsNullOrEmpty(texts[j].Text))
        {
          throw new NotAllTextFieldsFilledException();
        }
      }
      for (int j = 0; j < 7; j++)
      {
        var planIshrane = new plan_ishrane()
        {
          Dan = days[j],
          idPLAN_ISHRANE = getIdForSelectedDietPlan(userId, selectedDateTime, days[j]),
          KANDIDAT_KORISNIK_idKORISNIK = getIdCandidate(days[j]),
          TRENER_KORISNIK_idKORISNIK = userId,
          Opis = texts[j].Text.Replace(Environment.NewLine, ","),
          DatumVrijeme = DateTime.UtcNow
        };
        dnevnik_ishrane_db_Entities db = new dnevnik_ishrane_db_Entities();
        db.plan_ishrane.Add(planIshrane);
        db.Entry(planIshrane).State = System.Data.Entity.EntityState.Modified;
        db.SaveChanges();
      }
    }
    private void updateExercisePlanForConcretDay()
    {
      var texts = new[]
        {
                MondayTextBox,
                TuesdayTextBox,
                WednesdayTextBox,
                ThuersdayTextBox,
                FridayTextBox,
                SaturdayTextBox,
                SundayTextBox
            };
      for (int j = 0; j < texts.Length; j++)
      {
        if (String.IsNullOrEmpty(texts[j].Text))
        {
          throw new NotAllTextFieldsFilledException();
        }
      }
      for (int j = 0; j < 7; j++)
      {
        var planVjezbanja = new plan_vjezbanja()
        {
          Dan = days[j],
          idPLAN_VJEZBANJA = getIdForSelectedExercisePlan(userId, selectedDateTime, days[j]),
          KANDIDAT_KORISNIK_idKORISNIK = getIdCandidate(days[j]),
          TRENER_KORISNIK_idKORISNIK = userId,
          Opis = texts[j].Text.Replace(Environment.NewLine, ","),
          DatumVrijeme = DateTime.UtcNow
        };
        dnevnik_ishrane_db_Entities db = new dnevnik_ishrane_db_Entities();
        db.plan_vjezbanja.Add(planVjezbanja);
        db.Entry(planVjezbanja).State = System.Data.Entity.EntityState.Modified;
        db.SaveChanges();
      }
    }
    private int getIdCandidate(string day)
    {
      if (whatIsUpdating.StartsWith("diet"))
      {
        int idDietPlan = getIdForSelectedDietPlan(userId, selectedDateTime, day);
        plan_ishrane pi = dnevnikIshraneEntities.plan_ishrane.Where(elem => elem.idPLAN_ISHRANE == idDietPlan && elem.Dan.Equals(day)).First();
        return pi.KANDIDAT_KORISNIK_idKORISNIK;
      }
      else
      {
        int idExercisePlan = getIdForSelectedExercisePlan(userId, selectedDateTime, day);
        plan_vjezbanja pv = dnevnikIshraneEntities.plan_vjezbanja.Where(elem => elem.idPLAN_VJEZBANJA == idExercisePlan && elem.Dan.Equals(day)).First();
        return pv.KANDIDAT_KORISNIK_idKORISNIK;
      }
    }
    private int getIdForSelectedDietPlan(int userId, DateTime dateTime,string day)
    {
      int id = 0;
      List<plan_ishrane> list = dnevnikIshraneEntities.plan_ishrane.Where(elem => elem.TRENER_KORISNIK_idKORISNIK == userId && elem.Dan.Equals(day)).ToList();
      foreach (var e in list )
      {
        DateTime date1 = e.DatumVrijeme.Date.AddHours(e.DatumVrijeme.Hour).AddMinutes(e.DatumVrijeme.Minute);
        DateTime date2 = dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);
        if (date1.Equals(date2))
        {
          id = e.idPLAN_ISHRANE;
        }
      }
      return id;
    }
    private int getIdForSelectedExercisePlan(int userId, DateTime dateTime,string day)
    {
      int id = 0;
      List<plan_vjezbanja> list = dnevnikIshraneEntities.plan_vjezbanja.Where(elem => elem.TRENER_KORISNIK_idKORISNIK == userId && elem.Dan.Equals(day)).ToList();
      foreach (var e in list)
      {
        DateTime date1 = e.DatumVrijeme.Date.AddHours(e.DatumVrijeme.Hour).AddMinutes(e.DatumVrijeme.Minute);
        DateTime date2 = dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);
        if (date1.Equals(date2))
        {
          id = e.idPLAN_VJEZBANJA;
        }
      }
      return id;
    }
    private string dietPlanForConcretDay(int userId, DateTime selectedDateTime, string day)
    {
      List<plan_ishrane> list = dnevnikIshraneEntities.plan_ishrane.Where(e => e.Dan.Equals(day) && e.TRENER_KORISNIK_idKORISNIK == userId).ToList();
      foreach (var elem in list)
      {
        DateTime date1 = elem.DatumVrijeme.Date.AddHours(elem.DatumVrijeme.Hour).AddMinutes(elem.DatumVrijeme.Minute);
        DateTime date2 = selectedDateTime.Date.AddHours(selectedDateTime.Hour).AddMinutes(selectedDateTime.Minute);
        if (date1.Equals(date2))
        {
          return elem.Opis;
        }
      }
      return "";
    }
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

  }
}

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
  /// Interaction logic for FoodStuffDetailsWindow.xaml
  /// </summary>
  public partial class FoodStuffDetailsWindow : Window
  {
    private string name;
    private int candidateId;
    private string typeOfMeal;
    private dnevnik_ishrane_db_Entities dnevnikIshraneEntities = new dnevnik_ishrane_db_Entities();
    private namirnica stuff;
    private double previousAmount;
    private double gkcalValue;
    private double gfatsValue;
    private double gproteinsValue;
    private double gcarbsvalue;

    private string action;
    public FoodStuffDetailsWindow(string name, int candidateId, string typeOfMeal,string action)
    {
      this.name = name;
      this.candidateId = candidateId;
      this.typeOfMeal = typeOfMeal;
      this.action = action;
      InitializeComponent();
      stuff = dnevnikIshraneEntities.namirnicas.Where(elem => elem.Naziv.Equals(name)).First();
      nameOfFoodStuff.Text = name;
      kcalTextBlock.Text = stuff.KalorijskaVrijednost.ToString();
      proteiniTextBlock.Text = stuff.Proteini.ToString();
      fatsTextBlock.Text = stuff.Masti.ToString();
      carbsTextBlock.Text = stuff.UgljikoHidrati.ToString();
      previousAmount = Double.Parse(textBox.Text);

      gkcalValue = Convert.ToDouble(kcalTextBlock.Text) / Convert.ToDouble(textBox.Text);
      gproteinsValue = Convert.ToDouble(proteiniTextBlock.Text) / Convert.ToDouble(textBox.Text);
      gcarbsvalue = Convert.ToDouble(carbsTextBlock.Text) / Convert.ToDouble(textBox.Text);
      gfatsValue = Convert.ToDouble(fatsTextBlock.Text) / Convert.ToDouble(textBox.Text);
    }

    private void onTextChanged(object sender, KeyEventArgs e)
    {

      if (textBox.Text != "")
      {
        kcalTextBlock.Text = (gkcalValue * Convert.ToDouble(textBox.Text)).ToString();
        proteiniTextBlock.Text = (gproteinsValue * Convert.ToDouble(textBox.Text)).ToString();
        fatsTextBlock.Text = (gfatsValue * Convert.ToDouble(textBox.Text)).ToString();
        carbsTextBlock.Text = (gcarbsvalue * Convert.ToDouble(textBox.Text)).ToString();
      }
    }

    private void saveStuff(object sender, RoutedEventArgs e)
    {
      var meal = new obrok()
      {
        KANDIDAT_KORISNIK_idKORISNIK = candidateId,
        NAMIRNICA_idNAMIRNICA = stuff.idNAMIRNICA,
        TipObroka = typeOfMeal,
        Kolicina = Decimal.Parse(textBox.Text),
        Datum=DateTime.UtcNow.Date
      };
        dnevnikIshraneEntities.obroks.Add(meal);
       dnevnikIshraneEntities.obroks.Add(meal);
      if (action.Equals("update"))
      {
        MealsWindow.sumOfKcals -= previousAmount;
        MealsWindow.sumOfKcals +=Double.Parse(kcalTextBlock.Text);
        dnevnikIshraneEntities.Entry(meal).State = System.Data.Entity.EntityState.Modified;
      }
      dnevnikIshraneEntities.SaveChanges();

      Window window = new MealsWindow(candidateId,action);
      this.Hide();
      window.Show();
      
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_B_Dnevnik_ishrane.db_views
{
  public class ObrokView
  {
    private DateTime date;
    private int idCandidate;
    private string nameOfFoodStuff;
    private double kcalFoodStuff;
    private string typeOfMeal;
    private int idFoodStuff;
    public ObrokView()
    {

    }
    public ObrokView(DateTime date, int idCandidate, string typeOfMeal, double kcalFoodStuff, string nameOfFoodStuff,int idFoodStuff)
    {
      this.date = date;
      this.idCandidate = idCandidate;
      this.typeOfMeal = typeOfMeal;
      this.nameOfFoodStuff = nameOfFoodStuff;
      this.kcalFoodStuff = kcalFoodStuff;
      this.idFoodStuff = idFoodStuff;

    }

    public DateTime Date { get => date; set => date = value; }
    public int IdCandidate { get => idCandidate; set => idCandidate = value; }
    public string TypeOfMeal { get => typeOfMeal; set => typeOfMeal = value; }
    public string NameOfFoodStuff { get => nameOfFoodStuff; set => nameOfFoodStuff = value; }

    public double KcalFoodStuff { get => kcalFoodStuff; set => kcalFoodStuff = value; }
    public int IdFoodStuff { get => idFoodStuff; set => idFoodStuff = value; }
  }
}


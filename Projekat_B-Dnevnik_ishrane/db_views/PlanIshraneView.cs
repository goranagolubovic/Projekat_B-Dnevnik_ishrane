using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_B_Dnevnik_ishrane.db_views
{
  public class PlanIshraneView
  {
    private DateTime dateAndTime;
    private int idCandidate;
    private string nameOfTrener;
    private string surnameOfTrener;
    private int idDietPlan;
    public PlanIshraneView()
    {

    }
    public PlanIshraneView(DateTime dateAndTime, int idCandidate, string surnameOfTrener, string nameOfTrener,int idDietPlan)
    {
      this.dateAndTime = dateAndTime;
      this.idCandidate = idCandidate;
      this.surnameOfTrener = surnameOfTrener;
      this.nameOfTrener = nameOfTrener;
      this.idDietPlan = idDietPlan;

    }

    public DateTime DateAndTime { get => dateAndTime; set => dateAndTime = value; }
    public int IdCandidate { get => idCandidate; set => idCandidate = value; }
    public string NameOfTrener { get => nameOfTrener; set => nameOfTrener = value; }
    public string SurnameOfTrener { get => surnameOfTrener; set => surnameOfTrener = value; }

    public int IdDietPlan { get => idDietPlan; set => idDietPlan = value; }

  }
  }

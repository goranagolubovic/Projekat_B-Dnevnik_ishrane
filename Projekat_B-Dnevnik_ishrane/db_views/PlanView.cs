using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_B_Dnevnik_ishrane.db_views
{
  public class PlanView
  {
    private DateTime dateAndTime;
    private int idCandidate;
    private string nameOfTrener;
    private string surnameOfTrener;
    private string nameOfCandidate;
    private string surnameOfCandidate;
    private int idPlan;
    private int idCoach;
    public PlanView()
    {

    }
    public PlanView(DateTime dateAndTime, int idCandidate,int idCoach, string surnameOfTrener, string nameOfTrener,string nameOfCandidate,string surnameOfCandidate,int idPlan)
    {
      this.dateAndTime = dateAndTime;
      this.idCandidate = idCandidate;
      this.idCoach = idCoach;
      this.surnameOfTrener = surnameOfTrener;
      this.nameOfTrener = nameOfTrener;
      this.nameOfCandidate = nameOfCandidate;
      this.surnameOfCandidate = surnameOfCandidate;
      this.idPlan = idPlan;

    }

    public DateTime DateAndTime { get => dateAndTime; set => dateAndTime = value; }
    public int IdCandidate { get => idCandidate; set => idCandidate = value; }
    public string NameOfTrener { get => nameOfTrener; set => nameOfTrener = value; }
    public string SurnameOfTrener { get => surnameOfTrener; set => surnameOfTrener = value; }
    public string NameOfCandidate { get => nameOfCandidate; set => nameOfCandidate = value; }
    public string SurnameOfCandidate { get => surnameOfCandidate; set => surnameOfCandidate = value; }
    public int IdCoach { get => idCoach; set => idCoach = value; }
    public int IdPlan { get => idPlan; set => idPlan = value; }

  }
  }

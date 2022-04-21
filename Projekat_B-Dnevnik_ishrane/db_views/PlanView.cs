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
    private int idPlan;
    public PlanView()
    {

    }
    public PlanView(DateTime dateAndTime, int idCandidate, string surnameOfTrener, string nameOfTrener,int idPlan)
    {
      this.dateAndTime = dateAndTime;
      this.idCandidate = idCandidate;
      this.surnameOfTrener = surnameOfTrener;
      this.nameOfTrener = nameOfTrener;
      this.idPlan = idPlan;

    }

    public DateTime DateAndTime { get => dateAndTime; set => dateAndTime = value; }
    public int IdCandidate { get => idCandidate; set => idCandidate = value; }
    public string NameOfTrener { get => nameOfTrener; set => nameOfTrener = value; }
    public string SurnameOfTrener { get => surnameOfTrener; set => surnameOfTrener = value; }

    public int IdPlan { get => idPlan; set => idPlan = value; }

  }
  }

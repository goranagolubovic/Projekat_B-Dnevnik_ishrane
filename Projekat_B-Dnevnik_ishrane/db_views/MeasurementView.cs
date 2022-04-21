using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_B_Dnevnik_ishrane.db_views
{
  public class MeasurementView
  {
    private DateTime dateAndTime;
    private int idCandidate;
    private string nameOfTrener;
    private string surnameOfTrener;
    private decimal weight;

    public MeasurementView()
    {

    }
    public MeasurementView(DateTime dateAndTime, int idCandidate, string surnameOfTrener, string nameOfTrener,decimal weight)
    {
      this.dateAndTime = dateAndTime;
      this.idCandidate = idCandidate;
      this.surnameOfTrener = surnameOfTrener;
      this.nameOfTrener = nameOfTrener;
      this.weight = weight;

    }

    public DateTime DateAndTime { get => dateAndTime; set => dateAndTime = value; }
    public int IdCandidate { get => idCandidate; set => idCandidate = value; }
    public string NameOfTrener { get => nameOfTrener; set => nameOfTrener = value; }
    public string SurnameOfTrener { get => surnameOfTrener; set => surnameOfTrener = value; }

    public decimal Weight { get => weight; set => weight = value; }

  }
  }

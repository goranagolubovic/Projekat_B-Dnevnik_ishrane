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
    private string nameOfTrener;
    private string surnameOfTrener;
    private string nameOfCandidate;
    private string surnameOfCandidate;
    private int id;
    private int yearOfBirth;
    private decimal weight;

    public MeasurementView()
    {

    }
    public MeasurementView(DateTime dateAndTime, int id, string surnameOfTrener, string nameOfTrener, string surnameOfCandidate, string nameOfCandidate,int yearOfBirth,decimal weight)
    {
      this.dateAndTime = dateAndTime;
      this.id = id;
      this.nameOfCandidate = nameOfCandidate;
      this.surnameOfCandidate = surnameOfCandidate;
      this.yearOfBirth = yearOfBirth;
      this.surnameOfTrener = surnameOfTrener;
      this.nameOfTrener = nameOfTrener;
      this.weight = weight;

    }

    public DateTime DateAndTime { get => dateAndTime; set => dateAndTime = value; }
    public int Id { get => id; set => id = value; }
    public string NameOfTrener { get => nameOfTrener; set => nameOfTrener = value; }
    public string SurnameOfTrener { get => surnameOfTrener; set => surnameOfTrener = value; }
    public string NameOfCandidate { get => nameOfCandidate; set => nameOfCandidate = value; }
    public string SurnameOfCandidate { get => surnameOfCandidate; set => surnameOfCandidate = value; }
    public int YearOfBirth { get => yearOfBirth; set => yearOfBirth = value; }
    public decimal Weight { get => weight; set => weight = value; }

  }
  }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_B_Dnevnik_ishrane.db_views
{
  public class CandidateView
  {
    private int coachId;
    private string nameOfCandidate;
    private string surnameOfCandidate;
    private int yearOfBirth;
    private string username;
    private string password;
    private int active;

    public CandidateView()
    {

    }
    public CandidateView(int coachId,string surnameOfCandidate, string nameOfCandidate, int yearOfBirth, string username,string password,int active)
    {
      this.coachId = coachId;
      this.nameOfCandidate = nameOfCandidate;
      this.surnameOfCandidate = surnameOfCandidate;
      this.yearOfBirth = yearOfBirth;
      this.username = username;
      this.password = password;
      this.active = active;
    }

    public int CoachId { get => coachId; set => coachId = value; }
    public string NameOfCandidate { get => nameOfCandidate; set => nameOfCandidate = value; }
    public string SurnameOfCandidate { get => surnameOfCandidate; set => surnameOfCandidate = value; }
    public int YearOfBirth { get => yearOfBirth; set => yearOfBirth = value; }
    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
    public int Active { get => active; set => active = value; }
  }
}

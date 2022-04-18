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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekat_B_Dnevnik_ishrane
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    private static dnevnik_ishrane_db_Entities dnevnikIshraneEntities = new dnevnik_ishrane_db_Entities();
    private korisnik user;
    private static List<kandidat> listOfCandidates = new List<kandidat>();
    private int matchedUserId = -1;
    public MainWindow()
        {
            InitializeComponent();
        }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      user = dnevnikIshraneEntities.korisniks.Where(elem =>
      elem.KorisnickoIme.Equals(UserNameField.Text.Trim())
      && elem.Lozinka.Equals(PasswordField.Password.ToString().Trim())).First();
      if (user != null)
      {
        matchedUserId = user.idKORISNIK;
          if (checkIfUserIsCandidate(matchedUserId))
          {
            Window KandidatWindow = new KandidatWindow(matchedUserId, dnevnikIshraneEntities);
            this.Hide();
            KandidatWindow.Show();
          }
          else
          {
            Window TrenerWindow = new TrenerWindow();
            this.Hide();
            TrenerWindow.Show();
          }
      }
      else
      {
        MessageBox.Show("Korisnicko ime ili lozinka nisu ispravno uneseni.");
      }
    }
    public static bool checkIfUserIsCandidate(int matchedUserId)
    {
      bool isCandidate = false;
      listOfCandidates = dnevnikIshraneEntities.kandidats.ToList();
      foreach(kandidat k in listOfCandidates)
      {
        if (k.KORISNIK_idKORISNIK == matchedUserId)
        {
          isCandidate = true;
        }
      }
      return isCandidate;
    }
  }
}

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
using Projekat_B_Dnevnik_ishrane.models;
using Projekat_B_Dnevnik_ishrane.views;
namespace Projekat_B_Dnevnik_ishrane
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    private static dbModel dnevnikIshraneEntities = new dbModel();
    private korisnik user;
    private static List<kandidat> listOfCandidates = new List<kandidat>();
    private int matchedUserId = -1;
    public static string theme = "candy";
    public MainWindow()
        {
            InitializeComponent();
        }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      user = dnevnikIshraneEntities.korisniks.Where(elem =>
      elem.KorisnickoIme.Equals(UserNameField.Text.Trim())
      && elem.Lozinka.Equals(PasswordField.Password.ToString().Trim())).FirstOrDefault();
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
          Window TrenerWindow = new TrenerWindow(matchedUserId, dnevnikIshraneEntities);
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

    private void DarkMode_Checked(object sender, RoutedEventArgs e)
    {
      Properties.Settings.Default.ColorMode = "dark";
      theme = "dark";
      Properties.Settings.Default.Save();
    }

    private void LightMode_Checked(object sender, RoutedEventArgs e)
    {
      Properties.Settings.Default.ColorMode = "light";
      theme = "light";
      Properties.Settings.Default.Save();
    }

    private void CandyMode_Checked(object sender, RoutedEventArgs e)
    {
      Properties.Settings.Default.ColorMode = "candy";
      theme = "candy";
      Properties.Settings.Default.Save();
    }
  }
}

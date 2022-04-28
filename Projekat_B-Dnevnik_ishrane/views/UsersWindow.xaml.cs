using Projekat_B_Dnevnik_ishrane.db_views;
using Projekat_B_Dnevnik_ishrane.models;
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
  /// Interaction logic for UsersWindow.xaml
  /// </summary>
  public partial class UsersWindow : Window
  {
    private Window previousWindow;
    private int coachId;
    private dbModel dnevnikIshraneEntities = new dbModel();

    public UsersWindow(int coachId, Window previousWindow)
    {
      this.coachId = coachId;
      this.previousWindow = previousWindow;
      Properties.Settings.Default.ColorMode = MainWindow.theme;
      this.Resources.MergedDictionaries.Add(MainWindow.resourceDictionary);
      InitializeComponent();
      initializeDataGrid();
    }
    public void initializeDataGrid()
    {
      List<CandidateView>listOfCandidates = dnevnikIshraneEntities.kandidats.Join(
       dnevnikIshraneEntities.korisniks, k => k.KORISNIK_idKORISNIK, u => u.idKORISNIK, (k, u) =>
       new CandidateView
       {
         CoachId = k.TRENER_KORISNIK_idKORISNIK,
         SurnameOfCandidate = u.Prezime,
         NameOfCandidate = u.Ime,
         YearOfBirth = u.Godiste,
         Username=u.KorisnickoIme,
         Password=u.Lozinka,
         Active=u.Aktivan
       })
         .Where(elem => elem.CoachId == coachId && elem.Active==1).ToList();

      var list = new List<dynamic>();
      for (int i = 0; i < listOfCandidates.Count; i++)
      {
          list.Add(new
          {
            Ime = listOfCandidates[i].NameOfCandidate,
            Prezime = listOfCandidates[i].SurnameOfCandidate,
            Godiste = listOfCandidates[i].YearOfBirth

          });
      }
      dataGridViewUser.ItemsSource = list;

    }
    private void btnView_Click(object sender, RoutedEventArgs e)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext;
      Window window = new ViewUserWindow(dataRowView.Ime, dataRowView.Prezime, dataRowView.Godiste, this);
      this.Hide();
      window.Show();
    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext;
      Window window = new AddUserWindow(coachId,"update",dataRowView.Ime, dataRowView.Prezime, dataRowView.Godiste, this);
      this.Hide();
      window.Show();
    }
    private int findId(string name, string surname, int year)
    {
      korisnik k = dnevnikIshraneEntities.korisniks.Where(elem => elem.Ime.Equals(name) && elem.Prezime.Equals(surname) && elem.Godiste.Equals(year) && elem.Aktivan == 1).FirstOrDefault();
      if (k != null)
        return k.idKORISNIK;
      return 0;
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
      dynamic dataRowView = ((Button)e.Source).DataContext;
      int id = findId(dataRowView.Ime, dataRowView.Prezime, dataRowView.Godiste);
      korisnik oldUser = dnevnikIshraneEntities.korisniks.Where(elem => elem.idKORISNIK == id && elem.Aktivan==1).FirstOrDefault();
      oldUser.Aktivan = 0;
      dnevnikIshraneEntities.korisniks.Add(oldUser);
      dnevnikIshraneEntities.Entry(oldUser).State = System.Data.Entity.EntityState.Modified;
      dnevnikIshraneEntities.SaveChanges();
      initializeDataGrid();
    }
 

    private void dataGridViewUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void addCandidate(object sender, MouseButtonEventArgs e)
    {
      Window window = new AddUserWindow(coachId,"add",this);
      this.Hide();
      window.Show();
    }

    private void Exit(object sender, MouseButtonEventArgs e)
    {
      Application.Current.Shutdown();
    }

    private void goBack(object sender, MouseButtonEventArgs e)
    {
      this.Hide();
      previousWindow.Show();
    }
  }
}

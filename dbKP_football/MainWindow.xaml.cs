using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections;
using System;
using System.Collections.ObjectModel;

namespace dbKP_football
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            Data.db.leagues.Load();
            //League_ComboBox.DataContext = Leagues;
        }
        //private static db_KP_FootballEntities db = new db_KP_FootballEntities();
        public ObservableCollection<leagues> leagues = Data.GetLeagues();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private leagues selectedLeague = new leagues();
        public leagues SelectedLeague
        {
            get { return selectedLeague; }
            set { selectedLeague = value;
                Data.League_Id = value.L_ID;
                OnPropertyChanged("SelectedLeague"); }
        }

        private void Teams_buttonClick(object sender, RoutedEventArgs e)
        {
            var teams = new Teams();
            teams.Show();

        }

        private void Players_buttonClick(object sender, RoutedEventArgs e)
        {
            var footPlayers = new FootPlayers();
            footPlayers.Show();
        }

        private void Stadiums_buttonClick(object sender, RoutedEventArgs e)
        {
            var stadiums = new Stadiums();
            stadiums.Show();
        }

        private void Coaches_buttonClick(object sender, RoutedEventArgs e)
        {
            var coaches = new Coaches();
            coaches.Show();
        }

        private void Aboat_buttonClick(object sender, RoutedEventArgs e)
        {
            var about = new AboutTheProgramm();
            about.Show();
        }

        private void Exit_buttonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

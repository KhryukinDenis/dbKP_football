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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in db.leagues)
                League_ComboBox.Items.Add(item);
            League_ComboBox.DisplayMemberPath = "L_NAME";
            db.leagues.Load();

        }
        private static db_KP_FootballEntities db = new db_KP_FootballEntities();
        

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

        private void League_ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Data.League_Id = (League_ComboBox.SelectedItem as leagues).L_ID;
        }
    }
}

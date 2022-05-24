using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace dbKP_football
{
    /// <summary>
    /// Логика взаимодействия для Teams.xaml
    /// </summary>
    public partial class Teams : Window
    {
        public Teams()
        {
            InitializeComponent();
            db.teams.Load();
            team.Binding = new Binding("T_NAME");
            tourn.Binding = new Binding("T_TOURNIER");
            year.Binding = new Binding("T_YEAROFFOUND");
            stad.Binding = new Binding("stadiums.S_NAME");
            coach.Binding = new Binding("coaches.C_SURNAME");
            refresh();
        }


        private db_KP_FootballEntities db = new db_KP_FootballEntities();


        private void TAdd_button_Click(object sender, RoutedEventArgs e)
        {
            var TEAMS = new teams()
            {
                L_ID = Data.League_Id,
                T_NAME = textBox_nameTeam.Text,
                T_TOURNIER = Tournier_ComboBox.Text,
                T_QUAFOOTPLAYERS = int.Parse(textBox_quaFootPlayers.Text),
                T_YEAROFFOUND = int.Parse(textBox_YearOfFound.Text),
                S_ID = int.Parse(textBox_stadiumID.Text),
                C_ID = int.Parse(textBox_coachID.Text)
            };
            db.teams.Add(TEAMS);
            db.SaveChanges();
            refresh();
            Clear();
        }

        private void Clear()
        {
            textBox_nameTeam.Clear();
            Tournier_ComboBox.SelectedIndex = -1;
            textBox_quaFootPlayers.Clear();
            textBox_YearOfFound.Clear();
            textBox_stadiumID.Clear();
            textBox_coachID.Clear();
            textBox_searchT.Clear();
        }

        private void TClear_button_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            refresh();
        }

        private void TChange_button1_Click(object sender, RoutedEventArgs e)
        {
            var changeTea = db.teams.Find((T_dataGrid.SelectedItem as teams).T_ID);
            var t_changed = new T_Changed(changeTea);
            t_changed.Closing += T_changed_Closing;
            t_changed.Show();
        }

        private void T_changed_Closing(object sender, System.EventArgs e)
        {
            db.SaveChanges();
            refresh();
        }

        private void TDelete_button_Click(object sender, RoutedEventArgs e)
        {
            var delTeam = db.teams.Find((T_dataGrid.SelectedItem as teams).T_ID);
            db.teams.Remove(delTeam);
            db.SaveChanges();
            refresh();
        }

        private void TSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                T_dataGrid.Items.Clear();
                foreach (var i in Data.SearchInTeams(db, textBox_searchT.Text))
                {
                    T_dataGrid.Items.Add(i);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void refresh()
        {
            T_dataGrid.Items.Clear();
            SqlParameter l_id = new SqlParameter("@l_id", Data.League_Id);
            foreach (var i in db.teams.SqlQuery("select * from teams where l_id = @l_id", l_id))
            {
                T_dataGrid.Items.Add(i);
            }
            T_dataGrid.Items.Refresh();
        }

        private void PlayersClick(object sender, RoutedEventArgs e)
        {
            Data.Team_Id = (T_dataGrid.SelectedItem as teams).T_ID;
            var footPlayers = new FootPlayers();
            footPlayers.Show();
        }

        private void DefenseDurNum(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DefenseDurRusLet(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^А-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBox_searchT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    T_dataGrid.Items.Clear();
                    foreach (var i in Data.SearchInTeams(db, textBox_searchT.Text))
                    {
                        T_dataGrid.Items.Add(i);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}

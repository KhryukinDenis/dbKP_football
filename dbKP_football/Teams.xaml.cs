using System.Data.Entity;
using System.Linq;
using System.Windows;

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
            T_dataGrid.ItemsSource = db.teams.Local.ToBindingList();
        }

        private void refresh()
        {
            T_dataGrid.Items.Clear();
            foreach (var i in db.teams)
                T_dataGrid.Items.Add(i);
            T_dataGrid.Items.Refresh();
        }
        private db_KP_FootballEntities db = new db_KP_FootballEntities();


        private void TAdd_button_Click(object sender, RoutedEventArgs e)
        {
            var TEAMS = new teams()
            {
                T_NAME = textBox_nameTeam.Text,
                T_TOURNIER = Tournier_ComboBox.Text,
                T_QUAFOOTPLAYERS = int.Parse(textBox_quaFootPlayers.Text),
                T_YEAROFFOUND = int.Parse(textBox_YearOfFound.Text),
                S_ID = int.Parse(textBox_stadiumID.Text),
                C_ID = int.Parse(textBox_coachID.Text)
            };
            if (!db.teams.Any(u => u.T_NAME == TEAMS.T_NAME))
                db.teams.Add(TEAMS);

            T_dataGrid.Items.Refresh();
            db.SaveChanges();
        }

        private void TClear_button_Click(object sender, RoutedEventArgs e)
        {
            textBox_nameTeam.Clear();
            Tournier_ComboBox.SelectedIndex = -1;
            textBox_quaFootPlayers.Clear();
            textBox_YearOfFound.Clear();
            textBox_stadiumID.Clear();
            textBox_coachID.Clear();
        }

        private void TChange_button_Click(object sender, RoutedEventArgs e)
        {
            var changeTeam = db.teams.Find((T_dataGrid.SelectedItem as teams).T_ID);
        }

        private void TDelete_button_Click(object sender, RoutedEventArgs e)
        {
            var delTeam = db.teams.Find((T_dataGrid.SelectedItem as teams).T_ID);
            db.teams.Remove(delTeam);
            db.SaveChanges();
        }
    }
}

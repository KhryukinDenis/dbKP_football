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
            Data.db.teams.Load();
            T_dataGrid.ItemsSource = Data.db.teams.Local.ToBindingList();
            textBox_nameTeam.Text = Data.League_Id.ToString();
        }
        //private db_KP_FootballEntities db = new db_KP_FootballEntities();


        private void TAdd_button_Click(object sender, RoutedEventArgs e)
        {
            var TEAMS = new teams()
            {
                L_ID = int.Parse(textBox_leaguesID.Text),
                T_NAME = textBox_nameTeam.Text,
                T_TOURNIER = Tournier_ComboBox.Text,
                T_QUAFOOTPLAYERS = int.Parse(textBox_quaFootPlayers.Text),
                T_YEAROFFOUND = int.Parse(textBox_YearOfFound.Text),
                S_ID = int.Parse(textBox_stadiumID.Text),
                C_ID = int.Parse(textBox_coachID.Text)
            };
            if (!Data.db.teams.Any(u => u.T_NAME == TEAMS.T_NAME))
                Data.db.teams.Add(TEAMS);

            T_dataGrid.Items.Refresh();
            Data.db.SaveChanges();
        }

        private void TClear_button_Click(object sender, RoutedEventArgs e)
        {
            textBox_leaguesID.Clear();
            textBox_nameTeam.Clear();
            Tournier_ComboBox.SelectedIndex = -1;
            textBox_quaFootPlayers.Clear();
            textBox_YearOfFound.Clear();
            textBox_stadiumID.Clear();
            textBox_coachID.Clear();
        }

        private void TChange_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TDelete_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

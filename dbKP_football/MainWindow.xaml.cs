using System.Data.Entity;
using System.Windows;

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
            if (League_ComboBox.SelectedItem == null)
                MessageBox.Show("Выберите лигу!","Ошибка");
            else
            {
                var teams = new Teams();
                teams.Owner = this;
                teams.Show();
            }

        }

        private void Stadiums_buttonClick(object sender, RoutedEventArgs e)
        {
            if (League_ComboBox.SelectedItem == null)
                MessageBox.Show("Выберите лигу!", "Ошибка");
            else
            {
                var stadiums = new Stadiums();
                stadiums.Owner = this;
                stadiums.Show();
            }
        }

        private void Coaches_buttonClick(object sender, RoutedEventArgs e)
        {
            if (League_ComboBox.SelectedItem == null)
                MessageBox.Show("Выберите лигу!", "Ошибка");
            else
            {
                var coaches = new Coaches();
                coaches.Owner = this;
                coaches.Show();
            }
        }

        private void Aboat_buttonClick(object sender, RoutedEventArgs e)
        { 
            var about = new AboutTheProgramm();
            about.Owner = this;
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

using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace dbKP_football
{
    /// <summary>
    /// Логика взаимодействия для Stadiums.xaml
    /// </summary>
    public partial class Stadiums : Window
    {
        public Stadiums()
        {
            InitializeComponent();
            db.stadiums.Load();
            name.Binding = new Binding("S_NAME");
            cap.Binding = new Binding("S_CAPACITY");
            year.Binding = new Binding("S_YEAROPENING");
            city.Binding = new Binding("S_LOCATIONCITY");
            refresh();
        }
        private db_KP_FootballEntities db = new db_KP_FootballEntities();

        private void TAdd_button3_Click(object sender, RoutedEventArgs e)
        {
            var STADIUMS = new stadiums()
            {
                S_NAME = textBox_nameStadium.Text,
                S_CAPACITY = int.Parse(textBox_capacity.Text),
                S_YEAROPENING = int.Parse(textBox_YearOpening.Text),
                S_LOCATIONCITY = textBox_LocationCity.Text,
                L_ID = Data.League_Id
            };
            if (!db.stadiums.Any(u => u.S_NAME == STADIUMS.S_NAME))
                db.stadiums.Add(STADIUMS);

            db.SaveChanges();
            Clear();
            refresh();
        }

        private void Clear()
        {
            textBox_nameStadium.Clear();
            textBox_capacity.Clear();
            textBox_YearOpening.Clear();
            textBox_LocationCity.Clear();
        }

        private void TClear_button3_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void SChange_button1_Click(object sender, RoutedEventArgs e)
        {
            var changeStad = db.stadiums.Find((S_dataGrid.SelectedItem as stadiums).S_ID);
            var s_changed = new S_Changed(changeStad);
            s_changed.Closing += S_changed_Closing;
            s_changed.Show();
        }

        private void S_changed_Closing(object sender, System.EventArgs e)
        {
            db.SaveChanges();
            refresh();
        }

        private void SDelete_button_Click(object sender, RoutedEventArgs e)
        {
            var delStad = db.stadiums.Find((S_dataGrid.SelectedItem as stadiums).S_ID);
            db.stadiums.Remove(delStad);
            db.SaveChanges();
            refresh();
        }

        private void refresh()
        {
            S_dataGrid.Items.Clear();
            SqlParameter l_id = new SqlParameter("@l_id", Data.League_Id);
            foreach (var i in db.stadiums.SqlQuery("select * from stadiums where L_ID = @l_id",l_id))
                S_dataGrid.Items.Add(i);
            S_dataGrid.Items.Refresh();
        }
    }
}

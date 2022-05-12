using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace dbKP_football
{
    /// <summary>
    /// Логика взаимодействия для FootPlayers.xaml
    /// </summary>
    public partial class FootPlayers : Window
    {
        public FootPlayers()
        {
            InitializeComponent();
            db.footplayers.Load();
            FP_dataGrid.ItemsSource = db.footplayers.Local.ToBindingList();
        }
        private db_KP_FootballEntities db = new db_KP_FootballEntities();

        private void TAdd_button2_Click(object sender, RoutedEventArgs e)
        {
            var FOOTPLAYERS = new footplayers()
            {
                T_ID = int.Parse(textBox_teamID.Text),
                FP_SURNAME = textBox_surnamePlayers.Text,
                FP_NAME = textBox_namePlayers.Text,
                FP_DATEOFBIRTH = (DateTime)datePicker_dateOfBirthPlayers.SelectedDate,
                FP_NATIONALITY = textBox_nationalityPlayers.Text,
                FP_POSITION = Position_ComboBox.Text,
                FP_TEAMNUMBER = int.Parse(textBox_teamNumber.Text),
                FP_GROWTH = Convert.ToDouble(textBox_growth.Text),
                FP_WEIGHT = Convert.ToDouble(textBox_weight.Text),
                FP_WORKINGLEG = WorkingLeg_ComboBox.Text
            };
            if (!db.footplayers.Any(u => u.FP_TEAMNUMBER == FOOTPLAYERS.FP_TEAMNUMBER))
                db.footplayers.Add(FOOTPLAYERS);

            FP_dataGrid.Items.Refresh();
            db.SaveChanges();
        }

        private void TClear_button2_Click(object sender, RoutedEventArgs e)
        {
            textBox_teamID.Clear();
            textBox_surnamePlayers.Clear();
            textBox_namePlayers.Clear();
            datePicker_dateOfBirthPlayers.SelectedDate = null;
            textBox_nationalityPlayers.Clear();
            Position_ComboBox.SelectedIndex = 0;
            textBox_teamNumber.Clear();
            textBox_growth.Clear();
            textBox_weight.Clear();
            WorkingLeg_ComboBox.SelectedIndex = 0;
        }

        private void FTChange_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FTDelete_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

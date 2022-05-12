using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace dbKP_football
{
    /// <summary>
    /// Логика взаимодействия для Coaches.xaml
    /// </summary>
    public partial class Coaches : Window
    {
        public Coaches()
        {
            InitializeComponent();
            db.coaches.Load();
            surname.Binding = new Binding("C_SURNAME");
            name.Binding = new Binding("C_NAME");
            nation.Binding = new Binding("C_NATIONALITY");
            birthdate.Binding = new Binding("C_DATEOFBIRTH");
            refresh();
        }
        private db_KP_FootballEntities db = new db_KP_FootballEntities();

        private void TAdd_button4_Click(object sender, RoutedEventArgs e)
        {
            var COACHES = new coaches()
            {
                C_SURNAME = textBox_surnameCoaches.Text,
                C_NAME = textBox_nameCoaches.Text,
                C_NATIONALITY = textBox_nationalityCoaches.Text,
                C_DATEOFBIRTH = (DateTime)datePicker_dateOfBirthCoaches.SelectedDate,
                L_ID = Data.League_Id
            };

            db.SaveChanges();
            Clear();
            refresh();
        }

        private void Clear()
        {
            textBox_surnameCoaches.Clear();
            textBox_nameCoaches.Clear();
            textBox_nationalityCoaches.Clear();
            datePicker_dateOfBirthCoaches.SelectedDate = null;
        }

        private void TClear_button4_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void CChange_button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CDelete_button_Click(object sender, RoutedEventArgs e)
        {
            var delCoa = db.coaches.Find((C_dataGrid.SelectedItem as coaches).C_ID);
            db.coaches.Remove(delCoa);
            db.SaveChanges();
            refresh();
        }

        private void refresh()
        {
            C_dataGrid.Items.Clear();
            SqlParameter l_id = new SqlParameter("@l_id", Data.League_Id);
            foreach (var i in db.coaches.SqlQuery("select * from coaches where L_ID = @l_id", l_id))
            C_dataGrid.Items.Add(i);
            C_dataGrid.Items.Refresh();
        }
    }
}

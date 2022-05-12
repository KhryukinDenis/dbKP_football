using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

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
            C_dataGrid.ItemsSource = db.coaches.Local.ToBindingList();
        }
        private db_KP_FootballEntities db = new db_KP_FootballEntities();

        private void TAdd_button4_Click(object sender, RoutedEventArgs e)
        {
            var COACHES = new coaches()
            {
                C_SURNAME = textBox_surnameCoaches.Text,
                C_NAME = textBox_nameCoaches.Text,
                C_NATIONALITY = textBox_nationalityCoaches.Text,
                C_DATEOFBIRTH = (DateTime)datePicker_dateOfBirthCoaches.SelectedDate
            };
            //if

            C_dataGrid.Items.Refresh();
            db.SaveChanges();
        }

        private void TClear_button4_Click(object sender, RoutedEventArgs e)
        {
            textBox_surnameCoaches.Clear();
            textBox_nameCoaches.Clear();
            textBox_nationalityCoaches.Clear();
            datePicker_dateOfBirthCoaches.SelectedDate = null;
        }

        private void CChange_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CDelete_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

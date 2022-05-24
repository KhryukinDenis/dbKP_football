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

            db.coaches.Add(COACHES);
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
            textBox_searchC.Clear();
        }

        private void TClear_button4_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            refresh();
        }

        private void CChange_button1_Click(object sender, RoutedEventArgs e)
        {
            var changeCoa = db.coaches.Find((C_dataGrid.SelectedItem as coaches).C_ID);
            var c_changed = new C_Changed(changeCoa);
            c_changed.Closing += C_changed_Closing;
            c_changed.Show();
        }

        private void C_changed_Closing(object sender, System.EventArgs e)
        {
            db.SaveChanges();
            refresh();
        }

        private void CDelete_button_Click(object sender, RoutedEventArgs e)
        {
            var delCoa = db.coaches.Find((C_dataGrid.SelectedItem as coaches).C_ID);
            db.coaches.Remove(delCoa);
            db.SaveChanges();
            refresh();
        }

        private void CSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                C_dataGrid.Items.Clear();
                foreach (var i in Data.SearchInCoaches(db, textBox_searchC.Text))
                {
                    C_dataGrid.Items.Add(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void refresh()
        {
            C_dataGrid.Items.Clear();
            SqlParameter l_id = new SqlParameter("@l_id", Data.League_Id);
            foreach (var i in db.coaches.SqlQuery("select * from coaches where L_ID = @l_id", l_id))
            C_dataGrid.Items.Add(i);
            C_dataGrid.Items.Refresh();
        }

        private void DefenseDurRusLet(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^А-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DefenseDurDate(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBox_searchC_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    C_dataGrid.Items.Clear();
                    foreach (var i in Data.SearchInCoaches(db, textBox_searchC.Text))
                    {
                        C_dataGrid.Items.Add(i);
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

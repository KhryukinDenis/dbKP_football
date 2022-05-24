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
    /// Логика взаимодействия для FootPlayers.xaml
    /// </summary>
    public partial class FootPlayers : Window
    {
        public FootPlayers()
        {
            InitializeComponent();
            db.footplayers.Load();
            surname.Binding = new Binding("FP_SURNAME");
            name.Binding = new Binding("FP_NAME");
            birthdate.Binding = new Binding("FP_DATEOFBIRTH");
            nation.Binding = new Binding("FP_NATIONALITY");
            posit.Binding = new Binding("FP_POSITION");
            number.Binding = new Binding("FP_TEAMNUMBER");
            grow.Binding = new Binding("FP_GROWTH");
            weig.Binding = new Binding("FP_WEIGHT");
            leg.Binding = new Binding("FP_WORKINGLEG");
            refresh();
        }
        private db_KP_FootballEntities db = new db_KP_FootballEntities();

        private void FPAdd_button2_Click(object sender, RoutedEventArgs e)
        {
            var FOOTPLAYERS = new footplayers()
            {
                T_ID = Data.Team_Id,
                FP_SURNAME = textBox_surnamePlayers.Text,
                FP_NAME = textBox_namePlayers.Text,
                FP_DATEOFBIRTH = (DateTime)datePicker_dateOfBirthPlayers.SelectedDate,
                FP_NATIONALITY = textBox_nationalityPlayers.Text,
                FP_POSITION = Position_ComboBox.Text,
                FP_TEAMNUMBER = int.Parse(textBox_teamNumber.Text),
                FP_GROWTH = Convert.ToDouble(textBox_growth.Text),
                FP_WEIGHT = Convert.ToDouble(textBox_weight.Text),
                FP_WORKINGLEG = WorkingLeg_ComboBox.Text,
            };

            db.footplayers.Add(FOOTPLAYERS);
            db.SaveChanges();
            Clear();
            refresh();
        }

        private void Clear()
        {
            textBox_surnamePlayers.Clear();
            textBox_namePlayers.Clear();
            datePicker_dateOfBirthPlayers.SelectedDate = null;
            textBox_nationalityPlayers.Clear();
            Position_ComboBox.SelectedIndex = 0;
            textBox_teamNumber.Clear();
            textBox_growth.Clear();
            textBox_weight.Clear();
            WorkingLeg_ComboBox.SelectedIndex = 0;
            textBox_searchFP.Clear();
        }

        private void FPClear_button2_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            refresh();
        }

        private void FPChange_button1_Click(object sender, RoutedEventArgs e)
        {
            var changeFplay = db.footplayers.Find((FP_dataGrid.SelectedItem as footplayers).FP_ID);
            var fp_changed = new FP_Changed(changeFplay);
            fp_changed.Closing += FP_changed_Closing;
            fp_changed.Show();
        }

        private void FP_changed_Closing(object sender, System.EventArgs e)
        {
            db.SaveChanges();
            refresh();
        }

        private void FPDelete_button_Click(object sender, RoutedEventArgs e)
        {
            var delFplay = db.footplayers.Find((FP_dataGrid.SelectedItem as footplayers).FP_ID);
            db.footplayers.Remove(delFplay);
            db.SaveChanges();
            refresh();
        }

       private void FPSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FP_dataGrid.Items.Clear();
                foreach (var i in Data.SearchInFootplayers(db, textBox_searchFP.Text))
                {
                    FP_dataGrid.Items.Add(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void refresh()
        {
            FP_dataGrid.Items.Clear();
            SqlParameter t_id = new SqlParameter("@t_id", Data.Team_Id);
            foreach (var i in db.footplayers.SqlQuery("select * from footplayers where T_ID = @t_id", t_id))
                FP_dataGrid.Items.Add(i);
            FP_dataGrid.Items.Refresh();
        }

        private void DefenseDurNum(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DefenseDurRusLet(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^а-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DefenseDurDate(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBox_searchFP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    FP_dataGrid.Items.Clear();
                    foreach (var i in Data.SearchInFootplayers(db, textBox_searchFP.Text))
                    {
                        FP_dataGrid.Items.Add(i);
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

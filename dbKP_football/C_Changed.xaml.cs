using System;
using System.Windows;

namespace dbKP_football
{
    /// <summary>
    /// Логика взаимодействия для C_Changed.xaml
    /// </summary>
    public partial class C_Changed : Window
    {
        public C_Changed(coaches coa)
        {
            InitializeComponent();
            Coa = coa;
        }

        public coaches Coa { get; }

        private void CChange_button2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_UPsurnameCoaches.Text != "") Coa.C_SURNAME = textBox_UPsurnameCoaches.Text;
            if (textBox_UPnameCoaches.Text != "") Coa.C_NAME = textBox_UPnameCoaches.Text;
            if (textBox_UPnationalityCoaches.Text != "") Coa.C_NATIONALITY = textBox_UPnationalityCoaches.Text;
            if (UPdatePicker_dateOfBirthCoaches.SelectedDate != null) Coa.C_DATEOFBIRTH = (DateTime)UPdatePicker_dateOfBirthCoaches.SelectedDate;
            this.Close();
        }
    }
}

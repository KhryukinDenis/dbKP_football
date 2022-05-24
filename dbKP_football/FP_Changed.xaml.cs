using System;
using System.Windows;

namespace dbKP_football
{
    /// <summary>
    /// Логика взаимодействия для FP_Changed.xaml
    /// </summary>
    public partial class FP_Changed : Window
    {
        public FP_Changed(footplayers fplay)
        {
            InitializeComponent();
            Fplay = fplay;
        }

        public footplayers Fplay { get; }

        private void FPChange_button2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_UPteamID.Text != "") Fplay.T_ID = int.Parse(textBox_UPteamID.Text);
            if (textBox_UPsurnamePlayers.Text != "") Fplay.FP_SURNAME = textBox_UPsurnamePlayers.Text;
            if (textBox_UPnamePlayers.Text != "") Fplay.FP_NAME = textBox_UPnamePlayers.Text;
            if (UPdatePicker_dateOfBirthPlayers.SelectedDate != null) Fplay.FP_DATEOFBIRTH = (DateTime)UPdatePicker_dateOfBirthPlayers.SelectedDate;
            if (textBox_UPnationalityPlayers.Text != "") Fplay.FP_NATIONALITY = textBox_UPnationalityPlayers.Text;
            if (UPPosition_ComboBox.Text != "") Fplay.FP_POSITION = UPPosition_ComboBox.Text;
            if (textBox_UPteamNumber.Text != "") Fplay.FP_TEAMNUMBER = int.Parse(textBox_UPteamNumber.Text);
            if (textBox_UPgrowth.Text != "") Fplay.FP_GROWTH = Convert.ToDouble(textBox_UPgrowth.Text);
            if (textBox_UPweight.Text != "") Fplay.FP_WEIGHT = Convert.ToDouble(textBox_UPweight.Text);
            if (UPWorkingLeg_ComboBox.Text != "") Fplay.FP_WORKINGLEG = UPWorkingLeg_ComboBox.Text;
            this.Close();
        }
    }
}

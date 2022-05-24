using System.Windows;

namespace dbKP_football
{
    /// <summary>
    /// Логика взаимодействия для T_Changed.xaml
    /// </summary>
    public partial class T_Changed : Window
    {
        public T_Changed(teams tea)
        {
            InitializeComponent();
            Tea = tea;
        }

        public teams Tea { get; }

        private void TChange_button2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_UPnameTeam.Text != "") Tea.T_NAME = textBox_UPnameTeam.Text;
            if (UPTournier_ComboBox.Text != "") Tea.T_TOURNIER = UPTournier_ComboBox.Text;
            if (textBox_UPquaFootPlayers.Text != "") Tea.T_QUAFOOTPLAYERS = int.Parse(textBox_UPquaFootPlayers.Text);
            if (textBox_UPYearOfFound.Text != "") Tea.T_YEAROFFOUND = int.Parse(textBox_UPYearOfFound.Text);
            if (textBox_UPstadiumID.Text != "") Tea.S_ID = int.Parse(textBox_UPstadiumID.Text);
            if (textBox_UPcoachID.Text != "") Tea.C_ID = int.Parse(textBox_UPcoachID.Text);
            this.Close();
        }
    }
}

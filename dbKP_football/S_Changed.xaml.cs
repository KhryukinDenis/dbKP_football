using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dbKP_football
{
    /// <summary>
    /// Логика взаимодействия для S_Changed.xaml
    /// </summary>
    public partial class S_Changed : Window
    {
        public S_Changed(stadiums stad)
        {
            InitializeComponent();
            Stad = stad;
        }

        public stadiums Stad { get; }

        private void SChange_button2_Click(object sender, RoutedEventArgs e)
        {
            if(textBox_UPcapacity.Text!="") Stad.S_CAPACITY = int.Parse(textBox_UPcapacity.Text);
            if(textBox_UPLocationCity.Text != "") Stad.S_LOCATIONCITY = textBox_UPLocationCity.Text;
            if(textBox_UPnameStadium.Text != "") Stad.S_NAME = textBox_UPnameStadium.Text;
            if(textBox_UPYearOpening.Text != "") Stad.S_YEAROPENING = int.Parse(textBox_UPYearOpening.Text);
            this.Close();
        }
    }
}

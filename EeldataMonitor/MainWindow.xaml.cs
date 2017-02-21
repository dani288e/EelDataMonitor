using EelDataMonitor.DAL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EelDataMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<SensorData> _sensorData;
        private Bassin _bassin;
        private int hallID;

        public MainWindow()
        {
            _sensorData = new List<SensorData>();
            _bassin = new Bassin();
            InitializeComponent();
        }

        private void dataGrid_SensorDatas_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var result in DALManagerSingleton.Instance.GetSesnsorDatas(_sensorData))
            {
                dataGrid_SensorDatas.Items.Add( new { result.SensorID, result.AmbientTemperature, result.ID});
            }
        }

        private void btn_Feed_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_CreateBassin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hallID = int.Parse(txtBox_HallID.Text);

                if (DALManagerSingleton.Instance.CreateBassin(_bassin, hallID) == true)
                {
                    MessageBox.Show("Successfully created bassin");
                }
                else
                {
                    MessageBox.Show("An error occurred while trying to create bassin");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a number");
            }
        }
    }
}

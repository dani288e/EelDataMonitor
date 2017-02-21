using EelDataMonitor.DAL;
using EelDataMonitor.Networking;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Windows;

namespace EelDataMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<SensorData> _sensorData;
        private Bassin _bassin;
        private int _hallID;


        public MainWindow()
        {
            _sensorData = new List<SensorData>();
            _bassin = new Bassin();
            if (ConnectionManagerSingleton.Instance.ConnectToServer() == false) { MessageBox.Show("Could not connect to socket server");}
            InitializeComponent();
        }

        private void DataGrid_SensorDatas_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var result in DALManagerSingleton.Instance.GetSesnsorDatas(_sensorData))
            {
                dataGrid_SensorDatas.Items.Add(new { result.SensorID, result.AmbientTemperature, result.ID });
            }
        }

        private void btn_Feed_Click(object sender, RoutedEventArgs e)
        {
            string ip = txtBox_IP.Text;
            ConnectionManagerSingleton.Instance.SendFeed(ip);
        }



        private void btn_CreateBassin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _hallID = int.Parse(txtBox_HallID.Text);

                if (DALManagerSingleton.Instance.CreateBassin(_bassin, _hallID) == true)
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
                MessageBox.Show("Please enter a valid HallID", ex.ToString());
            }
        }

        private void txtBox_HallID_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBox_HallID.Text = string.Empty;
        }

        private void txtBox_IP_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBox_IP.Text = string.Empty;
        }
    }
}

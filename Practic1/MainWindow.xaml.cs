using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Practic1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDb; Initial Catalog = Aboba; Integrated Security = SSPI");
                connection.Open();
                MainGrid.Background = new SolidColorBrush(Colors.LightGreen);
                OutPutText.Text = "Подключено";
            }
            catch
            {
                OutPutText.Text = "Error";
                MainGrid.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Close();
                MainGrid.Background = new SolidColorBrush(Colors.GhostWhite);
                OutPutText.Text = "Отключено";
            }
            catch
            {
                OutPutText.Text = "Error: Сервер не подключен";
                MainGrid.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OutPutText.Text = "";
            string MySelect = @" Select average_grade From Aboba";
            SqlCommand command = new SqlCommand(MySelect, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    OutPutText.Text += sqlDataReader[i] + "\t";
                }
                OutPutText.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            OutPutText.Text = "";
            string MySelect = @" select FIO min_subject_name from Aboba where average_grade< " + Vvod.Text;
            SqlCommand command = new SqlCommand(MySelect, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    OutPutText.Text += sqlDataReader[i] + "\t";
                }
                OutPutText.Text += "\n";
            }
            sqlDataReader.Close();
           
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            
                OutPutText.Text = "";
                string MySelect = @" select FIO max_subject_name from Aboba where average_grade> " + Vvod.Text;
                SqlCommand command = new SqlCommand(MySelect, connection);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        OutPutText.Text += sqlDataReader[i] + "\t";
                    }
                    OutPutText.Text += "\n";
                }
                sqlDataReader.Close();

            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            OutPutText.Text = "";
            string MySelect = @" Select * From Aboba";
            SqlCommand command = new SqlCommand(MySelect, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    OutPutText.Text += sqlDataReader[i] + "\t";
                }
                OutPutText.Text += "\n";
            }
            sqlDataReader.Close();
        }
    }
}

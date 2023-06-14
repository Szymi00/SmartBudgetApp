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
using System.Windows.Shapes;

namespace Towam___projekt__1_
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }

        SqlConnection con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True");
        private void Clear()
        {
            username.Text = "";
            password.Password = "";
        }

        private void Register_Btt_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Password == "")
            {
                MessageBox.Show("Missing Information!");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True");
                    con.Open();
                    // user is table of LRDATABASE
                    //string add_data = "INSERT INTO [dbo].[user] VALUES(@username,@password)";
                    string add_data = "INSERT INTO [dbo].[user](username,password) VALUES(@username,@password)";
                    SqlCommand cmd = new SqlCommand(add_data, con);


                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@password", password.Password);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Register Completed.");
                    con.Close();
                    Clear();
                    //username.Text = "";
                    //password.Password = "";
                    MainWindow w1 = new MainWindow();
                    this.Close();
                    w1.Show();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void Back_Btt_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w1 = new MainWindow();
            w1.Show();
            this.Close();
   
        }
    }
}

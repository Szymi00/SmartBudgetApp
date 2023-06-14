using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Towam___projekt__1_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string User;
        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }

        private void Clear()
        {
            username.Text = "";
            password.Password = "";
        }

        private void Login_Btt_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Password == "")
            {
                MessageBox.Show("Incorrect password or username!");
            }
            SqlConnection con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM [dbo].[user] WHERE username='" + username.Text + "' AND password='" + password.Password + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                User = username.Text;
                MainApplicationWindow m1 = new MainApplicationWindow();
                this.Close();
                m1.Show();
            }
            else
            {
                MessageBox.Show("Password or Username is not correct");
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Register r1 = new Register();
            this.Close();
            r1.Show();
        }
    }
}

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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            UpdateProgress();
        }

        private double progressPercentage;

        private void AddSavingsGoal(string name, double amount)
        {
            using (SqlConnection con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO savings_goals(goal_name, goal_amount, current_amount, goal_date, saving_user) VALUES (@name, @amount, 0, @date, @user)", con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@user", MainWindow.User);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void UpdateProgress()
        {
            using (SqlConnection con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT goal_name, goal_amount, current_amount FROM [dbo].[savings_goals] WHERE saving_user = @user", con);
                    cmd.Parameters.AddWithValue("@user", MainWindow.User);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        labelGoalName.Content = reader.GetString(0);
                        double amount = reader.GetDouble(1);
                        Console.WriteLine("amount: " + amount);
                        double progress = reader.GetDouble(2);
                        Console.WriteLine("progress: " + progress);
                        double progressPercentage = (progress / amount) * 100;
                        progressBar.Value = progressPercentage;
                        if (progressPercentage > 100)
                            progressPercentage = 100;
                        if (progressPercentage < 0)
                            progressPercentage = 0;
                        UpdateColor();
                        reader.Close();
                    }
                }
                catch (Exception)
                {
                    con.Close();
                }
            }
        }

        private void UpdateColor()
        {
            if (progressPercentage >= 0 && progressPercentage < 25)
                progressBar.Foreground = new SolidColorBrush(Colors.Red);
            else if (progressPercentage >= 25 && progressPercentage < 50)
                progressBar.Foreground = new SolidColorBrush(Colors.Orange);
            else if (progressPercentage >= 50 && progressPercentage < 75)
                progressBar.Foreground = new SolidColorBrush(Colors.Yellow);
            else if (progressPercentage >= 75 && progressPercentage <= 100)
                progressBar.Foreground = new SolidColorBrush(Colors.Green);
        }

        //private void UpdateSavingsProgress(double current_amount)
        //{
        //    using (SqlConnection con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True"))
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("SELECT current_amount FROM [dbo].[savings_goals] WHERE saving_user = @user", con);
        //        cmd.Parameters.AddWithValue("@user", MainWindow.User);
        //        double previous_amount = Convert.ToDouble(cmd.ExecuteScalar());
        //        cmd = new SqlCommand("UPDATE savings_goals SET current_amount = @current_amount WHERE saving_user = @user", con);
        //        cmd.Parameters.AddWithValue("@current_amount", current_amount + previous_amount);
        //        cmd.Parameters.AddWithValue("@user", MainWindow.User);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}

        private void UpdateSavingsProgress(double current_amount)
        {
            using (SqlConnection con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT current_amount FROM [dbo].[savings_goals] WHERE saving_user = @user", con);
                cmd.Parameters.AddWithValue("@user", MainWindow.User);
                double previous_amount = Convert.ToDouble(cmd.ExecuteScalar());
                cmd = new SqlCommand("UPDATE savings_goals SET current_amount = @current_amount WHERE saving_user = @user", con);
                cmd.Parameters.AddWithValue("@current_amount", current_amount + previous_amount);
                cmd.Parameters.AddWithValue("@user", MainWindow.User);
                cmd.ExecuteNonQuery();
                con.Close();
                UpdateProgress(); 
            }
        }

        private void btnAddSavings_Click(object sender, RoutedEventArgs e)
        {
            string name = txtSavingsName.Text;
            double amount;
            if (double.TryParse(txtSavingsAmount.Text, out amount))
            {
                AddSavingsGoal(name, amount);
                UpdateProgress();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            double savings;
            if (double.TryParse(txtSavings.Text, out savings))
            {
                UpdateSavingsProgress(savings);
                UpdateProgress();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Incomes Obj = new Incomes();
            Obj.Show();
            this.Hide();
        }
    }
}

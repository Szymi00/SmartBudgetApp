using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ViewIncome.xaml
    /// </summary>
    public partial class ViewIncome : Window
    { 
        public ViewIncome()
        {
            InitializeComponent();
            FillComboBox();
            ResizeMode = ResizeMode.NoResize;
        }

        private void Logout_btt_Click(object sender, RoutedEventArgs e)
        {
            MainWindow r1 = new MainWindow();
            this.Close();
            r1.Show();
        }

        private void Dashboard_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainApplicationWindow Obj = new MainApplicationWindow();
            Obj.Show();
            this.Hide();
        }

        private void IncLbl_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Incomes Obj = new Incomes();
            Obj.Show();
            this.Hide();
        }

        private void ExpLbl_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Expenses Obj = new Expenses();
            Obj.Show();
            this.Hide();
        }


        private void ViewExpLbl_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewExpenses Obj = new ViewExpenses();
            Obj.Show();
            this.Hide();
        }

        private void DispalyIncomes()
        {
            //Con.Open();
            //string Query = "SELECT * FROM IncomeTbl";
            //SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            //SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            //var ds = new DataSet();
            //sda.Fill(ds);

            //Con.Close();
        }

        SqlConnection Con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True");

        private void IncomeDGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Load_inc_table_txt_click(object sender, RoutedEventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True");

            try
            {
                Con.Open();
                string Query = "SELECT IncName, IncAmt, IncCat, IncDesc, IncDate FROM IncomeTbl WHERE IncUser = @user ";
                if (IncCatBox.SelectedIndex != 0)
                {
                    if (IncCatBox.SelectedValue.ToString() != "All")
                    {
                        Query += "AND IncCat = @category ";
                    }
                }
                if (!string.IsNullOrEmpty(IncCatLbl.Text))
                {
                    Query += "AND IncName = @name ";
                }

                SqlCommand cmd = new SqlCommand(Query, Con);

                if (IncCatBox.SelectedIndex != 0)
                {
                    if (IncCatBox.SelectedValue.ToString() != "All")
                    {
                        cmd.Parameters.AddWithValue("@category", IncCatBox.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
                    }
                }
                if (!string.IsNullOrEmpty(IncCatLbl.Text))
                {
                    cmd.Parameters.AddWithValue("@name", IncCatLbl.Text);
                }

                cmd.Parameters.AddWithValue("@user", MainWindow.User);
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("IncomeTbl");
                sda.Fill(dt);
                IncomeDGV.ItemsSource = dt.DefaultView;
                sda.Update(dt);

                Con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Choose category.");
            }
            //try
            //{
            //    Con.Open();
            //    string Query = "SELECT * FROM IncomeTbl";
            //    SqlCommand cmd = new SqlCommand(Query, Con);
            //    cmd.ExecuteNonQuery();

            //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable("IncomeTbl");
            //    sda.Fill(dt);
            //    IncomeDGV.ItemsSource = dt.DefaultView;
            //    sda.Update(dt);

            //    Con.Close();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        class ComboBoxItem
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private void FillComboBox()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();
            items.Add(new ComboBoxItem { Name = "All", Value = "All" });
            items.Add(new ComboBoxItem { Name = "Salary", Value = "Salary" });
            items.Add(new ComboBoxItem { Name = "Savings", Value = "Saving" });
            items.Add(new ComboBoxItem { Name = "PocketMoney", Value = "PocketMoney" });
            items.Add(new ComboBoxItem { Name = "Other", Value = "Other" });
            IncCatBox.ItemsSource = items;
            IncCatBox.DisplayMemberPath = "Name";
            IncCatBox.SelectedValuePath = "Value";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window3 obj = new Window3();
            obj.Show();
            this.Hide();
        }
    }
}

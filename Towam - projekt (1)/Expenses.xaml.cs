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
    /// Interaction logic for Expenses.xaml
    /// </summary>
    public partial class Expenses : Window
    {
        public Expenses()
        {
            InitializeComponent();
            GetTotExp();
            FillComboBox();
            ResizeMode = ResizeMode.NoResize;
        }

        private void Logout_btt_Click(object sender, RoutedEventArgs e)
        {
            MainWindow r1 = new MainWindow();
            this.Close();
            r1.Show();
        }

        private void DashLbl_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
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

        private void ViewIncLbl_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewIncome Obj = new ViewIncome();
            Obj.Show();
            this.Hide();
        }

        private void ViewExpLbl_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewExpenses Obj = new ViewExpenses();
            Obj.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True");
        private void Clear()
        {
            ExpNameTb.Text = " ";
            ExpAmtTb.Text = " ";
            ExpDescTb.Text = " ";
            CatCb.SelectedIndex = 0;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ExpNameTb.Text == " " || ExpAmtTb.Text == " " || ExpDescTb.Text == " " || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {

                decimal expAmt;
                try
                {
                    expAmt = Convert.ToDecimal(ExpAmtTb.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Expense Amount");
                    return;
                }

                Con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ExpenseTbl(ExpName,ExpAmt,ExpCat,ExpDate,ExpDesc,ExpUser)VALUES(@EN,@EA,@EC,@ED,@EDe,@EU)", Con);
                cmd.Parameters.AddWithValue("@EN", ExpNameTb.Text);
                cmd.Parameters.AddWithValue("@EA", Convert.ToDecimal(ExpAmtTb.Text));
                cmd.Parameters.AddWithValue("@EC", CatCb.SelectedValue);
                cmd.Parameters.AddWithValue("@ED", ExpDate.SelectedDate.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@EDe", ExpDescTb.Text);
                cmd.Parameters.AddWithValue("@EU", MainWindow.User);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Expense Added!");
                Con.Close();
                Clear();
            }
        }

        private void GetTotExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Sum(ExpAmt) FROM ExpenseTbl WHERE ExpUser='" + MainWindow.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            TotExpLbl.Text = dt.Rows[0][0].ToString() + "zł";
            Con.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        class ComboBoxItem
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private void FillComboBox()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();
            items.Add(new ComboBoxItem { Name = "Food", Value = "Food" });
            items.Add(new ComboBoxItem { Name = "Clothes", Value = "Clothes" });
            items.Add(new ComboBoxItem { Name = "Medical", Value = "Medical" });
            items.Add(new ComboBoxItem { Name = "Household", Value = "Household" });
            items.Add(new ComboBoxItem { Name = "Travel", Value = "Travel" });
            items.Add(new ComboBoxItem { Name = "Vehicle", Value = "Vehicle" });
            items.Add(new ComboBoxItem { Name = "Other", Value = "Other" });
            CatCb.ItemsSource = items;
            CatCb.DisplayMemberPath = "Name";
            CatCb.SelectedValuePath = "Value";
        }
    }

    
}

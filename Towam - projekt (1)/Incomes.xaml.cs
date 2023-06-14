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
using System.Data.SqlClient;
using System.Data;

namespace Towam___projekt__1_
{
    /// <summary>
    /// Interaction logic for Incomes.xaml
    /// </summary>
    public partial class Incomes : Window
    {
        public Incomes()
        {
            InitializeComponent();
            GetTotInc();
            FillComboBox();
            ResizeMode = ResizeMode.NoResize;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DashLbl_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainApplicationWindow Obj = new MainApplicationWindow();
            Obj.Show();
            this.Hide();
        }

        private void ExpLbl_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Expenses Obj = new Expenses();
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

        private void Logout_btt_Click(object sender, RoutedEventArgs e)
        {
            MainWindow r1 = new MainWindow();
            this.Close();
            r1.Show();
        }

        SqlConnection Con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True");
        private void Clear()
        {
            IncNameTb.Text = " ";
            IncAmtTb.Text = " ";
            IncDescTb.Text = " ";
            CatCb.SelectedIndex = 0;
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IncNameTb.Text == " " || IncAmtTb.Text == " " || IncDescTb.Text == " " || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {

                decimal incAmt;
                try
                {
                    incAmt = Convert.ToDecimal(IncAmtTb.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Expense Amount");
                    return;
                }

                Con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO IncomeTbl(IncName,IncAmt,IncCat,IncDate,IncDesc,IncUser)VALUES(@IN,@IA,@IC,@ID,@IDe,@IU)", Con);
                cmd.Parameters.AddWithValue("@IN",IncNameTb.Text);
                cmd.Parameters.AddWithValue("@IA",Convert.ToDecimal(IncAmtTb.Text));
                cmd.Parameters.AddWithValue("@IC",((ComboBoxItem)CatCb.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@ID",IncDate.SelectedDate.Value.Date);
                cmd.Parameters.AddWithValue("@IDe",IncDescTb.Text);
                cmd.Parameters.AddWithValue("@IU",MainWindow.User);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Income Added!");
                Con.Close();
                Clear();
            }
        }
        //CatCb.SelectedItem.ToString());
        private void GetTotInc()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Sum(IncAmt) FROM IncomeTbl WHERE IncUser='" + MainWindow.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            TotIncLbl.Text = dt.Rows[0][0].ToString() + "zł";
            Con.Close();
        }

        //private void CatCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
            
        //}

        class ComboBoxItem
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private void FillComboBox()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();
            items.Add(new ComboBoxItem { Name = "Salary", Value = "Salary" });
            items.Add(new ComboBoxItem { Name = "Savings", Value = "Saving" });
            items.Add(new ComboBoxItem { Name = "PocketMoney", Value = "PocketMoney" });
            items.Add(new ComboBoxItem { Name = "Other", Value = "Other" });
            CatCb.ItemsSource = items;
            CatCb.DisplayMemberPath = "Name";
            CatCb.SelectedValuePath = "Value";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 Obj = new Window1();
            Obj.Show();
            this.Hide();
        }
    }
}

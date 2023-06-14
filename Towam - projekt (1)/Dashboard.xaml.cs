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
    /// Interaction logic for MainApplicationWindow.xaml
    /// </summary>
    public partial class MainApplicationWindow : Window
    {
        public MainApplicationWindow()
        {
            InitializeComponent();
            GetTotInc();
            GetTotExp();
            GetNumExp();
            GetNumInc();
            GetIncLDate();
            GetExpLDate();
            GetMaxIncome();
            GetMaxExpense();
            GetMinIncome();
            GetMinExpense();
            GetBalance();
            //GetMaxExpCat();
            //GetMaxIncCat();
            ResizeMode = ResizeMode.NoResize;
        }

        private void Logout_btt_Click(object sender, RoutedEventArgs e)
        {
            MainWindow r1 = new MainWindow();
            this.Close();
            r1.Show();
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

        private void Chart_Btn_Click(object sender, RoutedEventArgs e)
        {
            Window2 Obj = new Window2();
            Obj.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True");

        private void GetTotInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Sum(IncAmt) FROM IncomeTbl WHERE IncUser='" + MainWindow.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Inc = Convert.ToDecimal(dt.Rows[0][0].ToString());
                Console.WriteLine(Inc);
                TotalIncLbl1.Text = dt.Rows[0][0].ToString() + "zł";
                Con.Close();
            }
            catch (Exception Ex)
            {

                Con.Close();
            }
           
        }

        private void GetTotExp()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Sum(ExpAmt) FROM ExpenseTbl WHERE ExpUser='" + MainWindow.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Exp = Convert.ToDecimal(dt.Rows[0][0].ToString());
                Console.WriteLine(Exp);
                TotalExpLbl1.Text = dt.Rows[0][0].ToString() + "zł";
                Con.Close();
            }
            catch (Exception Ex)
            {

                Con.Close();
            }
           
        }

        decimal Inc, Exp;
        private void GetBalance()
        {
            decimal Bal = Inc - Exp;
            Console.WriteLine(Bal);
            BalanceLbl.Text = Bal + "zł";
        }

        private void GetNumExp()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Count(*) FROM ExpenseTbl WHERE ExpUser='" + MainWindow.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                NumExpLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception Ex)
            {

                Con.Close();
            }
           
        }

        private void GetNumInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Count(*) FROM IncomeTbl WHERE IncUser='" + MainWindow.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                NumIncLbl1.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception)
            {

                Con.Close();
            }
            
        }

        private void GetIncLDate()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Max(IncDate) FROM IncomeTbl WHERE IncUser='" + MainWindow.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                IncDateLbl.Text = dt.Rows[0][0].ToString();
                IncDateLbl_Copy.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception Ex)
            {

                Con.Close();
            }
            
        }

        private void GetExpLDate()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Max(ExpDate) FROM ExpenseTbl WHERE ExpUser='" + MainWindow.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ExpDateLbl.Text = dt.Rows[0][0].ToString();
                ExpDateLbl_Copy.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception Ex)
            {

                Con.Close();
            }
            
        }

        private void GetMaxIncome()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Max(IncAmt) FROM IncomeTbl WHERE IncUser='" + MainWindow.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MaxIncLbl.Text = dt.Rows[0][0].ToString() + "zł";
                Con.Close();
            }
            catch (Exception Ex)
            {

                Con.Close();
            }
           
        }

        private void GetMaxExpense()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Max(ExpAmt) FROM ExpenseTbl WHERE ExpUser='" + MainWindow.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MaxExpLbl.Text = dt.Rows[0][0].ToString() + "zł";
                Con.Close();
            }
            catch (Exception)
            {

                Con.Close();
            }
            
        }

        private void GetMinIncome()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Min(IncAmt) FROM IncomeTbl WHERE IncUser='" + MainWindow.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MinIncLbl.Text = dt.Rows[0][0].ToString() + "zł";
                Con.Close();
            }
            catch (Exception)
            {

                Con.Close();
            }
           
        }

        private void GetMinExpense()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Min(ExpAmt) FROM ExpenseTbl WHERE ExpUser='" + MainWindow.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MinExpLbl.Text = dt.Rows[0][0].ToString() + "zł";
                Con.Close();
            }
            catch (Exception)
            {

                Con.Close();
            }
           
        }

        //private void GetMaxExpCat()
        //{
        //    try
        //    {
        //        Con.Open();
        //        string InnerQuery = "SELECT Max(ExpAmt) FROM ExpenseTbl WHERE ExpUser='" + MainWindow.User + "'";
        //        DataTable dt1 = new DataTable();
        //        SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
        //        sda1.Fill(dt1);
        //        string Query = "SELECT ExpCat FROM ExpenseTbl WHERE ExpAmt = '" + dt1.Rows[0][0].ToString() + "' AND ExpUser='" + MainWindow.User + "'";
        //        SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);
        //        BestExpCatLbl.Text = dt.Rows[0][0].ToString();
        //        Con.Close();
        //    }
        //    catch (Exception)
        //    {

        //        Con.Close();
        //    }
           
        //}

        //private void GetMaxIncCat()
        //{
        //    try
        //    {
        //        Con.Open();
        //        string InnerQuery = "SELECT Max(IncAmt) FROM IncomeTbl";
        //        DataTable dt1 = new DataTable();
        //        SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
        //        sda1.Fill(dt1);
        //        string Query = "SELECT IncCat FROM IncomeTbl WHERE IncAmt = '" + dt1.Rows[0][0].ToString() + "'";
        //        SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
        //        DataTable dt = new DataTable();
        //        sda.Fill(dt);
        //        BestIncCatLbl.Text = dt.Rows[0][0].ToString();
        //        Con.Close();
        //    }
        //    catch (Exception)
        //    {

        //        Con.Close();
        //    }
            
        //}
    }
}

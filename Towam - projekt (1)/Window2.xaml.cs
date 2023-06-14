using LiveCharts;
using LiveCharts.Wpf;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            
         
        }

        public SeriesCollection PieChartData { get; set; }
        SqlConnection Con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True");

        decimal Inc, Exp, Bal;
     

        private void Load_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Sum(IncAmt) FROM IncomeTbl WHERE IncUser='" + MainWindow.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Inc = Convert.ToDecimal(dt.Rows[0][0].ToString());
                Console.WriteLine(Inc);

                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT Sum(ExpAmt) FROM ExpenseTbl WHERE ExpUser='" + MainWindow.User + "'", Con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                Exp = Convert.ToDecimal(dt2.Rows[0][0].ToString());
                Console.WriteLine(Exp);

                // Pobieranie sumy przychodów dla kategorii "Praca"
                SqlDataAdapter sda3 = new SqlDataAdapter("SELECT Sum(IncAmt) FROM IncomeTbl WHERE IncUser='" + MainWindow.User + "' AND IncCat='Salary'", Con);
                DataTable dt3 = new DataTable();
                sda3.Fill(dt3);
                decimal incWork = Convert.ToDecimal(dt3.Rows[0][0].ToString());
                Console.WriteLine(incWork);

                // Pobieranie sumy wydatków dla kategorii "Jedzenie"
                SqlDataAdapter sda4 = new SqlDataAdapter("SELECT Sum(ExpAmt) FROM ExpenseTbl WHERE ExpUser='" + MainWindow.User + "' AND ExpCat='Food'", Con);
                DataTable dt4 = new DataTable();
                sda4.Fill(dt4);
                decimal expFood = Convert.ToDecimal(dt4.Rows[0][0].ToString());
                Console.WriteLine(expFood);

                // Pobieranie sumy przychodów dla kategorii "Oszczędności"
                SqlDataAdapter sda5 = new SqlDataAdapter("SELECT Sum(IncAmt) FROM IncomeTbl WHERE IncUser='" + MainWindow.User + "' AND IncCat='Savings'", Con);
                DataTable dt5 = new DataTable();
                sda5.Fill(dt5);
                decimal incSave = Convert.ToDecimal(dt5.Rows[0][0].ToString());
               

                // Pobieranie sumy przychodów dla kategorii "Praca"
                SqlDataAdapter sda6 = new SqlDataAdapter("SELECT Sum(IncAmt) FROM IncomeTbl WHERE IncUser='" + MainWindow.User + "' AND IncCat='PocketMoney'", Con);
                DataTable dt6 = new DataTable();
                sda6.Fill(dt6);
                decimal incPocket = Convert.ToDecimal(dt6.Rows[0][0].ToString());
                

                // Pobieranie sumy przychodów dla kategorii "Praca"
                SqlDataAdapter sda7 = new SqlDataAdapter("SELECT Sum(ExpAmt) FROM ExpenseTbl WHERE ExpUser='" + MainWindow.User + "' AND ExpCat='Shopping'", Con);
                DataTable dt7 = new DataTable();
                sda7.Fill(dt7);
                decimal expBest = Convert.ToDecimal(dt7.Rows[0][0].ToString());

                // Pobieranie sumy wydatków dla kategorii "Jedzenie"
                SqlDataAdapter sda8 = new SqlDataAdapter("SELECT Sum(ExpAmt) FROM ExpenseTbl WHERE ExpUser='" + MainWindow.User + "' AND ExpCat='Travel'", Con);
                DataTable dt8 = new DataTable();
                sda8.Fill(dt8);
                decimal expTravel = Convert.ToDecimal(dt8.Rows[0][0].ToString());
                Console.WriteLine(expFood);

                decimal Bal = Inc - Exp;
                Con.Close();
                
                pieChart.Series = new SeriesCollection
        {
            new PieSeries
            {
                Title = "Incomes",
                Values = new ChartValues<decimal> { Inc },
                DataLabels = true
            },
            new PieSeries
            {
                Title = "Incomes (Salary)",
                Values = new ChartValues<decimal> { incWork },
                DataLabels = true
            },
            new PieSeries
            {
                Title = "Incomes (Savings)",
                Values = new ChartValues<decimal> { incSave },
                DataLabels = true
            },
            new PieSeries
            {
                Title = "Incomes (PocketMoney)",
                Values = new ChartValues<decimal> { incPocket },
                DataLabels = true
            },
            new PieSeries
            {
                Title = "Expenses",
                Values = new ChartValues<decimal> { Exp },
                DataLabels = true
            },
            new PieSeries
            {
                Title = "Expenses (Food)",
                Values = new ChartValues<decimal> { expFood },
                DataLabels = true
            },
            new PieSeries
            {
                Title = "Expenses (Shopping)",
                Values = new ChartValues<decimal> { expBest },
                DataLabels = true
            },
            new PieSeries
            {
                Title = "Expenses (Travel)",
                Values = new ChartValues<decimal> { expTravel },
                DataLabels = true
            },
            new PieSeries
            {
            Title = "Balance",
            Values = new ChartValues<decimal> { Bal },
            DataLabels = true
            }
            };
            }
            catch (Exception Ex)
            {
                Con.Close();
            }
        }
    

        private void back_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainApplicationWindow Obj = new MainApplicationWindow();
            Obj.Show();
            this.Hide();
        }
    }
}

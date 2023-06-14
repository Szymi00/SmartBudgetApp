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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }

        SqlConnection Con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True");

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT IncAmt, IncDate FROM IncomeTbl WHERE IncUser='" + MainWindow.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                // Tworzenie serii
                var incomeSeries = new LineSeries
                {
                    Title = "Incomes",
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                };

                // Dodawanie wartości do serii
                foreach (DataRow row in dt.Rows)
                {
                    incomeSeries.Values.Add(Convert.ToDouble(row["IncAmt"]));
                    MyChart.AxisX[0].Labels.Add(row["IncDate"].ToString());
                }

                // Dodawanie serii do wykresu
                MyChart.Series.Add(incomeSeries);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }


        private void MyChart_Loaded(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT ExpDate, ExpAmt FROM ExpenseTbl WHERE ExpUser='" + MainWindow.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            var dates = dt.AsEnumerable().Select(r => r.Field<DateTime>("ExpDate").ToString("dd-MM-yyyy")).ToArray();
            var values = dt.AsEnumerable().Select(r => r.Field<decimal>("ExpAmt")).ToArray();

            var series = new LineSeries
            {
                Title = "Expenses",
                Values = new ChartValues<double>(values.Select(x => (double)x).ToList()),
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 15
            };
            MyChart.Series.Add(series);

            MyChart.AxisX.Add(new Axis
            {
                Title = "Date",
                Labels = dates
            });
            MyChart.AxisY.Add(new Axis
            {
                Title = "Expense Amount",
                LabelFormatter = value => value.ToString("C")
            });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewExpenses obj = new ViewExpenses();
            obj.Show();
            this.Hide();
        }
    }
}

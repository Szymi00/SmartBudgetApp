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
    /// Interaction logic for ViewExpenses.xaml
    /// </summary>
    public partial class ViewExpenses : Window
    {
        public ViewExpenses()
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True");

            //string selectedCategory = (string)ExpCatBox.SelectedValue;
            //string enteredCategory = ExpCatLbl.Text;
            //try
            //{
            //    Con.Open();
            //    string Query = "SELECT * FROM ExpenseTbl";
            //    SqlCommand cmd = new SqlCommand(Query, Con);
            //    cmd.ExecuteNonQuery();

            //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable("ExpenseTbl");
            //    sda.Fill(dt);
            //    ExpenseDGV.ItemsSource = dt.DefaultView;
            //    sda.Update(dt);

            //    Con.Close();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            //string selectedCategory = ExpCatBox.SelectedItem.ToString();
            //string enteredCategory = ExpCatBox.Text;
            //if (selectedCategory != null)
            //{
            //    try
            //    {
            //        Con.Open();
            //        string Query = "SELECT * FROM ExpenseTbl WHERE ExpCat = @category AND ExpUser = @user";
            //        SqlCommand cmd = new SqlCommand(Query, Con);
            //        cmd.Parameters.AddWithValue("@category", selectedCategory);
            //        cmd.Parameters.AddWithValue("@user", MainWindow.User);
            //        cmd.ExecuteNonQuery();

            //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //        DataTable dt = new DataTable("ExpenseTbl");
            //        sda.Fill(dt);
            //        ExpenseDGV.ItemsSource = dt.DefaultView;
            //        sda.Update(dt);

            //        Con.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //else if (enteredCategory != null)
            //{
            //    try
            //    {
            //        Con.Open();
            //        string Query = "SELECT * FROM ExpenseTbl WHERE ExpCat = @category AND ExpUser = @user";
            //        SqlCommand cmd = new SqlCommand(Query, Con);
            //        cmd.Parameters.AddWithValue("@category", enteredCategory);
            //        cmd.Parameters.AddWithValue("@user", MainWindow.User);
            //        cmd.ExecuteNonQuery();

            //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //        DataTable dt = new DataTable("ExpenseTbl");
            //        sda.Fill(dt);
            //        ExpenseDGV.ItemsSource = dt.DefaultView;
            //        sda.Update(dt);

            //        Con.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select or enter a category.");
            //}

            try
            {
                Con.Open();
                string Query = "SELECT ExpName, ExpAmt, ExpCat, ExpDesc, ExpDate FROM ExpenseTbl WHERE ExpUser = @user ";
                if (ExpCatBox.SelectedIndex != 0)
                {
                    if (ExpCatBox.SelectedValue.ToString() != "All")
                    {
                        Query += "AND ExpCat = @category ";
                    }
                }
                if (!string.IsNullOrEmpty(ExpCatLbl.Text))
                {
                    Query += "AND ExpName = @name ";
                }

                SqlCommand cmd = new SqlCommand(Query, Con);

                if (ExpCatBox.SelectedIndex != 0)
                {
                    if (ExpCatBox.SelectedValue.ToString() != "All")
                    {
                        cmd.Parameters.AddWithValue("@category", ExpCatBox.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
                    }
                }
                if (!string.IsNullOrEmpty(ExpCatLbl.Text))
                {
                    cmd.Parameters.AddWithValue("@name", ExpCatLbl.Text);
                }

                cmd.Parameters.AddWithValue("@user", MainWindow.User);
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("ExpenseTbl");
                sda.Fill(dt);
                //DataGridTextColumn newColumn = new DataGridTextColumn();
                //newColumn.Binding = new Binding("ExpDate");
                //newColumn.Header = "Expense Date";
                //newColumn.Width = 100;
                //newColumn.ElementStyle = new Style(typeof(TextBlock));
                //newColumn.ElementStyle.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Right));
                //newColumn.ElementStyle.Setters.Add(new Setter(TextBlock.PaddingProperty, new Thickness(5, 0, 0, 0)));
                //newColumn.ElementStyle.Setters.Add(new Setter(TextBlock.TextProperty, new Binding("ExpDate") { StringFormat = "yyyy-MM-dd" }));
                //ExpenseDGV.Columns.Add(newColumn);
                ExpenseDGV.ItemsSource = dt.DefaultView;
                sda.Update(dt);

                Con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Choose category.");
            }
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
            items.Add(new ComboBoxItem { Name = "Food", Value = "Food" });
            items.Add(new ComboBoxItem { Name = "Clothes", Value = "Clothes" });
            items.Add(new ComboBoxItem { Name = "Medical", Value = "Medical" });
            items.Add(new ComboBoxItem { Name = "Household", Value = "Household" });
            items.Add(new ComboBoxItem { Name = "Travel", Value = "Travel" });
            items.Add(new ComboBoxItem { Name = "Vehicle", Value = "Vehicle" });
            items.Add(new ComboBoxItem { Name = "Other", Value = "Other" });
            ExpCatBox.ItemsSource = items;
            ExpCatBox.DisplayMemberPath = "Name";
            ExpCatBox.SelectedValuePath = "Value";
        }



        private void FilterExpenses(string category)
        {
             SqlConnection Con = new SqlConnection(@"Server=DESKTOP-M0I0V9D;Database=LRDATABASE;Integrated Security=True");
            Con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ExpenseTbl WHERE ExpCat = @category AND ExpUser = @user", Con);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@user", MainWindow.User);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Con.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window4 obj = new Window4();
            obj.Show();
            this.Close();
        }
    }    
}

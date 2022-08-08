using GLWpfApp.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GLWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Employee> employees = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();

            employees.Add(new Employee { FirstName = "Anna", LastName = "Nguyenova" });
            employees.Add(new Employee { FirstName = "Daniela", LastName = "Horvathova" });
            employees.Add(new Employee { FirstName = "Dominika", LastName = "Mala" });
            employees.Add(new Employee { FirstName = "David", LastName = "Kovac" });
            employees.Add(new Employee { FirstName = "Peter", LastName = "Duris" });

            listOfEmployees.ItemsSource = employees;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listOfEmployees.ItemsSource);
            view.Filter = EmployeeFilter;
        }

        private bool EmployeeFilter(object item)
        {
            if (String.IsNullOrEmpty(textFilter.Text))
                return true;
            else
                return ((item as Employee).FullName.Contains(textFilter.Text, StringComparison.OrdinalIgnoreCase));
        }

        private void textFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listOfEmployees.ItemsSource).Refresh();
        }
    }
}

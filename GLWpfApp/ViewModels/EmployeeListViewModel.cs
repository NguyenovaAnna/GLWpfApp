using GLWpfApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace GLWpfApp.ViewModels
{
    public class EmployeeListViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public ICollectionView EmployeesCollectionView { get; }

        private string _employeesFilter = string.Empty;
        public string EmployeesFilter
        {
            get
            {
                return _employeesFilter;
            }
            set
            {
                _employeesFilter = value;
                OnPropertyChanged(nameof(EmployeesFilter));
                EmployeesCollectionView.Refresh();
            }
        }

        public EmployeeListViewModel()
        {
            Employees = new ObservableCollection<Employee>()
            {
                new Employee { FirstName = "Anna", LastName = "Nguyenova" },
                new Employee { FirstName = "Daniela", LastName = "Horvathova" },
                new Employee { FirstName = "Dominika", LastName = "Mala" },
                new Employee { FirstName = "David", LastName = "Kovac" },
                new Employee { FirstName = "Peter", LastName = "Duris" }
            };

            EmployeesCollectionView = CollectionViewSource.GetDefaultView(Employees);
            EmployeesCollectionView.Filter = FilterEmployees;
        }

        private bool FilterEmployees(object obj)
        {
            if(obj is Employee Employee)
            {
                return Employee.FullName.Contains(EmployeesFilter, StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

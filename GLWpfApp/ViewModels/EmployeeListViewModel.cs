using GLWpfApp.Commands;
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
        private ObservableCollection<Employee> _searchedEmployees;
        private Employee _selectedEmployee;
        private string _searchText;

        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                if (_employees == value)
                    return;

                _employees = value;

                SearchedEmployees = new ObservableCollection<Employee>(_employees);
            }
        }

        public ObservableCollection<Employee> SearchedEmployees 
        { 
            get
            {
                return _searchedEmployees;
            }
            set
            {
                _searchedEmployees = value;
                OnPropertyChanged("SearchedEmployees");
            }
        }

        public Employee SelectedEmployee
        {
            get 
            {
                return _selectedEmployee;
            }
            set 
            {
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                if (_searchText == value)
                    return;

                _searchText = value;

                if (string.IsNullOrEmpty(SearchText))
                    Search();
            }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

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

            SearchCommand = new RelayCommand(Search);
            DeleteCommand = new RelayCommand(Delete);
        }

        public void Search()
       {
            if (string.IsNullOrEmpty(SearchText) || Employees == null || Employees.Count <= 0)
            {
                SearchedEmployees = new ObservableCollection<Employee>(Employees ?? Enumerable.Empty<Employee>());
                return;
            }

            SearchedEmployees = new ObservableCollection<Employee>(Employees.Where(employee => employee.FullName.ToLower().Contains(SearchText.ToLower())));
        }

        public void Delete()
        {

            if (SelectedEmployee != null)
            {
                SearchedEmployees.Remove(SelectedEmployee);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

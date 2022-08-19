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
    public class EmployeeListViewModel : ViewModelBase
    {        
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Employee> _searchedEmployees;
        private Employee _selectedEmployee;
        private Employee _employee;
        private string _searchText;
        private bool _employeeIsSelected;
        //private ICommand _submitCommand;
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
                OnPropertyChanged("Employees");

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

                if (SelectedEmployee != null)
                {
                    EmployeeIsSelected = true;
                }
            }
        }

        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                OnPropertyChanged("Employee");
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

        public bool EmployeeIsSelected
        {
            get
            {
                return _employeeIsSelected;
            }
            set
            {
                _employeeIsSelected = value;
                OnPropertyChanged("EmployeeIsSelected");
            }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand OpenDetailCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SubmitCommand { get; set; }
        //{
        //    get
        //    {
        //        if (_submitCommand == null)
        //        {
        //            _submitCommand = new AddEditEmployeeCommand(param => AddEmployee(param), param => true);
        //        }
        //        return _submitCommand;
        //    }

        //}

        public EmployeeListViewModel()
        {
            Employee = new Employee();
            Employees = new ObservableCollection<Employee>()
            {
                new Employee { FirstName = "Anna", LastName="Nguyenova", EmployeeNumber = 1111 },
                new Employee { FirstName = "Daniela", LastName = "Horvathova", EmployeeNumber = 2222 },
                new Employee { FirstName = "Dominika", LastName = "Mala", EmployeeNumber = 3333 },
                new Employee { FirstName = "David", LastName = "Kovac", EmployeeNumber = 4444 },
                new Employee { FirstName = "Peter", LastName = "Duris", EmployeeNumber = 5555 }
            };

            SearchCommand = new RelayCommand(Search);
            DeleteCommand = new RelayCommand(Delete);
            OpenDetailCommand = new RelayCommand(OpenDetail);
            CancelCommand = new RelayCommand(Cancel);
            SubmitCommand = new AddEditEmployeeCommand(AddEmployee);
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

        public void OpenDetail()
        {
            EmployeeIsSelected = true;
        }

        public void Cancel()
        {
            EmployeeIsSelected = false;
            SelectedEmployee = null;
        }

        public void AddEmployee(object parameter)
        {
            Employees.Add(new Employee() {FirstName = Employee.FirstName, LastName = Employee.LastName, EmployeeNumber = Employee.EmployeeNumber});
            EmployeeIsSelected = false;
        }
    }
}

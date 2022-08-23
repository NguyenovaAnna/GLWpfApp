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
        //private ObservableCollection<Employee> _searchedEmployees;
        private Employee _selectedEmployee;
        private Employee _employee;
        private bool _isEmployeeSelected;
        private bool _isAddedBtnClicked;
        private string _employeesFilter = string.Empty;
        private string _firstName;
        private string _lastName;
        private int _employeeNumber;

        public ICollectionView EmployeesCollectionView { get; }
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
                if (_selectedEmployee == value)
                    return;

                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");

                if (SelectedEmployee != null)
                {
                    IsEmployeeSelected = true;
                    IsAddedBtnClicked = false;
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
                if (_employee == value)
                    return;

                _employee = value;
                OnPropertyChanged("Employee");
            }
        }

        public bool IsEmployeeSelected
        {
            get
            {
                return _isEmployeeSelected;
            }
            set
            {
                _isEmployeeSelected = value;
                OnPropertyChanged("IsEmployeeSelected");
            }
        }

        public bool IsAddedBtnClicked
        {
            get
            {
                return _isAddedBtnClicked;
            }
            set
            {
                _isAddedBtnClicked = value;
                OnPropertyChanged("IsAddedBtnClicked");
            }
        }

        public string EmployeesFilter
        {
            get
            {
                return _employeesFilter;
            }
            set
            {
                _employeesFilter = value;
                OnPropertyChanged("EmployeesFilter");
                if (string.IsNullOrEmpty(EmployeesFilter))
                    Search();
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");  
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public int EmployeeNumber
        {
            get
            {
                return _employeeNumber;
            }
            set
            {
                _employeeNumber = value;
                OnPropertyChanged("EmployeeNumber");
            }
        }

        public ICommand SearchCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand OpenDetailCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SubmitCommand { get; set; }
        public ICommand EditCommand { get; set; }


        public EmployeeListViewModel()
        {
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
            EditCommand = new AddEditEmployeeCommand(EditEmployee);

            EmployeesCollectionView = CollectionViewSource.GetDefaultView(Employees);
            EmployeesCollectionView.Filter = FilterEmployees;
        }

        private bool FilterEmployees(object obj)
        {
            if (obj is Employee Employee)
            {
                return Employee.FullName.Contains(EmployeesFilter, StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }

        public void Search()
        {
            EmployeesCollectionView.Refresh();
        }


        public void Delete()
        {
            if (SelectedEmployee != null)
            {
                Employees.Remove(SelectedEmployee);
            }
            IsEmployeeSelected = false;
        }

        public void OpenDetail()
        {
            IsAddedBtnClicked = true;
            IsEmployeeSelected = false;
            SelectedEmployee = null;
        }

        public void Cancel()
        {
            IsEmployeeSelected = false;
            IsAddedBtnClicked = false;
            SelectedEmployee = null;
        }

        public void AddEmployee(object o)
        {
            var newEmployee = new Employee(FirstName, LastName, EmployeeNumber);
            Employees.Add(newEmployee);
            Search();
            FirstName = String.Empty;
            LastName = String.Empty;
            EmployeeNumber = 0;
            IsEmployeeSelected = false;
            IsAddedBtnClicked = false;
        }

        public void EditEmployee(object o)
        {
            SelectedEmployee = new Employee();
            Search();
            IsEmployeeSelected = false;
            IsAddedBtnClicked = false;
        }
    }
}

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
        private bool _isEmployeeSelected;
        private bool _isAddedBtnClicked;
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
                if (_selectedEmployee == value)
                    return;

                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");

                if (SelectedEmployee != null)
                {
                    IsEmployeeSelected = true;
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

        public ICommand SearchCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand OpenDetailCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SubmitCommand { get; set; }

        public ICommand EditCommand { get; set; }


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
            EditCommand = new AddEditEmployeeCommand(EditEmployee);
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
            IsAddedBtnClicked = true;
        }

        public void Cancel()
        {
            IsEmployeeSelected = false;
            IsAddedBtnClicked = false;
            SelectedEmployee = null;
        }

        public void AddEmployee(object o)
        {
            Employees.Add(Employee);
            Search();
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

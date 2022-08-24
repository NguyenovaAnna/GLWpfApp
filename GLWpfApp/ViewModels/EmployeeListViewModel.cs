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
        private Employee _selectedEmployee;
        private bool _isEmployeeSelected;
        private bool _isAddedBtnClicked;
        private bool _isVisible;
        private string _employeesFilter = string.Empty;

        public ICollectionView EmployeesCollectionView { get; }
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
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
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");

                if (SelectedEmployee != null)
                {
                    IsVisible = true;
                    SelectedEmployeeDetail.EmployeeNumber = value.EmployeeNumber;
                    SelectedEmployeeDetail.FirstName = value.FirstName;
                    SelectedEmployeeDetail.LastName = value.LastName;
                }
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

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged("IsVisible");
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

        public Employee Employee { get; set; }
        public Employee SelectedEmployeeDetail { get; set; }

        public ICommand SearchCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SubmitCommand { get; set; }


        public EmployeeListViewModel()
        {
            Employee = new Employee();
            SelectedEmployeeDetail = new Employee();
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
            AddCommand = new RelayCommand(Add);
            ResetCommand = new RelayCommand(Reset);
            CancelCommand = new RelayCommand(Cancel);
            SubmitCommand = new AddEditEmployeeCommand(Submit);

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
                var employeeToDelete = Employees.FirstOrDefault(x => x.EmployeeNumber == SelectedEmployeeDetail.EmployeeNumber);
                Employees.Remove(employeeToDelete);
            }

            IsVisible = false;
        }

        public void Add()
        {
            IsVisible = true;
            SelectedEmployee = null;
            SelectedEmployeeDetail.FirstName = String.Empty;
            SelectedEmployeeDetail.LastName = String.Empty;
            SelectedEmployeeDetail.EmployeeNumber = 0;
        }

        public void Reset()
        {
            EmployeesFilter = String.Empty;
        }

        public void Cancel()
        {
            IsVisible = false;
            SelectedEmployee = null;
            SelectedEmployeeDetail.FirstName = String.Empty;
            SelectedEmployeeDetail.LastName = String.Empty;
            SelectedEmployeeDetail.EmployeeNumber = 0;
        }

        public void Submit(object o)
        {
            if(SelectedEmployee == null)
            {
                var newEmployee = new Employee(SelectedEmployeeDetail.FirstName, SelectedEmployeeDetail.LastName, SelectedEmployeeDetail.EmployeeNumber);
                Employees.Add(newEmployee);
                Search();
                SelectedEmployeeDetail.FirstName = String.Empty;
                SelectedEmployeeDetail.LastName = String.Empty;
                SelectedEmployeeDetail.EmployeeNumber = 0;
                IsVisible = false;
            }
            else
            {
                var employeeToEdit = Employees.FirstOrDefault(x => x.EmployeeNumber == SelectedEmployeeDetail.EmployeeNumber);
                employeeToEdit.FirstName = SelectedEmployeeDetail.FirstName;
                employeeToEdit.LastName = SelectedEmployeeDetail.LastName;
                employeeToEdit.EmployeeNumber = SelectedEmployeeDetail.EmployeeNumber;
                Search();
                IsVisible = false;
            }
        }
    }
}

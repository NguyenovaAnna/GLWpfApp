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
        private Employee? _selectedEmployee;
        private bool _isEmployeeSelected;
        private bool _isAddedBtnClicked;
        private bool _isVisible;
        private bool _isEmployeeNumberExisting;
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

        public Employee? SelectedEmployee
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
                    IsEmployeeNumberExisting = false;
                    Assign(SelectedEmployeeDetail, SelectedEmployee);
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

        public bool IsEmployeeNumberExisting
        {
            get
            {
                return _isEmployeeNumberExisting;
            }
            set
            {
                _isEmployeeNumberExisting = value;
                OnPropertyChanged("IsEmployeeNumberExisting");
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
                new Employee { FirstName = "Anna", LastName="Nguyenova", EmployeeNumber = 1111, MiddleName = string.Empty, NationalIdNumber = 1, PreviousIdNumber = 0, PersonellNumber = 11, ActivationTime = new DateTime(2020,1,1), ExpirationTime = new DateTime(2025,12,31) },
                new Employee { FirstName = "Daniela", LastName = "Horvathova", EmployeeNumber = 2222, MiddleName = string.Empty, NationalIdNumber = 2, PreviousIdNumber = 0, PersonellNumber = 22, ActivationTime = new DateTime(2020,1,1), ExpirationTime = new DateTime(2025,12,31)  },
                new Employee { FirstName = "Dominika", LastName = "Mala", EmployeeNumber = 3333, MiddleName = string.Empty, NationalIdNumber = 3, PreviousIdNumber = 0, PersonellNumber = 33, ActivationTime = new DateTime(2020,1,1), ExpirationTime = new DateTime(2025,12,31)  },
                new Employee { FirstName = "David", LastName = "Kovac", EmployeeNumber = 4444, MiddleName = string.Empty, NationalIdNumber = 4, PreviousIdNumber = 0, PersonellNumber = 44, ActivationTime = new DateTime(2020,1,1), ExpirationTime = new DateTime(2025,12,31)  },
                new Employee { FirstName = "Peter", LastName = "Duris", EmployeeNumber = 5555, MiddleName = string.Empty, NationalIdNumber = 5, PreviousIdNumber = 0, PersonellNumber = 55, ActivationTime = new DateTime(2020,1,1), ExpirationTime = new DateTime(2025,12,31)  }
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
            var employeeToDelete = Employees.FirstOrDefault(x => x.EmployeeNumber == SelectedEmployee.EmployeeNumber);

            if (employeeToDelete != null)
            {
                Employees.Remove(employeeToDelete);
            }

            IsVisible = false;
        }

        public void Add()
        {
            IsVisible = true;
            SelectedEmployee = null;
            Clear();
        }

        public void Reset()
        {
            EmployeesFilter = String.Empty;
        }

        public void Cancel()
        {
            IsVisible = false;
            IsEmployeeNumberExisting = false;
            SelectedEmployee = null;
            Clear();
        }

        public void Submit(object o)
        {
            if (SelectedEmployee == null)
            {
                var employeeToAdd = Employees.FirstOrDefault(x => x.EmployeeNumber == SelectedEmployeeDetail.EmployeeNumber);

                if (employeeToAdd != null)
                {
                    IsEmployeeNumberExisting = true;
                }
                else
                {
                    var newEmployee = new Employee(SelectedEmployeeDetail.FirstName, SelectedEmployeeDetail.LastName, SelectedEmployeeDetail.EmployeeNumber,
                                        SelectedEmployeeDetail.MiddleName, SelectedEmployeeDetail.NationalIdNumber, SelectedEmployeeDetail.PreviousIdNumber,
                                        SelectedEmployeeDetail.PersonellNumber, SelectedEmployeeDetail.ActivationTime, SelectedEmployeeDetail.ExpirationTime);
                    Employees.Add(newEmployee);
                    Search();
                    Clear();
                    IsVisible = false;
                }
            }
            else
            {
                var employeeToEdit = Employees.FirstOrDefault(x => x.EmployeeNumber == SelectedEmployee.EmployeeNumber);
                var employeeToCheck = Employees.FirstOrDefault(y => y.EmployeeNumber == SelectedEmployeeDetail.EmployeeNumber);

                if (employeeToEdit != null)
                {
                    if (employeeToCheck != null && employeeToEdit.EmployeeNumber != employeeToCheck.EmployeeNumber)
                    {
                        IsEmployeeNumberExisting = true;
                    }
                    else
                    {
                        Assign(employeeToEdit, SelectedEmployeeDetail);
                        Search();
                        IsVisible = false;
                    }
                }
            }
        }

        private void Clear()
        {
            SelectedEmployeeDetail.FirstName = String.Empty;
            SelectedEmployeeDetail.LastName = String.Empty;
            SelectedEmployeeDetail.MiddleName = String.Empty;
            SelectedEmployeeDetail.EmployeeNumber = 0;
            SelectedEmployeeDetail.NationalIdNumber = 0;
            SelectedEmployeeDetail.PreviousIdNumber = 0;
            SelectedEmployeeDetail.PersonellNumber = 0;
            SelectedEmployeeDetail.ActivationTime = DateTime.Today;
            SelectedEmployeeDetail.ExpirationTime = DateTime.Today;
        }

        private void Assign(Employee employeeToBeAssignedTo, Employee employeeToBeAssignedFrom)
        {
            employeeToBeAssignedTo.FirstName = employeeToBeAssignedFrom.FirstName;
            employeeToBeAssignedTo.LastName = employeeToBeAssignedFrom.LastName;
            employeeToBeAssignedTo.MiddleName = employeeToBeAssignedFrom.MiddleName;
            employeeToBeAssignedTo.EmployeeNumber = employeeToBeAssignedFrom.EmployeeNumber;
            employeeToBeAssignedTo.NationalIdNumber = employeeToBeAssignedFrom.NationalIdNumber;
            employeeToBeAssignedTo.PreviousIdNumber = employeeToBeAssignedFrom.PreviousIdNumber;
            employeeToBeAssignedTo.PersonellNumber = employeeToBeAssignedFrom.PersonellNumber;
            employeeToBeAssignedTo.ActivationTime = employeeToBeAssignedFrom.ActivationTime;
            employeeToBeAssignedTo.ExpirationTime = employeeToBeAssignedFrom.ExpirationTime;
        }
    }
}

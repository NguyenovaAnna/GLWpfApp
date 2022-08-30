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
        private bool _isEmployeeNumberEmpty;
        private bool _isFirstNameEmpty;
        private bool _isLastNameEmpty;
        private bool _isContactMethodCheckBoxChecked;
        private bool _isPhoneNumberCheckBoxChecked;
        private bool _isEmailCheckBoxChecked;
        private string _employeesFilter = string.Empty;
        private int _employeeNum = 0;

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
                    EmployeeNum = SelectedEmployee.EmployeeNumber;
                    Assign(SelectedEmployeeDetail, SelectedEmployee);
                }
            }
        }
        public Employee Employee { get; set; }
        public Employee SelectedEmployeeDetail { get; set; }

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

        public bool IsEmployeeNumberEmpty
        {
            get
            {
                return _isEmployeeNumberEmpty;
            }
            set
            {
                _isEmployeeNumberEmpty = value;
                OnPropertyChanged("IsEmployeeNumberEmpty");
            }
        }
        public bool IsFirstNameEmpty
        {
            get
            {
                return _isFirstNameEmpty;
            }
            set
            {
                _isFirstNameEmpty = value;
                OnPropertyChanged("IsFirstNameEmpty");
            }
        }

        public bool IsLastNameEmpty
        {
            get
            {
                return _isLastNameEmpty;
            }
            set
            {
                _isLastNameEmpty = value;
                OnPropertyChanged("IsLastNameEmpty");
            }
        }

        public bool IsContactMethodCheckBoxChecked
        {
            get
            {
                return _isContactMethodCheckBoxChecked;
            }
            set
            {
                _isContactMethodCheckBoxChecked = value;
                OnPropertyChanged("IsContactMethodCheckBoxChecked");
            }
        }

        public bool IsPhoneNumberCheckBoxChecked
        {
            get
            {
                return _isPhoneNumberCheckBoxChecked;
            }
            set
            {
                _isPhoneNumberCheckBoxChecked = value;
                OnPropertyChanged("IsPhoneNumberCheckBoxChecked");
            }
        }

        public bool IsEmailCheckBoxChecked
        {
            get
            {
                return _isEmailCheckBoxChecked;
            }
            set
            {
                _isEmailCheckBoxChecked = value;
                OnPropertyChanged("IsEmailCheckBoxChecked");
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

        public int EmployeeNum
        {
            get { return _employeeNum; }
            set
            {
                _employeeNum = value;
                OnPropertyChanged("EmployeeNum");

                if (SelectedEmployee != null)
                {
                    var employeeToEdit = Employees.FirstOrDefault(x => x.EmployeeNumber == SelectedEmployee.EmployeeNumber);
                    var employeeToCheck = Employees.FirstOrDefault(y => y.EmployeeNumber == EmployeeNum);

                    if (employeeToEdit != null)
                    {
                        if (employeeToCheck != null && employeeToEdit.EmployeeNumber != employeeToCheck.EmployeeNumber)
                        {
                            IsEmployeeNumberExisting = true;
                        }
                        else
                        {
                            IsEmployeeNumberExisting = false;
                        }
                    }
                }
                else
                {
                    var employeeToAdd = Employees.FirstOrDefault(x => x.EmployeeNumber == EmployeeNum);

                    if (employeeToAdd != null)
                    {
                        IsEmployeeNumberExisting = true;
                        IsEmployeeNumberEmpty = false;
                    }
                    else
                    {
                        IsEmployeeNumberExisting = false;
                    }
                }
            }
        }

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
                new Employee { FirstName = "Anna", LastName="Nguyenova", EmployeeNumber = 1111, MiddleName = string.Empty, NationalIdNumber = 1, PreviousIdNumber = 0, PersonellNumber = 11, ActivationTime = new DateTime(2020,1,1), ExpirationTime = new DateTime(2025,12,31), PhoneNumber = "+421 911 111 111", Email = "anna@mail.com" },
                new Employee { FirstName = "Daniela", LastName = "Horvathova", EmployeeNumber = 2222, MiddleName = string.Empty, NationalIdNumber = 2, PreviousIdNumber = 0, PersonellNumber = 22, ActivationTime = new DateTime(2020,1,1), ExpirationTime = new DateTime(2025,12,31), PhoneNumber = "+421 911 222 222", Email = "daniela@mail.com" },
                new Employee { FirstName = "Dominika", LastName = "Mala", EmployeeNumber = 3333, MiddleName = string.Empty, NationalIdNumber = 3, PreviousIdNumber = 0, PersonellNumber = 33, ActivationTime = new DateTime(2020,1,1), ExpirationTime = new DateTime(2025,12,31), PhoneNumber = "+421 911 333 333", Email = "dominika@mail.com" },
                new Employee { FirstName = "David", LastName = "Kovac", EmployeeNumber = 4444, MiddleName = string.Empty, NationalIdNumber = 4, PreviousIdNumber = 0, PersonellNumber = 44, ActivationTime = new DateTime(2020,1,1), ExpirationTime = new DateTime(2025,12,31), PhoneNumber = "+421 911 444 444", Email = "david@mail.com" },
                new Employee { FirstName = "Peter", LastName = "Duris", EmployeeNumber = 5555, MiddleName = string.Empty, NationalIdNumber = 5, PreviousIdNumber = 0, PersonellNumber = 55, ActivationTime = new DateTime(2020,1,1), ExpirationTime = new DateTime(2025,12,31), PhoneNumber = "+421 911 555 555", Email = "peter@mail.com"  }
            };

            SearchCommand = new RelayCommand(Search);
            DeleteCommand = new RelayCommand(Delete);
            AddCommand = new RelayCommand(Add);
            ResetCommand = new RelayCommand(Reset);
            CancelCommand = new RelayCommand(Cancel);
            SubmitCommand = new SubmitCommand(Submit, CanSubmitExecute);

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
            IsEmployeeNumberExisting = false;
            IsContactMethodCheckBoxChecked = false;
            SelectedEmployee = null;
            SetPropertiesToFalse();
            UncheckCheckBoxes();
            Clear();
        }

        public void Submit(object parameter)
        {
            CheckEmployeeNumber();
            CheckFirstName();
            CheckLastName();

            if (SelectedEmployee == null && SelectedEmployeeDetail.EmployeeNumber != 0 && !String.IsNullOrEmpty(SelectedEmployeeDetail.FirstName) && !String.IsNullOrEmpty(SelectedEmployeeDetail.LastName))
            {

                var newEmployee = new Employee(SelectedEmployeeDetail.FirstName, SelectedEmployeeDetail.LastName, EmployeeNum,
                                    SelectedEmployeeDetail.MiddleName, SelectedEmployeeDetail.NationalIdNumber, SelectedEmployeeDetail.PreviousIdNumber,
                                    SelectedEmployeeDetail.PersonellNumber, SelectedEmployeeDetail.ActivationTime, SelectedEmployeeDetail.ExpirationTime, 
                                    SelectedEmployeeDetail.PhoneNumber, SelectedEmployeeDetail.Email);
                Employees.Add(newEmployee);
                Search();
                Clear();
                SetPropertiesToFalse();
            }
            
            if (SelectedEmployee != null && SelectedEmployeeDetail.EmployeeNumber != 0 && !String.IsNullOrEmpty(SelectedEmployeeDetail.FirstName) && !String.IsNullOrEmpty(SelectedEmployeeDetail.LastName))
            {
                var employeeToEdit = Employees.FirstOrDefault(x => x.EmployeeNumber == SelectedEmployee.EmployeeNumber);

                if (employeeToEdit != null)
                {
                    employeeToEdit.EmployeeNumber = EmployeeNum;
                    Assign(employeeToEdit, SelectedEmployeeDetail);
                    Search();
                    SetPropertiesToFalse();
                }
            }
        }

        private void Clear()
        {
            EmployeeNum = 0;
            SelectedEmployeeDetail.FirstName = String.Empty;
            SelectedEmployeeDetail.LastName = String.Empty;
            SelectedEmployeeDetail.MiddleName = String.Empty;
            SelectedEmployeeDetail.NationalIdNumber = 0;
            SelectedEmployeeDetail.PreviousIdNumber = 0;
            SelectedEmployeeDetail.PersonellNumber = 0;
            SelectedEmployeeDetail.ActivationTime = DateTime.Today;
            SelectedEmployeeDetail.ExpirationTime = DateTime.Today;
            SelectedEmployeeDetail.PhoneNumber = String.Empty;
            SelectedEmployeeDetail.Email = String.Empty;
        }

        private void Assign(Employee employeeToBeAssignedTo, Employee employeeToBeAssignedFrom)
        {
            employeeToBeAssignedTo.FirstName = employeeToBeAssignedFrom.FirstName;
            employeeToBeAssignedTo.LastName = employeeToBeAssignedFrom.LastName;
            employeeToBeAssignedTo.MiddleName = employeeToBeAssignedFrom.MiddleName;
            employeeToBeAssignedTo.NationalIdNumber = employeeToBeAssignedFrom.NationalIdNumber;
            employeeToBeAssignedTo.PreviousIdNumber = employeeToBeAssignedFrom.PreviousIdNumber;
            employeeToBeAssignedTo.PersonellNumber = employeeToBeAssignedFrom.PersonellNumber;
            employeeToBeAssignedTo.ActivationTime = employeeToBeAssignedFrom.ActivationTime;
            employeeToBeAssignedTo.ExpirationTime = employeeToBeAssignedFrom.ExpirationTime;
            employeeToBeAssignedTo.PhoneNumber = employeeToBeAssignedFrom.PhoneNumber;
            employeeToBeAssignedTo.Email = employeeToBeAssignedFrom.Email;
        }

        private void SetPropertiesToFalse()
        {
            IsVisible = false;
            IsEmployeeNumberEmpty = false;
            IsFirstNameEmpty = false;
            IsLastNameEmpty = false;
        }

        private void UncheckCheckBoxes()
        {
            IsContactMethodCheckBoxChecked = false;
            IsPhoneNumberCheckBoxChecked = false;
            IsEmailCheckBoxChecked = false;
        }


        private void CheckEmployeeNumber()
        {
            if (EmployeeNum == 0)
            {
                IsEmployeeNumberEmpty = true;
            }
        }

        private void CheckFirstName()
        {
            if (String.IsNullOrEmpty(SelectedEmployeeDetail.FirstName))
            {
                IsFirstNameEmpty = true;
            }
        }

        private void CheckLastName()
        {
            if (String.IsNullOrEmpty(SelectedEmployeeDetail.LastName))
            {
                IsLastNameEmpty = true;
            }
        }

        private bool CanSubmitExecute (object parameter)
        {
            if(IsEmployeeNumberExisting)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

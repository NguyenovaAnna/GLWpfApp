﻿using ClientApp.Commands;
using ClientApp.Models;
using ClientApp.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace ClientApp.ViewModels
{
    public class EmployeeListViewModel : ViewModelBase
    {
        EmployeeRepository employeeRepo = new EmployeeRepository();

        private ObservableCollection<Employee> _employees;
        private ObservableCollection<ContactMethod> _employeeContactMethods;
        private Employee? _selectedEmployee;
        private bool _isVisible;
        public bool _isContactMethodTextBoxVisible;
        private bool _isEmployeeNumberExisting;
        private bool _isEmployeeNumberEmpty;
        private bool _isFirstNameEmpty;
        private bool _isLastNameEmpty;
        private bool _isContactMethodCheckBoxChecked;
        private string _employeesFilter = string.Empty;
        private string _newContactMethodType = string.Empty;
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
                OnPropertyChanged(nameof(Employees));
            }
        }


        public ObservableCollection<ContactMethod> EmployeeContactMethods
        {
            get
            {
                return _employeeContactMethods;
            }
            set
            {
                _employeeContactMethods = value;
                OnPropertyChanged(nameof(EmployeeContactMethods));
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
                OnPropertyChanged(nameof(SelectedEmployee));

                if (SelectedEmployee != null)
                {
                    IsVisible = true;
                    IsEmployeeNumberExisting = false;
                    UncheckCheckBoxes();
                    IsContactMethodTextBoxVisible = false;
                    NewContactMethodType = String.Empty;
                    EmployeeNum = SelectedEmployee.EmployeeNumber;
                    Assign(SelectedEmployeeDetail, SelectedEmployee);
                    EmployeeContactMethods = new ObservableCollection<ContactMethod>();
                    foreach (var contactMethod in SelectedEmployee.ContactMethods)
                    {
                        EmployeeContactMethods.Add(new ContactMethod(contactMethod.IsSelected, contactMethod.ContactMethodType, contactMethod.ContactMethodValue));
                    }
                }
            }
        }
        public Employee SelectedEmployeeDetail { get; set; }

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public bool IsContactMethodTextBoxVisible
        {
            get
            {
                return _isContactMethodTextBoxVisible;
            }
            set
            {
                _isContactMethodTextBoxVisible = value;
                OnPropertyChanged(nameof(IsContactMethodTextBoxVisible));
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
                OnPropertyChanged(nameof(IsEmployeeNumberExisting));
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
                OnPropertyChanged(nameof(IsEmployeeNumberEmpty));
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
                OnPropertyChanged(nameof(IsFirstNameEmpty));
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
                OnPropertyChanged(nameof(IsLastNameEmpty));
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
                OnPropertyChanged(nameof(IsContactMethodCheckBoxChecked));
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
                OnPropertyChanged(nameof(EmployeesFilter));
                if (string.IsNullOrEmpty(EmployeesFilter))
                    Search();
            }
        }

        public string NewContactMethodType
        {
            get
            {
                return _newContactMethodType;
            }
            set
            {
                _newContactMethodType = value;
                OnPropertyChanged(nameof(NewContactMethodType));
            }
        }

        public int EmployeeNum
        {
            get { return _employeeNum; }
            set
            {
                _employeeNum = value;
                OnPropertyChanged(nameof(EmployeeNum));

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
        public ICommand AddContactMethodCommand { get; set; }

        public EmployeeListViewModel()
        {
            SelectedEmployeeDetail = new Employee();
            Employees = new ObservableCollection<Employee>();
            Task task = GetEmployees();
            
            SearchCommand = new RelayCommand(Search);
            DeleteCommand = new RelayCommand(Delete);
            AddCommand = new RelayCommand(Add);
            ResetCommand = new RelayCommand(Reset);
            CancelCommand = new RelayCommand(Cancel);
            AddContactMethodCommand = new RelayCommand(AddContactMethod);
            SubmitCommand = new SubmitCommand(Submit, CanSubmitExecute);

            EmployeesCollectionView = CollectionViewSource.GetDefaultView(Employees);
            EmployeesCollectionView.Filter = FilterEmployees;
        }

        public async Task GetEmployees()
        {
            var response = await employeeRepo.GetCallAsync("api/employees");
            if (response.IsSuccessStatusCode)
            {
                var employees = await response.Content.ReadAsAsync<ObservableCollection<Employee>>();

                foreach (var employee in employees)
                {
                    var newEmployee = new Employee(employee.FirstName, employee.LastName, employee.EmployeeNumber, employee.MiddleName, employee.NationalIdNumber,
                                                    employee.PreviousIdNumber, employee.PersonellNumber, employee.ActivationTime, employee.ExpirationTime, employee.ContactMethods);

                    Employees.Add(newEmployee);
                }
            }
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
                var employeeToDelete = Employees.FirstOrDefault(x => x.EmployeeNumber == SelectedEmployee.EmployeeNumber);

                if (employeeToDelete != null)
                {
                    Employees.Remove(employeeToDelete);
                    var url = "https://localhost:7168/api/employees/" + employeeToDelete.EmployeeNumber;
                    employeeRepo.DeleteCallAsync(url);
                }
            }

            IsVisible = false;
        }

        public void Add()
        {
            IsVisible = true;
            SelectedEmployee = null;
            Clear();
            UncheckCheckBoxes();
            EmployeeContactMethods = new ObservableCollection<ContactMethod>()
            {
                new ContactMethod (false, "PhoneNumber",String.Empty),
                new ContactMethod (false, "Email", String.Empty),
                new ContactMethod (false, "Skype",String.Empty)
            };
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

        public void AddContactMethod()
        {
            if (IsContactMethodTextBoxVisible == false)
            {
                IsContactMethodTextBoxVisible = true;
            }

            if (NewContactMethodType != String.Empty && IsContactMethodTextBoxVisible == true)
            {
                var newContactMethod = new ContactMethod(false, NewContactMethodType, String.Empty);
                EmployeeContactMethods.Add(newContactMethod);
                NewContactMethodType = String.Empty;
                IsContactMethodTextBoxVisible = false;
            }
        }

        public void Submit(object parameter)
        {
            CheckEmployeeNumber();
            CheckFirstName();
            CheckLastName();

            if (SelectedEmployee == null && EmployeeNum != 0 && !String.IsNullOrEmpty(SelectedEmployeeDetail.FirstName) && !String.IsNullOrEmpty(SelectedEmployeeDetail.LastName))
            {

                var newEmployee = new Employee(SelectedEmployeeDetail.FirstName, SelectedEmployeeDetail.LastName, EmployeeNum,
                                    SelectedEmployeeDetail.MiddleName, SelectedEmployeeDetail.NationalIdNumber, SelectedEmployeeDetail.PreviousIdNumber,
                                    SelectedEmployeeDetail.PersonellNumber, SelectedEmployeeDetail.ActivationTime, SelectedEmployeeDetail.ExpirationTime,
                                    new ObservableCollection<ContactMethod>(EmployeeContactMethods));

                Employees.Add(newEmployee);
                var url = "https://localhost:7168/api/employees";
                var emp = employeeRepo.PostCallAsync(url, newEmployee);
                Search();
                Clear();
                SetPropertiesToFalse();
            }

            if (SelectedEmployee != null && EmployeeNum != 0 && !String.IsNullOrEmpty(SelectedEmployeeDetail.FirstName) && !String.IsNullOrEmpty(SelectedEmployeeDetail.LastName))
            {
                var employeeToEdit = Employees.FirstOrDefault(x => x.EmployeeNumber == SelectedEmployee.EmployeeNumber);

                if (employeeToEdit != null)
                {
                    employeeToEdit.EmployeeNumber = EmployeeNum;
                    Assign(employeeToEdit, SelectedEmployeeDetail);
                    employeeToEdit.ContactMethods = new ObservableCollection<ContactMethod>();
                    foreach (var contactMethod in EmployeeContactMethods)
                    {
                        if (contactMethod.IsSelected == false)
                        {
                            contactMethod.ContactMethodValue = String.Empty;
                        }
                        employeeToEdit.ContactMethods.Add(new ContactMethod(contactMethod.IsSelected, contactMethod.ContactMethodType, contactMethod.ContactMethodValue));
                    }

                    var url = "https://localhost:7168/api/employees/" + employeeToEdit.EmployeeNumber;
                    employeeRepo.PutCallAsync(url,employeeToEdit);

                    Search();
                    SetPropertiesToFalse();
                    SelectedEmployee = null;
                }
            }
        }

        private void Clear()
        {
            EmployeeNum = GenerateId();
            SelectedEmployeeDetail.FirstName = String.Empty;
            SelectedEmployeeDetail.LastName = String.Empty;
            SelectedEmployeeDetail.MiddleName = String.Empty;
            SelectedEmployeeDetail.NationalIdNumber = 0;
            SelectedEmployeeDetail.PreviousIdNumber = 0;
            SelectedEmployeeDetail.PersonellNumber = 0;
            SelectedEmployeeDetail.ActivationTime = DateTime.Today;
            SelectedEmployeeDetail.ExpirationTime = DateTime.Today;
            NewContactMethodType = String.Empty;
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
        }

        private void SetPropertiesToFalse()
        {
            IsVisible = false;
            IsEmployeeNumberEmpty = false;
            IsFirstNameEmpty = false;
            IsLastNameEmpty = false;
            IsContactMethodTextBoxVisible = false;
        }

        private void UncheckCheckBoxes()
        {
            IsContactMethodCheckBoxChecked = false;
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

        private int GenerateId()
        {
            int maxId = Employees.Max(x => x.EmployeeNumber);
            int id;

            for (int i = 1; i <= maxId; i++)
            {
                var employee = Employees.FirstOrDefault(x => x.EmployeeNumber == i);
                if (employee == null)
                {
                    id = i;
                    return id;
                }
            }
            return maxId + 1;
        }

        private bool CanSubmitExecute(object parameter)
        {
            if (IsEmployeeNumberExisting)
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
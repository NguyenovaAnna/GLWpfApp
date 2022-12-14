using AutoMapper;
using ClientApp.Commands;
using ClientApp.Models;
using ClientApp.Profiles;
using ClientApp.RabbitMQ.Consumer;
using ClientApp.Repository;
using DataAccess.Entities;
using RabbitMQ.Client;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        EmployeeContactMethodRepo employeeContactMethodRepo = new EmployeeContactMethodRepo();
        private Mapper mapper;
        private ObservableCollection<EmployeeDisplayModel> _employees;
        private ObservableCollection<ContactMethodDisplayModel> _employeeContactMethods;
        private ObservableCollection<ContactMethodDisplayModel> _allContactMethods;
        private ObservableCollection<ContactMethodTypesDisplayModel> _contactMethodTypes;
        private EmployeeDisplayModel? _selectedEmployee;
        private bool _isVisible;
        private bool _isContactMethodTextBoxVisible;
        private bool _isEmployeeNumberExisting;
        private bool _isEmployeeNumberEmpty;
        private bool _isFirstNameEmpty;
        private bool _isLastNameEmpty;
        private bool _isContactMethodsCheckBoxChecked;
        private string _employeesFilter = string.Empty;
        private string _newContactMethodType = string.Empty;
        private int _employeeNum = 0;

        public ICollectionView EmployeesCollectionView { get; }

        public ObservableCollection<EmployeeDisplayModel> Employees 
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

        public ObservableCollection<ContactMethodDisplayModel> EmployeeContactMethods
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

        public ObservableCollection<ContactMethodDisplayModel> AllContactMethods
        {
            get
            {
                return _allContactMethods;
            }
            set
            {
                _allContactMethods = value;
                OnPropertyChanged(nameof(AllContactMethods));
            }
        }

        public ObservableCollection<ContactMethodTypesDisplayModel> ContactMethodTypes
        {
            get
            {
                return _contactMethodTypes;
            }
            set
            {
                _contactMethodTypes = value;
                OnPropertyChanged(nameof(ContactMethodTypes));
            }
        }

        public EmployeeDisplayModel? SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
                OnPropertyChanged(nameof(IsContactMethodsCheckBoxChecked));

                if (SelectedEmployee != null)
                {
                    IsVisible = true;
                    IsEmployeeNumberExisting = false;
                    IsContactMethodTextBoxVisible = false;
                    IsContactMethodsCheckBoxChecked = false;
                    NewContactMethodType = String.Empty;
                    EmployeeNum = SelectedEmployee.EmployeeNumber;
                    Assign(SelectedEmployeeDetail, SelectedEmployee);

                    EmployeeContactMethods = new ObservableCollection<ContactMethodDisplayModel>();

                    foreach (var contactMethod in SelectedEmployee.ContactMethods)
                    {
                        EmployeeContactMethods.Add(new ContactMethodDisplayModel(true, contactMethod.ContactMethodType, contactMethod.ContactMethodValue));
                    }

                    AllContactMethods = new ObservableCollection<ContactMethodDisplayModel>();

                    foreach (var cm in ContactMethodTypes)
                    {
                        var newContactMethod = new ContactMethodDisplayModel();
                        var selectedEmployeeContactMethodType = SelectedEmployee.ContactMethods.FirstOrDefault(x => x.ContactMethodType == cm.ContactMethodType);
                        if (selectedEmployeeContactMethodType != null)
                        {
                            newContactMethod.ContactMethodId = cm.ContactMethodId;
                            newContactMethod.ContactMethodType = cm.ContactMethodType;
                            newContactMethod.ContactMethodValue = selectedEmployeeContactMethodType.ContactMethodValue;
                            newContactMethod.IsSelected = true;
                        }
                        else
                        {
                            newContactMethod.ContactMethodId = cm.ContactMethodId;
                            newContactMethod.ContactMethodType = cm.ContactMethodType;
                            newContactMethod.ContactMethodValue = String.Empty;
                            newContactMethod.IsSelected = false;
                        }

                        AllContactMethods.Add(newContactMethod);
                    }   
                }
            }
        }
        public EmployeeDisplayModel SelectedEmployeeDetail { get; set; }

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

        public bool IsContactMethodsCheckBoxChecked
        {
            get
            {
                return _isContactMethodsCheckBoxChecked;
            }
            set
            {
                _isContactMethodsCheckBoxChecked = value;
                OnPropertyChanged(nameof(IsContactMethodsCheckBoxChecked));
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

        private string _errorMessage;
        private bool _hasErrorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                if (!string.IsNullOrEmpty(ErrorMessage))
                {
                    HasErrorMessage = true;
                }
                else
                {
                    HasErrorMessage = false;
                }
            }
        }

        public bool HasErrorMessage
        {
            get
            {
                return _hasErrorMessage;
            }
            set
            {
                _hasErrorMessage = value;
                OnPropertyChanged(nameof(HasErrorMessage));
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
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            QueueConsumer.Consume(channel);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmpProfile>();
                cfg.AddProfile<CMProfile>();
            });

            mapper = new Mapper(config);

            SelectedEmployeeDetail = new EmployeeDisplayModel();
            
            Employees = new ObservableCollection<EmployeeDisplayModel>();
            GetEmployees();

            ContactMethodTypes = new ObservableCollection<ContactMethodTypesDisplayModel>();
            GetContactMethodTypes();

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

        public async void GetEmployees()
        {
            try
            {
                var response = await employeeContactMethodRepo.GetCallAsync("api/employees");

                if (response.IsSuccessStatusCode)
                {
                    var emps = await response.Content.ReadAsAsync<ObservableCollection<EmployeeDTO>>();
                    Employees.Clear();
                    Employees = mapper.Map<ObservableCollection<EmployeeDisplayModel>>(emps);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Service is not available.";
            }
        }

        public async void GetContactMethodTypes()
        {
            var response = await employeeContactMethodRepo.GetContactMethodsCallAsync("api/employees/contactMethods");

            if (response.IsSuccessStatusCode)
            {
                var contactMethodTypes = await response.Content.ReadAsAsync<ObservableCollection<ContactMethodTypesDTO>>();
                ContactMethodTypes.Clear();
                ContactMethodTypes = mapper.Map<ObservableCollection<ContactMethodTypesDisplayModel>>(contactMethodTypes);
            }
        }

        private bool FilterEmployees(object obj)
        {
            if (obj is EmployeeDisplayModel Employee)
            {
                return Employee.FullName.Contains(EmployeesFilter, StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }

        public void Search()
        {
            EmployeesCollectionView.Refresh();
        }

        public async void Delete()
        {
            if (SelectedEmployee != null)
            {
                var employeeToDelete = Employees.FirstOrDefault(x => x.EmployeeNumber == SelectedEmployee.EmployeeNumber);
                var employeeToDeleteDTO = mapper.Map<EmployeeDTO>(employeeToDelete);

                if (employeeToDeleteDTO != null)
                {
                    var url = "api/employees/" + employeeToDeleteDTO.EmployeeNumber;
                    var emp = await employeeContactMethodRepo.DeleteCallAsync(url);
                    GetEmployees();
                }
            }

            IsVisible = false;
        }

        public void Add()
        {
            IsVisible = true;
            SelectedEmployee = null;
            EmployeeNum = 0;
            Clear();
            IsContactMethodsCheckBoxChecked = true;
            AllContactMethods = new ObservableCollection<ContactMethodDisplayModel>();

            foreach (var cm in ContactMethodTypes)
            {
                var newContactMethod = new ContactMethodDisplayModel();
               
                newContactMethod.ContactMethodId = cm.ContactMethodId;
                newContactMethod.ContactMethodType = cm.ContactMethodType;
                newContactMethod.ContactMethodValue = String.Empty;
                newContactMethod.IsSelected = false;
                
                AllContactMethods.Add(newContactMethod);
            }
        }

        public void Reset()
        {
            EmployeesFilter = String.Empty;
        }

        public void Cancel()
        {
            IsEmployeeNumberExisting = false;
            SelectedEmployee = null;
            SetPropertiesToFalse();
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
                var newContactMethod = new ContactMethodDisplayModel(false, NewContactMethodType, String.Empty);
                EmployeeContactMethods.Add(newContactMethod);
                NewContactMethodType = String.Empty;
                IsContactMethodTextBoxVisible = false;
            }
        }

        public async void Submit(object parameter)
        {
            CheckFirstName();
            CheckLastName();

            if (SelectedEmployee == null && !String.IsNullOrEmpty(SelectedEmployeeDetail.FirstName) && !String.IsNullOrEmpty(SelectedEmployeeDetail.LastName))
            {
                var newEmployee = new EmployeeDisplayModel();
                Assign(newEmployee, SelectedEmployeeDetail);

                newEmployee.ContactMethods = new ObservableCollection<ContactMethodDisplayModel>();

                foreach (var contactMethod in AllContactMethods)
                {
                    if (contactMethod.IsSelected == true && !String.IsNullOrEmpty(contactMethod.ContactMethodValue))
                    {
                        var newContactMethod = new ContactMethodDisplayModel();
                        AssignContactMethod(newContactMethod, contactMethod);
                        newEmployee.ContactMethods.Add(newContactMethod);
                    }
                }

                var newEmployeeDTO = mapper.Map<EmployeeDTO>(newEmployee);
                var url = "api/employees";
                var emp = await employeeContactMethodRepo.PostCallAsync(url, newEmployeeDTO);
                GetEmployees();
                Search();
                Clear();
                SetPropertiesToFalse();
            }

            if (SelectedEmployee != null && !String.IsNullOrEmpty(SelectedEmployeeDetail.FirstName) && !String.IsNullOrEmpty(SelectedEmployeeDetail.LastName))
            {
                var employeeToEdit = Employees.FirstOrDefault(x => x.EmployeeNumber == SelectedEmployee.EmployeeNumber);

                if (employeeToEdit != null)
                {
                    employeeToEdit.EmployeeNumber = EmployeeNum;
                    Assign(employeeToEdit, SelectedEmployeeDetail);
                    employeeToEdit.ContactMethods.Clear();

                    if (IsContactMethodsCheckBoxChecked == false)
                    {
                        foreach (var contactMethod in EmployeeContactMethods)
                        {
                            if (contactMethod.IsSelected == true && !String.IsNullOrEmpty(contactMethod.ContactMethodValue))
                            {
                                var employeeToEditContactMethod = new ContactMethodDisplayModel();
                                var contactMethodId = ContactMethodTypes.FirstOrDefault(x => x.ContactMethodType == contactMethod.ContactMethodType);
                                if (contactMethodId != null)
                                {
                                    employeeToEditContactMethod.ContactMethodId = contactMethodId.ContactMethodId;
                                    employeeToEditContactMethod.ContactMethodType = contactMethod.ContactMethodType;
                                    employeeToEditContactMethod.ContactMethodValue = contactMethod.ContactMethodValue;
                                }
                                employeeToEdit.ContactMethods.Add(employeeToEditContactMethod);
                            }

                        }
                    }
                    else
                    {
                        foreach (var contactMethod in AllContactMethods)
                        {
                            if (contactMethod.IsSelected == true)
                            {
                                var employeeToEditContactMethod = new ContactMethodDisplayModel();
                                AssignContactMethod(employeeToEditContactMethod, contactMethod);
                                employeeToEdit.ContactMethods.Add(employeeToEditContactMethod);
                            }
                        }
                    }
                    
                    var employeeToEditDto = mapper.Map<EmployeeDTO>(employeeToEdit);
                    var url = "api/employees/" + employeeToEdit.EmployeeNumber;
                    var emp = await employeeContactMethodRepo.PutCallAsync(url, employeeToEditDto);
                    GetEmployees();
                    Search();
                    SetPropertiesToFalse();
                    SelectedEmployee = null;
                }
            }
        }

        private void Clear()
        {
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

        private void Assign(EmployeeDisplayModel employeeToBeAssignedTo, EmployeeDisplayModel employeeToBeAssignedFrom)
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

        private void AssignContactMethod(ContactMethodDisplayModel methodToBeAssignedTo, ContactMethodDisplayModel methodToBeAssignedFrom)
        {
            methodToBeAssignedTo.ContactMethodId = methodToBeAssignedFrom.ContactMethodId;
            methodToBeAssignedTo.IsSelected = methodToBeAssignedFrom.IsSelected;
            methodToBeAssignedTo.ContactMethodType = methodToBeAssignedFrom.ContactMethodType;
            methodToBeAssignedTo.ContactMethodValue = methodToBeAssignedFrom.ContactMethodValue;
        }

        private void SetPropertiesToFalse()
        {
            IsVisible = false;
            IsEmployeeNumberEmpty = false;
            IsFirstNameEmpty = false;
            IsLastNameEmpty = false;
            IsContactMethodTextBoxVisible = false;
            IsContactMethodsCheckBoxChecked = false;
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

        //private int GenerateId()
        //{
        //    if (Employees.Count == 0)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        int maxId = Employees.Max(x => x.EmployeeNumber);
        //        int id;

        //        for (int i = 1; i <= maxId; i++)
        //        {
        //            var employee = Employees.FirstOrDefault(x => x.EmployeeNumber == i);
        //            if (employee == null)
        //            {
        //                id = i;
        //                return id;
        //            }
        //        }
        //        return maxId + 1;
        //    } 
        //}

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

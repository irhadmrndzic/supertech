using superTech.Models.City;
using superTech.Models.User;
using superTechMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace superTechMobile.ViewModels.Registration
{
    public class RegistrationViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly APIService.APIService _usersApiService = new APIService.APIService("users");
        private readonly APIService.APIService _citiesService = new APIService.APIService("cities");
        public ICommand RegisterCommand { get; }
        public ICommand InitCommand { get; }
        public ObservableCollection<CityModel> Cities { get; set; } = new ObservableCollection<CityModel>();
        public IList<CityModel> AllCities { get; set; }


        string _firstName = string.Empty;
        string _lastName = string.Empty;
        string _username = string.Empty;
        string _password = string.Empty;
        string _passwordConfirmation = string.Empty;
        DateTime _dateOfBirth = Convert.ToDateTime("01/01/2003");
        string _email = string.Empty;
        string _phoneNumber = string.Empty;
        string _address = string.Empty;
        string _gender = string.Empty;
        DateTime _fromMiminumDate = Convert.ToDateTime("01/01/1940");
        private CityModel _city;
        public CityModel SelectedCity
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }


        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public string PasswordConfirmation
        {
            get { return _passwordConfirmation; }
            set { SetProperty(ref _passwordConfirmation, value); }
        }
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }
        public string Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { SetProperty(ref _dateOfBirth, value); }
        }

        public DateTime FromMiminumDate
        {
            get { return _fromMiminumDate; }
            set
            {
                if (_fromMiminumDate == value)
                    return;

                _fromMiminumDate = value;
                NotifyPropertyChanged(nameof(FromMiminumDate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RegistrationViewModel()
        {
            RegisterCommand = new Command(async () => await onRegistrationClicked());
            InitCommand = new Command(async () => await Init());
        }



        public async Task Init()
        {
            try
            {
                AllCities = await _citiesService.Get<IList<CityModel>>(null);
                Cities.Clear();

                foreach (var city in AllCities)
                {
                    Cities.Add(city);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task onRegistrationClicked()
        {
            try
            {

                if (string.IsNullOrEmpty(FirstName) || string.IsNullOrWhiteSpace(FirstName)
                       || string.IsNullOrEmpty(LastName) || string.IsNullOrWhiteSpace(LastName)
                       || string.IsNullOrEmpty(Gender)
                       || string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Email)
                       || string.IsNullOrEmpty(Username) || string.IsNullOrWhiteSpace(Username)
                       || string.IsNullOrEmpty(Password) || string.IsNullOrWhiteSpace(Password)
                       || string.IsNullOrEmpty(PasswordConfirmation) || string.IsNullOrWhiteSpace(PasswordConfirmation))
                {
                    throw new Exception("Sva polja su obavezna!");
                }
                if (PasswordConfirmation != Password)
                {
                    throw new Exception("Passwordi se ne slažu!");
                }

                if (!string.IsNullOrEmpty(FirstName) && !Regex.IsMatch(FirstName, "^[a-zA-Z]+$"))
                {
                    throw new Exception("Ime može sadržavati samo slova!");
                }

                if (!string.IsNullOrEmpty(LastName) && !Regex.IsMatch(LastName, "^[a-zA-Z]+$"))
                {
                    throw new Exception("Prezime može sadržavati samo slova!");
                }


                if (!string.IsNullOrEmpty(Username) && !Regex.IsMatch(Username, "^[a-zA-Z0-9]+$"))
                {
                    throw new Exception("Korisničko ime može sadržavati samo slova i brojeve!");
                } 

                if (!string.IsNullOrEmpty(Gender) && !Regex.IsMatch(Gender, "^[a-zA-Z]+$"))
                {
                    throw new Exception("Spol može sadržavati samo slova!");
                }

                if (!string.IsNullOrEmpty(Address) && !Regex.IsMatch(Address, "[A-Za-z0-9'\\.\\-\\s\\,]"))
                {
                    throw new Exception("Unesite validu adresu!");
                }

                if (!string.IsNullOrEmpty(DateOfBirth.ToString()) && !(DateTime.Now.Year - 18 >= DateOfBirth.Year) )
                {
                    throw new Exception("Morate biti stariji od 18 godina!");
                }


                if (!string.IsNullOrEmpty(Email) && !Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    throw new Exception("Unesite validan email!");
                }

                var role = new List<int>();
                role.Add(1);//buyer
                UserUpsertRequest request = new UserUpsertRequest
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    UserName = Username,
                    Password = Password,
                    PasswordConfirmation = PasswordConfirmation,
                    Active = true,
                    DateOfBirth = Convert.ToDateTime(DateOfBirth).ToString("dd-MM-yyyy"),
                    DateOfRegistration = DateTime.Now.ToString("dd-MM-yyyy"),
                    Address = Address,
                    CityId = int.Parse(SelectedCity.CityId),
                    Email = Email,
                    Gender = Gender,
                    PhoneNumber = PhoneNumber,
                    Roles = role
                };

                await _usersApiService.Insert<UserModel>(request);
                Application.Current.MainPage = new LoginPage();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }


        }
    }
}

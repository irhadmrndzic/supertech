﻿using superTech.Models.User;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace superTechMobile.ViewModels.UserDetails
{
    public class UserDetailsViewModel : BaseViewModel
    {

        private readonly APIService.APIService _usersApiService = new APIService.APIService("users");

        private string _username;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _email;
        private string _phoneNumber;
        private string _oldPhoneNumber;
        private string _oldEmail;
        private string _gender;
        private string _address;
        private string _city;
        
        private bool isTextChangedEmail = false;
        private bool isTextChangedPhone = false;
        private bool isTextChanged = false;
        UserModel user = new UserModel();
        public ICommand SaveCommand { get; }

        public UserDetailsViewModel()
        {
            SaveCommand = new Command(async () => await onSaveClicked());

        }
        public string Username { get => _username; set { SetProperty(ref _username, value); } }
        public string FirstName { get => _firstName; set { SetProperty(ref _firstName, value); } }
        public string LastName { get => _lastName; set { SetProperty(ref _lastName, value); } }
        public DateTime DateOfBirth { get => _dateOfBirth; set { SetProperty(ref _dateOfBirth, value); } }
        public string Email { get => _email; set { SetProperty(ref _email, value); } }
        public string PhoneNumber { get => _phoneNumber; set { SetProperty(ref _phoneNumber, value); } }
        public string OldPhoneNumber { get => _oldPhoneNumber; set { SetProperty(ref _oldPhoneNumber, value); } }
        public string OldEmail { get => _oldEmail; set { SetProperty(ref _oldEmail, value); } }
        public string Gender { get => _gender; set { SetProperty(ref _gender, value); } }
        public string Address { get => _address; set { SetProperty(ref _address, value); } }
        public string City { get => _city; set { SetProperty(ref _city, value); } }

        public bool IsTextChangedEmail { get => isTextChangedEmail; set { SetProperty(ref isTextChangedEmail, value); } }
        public bool IsTextChangedPhoneNumber { get => isTextChangedPhone; set { SetProperty(ref isTextChangedPhone, value); } }
        public bool IsTextChanged { get => isTextChanged; set { SetProperty(ref isTextChanged, value); } }


        public async Task Init()
        {
            try
            {
               user = await _usersApiService.GetById<UserModel>(APIService.APIService.userId);
                if (user.UserName != "")
                {
                    Username = user.UserName;
                    FirstName = user.FirstName;
                    LastName = user.LastName;
                    DateOfBirth = Convert.ToDateTime(user.DateOfBirth);
                    Email = user.Email;
                    PhoneNumber = user.PhoneNumber;
                    Gender = user.Gender;
                    Address = user.Address;
                    City = user.CityString;

                    OldPhoneNumber = user.PhoneNumber;
                    OldEmail = user.Email;
                    isTextChanged = false;
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
            }
        }


        public async Task onSaveClicked()
        {
            try
            {
             UserUpsertRequest request = new UserUpsertRequest();
            request.UserName = user.UserName;
            request.FirstName = user.FirstName;
            request.Active = user.Active;
            request.LastName = user.LastName;
            request.DateOfBirth = user.DateOfBirth;
            request.Address = user.Address;
            if (!string.IsNullOrEmpty(Email) && !Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                throw new Exception("Unesite validan email!");
            }
            else
            {
                request.Email = Email;
            }
          
            request.PhoneNumber = PhoneNumber;
            request.Roles = user.Roles;
            request.CityId = user.City;
            request.Gender = user.Gender;
            request.DateOfRegistration = user.RegistrationDate;
           
                await _usersApiService.Update<UserModel>(APIService.APIService.userId, request);
                await Application.Current.MainPage.DisplayAlert("Info", "Uspješno ste uredili profil!", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
            }
        }

    }
}

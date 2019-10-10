﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using UtilityManagerXamarin.Services;
using Xamarin.Forms;

namespace UtilityManagerXamarin.ViewModels
{
    class RegisterEmployeeViewModel
    {
        ApiServices apiServices = new ApiServices();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Residence { get; set; }
        public string IdCardNumber { get; set; }
        public string Sex { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public string Picture { get; set; }

        public ICommand RegisterEmployeeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isSuccess = await apiServices.RegisterEmployeeAsync(FirstName, LastName, Email, Password, Picture, Phone, Residence, IdCardNumber, Sex);
                    await App.Current.MainPage.DisplayAlert("Task Successfull", "Employee Registered Successfully!", "OK");

                });



            }
        }
    }
}

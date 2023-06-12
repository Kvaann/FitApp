using FitApp.Helpers;
using FitApp.ViewModels.Abstract;
using FitAppApi;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FitApp.ViewModels.UsersViewModel
{
    public class NewUserViewModel : ANewViewModel<Users>
    {
        #region Fields

        private int id;
        private string userName;
        private string password;
        private string email;
        private string firstName;
        private string lastName;
        private string gender;
        private int age;
        private decimal weight;
        private decimal height;
        private string activityLevel;

        #endregion Fields

        #region Properties

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        public string Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }

        public int Age
        {
            get => age;
            set => SetProperty(ref age, value);
        }

        public decimal Weight
        {
            get => weight;
            set => SetProperty(ref weight, value);
        }

        public decimal Height
        {
            get => height;
            set => SetProperty(ref height, value);
        }

        public string ActivityLevel
        {
            get => activityLevel;
            set => SetProperty(ref activityLevel, value);
        }

        public ObservableCollection<Users> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddSinCommand { get; }

        #endregion Properties

        #region Contructor

        public NewUserViewModel()
            : base()
        {
        }

        #endregion

        #region Methods

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(userName);
        }

        public override Users SetItem()
        {
            return new Users
            {
                CreationDate = DateTime.Now,
                UserName = this.UserName,
                Password = this.Password,
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Gender = this.Gender,
                Age = this.Age,
                Weight = (double)this.Weight,
                Height = (double)this.Height,
                ActivityLevel = this.ActivityLevel,
                IsActive = true,
                ModificationDate = DateTime.Now,

                Notes = "New item",
                Title = "User"
            }.CopyProperties(this);
        }

        #endregion
    }
}
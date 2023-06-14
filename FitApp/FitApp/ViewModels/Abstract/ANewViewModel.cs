using FitApp.Services.Abstract;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitApp.ViewModels.Abstract
{
    public abstract class ANewViewModel<T> : BaseViewModel
    {
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        public ANewViewModel()
        {
            try
            {
                SaveCommand = new Command(OnSave, ValidateSave);
                CancelCommand = new Command(OnCancel);
                this.PropertyChanged +=
                    (_, __) => SaveCommand.ChangeCanExecute();
            }
            catch (Exception e)
            { 

            }
        }
        public abstract bool ValidateSave();
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        public abstract T SetItem();
        private async void OnSave()
        {
            await DataStore.AddItemAsync(SetItem());
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
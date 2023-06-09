using FitApp.Helpers;
using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitApp.Views.ExerciseView;
using FitAppApi;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitApp.ViewModels.ExerciseViewModel
{
    public class ExeriseEditViewModel : AItemDatailsViewModel<Exercises>
    {
        #region Constructor

        public ExeriseEditViewModel()
        {
            
        }

        #endregion

        #region Fields

        private int id;
        private string exerciseName;
        private string exerciseDescription;
        private string exerciseType;
        private string muscleGroup;

        #endregion

        #region Properties

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string ExerciseName
        {
            get => exerciseName;
            set => SetProperty(ref exerciseName, value);
        }

        public string ExerciseDescription
        {
            get => exerciseDescription;
            set => SetProperty(ref exerciseDescription, value);
        }

        public string ExerciseType
        {
            get => exerciseType;
            set => SetProperty(ref exerciseType, value);
        }

        public string MuscleGroup
        {
            get => muscleGroup;
            set => SetProperty(ref muscleGroup, value);
        }

        public ObservableCollection<Exercises> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddSinCommand { get; }

        #endregion Properties


        public override void LoadProperties(Exercises item)
        {
            ExerciseName = item.ExerciseName;
            ExerciseDescription = item.ExerciseDescription;
            ExerciseType = item.ExerciseType;
            MuscleGroup = item.MuscleGroup;
            Title = "Exercise Details";
            this.CopyProperties(item);
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var dataStore = DependencyService.Get<ExerciseService>();
                var items = (await dataStore.GetItemsAsync(true)).Where(item => item.ExerciseID == Id);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task OnEditSelected(int id)
        {
            var item = DataStore.GetItemAsync(id);
            LoadProperties(item.Result);
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(ExerciseEditPage)}?{nameof(ExerciseDetailsViewModel.ItemId)}={item.Id}");
        }

        public override void OnUpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}

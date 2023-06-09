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
    public class ExerciseDetailsViewModel : AItemDatailsViewModel<Exercises>
    {
        public ExerciseDetailsViewModel()
            : base()
        {
            Items = new ObservableCollection<Exercises>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddSinCommand = new Command(async () => await OnEditSelected(ItemId));
        }

        #region Fields

        private int id;
        private string exerciseName;
        private string exerciseDescription;
        private string exerciseType;
        private string muscleGroup;

        #endregion Fields

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

        public override async void LoadProperties(Exercises item)
        {
            ExerciseName = item.ExerciseName;
            ExerciseDescription = item.ExerciseDescription;
            ExerciseType = item.ExerciseType;
            MuscleGroup = item.MuscleGroup;
            Title = "Exercise Details";
            this.CopyProperties(item);
            await ExecuteLoadItemsCommand();
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
            var dataStore = DependencyService.Get<ExerciseService>();
            var item = (await dataStore.GetItemsAsync(true)).Where(item2 => item2.ExerciseID == id).First();
            LoadProperties(item);
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(ExerciseEditPage)}?{nameof(ExerciseDetailsViewModel.ItemId)}={item.ExerciseID}");
        }

        public override async void OnUpdateAsync()
        {
            var dataStore = DependencyService.Get<ExerciseService>();
            var Item = (await dataStore.GetItemsAsync(true)).Where(item => item.ExerciseID == ItemId).First();
            Item.ModificationDate = DateTime.Now;
            Item.ExerciseDescription = this.ExerciseDescription;
            Item.ExerciseName = this.ExerciseName;
            Item.ExerciseType = this.ExerciseType;
            Item.MuscleGroup = this.MuscleGroup;
            await DataStore.UpdateItemAsync(Item);
            await Shell.Current.GoToAsync("..");
        }
    }
}
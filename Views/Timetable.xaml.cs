using Tizen.Wearable.CircularUI.Forms;
using TPG.Model;
using Xamarin.Forms.Xaml;

namespace TPG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Timetable : CirclePage
    {
        ProchainDepart proDep;

        public Timetable(ProchainDepart proDep)
        {
            this.proDep = proDep;
            InitializeComponent();
            loadingState(true);
        }

        protected override async void OnAppearing()
        {
            TimetableModel timetable = await TPGProvider.TimetableAsync(proDep);
            mylist.ItemsSource = timetable.prochainsDeparts.prochainDepart;
            loadingState(false);
            base.OnAppearing();
        }

        private void loadingState(bool load)
        {
            loading.IsRunning = load;
            loading.IsEnabled = load;
            loading.IsVisible = load;
            mylist.IsVisible = !load;
        }

    }
}
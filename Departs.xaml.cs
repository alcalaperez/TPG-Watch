using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Tizen.Wearable.CircularUI.Forms;
using TPG.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Departs : CirclePage
    {
        Connexion conexion;

        public Departs(Connexion conexion)
        {
            this.conexion = conexion;
            InitializeComponent();
            loadingState(true);          
        }

        protected override async void OnAppearing()
        {
            DepartsModel departures = await RESTCall.DesparturesAsync(conexion.codeArret);

            foreach (ProchainDepart prochDep in departures.prochainsDeparts.prochainDepart)
            {
                prochDep.codeArret = conexion.codeArret;
            }
            mylist.ItemsSource = departures.prochainsDeparts.prochainDepart;
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
        
        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await Navigation.PushAsync(new Timetable((ProchainDepart)e.Item));
        }
    }
}

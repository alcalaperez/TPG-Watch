using System;
using System.Collections.Generic;
using System.Linq;
using Tizen.Wearable.CircularUI.Forms;
using TPG.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : CirclePage
    {
        List<Connexion> conexionList;

        public MainPage()
        {
            InitializeComponent();
            loadingState(true);
        }


        protected override async void OnAppearing()
        {
            RootObject arrets = await TPGProvider.CallArretsAsync();
            conexionList = arrets.connexions.connexion.OrderBy(o => o.nomArret).ToList();
            mylist.ItemsSource = conexionList;
            loadingState(false);
            base.OnAppearing();
        }

        private void loadingState(bool load)
        {
            loading.IsRunning = load;
            loading.IsEnabled = load;
            loading.IsVisible = load;
            search.IsVisible = !load;
            mylist.IsVisible = !load;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (conexionList == null)
            {
                return;
            }
            else if (String.IsNullOrEmpty(e.NewTextValue))
            {
                mylist.ItemsSource = conexionList;
                search.Text = "";
            }
            else
            {
                mylist.ItemsSource = conexionList.Where(x => x.nomArret.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }

        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }
            await Navigation.PushAsync(new Departs(((Connexion)e.Item)));
        }

        public void PopupEntry_Completed(object sender, EventArgs e)
        {
            mylist.ItemsSource = conexionList.Where(x => x.nomArret.Contains(search.Text));
        }
    }
}
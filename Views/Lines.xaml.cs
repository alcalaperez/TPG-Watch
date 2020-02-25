using System.Collections.Generic;
using Tizen.Wearable.CircularUI.Forms;
using TPG.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lines : CirclePage
    {
        private Connexion item;

        public Lines(Connexion conexion)
        {
            InitializeComponent();
        }

        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }
            await Navigation.PopAsync();

        }

        public class LineaModel : List<string>
        {
            public List<string> lines { get; set; }

            public LineaModel(List<string> lines)
            {
                this.lines = lines;
            }
        }
    }

}
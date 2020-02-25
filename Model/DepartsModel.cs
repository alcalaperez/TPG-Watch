using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPG.Model
{
    public class ProchainDepart
    {
        public object ligne { get; set; }
        public object ligneTech { get; set; }
        public string transporteur { get; set; }
        public string destination { get; set; }
        public object attente { get; set; }
        public string fiabilite { get; set; }
        public int attenteMilli { get; set; }
        public string heureArrivee { get; set; }
        public string heureDepart { get; set; }
        public string destinationMajuscule { get; set; }
        public string deviation { get; set; }
        public int horaireRef { get; set; }
        public string vehiculeType { get; set; }
        public int vehiculeNo { get; set; }
        public string mnemol { get; set; }
        public string quai { get; set; }
        public int courseRef { get; set; }
        public string caracteristique { get; set; }
        public object codeArret { get; set; }
        public string departString => $"Line {ligne} at {heureDepart} ({attente} min)";
        public string detailString => $"Direction {destination}";

    }

    public class ProchainsDeparts
    {
        public string nomArret { get; set; }
        public string heure { get; set; }
        public string timestamp { get; set; }
        public string codeArret { get; set; }
        public string arretFinal { get; set; }
        public List<ProchainDepart> prochainDepart { get; set; }
    }

    public class DepartsModel
    {
        public ProchainsDeparts prochainsDeparts { get; set; }
    }
}

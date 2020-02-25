using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPG.Model
{

    public class ProchainDepartTimetable
    {
        public int ligne { get; set; }
        public int ligneTech { get; set; }
        public string transporteur { get; set; }
        public string destination { get; set; }
        public int attenteMilli { get; set; }
        public string heureArrivee { get; set; }
        public string heureDepart { get; set; }
        public string heure { get; set; }
        public int courseRef { get; set; }
    }

    public class ProchainsDepartsTimetable
    {
        public string nomArret { get; set; }
        public string heure { get; set; }
        public string timestamp { get; set; }
        public string codeArret { get; set; }
        public string arretFinal { get; set; }
        public List<ProchainDepartTimetable> prochainDepart { get; set; }
    }

    public class TimetableModel
    {
        public ProchainsDepartsTimetable prochainsDeparts { get; set; }
    }
}

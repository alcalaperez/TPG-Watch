using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPG.Model
{
    public class Connexion
    {
        public string nomArret { get; set; }
        public string codeArret { get; set; }
        public string lignes { get; set; }
        public string lignesTech { get; set; }
        public string transporteurs { get; set; }
        public object ligne { get; set; }
        public object ligneTech { get; set; }
        public string transporteur { get; set; }        
        public string ligneFormat { 
            get {
                if(lignes != null && lignes != "")
                {
                    return lignes;
                }
                return ligne.ToString();
            } set { } }


        override public string ToString()
        {
            string str = String.Empty;
            str = String.Concat(str, "nomArret = ", nomArret, "\r\n");
            str = String.Concat(str, "codeArret = ", codeArret, "\r\n");
            str = String.Concat(str, "lignes = ", lignes, "\r\n");
            str = String.Concat(str, "lignesTech = ", lignesTech, "\r\n");
            str = String.Concat(str, "ligne = ", ligne, "\r\n");
            return str;
        }
    }

    public class Connexions
    {
        public string timestamp { get; set; }
        public List<Connexion> connexion { get; set; }
    }

    public class RootObject
    {
        public Connexions connexions { get; set; }

        public static implicit operator string(RootObject v)
        {
            throw new NotImplementedException();
        }
    }
}

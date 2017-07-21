using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_e
{
    class Question
    {
        public int numQuestion { get;  set; }
        public string ennonce { get;  set; }
        public string chemin { get;  set; }

        public int hauteur { get;  set; }
        public int largeur { get; set; }

        public List<Zone> Zones{get;  set;}

        public Question(int numQuestion, string ennonce, string chemin, int hauteur,int largeur)
        {
            this.numQuestion = numQuestion;
            this.ennonce = ennonce;
            this.chemin = chemin;
            this.hauteur = hauteur;
            this.largeur = largeur;
            this.Zones = new List <Zone>();
        }

        public Question()
        { this.Zones = new List<Zone>(); }
    }
}

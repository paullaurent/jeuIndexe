using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_e
{
    class Zone //permet de gérer les zones à cliquer
    {
        public int hauteur { get; private set; }
        public int largeur { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }

        public Zone(int x, int y, int hauteur, int largeur)
        {
            this.hauteur = hauteur;
            this.largeur = largeur;
            this.x = x;
            this.y = y;
        }
        public Zone()
        { }
    }
}

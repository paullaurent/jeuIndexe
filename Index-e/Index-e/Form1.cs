using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Index_e
{
    public partial class Form1 : Form
    {
        List<Question> Questions = new List<Question>();
        int numQuestion = 1;
        int numMaxQuestion = 0;
        int nb_erreurs = 0;
        public Form1()
        {

            readTxt();
            InitializeComponent();
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Size = new System.Drawing.Size(Questions[0].largeur, Questions[0].hauteur);
            label1.BackColor = Color.FromArgb(0, Color.Green);
        }
        public void readTxt()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Paul\Documents\Ecole\2A\indexe\jeuIndexe\data.txt");
            int i = 0;
            int j = -1;
            while (i != lines.Length)
            {
                

                if (lines[i] == "question")
                {
                    Question question = new Question();
                    question.numQuestion = Convert.ToInt32(lines[i + 1]);
                    numMaxQuestion = Convert.ToInt32(lines[i + 1]);
                    question.ennonce = lines[i + 3];
                    question.chemin = lines[i + 5];
                    question.hauteur = Convert.ToInt32 (lines[i + 7]);
                    question.largeur = Convert.ToInt32(lines[i + 9]);
                    Questions.Add(question);
                    i += 10;
                    j++;
                }

                else if (lines[i] == "zone")
                {
                    Char delimiter = ',';
                    String[] substrings = lines[i + 1].Split(delimiter);
                    Zone zone = new Zone(Convert.ToInt32(substrings[0]), Convert.ToInt32(substrings[1]), Convert.ToInt32(substrings[2]), Convert.ToInt32(substrings[3]));
                    Questions[j].Zones.Add(zone);
                    i += 2;
                }
            }

        }


        int res = 0;
        private void label1_Click(object sender, EventArgs e)
        {
            int nbZones = 0;
            Zone zone=new Zone();

            int ok = 0; //permet de savoir si une zone correspond
            int x = MousePosition.X;
            int y = MousePosition.Y;
            using (Graphics g = this.label1.CreateGraphics())
            {

                ok = 0;
                for (int i = 0; i < numMaxQuestion; i++)
                {
                    for (int j = 0; j < Questions[i].Zones.Count; j++)
                    {
                        if (Questions[i].numQuestion == numQuestion)
                        {
                            
                            if (x > Questions[i].Zones[j].x && x < Questions[i].Zones[j].x + Questions[i].Zones[j].largeur && y > Questions[i].Zones[j].y && y < Questions[i].Zones[j].y + Questions[i].Zones[j].hauteur)
                            {
                                nbZones = Questions[i].Zones.Count;
                                zone = Questions[i].Zones[j];
                                ok++;
                            }

                        }
                    }
                }
                if (ok == 1)
                {

                    PictureBox panel = new PictureBox();
                    panel.BackColor = Color.Green;
                    panel.Location=new Point(Convert.ToInt32(zone.x + 0.05 * zone.largeur), Convert.ToInt32(zone.y + 0.05 * zone.hauteur));
                    panel.Size = new Size(Convert.ToInt32(0.9 * zone.hauteur), Convert.ToInt32(0.9 * zone.largeur));
                    this.Controls.Add(panel);
                    panel.BringToFront();
                    res++;
                }
                else
                {
                    string message = "Cette zone ne correspond pas";
                    string caption = "Mauvaise zone";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);

                }

                if (res == nbZones)
                {
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl.Name != "label1")
                        {
                            ctrl.BackColor = Color.Transparent;
                        }
                    }
                    InitializeComponent();
                }

            }

        }


    }
}

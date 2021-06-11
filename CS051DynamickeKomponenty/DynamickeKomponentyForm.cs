using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS051DynamickeKomponenty
{
    public partial class DynamickeKomponentyForm : Form
    {
        public DynamickeKomponentyForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DynamickeKomponentyForm_Click(object sender, EventArgs e)
        {
            
        }

        private class AnimovanyObjekt
        {
            public float dx { get; set; }
            public float dy { get; set; }

            public AnimovanyObjekt(float dx, float dy)
            {
                this.dx = dx;
                this.dy = dy;
            }
        }

        private Random rnd = new Random();


        private void DynamickeKomponentyForm_MouseClick(object sender, MouseEventArgs e)
        {
            var checkbox = new CheckBox()
            {
                Top = e.Y,
                Left = e.X,
                Tag = new AnimovanyObjekt(rnd.Next(1, 1), rnd.Next(1, 1)),
                BackColor = Color.Red,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(16, 16),
                Padding = new Padding(3, 3, 3, 3),
            };
            checkbox.MouseLeave += animovanyCheckBox_ZvysitSkore;
            this.Controls.Add(checkbox);

        }

        private void animaceTimer_Tick(object sender, EventArgs e)
        {
            int height = this.Height -60;
            int width = this.Width -40;
            int aoX, aoY;

            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(CheckBox))
                {
                    CheckBox ch = (c as CheckBox);

                    AnimovanyObjekt ao = (ch.Tag as AnimovanyObjekt);
                    
                    ch.Top += (int)ao.dy;
                    ch.Left += (int)ao.dx;
                    aoX = ch.Top;
                    aoY = ch.Left;

                    if (aoX >= (height) || aoX <= 10)
                    {
                        ao.dy *= -1;
                    }
                    if (aoY >= (width) || aoY <= 10)
                    {
                        ao.dx *= -1;
                    }
                }                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
         
        }
        private int score = 0;
        private void animovanyCheckBox_ZvysitSkore(object sender, EventArgs e)
        {
            CheckBox ch = (sender as CheckBox);
            AnimovanyObjekt ao = (ch.Tag as AnimovanyObjekt);

            scoreLabel.Text = string.Format("score: {0:0000}", score += (int)Math.Sqrt(ao.dx * ao.dx + ao.dy * ao.dy));
            ao.dx *= (float)1.2;
            ao.dy *= (float)1.2;
        }

        private void checkBox1_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}

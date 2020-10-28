using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_0_
{
    public partial class Form1 : Form
    {
        public box_for_things box = new box_for_things();
        public static PictureBox tt = new PictureBox();
        //   public Mandelbrot test = new Mandelbrot();
        //   public Burningship test = new Burningship();
        public Julia test = new Julia();
        public Form1()
        {
            InitializeComponent();

            tt.Size = new Size(Consts.WIDTH, Consts.HEIGHT);
            tt.Image = test.Draw_to_Bitmap(box);
            this.Controls.Add(tt);
            var g = Graphics.FromImage(tt.Image);
            g.DrawImage(tt.Image, 0, 0);
        }


        // работает только через SHIFT + KEY в английской раскладке
        private void Form1_Key_pres(object sender, KeyPressEventArgs e)
        {
            var g = Graphics.FromImage(tt.Image);
            switch (e.KeyChar)
            {
                case (char)Keys.A:
                    box.x += 500;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.D:
                    box.x -= 500;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.W:
                    box.y += 500;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.S:
                    box.y -= 500;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.Oemplus:
                    box.z *= 2;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.OemMinus:
      //              if (box.z > 1)
                        box.z /= 2;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.Add:
                    box.z *= 2;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.Subtract:
                    //              if (box.z > 1)
                    box.z /= 2;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.Q:
                    box.z *= 2;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.E:
                    if (box.z > 1)
                        box.z /= 2;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
            }
    //        MessageBox.Show("" + e.KeyChar.ToString());
        }

        // без этих штук не работает корректно
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}


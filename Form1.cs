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

// глобальные вопросы к нэймингу 

namespace WindowsForms_0_
{
    public partial class Form1 : Form
    {
        public box_for_things box = new box_for_things();
        public static PictureBox tt = new PictureBox();

        // тип фрактала изменяется типом обьекта test
        public Mandelbrot test = new Mandelbrot();
        //   public Burningship test = new Burningship();
    //    public Julia test = new Julia();
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
            // повторяющиеся блоки можно было бы вынести в функции, но они существуют 
            // только потому что на моей клавиауре клавиши + и - не отлавливаются            
            switch (e.KeyChar)
            { 
                case (char)Keys.A:
                    box.x += 500/box.z;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.D:
                    box.x -= 500/box.z;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.W:
                    box.y += 500/box.z;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.S:
                    box.y -= 500/box.z;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.Oemplus:
                    box.z *= 2;
                    box.max_iter += 100;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.OemMinus:
      //              if (box.z > 1)
                        box.z /= 2;
                    if (box.max_iter > 300)
                        box.max_iter -= 100;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.Add:
                    box.z *= 2;
                    box.max_iter += 100;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.Subtract:
                    if (box.z > 1)
                        box.z /= 2;
                    if (box.max_iter > 300)
                        box.max_iter -= 100; 
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.Q:
                    box.z *= 2;
                    box.max_iter += 100;
                    tt.Image = test.Draw_to_Bitmap(box);
                    g.DrawImage(tt.Image, 0, 0);
                    break;
                case (char)Keys.E:
                    if (box.z > 1)
                        box.z /= 2;
                    if (box.max_iter > 300)
                        box.max_iter -= 100;
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

        // не разобрался как работает MouseMove - messageBox выводит правдоподбные координаты, но в рандомные промежутки времени
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
  //          MessageBox.Show("" + e.X + "\n" + e.Y);
            if (test is Julia)
            {
                /*MessageBox.Show("" + e.X);*/
                box.d_re = 0.5 * (e.X * 1.0) / this.Width;
            }
        }
    }
}


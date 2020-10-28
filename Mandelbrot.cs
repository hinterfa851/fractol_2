using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsForms_0_
{
    // Обьявление констант 
    public class Consts
    {
        public static int WIDTH { get; } = 1000;
        public static int HEIGHT { get; } = 1000;
        public static int MAX_ITER { get; } = 300;
    }

    public class Mandelbrot
    {
        public virtual double cre { get; } = 0;
        public virtual double cim { get; } = 0;
        public PictureBox tt;
        public Bitmap array = new Bitmap(Consts.WIDTH, Consts.HEIGHT);
        public Mandelbrot()
        {
           
        }
        protected virtual double findOld(double New)
        {
            return (New);
        }
        protected virtual double findNewre(double oldim, double oldre, double pr)
        {
            return (oldre * oldre
                    - oldim * oldim + this.cre + pr);
        }

        protected virtual double findNewim(double oldim, double oldre, double pi)
        {
            return (2 * oldre * oldim + this.cim + pi);
        }

        protected virtual double initNewim(int i)
        {
            return (0);
        }

        protected virtual double initNewre(int i)
        {
            return (0);
        }
        public virtual int test_func(int i, int j, box_for_things box)
        {
            double counter;

            counter = 0;
            double newre = initNewre(i);
            double newim = initNewim(j);

            double oldre;
            double oldim;

    //        if (box_for_things.x != 0)
    //            MessageBox.Show("" + box_for_things.x);

            double pr = ((i - Consts.WIDTH / 2)) / (0.25 * Consts.WIDTH * box.z) - box.x / Consts.WIDTH;
            //           double pr = ((i - WIDTH / 2)) / (0.25 * WIDTH * fractol->z)
            //       + fractol->x / (WIDTH);
            double pi = ((j - Consts.HEIGHT / 2)) / (0.25 * Consts.HEIGHT * box.z) - box.y / Consts.HEIGHT;
            //             + fractol->y / (HEIGHT);

            while (counter < Consts.MAX_ITER)
            {
                oldre = findOld(newre);
                oldim = findOld(newim);
                newre = findNewre(oldim, oldre, pr);
                newim = findNewim(oldim, oldre, pi);
                if ((newre * newre + newim * newim) > 4)
                    return ((int)counter);
                counter += 1;
            }
            return ((int)counter);
        }


        int get_light(int start, int end, double percentage)
        {
            return ((int)((1 - percentage) * start + percentage * end));
        }

        void gcol(int counter, int c1, int c2, int i, int j)
        {
            int red;
            int green;
            int blue;
            double test;
            double num;

            if (counter <= Consts.MAX_ITER * 1.0 / 10)
                num = 0.1;
            else
                num = 1;
            test = counter / (Consts.MAX_ITER * num * 0.1);
            num = (num) * Consts.MAX_ITER;
            red = get_light((c1 >> 16) & 0xFF, (c2 >> 16) & 0xFF, ((int)test) / 10.0);
            green = get_light((c1 >> 8) & 0xFF, (c2 >> 8) & 0xFF, ((int)test) / 10.0);
            blue = get_light(c1 & 0xFF, c2 & 0xFF, ((int)test) / 10.0);
            array.SetPixel(i, j, Color.FromArgb(red, green, blue));
        }

        void color_helper(int i, int j, box_for_things box)
        {
            int test;

            test = test_func(i, j, box);
            if (test == Consts.MAX_ITER)
                array.SetPixel(i, j, Color.FromArgb(0, 0, 0));
            else if (test <= Consts.MAX_ITER * 1.0 / 10)
                gcol(test, 0x0D1C33, 0x2B6832, i, j);
            else
                gcol(test, 0x4F9300, 0xA1D700, i, j);
        }

        public  Bitmap Draw_to_Bitmap(box_for_things box)
        {
            for (int i = 0; i < Consts.WIDTH; i++)
            {
                for (int j = 0; j < Consts.HEIGHT; j++)
                      color_helper(i, j, box);
                //    array.SetPixel(i, j, Color.FromArgb(0, 0, 0));
            }
            return array;
        }
    }
}

/*
    public class Mandelbrot
    {
        Bitmap array = new Bitmap(Consts.WIDTH, Consts.HEIGHT);
        public virtual double cre { get; } = 0;
        public virtual double cim { get; } = 0;
        protected virtual double findOld(double New)
        {
            return (New);
        }
        protected virtual double findNewre(double oldim, double oldre, double pr)
        {
            return (oldre * oldre
                    - oldim * oldim + this.cre + pr);
        }

        protected virtual double findNewim(double oldim, double oldre, double pi)
        {
            return (2 * oldre * oldim + this.cim + pi);
        }

        protected virtual double initNewim(int i)
        {
            return (0);
        }

        protected virtual double initNewre(int i)
        {
            return (0);
        }
        public virtual int test_func(int i, int j)
        {
            double counter;

            counter = 0;
            double newre = initNewre(i);
            double newim = initNewim(j);

            double oldre;
            double oldim;

            double pr = ((i - Consts.WIDTH / 2)) / (0.25 * Consts.WIDTH) + box_for_things.x/Consts.WIDTH;
            //           double pr = ((i - WIDTH / 2)) / (0.25 * WIDTH * fractol->z)
            //       + fractol->x / (WIDTH);
            double pi = ((j - Consts.HEIGHT / 2)) / (0.25 * Consts.HEIGHT);
            //             + fractol->y / (HEIGHT);

            while (counter < Consts.MAX_ITER)
            {
                oldre = findOld(newre);
                oldim = findOld(newim);
                newre = findNewre(oldim, oldre, pr);
                newim = findNewim(oldim, oldre, pi);
                if ((newre * newre + newim * newim) > 4)
                    return ((int)counter);
                counter += 1;
            }
            return ((int)counter);
        }


        int get_light(int start, int end, double percentage)
        {
            return ((int)((1 - percentage) * start + percentage * end));
        }

        void gcol(int counter, int c1, int c2, int i, int j)
        {
            int red;
            int green;
            int blue;
            double test;
            double num;

            if (counter <= Consts.MAX_ITER * 1.0 / 10)
                num = 0.1;
            else
                num = 1;
            test = counter / (Consts.MAX_ITER * num * 0.1);
            num = (num) * Consts.MAX_ITER;
            red = get_light((c1 >> 16) & 0xFF, (c2 >> 16) & 0xFF, ((int)test) / 10.0);
            green = get_light((c1 >> 8) & 0xFF, (c2 >> 8) & 0xFF, ((int)test) / 10.0);
            blue = get_light(c1 & 0xFF, c2 & 0xFF, ((int)test) / 10.0);
            array.SetPixel(i, j, Color.FromArgb(red, green, blue));
        }

        void color_helper(int i, int j)
        {
            int test;

            test = test_func(i, j);
            if (test == Consts.MAX_ITER)
                array.SetPixel(i, j, Color.FromArgb(0, 0, 0));
            else if (test <= Consts.MAX_ITER * 1.0 / 10)
                gcol(test, 0x0D1C33, 0x2B6832, i, j);
            else
                gcol(test, 0x4F9300, 0xA1D700, i, j);
        }
        public void DrawImage(PaintEventArgs e)
        {
            for (int i = 0; i < Consts.WIDTH; i++)
            {
                for (int j = 0; j < Consts.HEIGHT; j++)
                    color_helper(i, j);
            }
            e.Graphics.DrawImage(array, 0, 0);
        }
    }
}
*/
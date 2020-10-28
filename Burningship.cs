using System;


namespace WindowsForms_0_
{
    public class Burningship : Mandelbrot
    {
        protected override double findOld(double New)
        {
            return Math.Abs(New);
        }
    }
}



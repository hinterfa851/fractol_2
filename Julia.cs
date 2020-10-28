using System;


namespace WindowsForms_0_
{
    // выглядит избыточным решением, возможно стоило перегрузить только test_funk
    public class Julia : Mandelbrot
    {

        public override double cre { get; } = -0.7;
        public override double cim { get; } = 0.5;

        protected override double findNewre(double oldim, double oldre, double pr)
        {
            return (oldre * oldre
                    - oldim * oldim + this.cre);
        }

        protected override double findNewim(double oldim, double oldre, double pi)
        {
            return (2 * oldre * oldim + cim);
        }

        protected override double initNewre(int i)
        {
            return ((i - Consts.WIDTH / 2)) / (0.25 * Consts.WIDTH);
        }

        protected override double initNewim(int i)
        {
            return ((i - Consts.HEIGHT / 2)) / (0.25 * Consts.HEIGHT);
        }
    }
}
    
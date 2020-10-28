using System;


namespace WindowsForms_0_
{
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
        /*
        public override double cre { get; } = -0.7;
        public override double cim { get; } = 0.5;

        public override int test_func(int i, int j)
        {
            double counter;

            counter = 0;
            double oldre;
            double oldim;

            double newre = ((i - Consts.WIDTH / 2)) / (0.25 * Consts.WIDTH);
            double newim = ((j - Consts.HEIGHT / 2)) / (0.25 * Consts.HEIGHT);

            while (counter < Consts.MAX_ITER)
            {
                oldre = newre;
                oldim = newim;
                newre = oldre * oldre
                    - oldim * oldim + cre;
                newim = 2 * oldre * oldim + cim;
                if ((newre * newre + newim * newim) > 4)
                    return ((int)counter);
                counter += 1;
            }
            return ((int)counter);
        }
    
    }
        */


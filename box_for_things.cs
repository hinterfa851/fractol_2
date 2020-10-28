using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_0_
{
    public class box_for_things
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double d_re { get; set; }
        public double d_im { get; set; }

        public double max_iter { get; set; }
        public box_for_things ()
        {
            x = 0;
            y = 0;
            z = 1;
            d_re = 0.5;
            d_im = -0.7;
            max_iter = 300;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letalka
{
    struct AngleFunc
    {
        public static float Diff(float a, float b) {
            float fp2 = (float)Math.PI*2;
            a %= fp2;
            b %= fp2;
            float ret = (a - b - fp2) % fp2;
            float r2  = (a - b + fp2) % fp2;
            float r3  = (a - b) % fp2;
            if (Math.Abs(r2) < Math.Abs(ret)) ret = r2;
            if (Math.Abs(r3) < Math.Abs(ret)) ret = r3;
            return ret;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letalka
{
    //builder???
    /*
     * Летно-технические характеристики
     */
    class LTH
    {
        //const???
        public float forwardSpeed;
        public float backwardSpeed;
        public float strafeSpeed;
        public float turnSpeed;
        public float width;
        public float length;

        public LTH(float forwardSpeed, float backwardSpeed, float strafeSpeed, float turnSpeed, float width, float length)
        {
            this.forwardSpeed = forwardSpeed;
            this.backwardSpeed = backwardSpeed;
            this.strafeSpeed = strafeSpeed;
            this.turnSpeed = turnSpeed;
            this.width = width;
            this.length = length;
        }
    }
}

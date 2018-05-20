using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letalka
{
    interface IMediator<T>
    {
        void ObjectChanged(WorldObject obj);
    }
}

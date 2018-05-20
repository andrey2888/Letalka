using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letalka
{
    interface ISubject
    {
        void AddObserver(IObserver observer);
        void DeleteObserver(IObserver observer);
        void Notify();
    }
}

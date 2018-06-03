
using System.Collections.Generic;

namespace Letalka
{
    public interface Observer
    {
        void Update(string message);
    }

    public abstract class Observable
    {
        public List<Observer> Observers { get; set; } = new List<Observer>();

        public void NotifyAll(string message)
        {
            Observers.ForEach(o => o.Update(message));
        }
    }
}

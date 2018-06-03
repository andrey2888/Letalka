using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Letalka
{
    public class StateFactory
    {
        static Dictionary<Type, IGameState> states = new Dictionary<Type, IGameState>()
        {
            [typeof(Menu)] = new Menu(),
            [typeof(Game1)] = new Game1()
        };
        public static IGameState GetState(Type stateType) => states[stateType];
    }
}
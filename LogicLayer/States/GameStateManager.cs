using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.LogicLayer
{
    class GameStateManager
    {

        Stack<GameState> states; 

        public GameStateManager()
        {
            states = new Stack<GameState>();

        }

        public void Update()
        {
            states.Peek().Update();
        }

        public void Add(GameState state)
        {
            states.Push(state);
        }

        public void Remove()
        {
            states.Pop();
        }

        public GameState GetState()
        {
            return states.Peek();
        }
    }
}

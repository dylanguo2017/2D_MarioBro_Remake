using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using static Game.Utility;

namespace Game
{

    public class GamepadController : IController
    {
        private Dictionary<Buttons, ICommand> controllerMappings;

        Buttons[] exist = new Buttons[six] { Buttons.LeftThumbstickUp, Buttons.LeftThumbstickDown, Buttons.LeftThumbstickLeft, Buttons.LeftThumbstickRight, Buttons.A, Buttons.B };

        public GamepadController()
        {
            controllerMappings = new Dictionary<Buttons, ICommand>();
        }

        public void RegisterCommand(Buttons button, ICommand command)
        {
            controllerMappings.Add(button, command);
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
           
        }

        public bool isConnected()
        {
            return GamePad.GetState(PlayerIndex.One).IsConnected;
        }

        public void Update()
        {
            GamePadState currentState = GamePad.GetState(PlayerIndex.One);

            if (currentState.IsButtonDown(exist[zero]))
            {
                controllerMappings[exist[zero]].Execute();
            }
            if (currentState.IsButtonDown(exist[one]))
            {
                controllerMappings[exist[one]].Execute();
            }
            if (currentState.IsButtonDown(exist[two]))
            {
                controllerMappings[exist[two]].Execute();
            }
            if (currentState.IsButtonDown(exist[three]))
            {
                controllerMappings[exist[three]].Execute();
            }
            if (currentState.IsButtonDown(exist[four]))
            {
                controllerMappings[exist[four]].Execute();
            }
            if (currentState.IsButtonDown(exist[five]))
            {
                controllerMappings[exist[five]].Execute();
            }
        }
    }
}

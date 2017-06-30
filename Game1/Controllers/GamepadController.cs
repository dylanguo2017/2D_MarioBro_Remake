using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game
{

    public class GamepadController : IController
    {
        private Dictionary<Buttons, ICommand> controllerMappings;

        Buttons[] exist = new Buttons[5] { Buttons.LeftThumbstickUp, Buttons.LeftThumbstickDown, Buttons.LeftThumbstickLeft, Buttons.LeftThumbstickRight, Buttons.A };

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

            if (currentState.IsButtonDown(exist[0]))
            {
                controllerMappings[exist[0]].Execute();
            }
            if (currentState.IsButtonDown(exist[1]))
            {
                controllerMappings[exist[1]].Execute();
            }
            if (currentState.IsButtonDown(exist[2]))
            {
                controllerMappings[exist[2]].Execute();
            }
            if (currentState.IsButtonDown(exist[3]))
            {
                controllerMappings[exist[3]].Execute();
            }
            if (currentState.IsButtonDown(exist[4]))
            {
                controllerMappings[exist[4]].Execute();
            }
        }
    }
}

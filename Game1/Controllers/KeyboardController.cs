using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using static Game.Utility;

namespace Game
{

    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        public bool wDown = false;
        
        Keys[] exist = new Keys[seventeen] {Keys.W,Keys.A,Keys.S,Keys.D,Keys.R, Keys.Y, Keys.U, Keys.I, Keys.O, Keys.Z, Keys.X, Keys.C, Keys.Q, Keys.Up, Keys.Down, Keys.Left, Keys.Right };

        public KeyboardController()
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void RegisterCommand(Buttons but, ICommand command)
        {
            
        }

        public bool isConnected()
        {
            return true;
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                foreach (Keys keyB in exist)
                {
                    if (keyB.Equals(key))
                    {
                        controllerMappings[key].Execute();
                        if (!wDown && keyB.Equals(Keys.W))
                        {
                            wDown = true;
                        }
                    }
                }
            }
            if (wDown && Keyboard.GetState().IsKeyUp(Keys.W))
            {
                controllerMappings[Keys.Space].Execute();
                wDown = false;
            }
        }
    }
}

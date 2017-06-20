using Microsoft.Xna.Framework.Input;

namespace Game
{
    public interface IController
    {
        void Update();
        void RegisterCommand(Keys key, ICommand command);
        void RegisterCommand(Buttons button, ICommand command);
        bool isConnected();
    }
}




using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class KeyBind
    {

        public Game myGame;
        private ICommand qtCmd;
        private ICommand wCmd;
        private ICommand aCmd;
        private ICommand sCmd;
        private ICommand dCmd;
        private ICommand zCmd;
        private ICommand xCmd;
        private ICommand cCmd;
        private ICommand yCmd;
        private ICommand uCmd;
        private ICommand iCmd;
        private ICommand oCmd;
        private ICommand rCmd;
        private ICommand auCmd;
        private ICommand adCmd;
        private ICommand alCmd;
        private ICommand arCmd;
        private ICommand spaceCmd;

        public KeyBind(Game game)
        {
            myGame = game;
        }

        public void BindKey()
        {
            qtCmd = new QuitCommand(myGame);
            wCmd = new WCommand(myGame);
            aCmd = new ACommand(myGame);
            sCmd = new SCommand(myGame);
            dCmd = new DCommand(myGame);
            zCmd = new ZCommand(myGame);
            xCmd = new XCommand(myGame);
            cCmd = new CCommand(myGame);
            yCmd = new YCommand(myGame);
            uCmd = new UCommand(myGame);
            iCmd = new ICmd(myGame);
            oCmd = new OCommand(myGame);
            rCmd = new RCommand(myGame);
            auCmd = new AUCommand(myGame);
            adCmd = new ADCommand(myGame);
            alCmd = new ALCommand(myGame);
            arCmd = new ARCommand(myGame);
            spaceCmd = new SpaceCommand(myGame);
            myGame.keyboard.RegisterCommand(Keys.Q, qtCmd);
            myGame.keyboard.RegisterCommand(Keys.W, wCmd);
            myGame.keyboard.RegisterCommand(Keys.A, aCmd);
            myGame.keyboard.RegisterCommand(Keys.S, sCmd);
            myGame.keyboard.RegisterCommand(Keys.D, dCmd);
            myGame.keyboard.RegisterCommand(Keys.Z, zCmd);
            myGame.keyboard.RegisterCommand(Keys.X, xCmd);
            myGame.keyboard.RegisterCommand(Keys.C, cCmd);
            myGame.keyboard.RegisterCommand(Keys.Y, yCmd);
            myGame.keyboard.RegisterCommand(Keys.U, uCmd);
            myGame.keyboard.RegisterCommand(Keys.I, iCmd);
            myGame.keyboard.RegisterCommand(Keys.O, oCmd);
            myGame.keyboard.RegisterCommand(Keys.R, rCmd);
            myGame.keyboard.RegisterCommand(Keys.Up, auCmd);
            myGame.keyboard.RegisterCommand(Keys.Down, adCmd);
            myGame.keyboard.RegisterCommand(Keys.Left, alCmd);
            myGame.keyboard.RegisterCommand(Keys.Right, arCmd);
            myGame.keyboard.RegisterCommand(Keys.Space, spaceCmd);
            myGame.gmPad.RegisterCommand(Buttons.LeftThumbstickUp, wCmd);
            myGame.gmPad.RegisterCommand(Buttons.LeftThumbstickLeft, aCmd);
            myGame.gmPad.RegisterCommand(Buttons.LeftThumbstickDown, sCmd);
            myGame.gmPad.RegisterCommand(Buttons.LeftThumbstickRight, dCmd);
            myGame.gmPad.RegisterCommand(Buttons.A, zCmd);
            myGame.gmPad.RegisterCommand(Buttons.B, xCmd);
        }

    }
}

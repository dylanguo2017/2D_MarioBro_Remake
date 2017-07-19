using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game.Utility;

namespace Game
{
    public class DeadMario : IMario
    {
        private Game myGame;
        private MarioStateClass marioState;
        private Texture2D texture;
        MarioPositionDic marioPosition = new MarioPositionDic();
        private int currentFrame;

        private Rectangle destinationRectangle;
        public bool visible { get; set; }

        public DeadMario(Game game)
        {
            myGame = game;
            marioState = myGame.marioState;
            texture = myGame.marioSprites;

            myGame.gameOver.setDelay();

            currentFrame = 12;
            marioState.curStat = MarioStateClass.marioStatus.dead;
           
            myGame.soundEffect.MarioDies();
            visible = true;
        }

        public MarioStateClass.marioStatus currentStatus()
        {
            return marioState.curStat;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                int width = 17;
                int height = 17;

                Rectangle sourceRectangle = new Rectangle((int)marioPosition.PositionArr[currentFrame].X, (int)marioPosition.PositionArr[currentFrame].Y, width, height);

                if (!marioState.facingLeft && marioState.move && marioState.XCoor - marioState.offset > fourHundred)
                {
                    marioState.offset = marioState.XCoor - fourHundred;
                }
                destinationRectangle = new Rectangle(marioState.XCoor - marioState.offset, marioState.YCoor, width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }

    }
}
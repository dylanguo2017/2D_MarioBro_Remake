using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class DeadMario : IMario
    {
        private MarioStateClass marioState;
        private Texture2D texture;
        MarioPositionDic marioPosition = new MarioPositionDic();
        private int currentFrame;

        private Rectangle destinationRectangle;

        public DeadMario(MarioStateClass mainState, Texture2D spriteSheet)
        {
            marioState = mainState;
            texture = spriteSheet;

            currentFrame = 12;
            marioState.curStat = MarioStateClass.marioStatus.dead;
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
            int width = 17;
            int height = 17;

            Rectangle sourceRectangle = new Rectangle((int)marioPosition.PositionArr[currentFrame].X, (int)marioPosition.PositionArr[currentFrame].Y, width, height);

            if (!marioState.facingLeft && marioState.move && marioState.XCoor - marioState.offset > 400)
            {
                marioState.offset = marioState.XCoor - 400;
            }
            destinationRectangle = new Rectangle(marioState.XCoor - marioState.offset, marioState.YCoor, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }

    }
}
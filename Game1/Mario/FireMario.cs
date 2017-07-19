using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game.Utility;

namespace Game
{
    public class FireMario : IMario
    {
        private Game myGame;
        private MarioStateClass marioState;
        public MarioStateClass MarState
        {
            get
            {
                return marioState;
            }
        }
        private Texture2D texture;

        private int rightFacingCurrentFrame;
        public int RightFrame
        {
            get
            {
                return rightFacingCurrentFrame;
            }
        }
        private int leftFacingCurrentFrame;
        public int LeftFrame
        {
            get
            {
                return leftFacingCurrentFrame;
            }
        }
        private DrawFireMario drawMar;
        private Rectangle destinationRectangle;
        private int animMod;
        public bool visible { get; set; }

        public FireMario(Game game)
        {
            myGame = game;
            marioState = myGame.marioState;
            texture = myGame.marioSprites;

            leftFacingCurrentFrame = 36;
            rightFacingCurrentFrame = 28;
            marioState.curStat = MarioStateClass.marioStatus.fire;
            marioState.star = false;
            animMod = 0;
            drawMar = new DrawFireMario(myGame, this);

            visible = true;
        }

        public MarioStateClass.marioStatus currentStatus()
        {
            return marioState.curStat;
        }

        public void Update()
        {
            animMod++;
            if (animMod % twenty == zero)
            {
                if (marioState.move && marioState.facingLeft)
                {
                    leftFacingCurrentFrame++;
                    if (leftFacingCurrentFrame == thirtyEight)
                        leftFacingCurrentFrame = 36;
                }
                else if (marioState.move && !marioState.facingLeft)
                {
                    rightFacingCurrentFrame++;
                    if (rightFacingCurrentFrame == thirty)
                        rightFacingCurrentFrame = 28;
                }
            }
            marioState.marioPhys.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                Rectangle sourceRectangle = drawMar.giveSource();

                if (!marioState.facingLeft && marioState.move && marioState.XCoor - marioState.offset > fourHundred)
                {
                    marioState.offset = marioState.XCoor - fourHundred;
                }
                destinationRectangle = new Rectangle(marioState.XCoor - marioState.offset, marioState.YCoor - sixteen, sourceRectangle.Width, sourceRectangle.Height);

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
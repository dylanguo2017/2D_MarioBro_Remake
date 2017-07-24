using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game.Utility;

namespace Game
{
    public class LargeMario : IMario
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
        private DrawLargeMario drawMar;
        private Rectangle destinationRectangle;
        private int invCtr;
        private int animMod;
        public bool visible { get; set; }

        public LargeMario(Game game)
        {
            myGame = game;
            marioState = myGame.marioState;
            texture = myGame.marioSprites;

            rightFacingCurrentFrame = 14;
            leftFacingCurrentFrame = 21;
            marioState.curStat = MarioStateClass.marioStatus.large;
            marioState.star = false;
            invCtr = 0;
            animMod = 0;
            drawMar = new DrawLargeMario(myGame, this);

            visible = true;
        }

        public MarioStateClass.marioStatus currentStatus()
        {
            return marioState.curStat;
        }

        public void Update()
        {
            animMod++;
            if (marioState.inv && invCtr == zero)
            {
                invCtr = 10;
            }

            marioState.marioPhys.Update();
            if (animMod % twenty == zero)
            {
                if (invCtr > zero)
                {
                    invCtr--;
                    if (invCtr == zero)
                    {
                        marioState.inv = false;
                    }
                }
                if (marioState.move && marioState.facingLeft)
                {
                    leftFacingCurrentFrame++;
                    if (leftFacingCurrentFrame == twentyThree)
                        leftFacingCurrentFrame = 21;
                }
                else if (marioState.move && !marioState.facingLeft)
                {
                    rightFacingCurrentFrame++;

                    if (rightFacingCurrentFrame == stdSpriteSize)
                        rightFacingCurrentFrame = 14;

                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {

                if (!marioState.facingLeft && marioState.move && marioState.XCoor - marioState.offset > fourHundred)
                {
                    marioState.offset = marioState.XCoor - fourHundred;
                }

                Rectangle sourceRectangle = drawMar.giveSource();

                destinationRectangle = new Rectangle(marioState.XCoor - marioState.offset, marioState.YCoor - stdSpriteSize, sourceRectangle.Width, sourceRectangle.Height);
                if (invCtr % two == one)
                {
                    return;
                }
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

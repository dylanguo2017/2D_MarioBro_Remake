using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game.Utility;

namespace Game
{
    public class LargeStarMario : IMario
    {
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
        private DrawLargeStarMario drawMar;
        public int duration;
        private Rectangle destinationRectangle;
        private int animMod;
        private bool altColor;
        public bool AltColor
        {
            get
            {
                return altColor;
            }
        }
        private Game myGame;
        public bool visible { get; set; }

        public LargeStarMario(Game game)
        {
            myGame = game;
            marioState = myGame.marioState;
            texture = myGame.marioSprites;

            leftFacingCurrentFrame = 63;
            rightFacingCurrentFrame = 56;
            marioState.star = true;
            marioState.curStat = MarioStateClass.marioStatus.large;
            duration = 10;
            altColor = false;
            animMod = 0;
            drawMar = new DrawLargeStarMario(this);
            myGame.marioState.bat = false;

            myGame.sound.Starman();
            visible = true;
        }

        public MarioStateClass.marioStatus currentStatus()
        {
            return marioState.curStat;
        }

        public void Update()
        {
            animMod++;
            if (animMod % twenty == 0)
            {
                if (marioState.move && marioState.facingLeft)
                {
                    if (leftFacingCurrentFrame == sixtyThree)
                    {
                        leftFacingCurrentFrame = 22;
                    }
                    else
                    {
                        leftFacingCurrentFrame = 63;
                    }
                }
                else if (marioState.move && !marioState.facingLeft)
                {
                    if (rightFacingCurrentFrame == fiftySeven)
                    {
                        rightFacingCurrentFrame = 14;
                    }  
                    else
                    {
                        rightFacingCurrentFrame = 57;
                    }
                }
                altColor = !altColor;
            }
            marioState.marioPhys.Update();

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

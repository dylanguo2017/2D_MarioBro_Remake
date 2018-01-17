using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game.Utility;

namespace Game
{
    public class SmallStarMario : IMario
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
        private DrawSmallStarMario drawMar;
        private int duration;
        private Rectangle destinationRectangle;
        private bool altColor;
        public bool visible { get; set; }

        public bool AltColor
        {
            get
            {
                return altColor;
            }
        }
        private int animMod;
        private Game myGame;

        public SmallStarMario(Game game)
        {
            myGame = game;
            marioState = myGame.marioState;
            texture = myGame.marioSprites;

            rightFacingCurrentFrame = 44;
            leftFacingCurrentFrame = 50;
            marioState.star = true;
            marioState.curStat = MarioStateClass.marioStatus.small;
            duration = 10;
            altColor = false;
            animMod = 0;
            drawMar = new DrawSmallStarMario(this);
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
            if (animMod % twenty == zero)
            {
                if (marioState.move && marioState.facingLeft && !marioState.jump)
                {
                    leftFacingCurrentFrame++;
                    if (leftFacingCurrentFrame == fiftyTwo)
                    {
                        leftFacingCurrentFrame = 50;
                    }
                }
                else if (marioState.move && !marioState.facingLeft && !marioState.jump)
                {
                    rightFacingCurrentFrame++;
                    if (rightFacingCurrentFrame == fourtySix)
                    {
                        rightFacingCurrentFrame = 44;
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
                destinationRectangle = new Rectangle(marioState.XCoor - marioState.offset, marioState.YCoor, sourceRectangle.Width, sourceRectangle.Height);

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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game.Utility;

namespace Game
{
    public class BatMario : IMario
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
        private Texture2D textureLeft;
        private Texture2D textureRight;
        private Texture2D texture;

        private int rightFacingCurrentFrame;
        private int leftFacingCurrentFrame;
        private DrawLargeMario drawMar;
        private Rectangle destinationRectangle;
        private BatMarioDic sourceBat;
        private int animMod;
        private int batTimer;
        public bool visible { get; set; }

        public BatMario(Game game)
        {
            myGame = game;
            marioState = myGame.marioState;
            textureLeft = myGame.marioBatLeft;
            textureRight = myGame.marioBatRight;
            texture = textureRight;
            rightFacingCurrentFrame = 1;
            leftFacingCurrentFrame = 4;
            marioState.star = false;
            animMod = 0;
            sourceBat = new BatMarioDic();
            marioState.bat = true;
            batTimer = 300;

            visible = true;
        }

        public MarioStateClass.marioStatus currentStatus()
        {
            return marioState.curStat;
        }

        public void Transform(Game game)
        {
            if (game.marioState.curStat.Equals(MarioStateClass.marioStatus.fire))
                game.mario = new FireMario(game);
            else if (game.marioState.curStat.Equals(MarioStateClass.marioStatus.large))
                game.mario = new LargeMario(game);
            else
                game.mario = new SmallMario(game);
            game.marioState.bat = false;
        }

        public void Update()
        {
            animMod++;
            batTimer--;
            if (batTimer == 0)
                Transform(myGame);
            if (animMod % three == zero)
                Unstable(myGame.marioState);
            if (animMod % ten == zero)
            {
                if (marioState.facingLeft)
                {
                    leftFacingCurrentFrame--;
                    if (leftFacingCurrentFrame < zero)
                        leftFacingCurrentFrame = 4;
                }
                else
                {
                    rightFacingCurrentFrame++;
                    if (rightFacingCurrentFrame > four)
                        rightFacingCurrentFrame = 0;

                }
            }
        }

        public void Unstable(MarioStateClass marState)
        {
            System.Random dummy = new System.Random();
            if(dummy.Next() % 4 == 0 && !marState.move)
            {
                marState.XCoor -= 3;
            }
            else if (dummy.Next() % 3 == 0)
            {
                if (marState.YCoor - 3 > 0)
                    marState.YCoor -= 5;
            }
            else if (dummy.Next() % 5 == 0)
            {
                marState.YCoor += 5;
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
                Rectangle sourceRectangle;
                if (marioState.facingLeft)
                {
                    sourceRectangle = sourceBat.RecArrLeft[leftFacingCurrentFrame];
                    texture = textureLeft;
                }
                else
                {
                    sourceRectangle = sourceBat.RecArrRight[rightFacingCurrentFrame];
                    texture = textureRight;
                }

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

using Game.Sprites;

namespace Game
{
    public class Initialize
    {
        private Game myGame;

        public Initialize(Game game)
        {
            myGame = game;
        }

        public void Game()
        {
            myGame.questionMarkBlock = new MotionlessAnimatedSprite(myGame.questionMarkBlockSprite, 1, 3, 290, 200);
            myGame.diamondBlock = new MotionlessNonAnimatedSprite(myGame.diamondBlockSprite, 1, 1, 100, 200);
            myGame.brickBlock = new MotionlessNonAnimatedSprite(myGame.brickBlockSprite, 1, 1, 388, 200);
            myGame.crackBlock = new MotionlessNonAnimatedSprite(myGame.crackBlockSprite, 1, 1, 484, 200);
            myGame.pipe = new MotionlessNonAnimatedSprite(myGame.pipeSprite, 1, 1, 580, 200);
            myGame.usedBlock = new MotionlessNonAnimatedSprite(myGame.usedBlockSprite, 1, 1, 196, 200);
            myGame.invisibleBlock = new MotionlessNonAnimatedSprite(myGame.invisibleBlockSprite, 1, 1, 4, 200);

            myGame.star = new MotionlessAnimatedSprite(myGame.starItem, 1, 4, 500, 100);
            myGame.greenMushroom = new MotionlessAnimatedSprite(myGame.greenMushroomItem, 1, 1, 400, 100);
            myGame.redMushroom = new MotionlessAnimatedSprite(myGame.redMushroomItem, 1, 1, 300, 100);
            myGame.coin = new MotionlessAnimatedSprite(myGame.coinItem, 1, 4, 200, 100);
            myGame.fireFlower = new MotionlessAnimatedSprite(myGame.fireFlowerItem, 1, 4, 100, 100);

            myGame.oneCloud = new MotionlessNonAnimatedSprite(myGame.oneCloudBgElement, 1, 1, 700, 50);
            myGame.threeClouds = new MotionlessNonAnimatedSprite(myGame.threeCloudsBgElement, 1, 1, 325, 130);
            myGame.threeBushes = new MotionlessNonAnimatedSprite(myGame.threeBushesBgElement, 1, 1, 350, 465);
            myGame.smallMountain = new MotionlessNonAnimatedSprite(myGame.smallMountainBgElement, 1, 1, 550, 455);
            myGame.bigMountain = new MotionlessNonAnimatedSprite(myGame.bigMountainBgElement, 1, 1, 100, 445);

            myGame.goomba = new MotionlessAnimatedSprite(myGame.goombaEnemy, 1, 2, 600, 150);
            myGame.koopa = new MotionlessAnimatedSprite(myGame.koopaEnemy, 1, 3, 700, 150);

            myGame.mario = new SmallMario(myGame.marioState, myGame.marioSprites);

            myGame.list = myGame.levelList.Load();
        }
    }
}

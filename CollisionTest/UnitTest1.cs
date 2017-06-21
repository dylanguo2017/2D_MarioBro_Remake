using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;


namespace CollisionTest
{
    [TestClass]
    public class UnitTest1 
    {
      
        public Game.Game myGame = new Game.Game();
        MarioStateClass testState = new MarioStateClass(false, false, false, false);

        [TestMethod]
        public void TestMethod1()
        {

            Game.LargeMario largeMario = new Game.LargeMario(testState, myGame.marioSprites);
            Game.ISprite fireFlower = new Game.Sprites.MotionlessAnimatedSprite(myGame.fireFlowerItem, 1, 4, 200, 400);
            Game.MarioItemCollisionHandler TestResult = new Game.MarioItemCollisionHandler(myGame);
            Assert.AreEqual(myGame.marioState, TestResult);
        }
         public void TestMethod2()
        {
            Game.SmallMario smallMario = new Game.SmallMario(testState, myGame.marioSprites);
            Game.ISprite goomba = new Game.Sprites.MotionlessAnimatedSprite(myGame.goombaEnemy, 1, 4, 200, 400);
            Game.MarioEnemyCollisionHandler TestResult = new Game.MarioEnemyCollisionHandler(myGame);
            Assert.AreEqual(myGame.marioState, TestResult);
        }
        public void TestMethod3()
        {
            Game.SmallMario smallMario = new Game.SmallMario(testState, myGame.marioSprites);
            Game.ISprite questionBlock = new Game.Sprites.MotionlessAnimatedSprite(myGame.questionMarkBlockSprite, 1, 4, 200, 400);
            Game.MarioBlockCollisionHandler TestResult = new Game.MarioBlockCollisionHandler(myGame);
            Assert.AreEqual(myGame.marioState, TestResult);
        }






    }
}

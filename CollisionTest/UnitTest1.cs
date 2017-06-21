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
            //testState.curStat=
            Game.LargeMario largeMario = new Game.LargeMario(testState, myGame.marioSprites);
            Game.ISprite fireFlower = new Game.Sprites.MotionlessAnimatedSprite(myGame.fireFlowerItem, 1, 4, 200, 400); 

            //Assert.AreEqual(myGame.marioState, CollisionTest(LargeMario, fireFlower));



        }
    }
}

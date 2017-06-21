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
            testState.curStat=
            Game.SmallMario sm=new Game.SmallMario(testState,myGame.marioSprites);
            Assert.AreEqual(sm.currentStatus(),testState.curStat);
           
            
        }
    }
}

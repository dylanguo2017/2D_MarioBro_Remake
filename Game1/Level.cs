using Game.Blocks;
using Game.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using static Game.Utility;

namespace Game
{
    public static class Level
    {
        public static List<IEnemy> enemyList;
        public static List<IItem> itemList;
        public static List<IBlock> blockList;

        public static List<IEnemy> enemyPipeList;
        public static List<IItem> itemPipeList;
        public static List<IBlock> blockPipeList;

        public static List<IBackground> bgList;

        public static void LoadLists(Game myGame)
        {
            enemyList = new List<IEnemy>();
            itemList = new List<IItem>();
            blockList = new List<IBlock>();

            enemyPipeList = new List<IEnemy>();
            itemPipeList = new List<IItem>();
            blockPipeList = new List<IBlock>();

            bgList = new List<IBackground>();

            StreamReader levelFile = new StreamReader(
         Path.Combine(Directory.GetCurrentDirectory(),
                      "Content", "Levels", "Level1-1.txt")
         );

            StreamReader bonusLevelFile = new StreamReader(
       Path.Combine(Directory.GetCurrentDirectory(),
                    "Content", "Levels", "Level1-1BONUS.txt")
                    );

            String inComingLine;
            int posRow = zero;

            while (!levelFile.EndOfStream)
            {
                inComingLine = levelFile.ReadLine();
                String[] target = inComingLine.Split(',');
                int posCol = zero;
                while (posCol < target.Length)
                {
                    if (target[posCol].Equals("brick"))
                    {
                        Brick gameObject = new Brick(myGame, myGame.blockSprite, twentyEight, thirtyThree, posCol * sixteen, posRow * sixteen);
                        blockList.Add(gameObject);
                    }

                    else if (target[posCol].Equals("crack"))
                    {
                        Crack gameObject = new Crack(myGame, myGame.blockSprite, twentyEight, thirtyThree, posCol * sixteen, posRow * sixteen);
                        blockList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("diamond"))
                    {
                        Diamond gameObject = new Diamond(myGame, myGame.blockSprite, twentyEight, thirtyThree, posCol * sixteen, posRow * sixteen);
                        blockList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("question"))
                    {
                        Question gameObject = new Question(myGame, myGame.blockSprite, twentyEight, thirtyThree, posCol * sixteen, posRow * sixteen);
                        blockList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("used"))
                    {
                        Used gameObject = new Used(myGame, myGame.blockSprite, twentyEight, thirtyThree, posCol * sixteen, posRow * sixteen);
                        blockList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("invisible"))
                    {
                        Invisible gameObject = new Invisible(myGame, myGame.blockSprite, twentyEight, thirtyThree, posCol * sixteen, posRow * sixteen);
                        blockList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("standardPipe"))
                    {
                        Pipe pipe = new Pipe(myGame, myGame.blockSprite, twentyEight, thirtyThree, posCol * sixteen, posRow * sixteen);
                        blockList.Add(pipe);

                        IEnemy enemy = new PiranhaPlant(myGame, myGame.piranhaPlant, pipe.drawLocation.X, pipe.drawLocation.Y);
                        enemyList.Add(enemy);
                    }

                    else if (target[posCol].Equals("standardPipeTransition"))
                    {
                        PipeTransition gameObject = new PipeTransition(myGame, myGame.blockSprite, twentyEight, thirtyThree, posCol * sixteen, posRow * sixteen);
                        blockList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("popPipe"))
                    {
                        PopPipe gameObject = new PopPipe(myGame, myGame.blockSprite, twentyEight, thirtyThree, posCol * sixteen, posRow * sixteen);
                        blockList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("pipeNeck"))
                    {
                        PipeNeck gameObject = new PipeNeck(myGame, myGame.blockSprite, twentyEight, thirtyThree, posCol * sixteen, posRow * sixteen);
                        blockList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("smallCastle"))
                    {
                        IBlock gameObject = new Castle(myGame, myGame.smallCastle, one, one, posCol * sixteen, posRow * sixteen);
                        blockList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("flagpole"))
                    {
                        IItem gameObject = new Flagpole(myGame, myGame.flagpoleElement, one, one, posCol * sixteen, posRow * sixteen);
                        itemList.Add(gameObject);
                        IBlock block = new Diamond(myGame, myGame.blockSprite, twentyEight, thirtyThree, (posCol * sixteen) - 6, (posRow * sixteen) + oneHundredTwentyEight);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("star"))
                    {
                        StarItem gameObject = new StarItem(myGame, myGame.itemSprite, twentyOne, thirtySix, posCol * sixteen, posRow * sixteen);
                        itemList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("coin"))
                    {
                        CoinItem gameObject = new CoinItem(myGame, myGame.itemSprite, twentyOne, thirtySix, posCol * sixteen, posRow * sixteen);
                        itemList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("flower"))
                    {
                        FlowerItem gameObject = new FlowerItem(myGame, myGame.itemSprite, twentyOne, thirtySix, posCol * sixteen, posRow * sixteen);
                        itemList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("redMushroom"))
                    {
                        RedMushroomItem gameObject = new RedMushroomItem(myGame, myGame.itemSprite, twentyOne, thirtySix, posCol * sixteen, posRow * sixteen);
                        itemList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("greenMushroom"))
                    {
                        GreenMushroomItem gameObject = new GreenMushroomItem(myGame, myGame.itemSprite, twentyOne, thirtySix, posCol * sixteen, posRow * sixteen);
                        itemList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("goomba"))
                    {
                        IEnemy enemy = new Goomba(myGame, myGame.goomba, posCol * sixteen, posRow * sixteen);
                        enemyList.Add(enemy);
                    }
                    else if (target[posCol].Equals("koopa"))
                    {
                        IEnemy enemy = new Koopa(myGame, myGame.koopa, posCol * sixteen, posRow * sixteen);
                        enemyList.Add(enemy);
                    }
                    else if (target[posCol].Equals("oneCloud"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.oneCloudBgElement, posCol * sixteen, posRow * sixteen);
                        bgList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("threeClouds"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.threeCloudsBgElement, posCol * sixteen, posRow * sixteen);
                        bgList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("oneBush"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.oneBushBgElement, posCol * sixteen, posRow * sixteen);
                        bgList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("threeBushes"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.threeBushesBgElement, posCol * sixteen, posRow * sixteen);
                        bgList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("smallMountain"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.smallMountainBgElement, posCol * sixteen, posRow * sixteen);
                        bgList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("bigMountain"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.bigMountainBgElement, posCol * sixteen, posRow * sixteen);
                        bgList.Add(gameObject);
                    }
                    else if (target[posCol].Equals("title"))
                    {
                        IBackground gameObject = new Background(myGame, myGame.titleScreen, posCol * sixteen, posRow * sixteen);
                        bgList.Add(gameObject);
                    }

                    posCol++;
                }
                posRow++;
            }

            posRow = zero;
            while (!bonusLevelFile.EndOfStream)
            {
                inComingLine = bonusLevelFile.ReadLine();
                String[] target = inComingLine.Split(',');
                int positionColumn = zero;

                while (positionColumn < target.Length)
                {
                    if (target[positionColumn].Equals("blueBrick"))
                    {
                        BlueBrick gameObject = new BlueBrick(myGame, myGame.blueBlockSprite, one, two, positionColumn * sixteen, posRow * sixteen);
                        blockPipeList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("blueCrack"))
                    {
                        BlueCrack gameObject = new BlueCrack(myGame, myGame.blueBlockSprite, one, two, positionColumn * sixteen, posRow * sixteen);
                        blockPipeList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("coin"))
                    {
                        CoinItem gameObject = new CoinItem(myGame, myGame.itemSprite, twentyOne, thirtySix, positionColumn * sixteen, posRow * sixteen);
                        itemPipeList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("pipeNeck"))
                    {
                        PipeNeck gameObject = new PipeNeck(myGame, myGame.blockSprite, twentyEight, thirtyThree, positionColumn * sixteen, posRow * sixteen);
                        blockPipeList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("sidePipe"))
                    {
                        SidePipe gameObject = new SidePipe(myGame, myGame.blockSprite, twentyEight, thirtyThree, positionColumn * sixteen, posRow *  sixteen);
                        blockPipeList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("pipeNeck"))
                    {
                        PipeNeck gameObject = new PipeNeck(myGame, myGame.blockSprite, twentyEight, thirtyThree, positionColumn * sixteen, posRow * sixteen);
                        blockPipeList.Add(gameObject);
                    }
                    positionColumn++;
                }
                posRow++;
            }
            levelFile.Close();
            bonusLevelFile.Close();
            IComparer<IBlock> blockComp = new BlockComparer<IBlock>();
            IComparer<IItem> itemComp = new ItemComparer<IItem>();
            IComparer<IEnemy> enemyComp = new EnemyComparer<IEnemy>();
            blockList.Sort(blockComp);
            itemList.Sort(itemComp);
            enemyList.Sort(enemyComp);
            blockPipeList.Sort(blockComp);
            itemPipeList.Sort(itemComp);
            enemyPipeList.Sort(enemyComp);

            //TESTING ONLY BELOW THIS PT
            //for (int i = 0; i < 576; i++)
            //    System.Diagnostics.Debug.WriteLine("OBJECT NAME: " + blockList[i].texture.ToString() + "    LOCATION:" + blockList[i].DrawLoc + "      OBJ #:"+i);
        }
        
        private class BlockComparer<T> : IComparer<T>
        {
            int IComparer<T>.Compare(T  a, T b)
            {
                IBlock b1 = (IBlock)a;
                IBlock b2 = (IBlock)b;
                if (b1.DrawLoc > b2.DrawLoc)
                    return one;
                if (b1.DrawLoc < b2.DrawLoc)
                    return minusOne;
                else
                    return zero;
            }
        }
        private class ItemComparer<T> : IComparer<T>
        {
            int IComparer<T>.Compare(T a, T b)
            {
                IItem b1 = (IItem)a;
                IItem b2 = (IItem)b;
                if (b1.currentLoc > b2.currentLoc)
                    return one;
                if (b1.currentLoc < b2.currentLoc)
                    return minusOne;
                else
                    return zero;
            }
        }
        private class EnemyComparer<T> : IComparer<T>
        {
            int IComparer<T>.Compare(T a, T b)
            {
                IEnemy b1 = (IEnemy)a;
                IEnemy b2 = (IEnemy)b;
                if (b1.enemyPhys.XCoor > b2.enemyPhys.XCoor)
                    return one;
                if (b1.enemyPhys.XCoor < b2.enemyPhys.XCoor)
                    return minusOne;
                else
                    return zero;
            }
        }
    }
}

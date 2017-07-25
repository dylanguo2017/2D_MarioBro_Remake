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

        public static List<IBg> bgList;

        public static void LoadLists(Game myGame)
        {
            enemyList = new List<IEnemy>();
            itemList = new List<IItem>();
            blockList = new List<IBlock>();

            enemyPipeList = new List<IEnemy>();
            itemPipeList = new List<IItem>();
            blockPipeList = new List<IBlock>();

            bgList = new List<IBg>();

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
                        IBlock block = new Brick(myGame, posCol, posRow);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("crack"))
                    {
                        IBlock block = new Crack(myGame, posCol, posRow);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("diamond"))
                    {
                        IBlock block = new Diamond(myGame, posCol * stdSpriteSize, posRow * stdSpriteSize);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("question"))
                    {
                        IBlock block = new Question(myGame, posCol, posRow);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("questionRedM"))
                    {
                        Question block = new Question(myGame, posCol, posRow);
                        block.contain = Utility.items.redM;
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("questionFireF"))
                    {
                        Question block = new Question(myGame, posCol, posRow);
                        block.contain = Utility.items.flower;
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("questionCoin"))
                    {
                        Question block = new Question(myGame, posCol, posRow);
                        block.contain = Utility.items.coin;
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("questionGreenM"))
                    {
                        Question block = new Question(myGame, posCol, posRow);
                        block.contain = Utility.items.greenM;
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("questionBat"))
                    {
                        Question block = new Question(myGame, posCol, posRow);
                        block.contain = Utility.items.bat;
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("used"))
                    {
                        IBlock block = new Used(myGame, posCol, posRow);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("invisible"))
                    {
                        IBlock block = new Invisible(myGame, posCol, posRow);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("standardPipe"))
                    {
                        Pipe block = new Pipe(myGame, posCol, posRow);
                        blockList.Add(block);

                        IEnemy enemy = new PiranhaPlant(myGame, block.drawLoc.X, block.drawLoc.Y);
                        enemyList.Add(enemy);
                    }

                    else if (target[posCol].Equals("standardPipeTransition"))
                    {
                        IBlock block = new PipeTransition(myGame, posCol, posRow);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("popPipe"))
                    {
                        IBlock block = new PopPipe(myGame, posCol, posRow);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("pipeNeck"))
                    {
                        IBlock block = new PipeNeck(myGame, posCol, posRow);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("smallCastle"))
                    {
                        IBlock block = new Castle(myGame, posCol, posRow);
                        blockList.Add(block);
                    }

                    else if (target[posCol].Equals("flagpole"))
                    {
                        IItem item = new Flagpole(myGame, posCol, posRow);
                        itemList.Add(item);

                        IBlock block = new Diamond(myGame, (posCol * stdSpriteSize) - six, (posRow * stdSpriteSize) + oneHundredTwentyEight);
                        blockList.Add(block);
                    }

                    else if (target[posCol].Equals("coin"))
                    {
                        IItem item = new Coin(myGame, posCol * stdSpriteSize, posRow * stdSpriteSize);
                        itemList.Add(item);
                    }
                    else if (target[posCol].Equals("star"))
                    {
                        IItem item = new Star(myGame, posCol * stdSpriteSize, posRow * stdSpriteSize);
                        itemList.Add(item);
                    }
                    else if (target[posCol].Equals("flower"))
                    {
                        IItem item = new FireFlower(myGame, posCol * stdSpriteSize, posRow * stdSpriteSize);
                        itemList.Add(item);
                    }
                    else if (target[posCol].Equals("redMushroom"))
                    {
                        IItem item = new RedMushroom(myGame, posCol * stdSpriteSize, posRow * stdSpriteSize);
                        itemList.Add(item);
                    }
                    else if (target[posCol].Equals("greenMushroom"))
                    {
                        IItem item = new GreenMushroom(myGame, posCol * stdSpriteSize, posRow * stdSpriteSize);
                        itemList.Add(item);
                    }


                    else if (target[posCol].Equals("goomba"))
                    {
                        IEnemy enemy = new Goomba(myGame, posCol, posRow);
                        enemyList.Add(enemy);
                    }
                    else if (target[posCol].Equals("koopa"))
                    {
                        IEnemy enemy = new Koopa(myGame, posCol, posRow);
                        enemyList.Add(enemy);
                    }

                    
                    else if (target[posCol].Equals("oneCloud"))
                    {
                        IBg bg = new Bg(myGame, myGame.oneCloudBgElement, posCol, posRow);
                        bgList.Add(bg);
                    }
                    else if (target[posCol].Equals("threeClouds"))
                    {
                        IBg bg = new Bg(myGame, myGame.threeCloudsBgElement, posCol, posRow);
                        bgList.Add(bg);
                    }
                    else if (target[posCol].Equals("oneBush"))
                    {
                        IBg bg = new Bg(myGame, myGame.oneBushBgElement, posCol, posRow);
                        bgList.Add(bg);
                    }
                    else if (target[posCol].Equals("threeBushes"))
                    {
                        IBg bg = new Bg(myGame, myGame.threeBushesBgElement, posCol, posRow);
                        bgList.Add(bg);
                    }
                    else if (target[posCol].Equals("smallMountain"))
                    {
                        IBg bg = new Bg(myGame, myGame.smallMountainBgElement, posCol, posRow);
                        bgList.Add(bg);
                    }
                    else if (target[posCol].Equals("bigMountain"))
                    {
                        IBg bg = new Bg(myGame, myGame.bigMountainBgElement, posCol, posRow);
                        bgList.Add(bg);
                    }
                    else if (target[posCol].Equals("title"))
                    {
                        IBg bg = new Bg(myGame, myGame.titleScreen, posCol, posRow);
                        bgList.Add(bg);
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
                int posCol = zero;

                while (posCol < target.Length)
                {
                    if (target[posCol].Equals("blueBrick"))
                    {
                        IBlock block = new BlueBrick(myGame, posCol, posRow);
                        blockPipeList.Add(block);
                    }
                    else if (target[posCol].Equals("blueCrack"))
                    {
                        IBlock block = new BlueCrack(myGame, posCol, posRow);
                        blockPipeList.Add(block);
                    }

                    else if (target[posCol].Equals("coin"))
                    {
                        IItem item = new Coin(myGame, posCol * stdSpriteSize, posRow * stdSpriteSize);
                        itemPipeList.Add(item);
                    }

                    else if (target[posCol].Equals("pipeNeck"))
                    {
                        IBlock block = new PipeNeck(myGame, posCol, posRow);
                        blockPipeList.Add(block);
                    }
                    else if (target[posCol].Equals("sidePipe"))
                    {
                        IBlock block = new SidePipe(myGame, posCol, posRow);
                        blockPipeList.Add(block);
                    }
                    else if (target[posCol].Equals("pipeNeck"))
                    {
                        IBlock block = new PipeNeck(myGame, posCol, posRow);
                        blockPipeList.Add(block);
                    }
                    posCol++;
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
                if (b1.DrawLoc > b2.DrawLoc)
                    return one;
                if (b1.DrawLoc < b2.DrawLoc)
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

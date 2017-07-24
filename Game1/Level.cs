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
                        IBlock block = new Brick(myGame, posCol * sixteen, posRow * sixteen);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("crack"))
                    {
                        IBlock block = new Crack(myGame, posCol * sixteen, posRow * sixteen);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("diamond"))
                    {
                        IBlock block = new Diamond(myGame, posCol * sixteen, posRow * sixteen);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("question"))
                    {
                        IBlock block = new Question(myGame, posCol * sixteen, posRow * sixteen);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("used"))
                    {
                        IBlock block = new Used(myGame, posCol * sixteen, posRow * sixteen);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("invisible"))
                    {
                        IBlock block = new Invisible(myGame, posCol * sixteen, posRow * sixteen);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("standardPipe"))
                    {
                        Pipe block = new Pipe(myGame, posCol * sixteen, posRow * sixteen);
                        blockList.Add(block);

                        IEnemy enemy = new PiranhaPlant(myGame, block.drawLoc.X, block.drawLoc.Y);
                        enemyList.Add(enemy);
                    }

                    else if (target[posCol].Equals("standardPipeTransition"))
                    {
                        PipeTransition block = new PipeTransition(myGame, posCol * sixteen, posRow * sixteen);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("popPipe"))
                    {
                        PopPipe block = new PopPipe(myGame, posCol * sixteen, posRow * sixteen);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("pipeNeck"))
                    {
                        PipeNeck block = new PipeNeck(myGame, posCol * sixteen, posRow * sixteen);
                        blockList.Add(block);
                    }
                    else if (target[posCol].Equals("smallCastle"))
                    {
                        IBlock block = new Castle(myGame, posCol * sixteen, posRow * sixteen);
                        blockList.Add(block);
                    }

                    else if (target[posCol].Equals("flagpole"))
                    {
                        IItem item = new Flagpole(myGame, posCol * sixteen, posRow * sixteen);
                        itemList.Add(item);

                        IBlock block = new Diamond(myGame, (posCol * sixteen) - six, (posRow * sixteen) + oneHundredTwentyEight);
                        blockList.Add(block);
                    }

                    else if (target[posCol].Equals("star"))
                    {
                        IItem item = new Star(myGame, posCol * sixteen, posRow * sixteen);
                        itemList.Add(item);
                    }
                    else if (target[posCol].Equals("coin"))
                    {
                        IItem item = new Coin(myGame, posCol * sixteen, posRow * sixteen);
                        itemList.Add(item);
                    }
                    else if (target[posCol].Equals("flower"))
                    {
                        IItem item = new Flower(myGame, posCol * sixteen, posRow * sixteen);
                        itemList.Add(item);
                    }
                    else if (target[posCol].Equals("redMushroom"))
                    {
                        IItem item = new RedMushroom(myGame, posCol * sixteen, posRow * sixteen);
                        itemList.Add(item);
                    }
                    else if (target[posCol].Equals("greenMushroom"))
                    {
                        IItem item = new GreenMushroom(myGame, posCol * sixteen, posRow * sixteen);
                        itemList.Add(item);
                    }


                    else if (target[posCol].Equals("goomba"))
                    {
                        IEnemy enemy = new Goomba(myGame, posCol * sixteen, posRow * sixteen);
                        enemyList.Add(enemy);
                    }
                    else if (target[posCol].Equals("koopa"))
                    {
                        IEnemy enemy = new Koopa(myGame, posCol * sixteen, posRow * sixteen);
                        enemyList.Add(enemy);
                    }

                    
                    else if (target[posCol].Equals("oneCloud"))
                    {
                        IBackground bg = new Background(myGame, myGame.oneCloudBgElement, posCol * sixteen, posRow * sixteen);
                        bgList.Add(bg);
                    }
                    else if (target[posCol].Equals("threeClouds"))
                    {
                        IBackground bg = new Background(myGame, myGame.threeCloudsBgElement, posCol * sixteen, posRow * sixteen);
                        bgList.Add(bg);
                    }
                    else if (target[posCol].Equals("oneBush"))
                    {
                        IBackground bg = new Background(myGame, myGame.oneBushBgElement, posCol * sixteen, posRow * sixteen);
                        bgList.Add(bg);
                    }
                    else if (target[posCol].Equals("threeBushes"))
                    {
                        IBackground bg = new Background(myGame, myGame.threeBushesBgElement, posCol * sixteen, posRow * sixteen);
                        bgList.Add(bg);
                    }
                    else if (target[posCol].Equals("smallMountain"))
                    {
                        IBackground bg = new Background(myGame, myGame.smallMountainBgElement, posCol * sixteen, posRow * sixteen);
                        bgList.Add(bg);
                    }
                    else if (target[posCol].Equals("bigMountain"))
                    {
                        IBackground bg = new Background(myGame, myGame.bigMountainBgElement, posCol * sixteen, posRow * sixteen);
                        bgList.Add(bg);
                    }
                    else if (target[posCol].Equals("title"))
                    {
                        IBackground bg = new Background(myGame, myGame.titleScreen, posCol * sixteen, posRow * sixteen);
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
                        IBlock block = new BlueBrick(myGame, posCol * sixteen, posRow * sixteen);
                        blockPipeList.Add(block);
                    }
                    else if (target[posCol].Equals("blueCrack"))
                    {
                        IBlock block = new BlueCrack(myGame, posCol * sixteen, posRow * sixteen);
                        blockPipeList.Add(block);
                    }

                    else if (target[posCol].Equals("coin"))
                    {
                        IItem item = new Coin(myGame, posCol * sixteen, posRow * sixteen);
                        itemPipeList.Add(item);
                    }

                    else if (target[posCol].Equals("pipeNeck"))
                    {
                        IBlock block = new PipeNeck(myGame, posCol * sixteen, posRow * sixteen);
                        blockPipeList.Add(block);
                    }
                    else if (target[posCol].Equals("sidePipe"))
                    {
                        IBlock block = new SidePipe(myGame, posCol * sixteen, posRow *  sixteen);
                        blockPipeList.Add(block);
                    }
                    else if (target[posCol].Equals("pipeNeck"))
                    {
                        IBlock block = new PipeNeck(myGame, posCol * sixteen, posRow * sixteen);
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

using Game.Sprites;
using System;
using System.Collections;
using System.IO;

namespace Game
{
    public static class Level
    {
        public static ArrayList Load(Game myGame)
        {
            ArrayList list = new ArrayList();
            StreamReader levelFile = new StreamReader(
         Path.Combine(Directory.GetCurrentDirectory(),
                      "Content", "Levels", "TLevel1-1.txt")
         );
            String inComingLine;
            int positionRow = 0;

            while (!levelFile.EndOfStream)
            {
                inComingLine = levelFile.ReadLine();
                String[] target = inComingLine.Split(',');
                int positionColumn = 0;
                while (positionColumn < target.Length)
                {
                    ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.invisibleBlockSprite, 1, 1, 0, 0);

                    if (target[positionColumn] == "brick")
                    {
                        gameObject = new MotionlessNonAnimatedSprite(myGame.brickBlockSprite, 1, 1, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "crack")
                    {
                        gameObject = new MotionlessNonAnimatedSprite(myGame.crackBlockSprite, 1, 1, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "diamond")
                    {
                       gameObject = new MotionlessNonAnimatedSprite(myGame.diamondBlockSprite, 1, 1, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "question")
                    {
                        gameObject = new MotionlessAnimatedSprite(myGame.questionMarkBlockSprite, 1, 3, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "used")
                    {
                        gameObject = new MotionlessNonAnimatedSprite(myGame.usedBlockSprite, 1, 1, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "invisible")
                    {
                        gameObject = new MotionlessNonAnimatedSprite(myGame.invisibleBlockSprite, 1, 1, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "pipe")
                    {
                        gameObject = new MotionlessNonAnimatedSprite(myGame.pipeSprite, 1, 1, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "star")
                    {
                        gameObject = new MotionlessAnimatedSprite(myGame.starItem, 1, 4, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "coin")
                    {
                        gameObject = new MotionlessAnimatedSprite(myGame.coinItem, 1, 4, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "goomba")
                    {
                        gameObject = new MotionlessAnimatedSprite(myGame.goombaEnemy, 1, 2, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "koopa")
                    {
                        gameObject = new MotionlessAnimatedSprite(myGame.koopaEnemy, 1, 3, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "flower")
                    {
                        gameObject = new MotionlessAnimatedSprite(myGame.fireFlowerItem, 1, 4, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "redMushroom")
                    {
                        gameObject = new MotionlessAnimatedSprite(myGame.redMushroomItem, 1, 1, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "greenMushroom")
                    {
                        gameObject = new MotionlessAnimatedSprite(myGame.greenMushroomItem, 1, 1, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "oneCloud")
                    {
                        gameObject = new MotionlessNonAnimatedSprite(myGame.oneCloudBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "threeClouds")
                    {
                        gameObject = new MotionlessNonAnimatedSprite(myGame.threeCloudsBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "threeBushes")
                    {
                        gameObject = new MotionlessNonAnimatedSprite(myGame.threeBushesBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "smallMountain")
                    {
                        gameObject = new MotionlessNonAnimatedSprite(myGame.smallMountainBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                    }
                    else if (target[positionColumn] == "bigMountain")
                    {
                        gameObject = new MotionlessNonAnimatedSprite(myGame.bigMountainBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                    }
                    list.Add(gameObject);
                    positionColumn++;
                }
                positionRow++;
            }
            levelFile.Close();
            return list;
        }

    }
}

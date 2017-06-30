using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Enemies
{
    public class KoopaEnemy : IEnemy
    {
        public Texture2D texture;

        KoopaPositionDic koopaPosition = new KoopaPositionDic();

        private int rightFacingCurrentFrame;
        private int leftFacingCurrentFrame;

        private Rectangle destinationRectangle;
        public void Move()
        {

        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spritebatch)
        {

        }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Enemies
{
    public interface IEnemy
    {
        void Move();

        void Update();

        void Draw(SpriteBatch spritebatch);

        Rectangle DestinationRectangle();


    }
}

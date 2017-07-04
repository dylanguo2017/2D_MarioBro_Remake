using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Enemies
{
    public interface IEnemy
    {
        
        void Update();

        void Draw(SpriteBatch spritebatch);

        Rectangle DestinationRectangle();


    }
}

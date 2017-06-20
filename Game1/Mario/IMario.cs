using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public interface IMario
    {
        void Draw(SpriteBatch spritebatch);
        void Update();

        Rectangle DestinationRectangle();

        MarioStateClass.marioStatus currentStatus();
    }
}

using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public interface IBackground
    {
        Texture2D texture { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}

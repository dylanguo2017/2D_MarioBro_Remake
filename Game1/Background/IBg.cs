using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public interface IBg
    {
        Texture2D texture { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}

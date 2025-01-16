using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZero.Interfaces
{
    public interface ISprite
    {
        public Texture2D Texture { get; set; }
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
    
}
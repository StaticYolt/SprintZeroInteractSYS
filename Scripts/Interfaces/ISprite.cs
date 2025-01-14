using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SprintZero.Interfaces
{
    public interface ISprite
    {
        public Texture2D _texture { get; set; }
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
//public List<Rectangle> _sourceRectangles { get; set; }
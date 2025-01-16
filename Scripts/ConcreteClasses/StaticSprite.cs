using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SprintZero.Interfaces;

namespace SprintZero.ConcreteClasses {
  public class StaticSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        
        public StaticSprite(Texture2D texture)
        {
            Texture = texture;
        }
 
        public void Update(GameTime gameTime)
        {

        }
 
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        { 
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, location, Color.White);
            spriteBatch.End();
        }
    }
}



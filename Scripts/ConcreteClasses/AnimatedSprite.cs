using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SprintZero.Interfaces;

namespace SprintZero.ConcreteClasses {
  public class AnimatedSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private List<Rectangle> _sourceRectangles = new List<Rectangle>();

        float frameTimeMax;
        float frameTime;
        public AnimatedSprite(Texture2D texture, int rows, int columns, float frameTime)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            for(int i = 0; i < Rows; i++) {
                for(int j = 0; j < Columns; j++) {
                    _sourceRectangles.Add(new Rectangle(j * (Texture.Width / Columns), i * (Texture.Height / Rows), Texture.Width / Columns, Texture.Height / Rows));
                }
            }
            frameTimeMax = frameTime;
            this.frameTime = frameTimeMax;
        }
 
        public void Update(GameTime gameTime)
        {
            frameTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(frameTime <= 0) {
                currentFrame++;
                frameTime = frameTimeMax;
                if (currentFrame == totalFrames){
                    currentFrame = 0;
                }
            }
        }
 
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Texture.Width / Columns, Texture.Height / Rows);
 
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, _sourceRectangles[currentFrame], Color.White);
            spriteBatch.End();
        }
    }
}


// namespace TextureAtlas
// {
    // public class AnimatedSprite
    // {
    //     public Texture2D Texture { get; set; }
    //     public int Rows { get; set; }
    //     public int Columns { get; set; }
    //     private int currentFrame;
    //     private int totalFrames;
 
    //     public AnimatedSprite(Texture2D texture, int rows, int columns)
    //     {
    //         Texture = texture;
    //         Rows = rows;
    //         Columns = columns;
    //         currentFrame = 0;
    //         totalFrames = Rows * Columns;
    //     }
 
    //     public void Update()
    //     {
    //         currentFrame++;
    //         if (currentFrame == totalFrames)
    //             currentFrame = 0;
    //     }
 
    //     public void Draw(SpriteBatch spriteBatch, Vector2 location)
    //     {
    //         int width = Texture.Width / Columns;
    //         int height = Texture.Height / Rows;
    //         int row = currentFrame / Columns;
    //         int column = currentFrame % Columns;
 
    //         Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
    //         Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
 
    //         spriteBatch.Begin();
    //         spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
    //         spriteBatch.End();
    //     }
    // }
// }
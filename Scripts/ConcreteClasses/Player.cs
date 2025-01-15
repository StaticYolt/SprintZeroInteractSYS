using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.ConcreteClasses
{
    public class Player {
        private ISprite sprite {get; set;}
        private Vector2 position;
        private GameTime _gameTime;
        private int _speed = 1;
        public Player(ISprite sprite, int speed) {
            this.sprite = sprite;
            position = new Vector2(0, 0);
            _gameTime = new GameTime();
            _speed = speed;
            
        }
        public void Update(GameTime gameTime) {
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location) {
            sprite.Draw(spriteBatch, location + position);
        }
        public void MoveRight() {
            position.X += (float)(_speed * _gameTime.ElapsedGameTime.TotalSeconds);
        }
        public void MoveLeft() {
            position.X -= (float)(_speed * _gameTime.ElapsedGameTime.TotalSeconds);
        }
        public void Reset() {
            position = new Vector2(0, 0);
        }
        //might want to have the player class itself handle movement instead of having outside stuff call methods to deal with it.
    }
    
}
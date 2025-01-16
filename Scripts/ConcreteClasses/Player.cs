using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SprintZero.Interfaces;

namespace SprintZero.ConcreteClasses
{
    public class Player {
        private ISprite sprite;
        private Vector2 position;
        private GameTime _gameTime;
        private float _speed = .5f;
        
        private float moveTimeContMax = 5f;
        
        public Player(ISprite sprite, float speed) {
            
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
            position.X += (float)_speed;
        }
        public void MoveLeft() {
            position.X -= (float)_speed ;
        }
        public void MoveUp() {
            position.Y -= (float)_speed;
        }
        public void MoveDown() {
            position.Y += (float)_speed;
        }
        public void Reset() {
            position = new Vector2(0, 0);
        }
        public void SetSprite(ISprite sprite) {
            this.sprite = sprite;
        }
    }
    
}
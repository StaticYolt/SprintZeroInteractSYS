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
            // switch(state) {
            //     case playerState.idle:
            //         break;
            //     case playerState.movingLeftRight:
            //         moveTimeCont -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            //         if(moveTimeCont <= 0) {
            //             moveTimeCont = moveTimeContMax;
            //             shouldMoveRight = !shouldMoveRight;
            //         }
            //         Console.WriteLine(shouldMoveRight);
            //         if(shouldMoveRight) {
            //             MoveRight();
            //         }
            //         else {
            //             MoveLeft();
            //         }
            //         break;
            // }
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
//* _gameTime.ElapsedGameTime.TotalSeconds)
        public void Reset() {
            position = new Vector2(0, 0);
        }

        public void SetSprite(ISprite sprite) {
            this.sprite = sprite;
        }
        //might want to have the player class itself handle movement instead of having outside stuff call methods to deal with it.
    }
    
}
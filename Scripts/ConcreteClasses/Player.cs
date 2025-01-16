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
        private float _speed = 100f;
        private float leftRightTimerMax = 4f;
        private float leftRightTimer;
        private bool leftRightShouldMoveRight = true;

        private float upDownTimerMax = 2f;
        private float upDownTimer;
        private bool upDownShouldMoveUp = true;
        private float animSpriteFrameRate = .1f;

        private SprintZero root;
        AnimatedSprite ezaelLeftSprite;
        AnimatedSprite ezaelRightSprite;
        AnimatedSprite ezaelShootDownSprite;
        StaticSprite ezaelStillForwardSprite;
        enum PlayerState {
            LeftRight,
            UpDown,
            Idle
        }
        PlayerState state;

        public Player(SprintZero root, Vector2 startPos) {
            this.position = startPos;
            this.root = root;
            this.state = PlayerState.Idle;
            this.leftRightTimer = leftRightTimerMax;
            this.upDownTimer = upDownTimerMax;

            LoadContent();
        }

        public void Update(GameTime gameTime) {
            switch(state) {
                case PlayerState.UpDown:
                    upDownTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if(upDownTimer <= 0) {
                        upDownTimer = upDownTimerMax;
                        upDownShouldMoveUp = !upDownShouldMoveUp;
                    }
                    if(upDownShouldMoveUp) {
                        MoveUp(gameTime);
                    }
                    else {
                        MoveDown(gameTime);
                    }
                    break;
                case PlayerState.LeftRight:
                    leftRightTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if(leftRightTimer <= 0) {
                        leftRightTimer = leftRightTimerMax;
                        leftRightShouldMoveRight = !leftRightShouldMoveRight;
                        if(leftRightShouldMoveRight) {
                            SetSprite(ezaelRightSprite);
                            Console.WriteLine("StartMoving right");
                        }
                        else {
                            SetSprite(ezaelLeftSprite);
                            Console.WriteLine("StartMoving left");
                        }
                    }
                    if(leftRightShouldMoveRight) {
                        MoveRight(gameTime);
                    }
                    else {
                        MoveLeft(gameTime);
                    }
                    break;
                case PlayerState.Idle:
                    break;
            }
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location) {
            sprite.Draw(spriteBatch, location + position);
        }

        public void LoadContent() 
        {
            Texture2D ezealLTexture = root.Content.Load<Texture2D>("EzaelLeft");
            ezaelLeftSprite = new AnimatedSprite(ezealLTexture, 1, 4, animSpriteFrameRate);

            Texture2D ezealRTexture = root.Content.Load<Texture2D>("EzaelRight");
            ezaelRightSprite = new AnimatedSprite(ezealRTexture, 1, 4, animSpriteFrameRate);
            
            Texture2D ezaelStillForwardTexture = root.Content.Load<Texture2D>("EzaelStillForwards");
            ezaelStillForwardSprite = new StaticSprite(ezaelStillForwardTexture);

            Texture2D ezaelShootDownTexture = root.Content.Load<Texture2D>("EzaelShootDown");
            ezaelShootDownSprite = new AnimatedSprite(ezaelShootDownTexture, 1, 5, animSpriteFrameRate);
            SetSprite(ezaelStillForwardSprite);
        }

        private void MoveRight(GameTime gameTime) { position.X += (float)(_speed * gameTime.ElapsedGameTime.TotalSeconds); }
        private void MoveLeft(GameTime gameTime) { position.X -= (float)(_speed * gameTime.ElapsedGameTime.TotalSeconds); }
        private void MoveUp(GameTime gameTime) { position.Y -= (float)(_speed * gameTime.ElapsedGameTime.TotalSeconds); }
        private void MoveDown(GameTime gameTime) { position.Y += (float)(_speed * gameTime.ElapsedGameTime.TotalSeconds); }
        public void Reset() { position = new Vector2(0, 0); }
        public void SetSprite(ISprite sprite) { this.sprite = sprite;}

        public void NonMovingNonAnimatedSprite() {
            SetSprite(ezaelStillForwardSprite);
            state = PlayerState.Idle;
        }
        public void NonMovingAnimatedSprite() {
            SetSprite(ezaelShootDownSprite);
            state = PlayerState.Idle;
        }
        public void MovingNonAnimatedSprite() {
            SetSprite(ezaelStillForwardSprite);
            state = PlayerState.UpDown;
        }
        public void MovingAnimatedSprite() {
            SetSprite(ezaelRightSprite);
            state = PlayerState.LeftRight;
        }
    }
    
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SprintZero.ConcreteClasses;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SprintZero;

public class SprintZero : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private KeyboardController keyboardController;
    private MouseController mouseController;
    private int screenWidth;
    private int screenHeight;
    private Player player;
    private AnimatedSprite ezaelLeftSprite;
    private AnimatedSprite ezaelRightSprite;
    private StaticSprite ezaelStillForwardSprite;
    
    private float leftRightTimerMax = 2f;
    private float leftRightTimer = 2f;
    private bool leftRightShouldMoveRight = true;

    private float upDownTimerMax = 2f;
    private float upDownTimer = 2f;
    private bool upDownShouldMoveUp = true;
    
    enum PlayerState {
        idle,
        moveLeftRight,
        moveUpDown
    }
    private PlayerState state;

    private SpriteFont font;

    public SprintZero()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        keyboardController = new KeyboardController(new Dictionary<object, Delegate> {
            { Keys.W, new Action(actionOne)},
            { Keys.A, new Action(actionTwo)},
            { Keys.S, new Action(actionThree)},
            { Keys.D, new Action(actionFour)}
        });
        screenWidth = 800;
        screenHeight = 400;

        mouseController = new MouseController(new Dictionary<object, Delegate> {
            {new Rectangle(0, 0, screenWidth / 2, screenHeight / 2), new Action(actionOne)},
            {new Rectangle(screenWidth / 2, 0, screenWidth / 2, screenHeight / 2), new Action(actionTwo)},
            {new Rectangle(0, screenHeight / 2, screenWidth / 2, screenHeight / 2), new Action(actionThree)},
            {new Rectangle(screenWidth / 2, screenHeight / 2, screenWidth / 2, screenHeight / 2), new Action(actionFour)}
        });

        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        Texture2D ezealLTexture = Content.Load<Texture2D>("EzaelLeft");
        ezaelLeftSprite = new AnimatedSprite(ezealLTexture, 1, 4, .1f);

        Texture2D ezealRTexture = Content.Load<Texture2D>("EzaelRight");
        ezaelRightSprite = new AnimatedSprite(ezealRTexture, 1, 4, .1f);
        
        Texture2D ezaelStillForwardTexture = Content.Load<Texture2D>("EzaelStillForwards");
        ezaelStillForwardSprite = new StaticSprite(ezaelStillForwardTexture);

        player = new Player(ezaelStillForwardSprite, .5f);
        font = Content.Load<SpriteFont>("Fonts/arial");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        switch(state) {
            case PlayerState.idle:
                break;
            case PlayerState.moveLeftRight:
                leftRightTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if(leftRightTimer <= 0) {
                    leftRightTimer = leftRightTimerMax;
                    leftRightShouldMoveRight = !leftRightShouldMoveRight;
                }
                if(leftRightShouldMoveRight) {
                    player.MoveRight();
                }
                else {
                    player.MoveLeft();
                }
                break;
            case PlayerState.moveUpDown:
                upDownTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if(upDownTimer <= 0) {
                    upDownTimer = upDownTimerMax;
                    upDownShouldMoveUp = !upDownShouldMoveUp;
                }
                if(upDownShouldMoveUp) {
                    player.MoveUp();
                }
                else {
                    player.MoveDown();
                }
                break;
        }
        player.Update(gameTime);
        keyboardController.Update();
        mouseController.Update();


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        player.Draw(_spriteBatch, new Vector2(screenWidth / 2 - 64 , screenHeight / 2 - 32));
        _spriteBatch.Begin();
        _spriteBatch.DrawString(font, "Credits\nProgram Made By: Leo Cheng\nSprites from: Leo Cheng", new Vector2(275, 350), Color.Black);
        _spriteBatch.End();
        base.Draw(gameTime);
    }

    public void actionOne() {
        state = PlayerState.idle;
        player.SetSprite(ezaelStillForwardSprite);
        player.Reset();
        
    }
    public void actionTwo() {
        state = PlayerState.idle;
        player.SetSprite(ezaelRightSprite);
        player.Reset();
    }
    public void actionThree() {
        state = PlayerState.moveUpDown;
        player.SetSprite(ezaelStillForwardSprite);
        player.Reset();
    }
    public void actionFour() {
        state = PlayerState.moveLeftRight;
        player.SetSprite(ezaelLeftSprite);
        player.Reset();
    }
}

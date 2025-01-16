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
            { Keys.D0, new Action(QuitGame)},
            { Keys.D1, new Action(NonMovingNonAnimated)},
            { Keys.D2, new Action(NonMovingAnimated)},
            { Keys.D3, new Action(MovingNonAnimated)},
            { Keys.D4, new Action(MovingAnimated)}
        });
        screenWidth = 800;
        screenHeight = 400;

        mouseController = new MouseController(new Dictionary<object, Delegate> {
            {new Rectangle(0, 0, screenWidth / 2, screenHeight / 2), new Action(NonMovingNonAnimated)},
            {new Rectangle(screenWidth / 2, 0, screenWidth / 2, screenHeight / 2), new Action(NonMovingAnimated)},
            {new Rectangle(0, screenHeight / 2, screenWidth / 2, screenHeight / 2), new Action(MovingNonAnimated)},
            {new Rectangle(screenWidth / 2, screenHeight / 2, screenWidth / 2, screenHeight / 2), new Action(MovingAnimated)}
        });

        player = new Player(this, Vector2.Zero);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        font = Content.Load<SpriteFont>("Fonts/arial");
    }

    protected override void Update(GameTime gameTime)
    {
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

    public void NonMovingNonAnimated() {
        player.NonMovingNonAnimatedSprite();
        player.Reset();
        
    }
    public void NonMovingAnimated() {
        player.NonMovingAnimatedSprite();
        player.Reset();
    }
    public void MovingNonAnimated() {
        player.MovingNonAnimatedSprite();
        player.Reset();
    }
    public void MovingAnimated() {
        player.MovingAnimatedSprite();
        player.Reset();
    }
    public void QuitGame() {
        Exit();
    }
}

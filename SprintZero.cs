using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SprintZero.ConcreteClasses;
using System;
using TextureAtlas;
using System.Collections.Generic;

namespace SprintZero;

public class SprintZero : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private AnimatedSprite ezaelSprite;
    private KeyboardController keyboardController;
    private MouseController mouseController;

    // private int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
    private int screenWidth;
    private int screenHeight;
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
        Texture2D ezealTexture = Content.Load<Texture2D>("EzaelSpriteSheet");
        ezaelSprite = new AnimatedSprite(ezealTexture, 8, 8);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        ezaelSprite.Update();
        keyboardController.Update();
        mouseController.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        ezaelSprite.Draw(_spriteBatch, new Vector2(400, 200));
        base.Draw(gameTime);
    }

    public void actionOne() {
        Console.WriteLine("Action One");
    }
    public void actionTwo() {
        Console.WriteLine("Action Two");
    }
    public void actionThree() {
        Console.WriteLine("Action Three");
    }
    public void actionFour() {
        Console.WriteLine("Action Four");
    }
}

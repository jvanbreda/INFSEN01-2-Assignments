using GuiApplication.GuiElements;
using GuiApplication.Iterators;
using GuiApplication.Visitors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GuiApplication {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1: Game {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static SpriteFont font;
        public static Vector2 mousePosition;
        private MouseState mouseState;
        private MouseState previousState;

        private IVisitor drawVisitor;
        private IVisitor updateVisitor;

        private GuiElementCollection collection;
        private IIterator iterator;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            mouseState = Mouse.GetState();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
            this.IsMouseVisible = true;

            List<IGuiElement> elements = new List<IGuiElement> {
                new Label("Hello 1", new Vector2(10, 10), Color.Black),
                new Label("Hello 2", new Vector2(50, 50), Color.Black),
                new Button("Click me", new Vector2(100, 100), new Vector2(100, 50), Color.Pink, Color.Blue, Color.Red, null)
            };

            collection = new GuiElementCollection(elements);
            iterator = collection.Iterator();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            font = Content.Load<SpriteFont>("default");
            spriteBatch = new SpriteBatch(GraphicsDevice);

            drawVisitor = new DrawVisitor(spriteBatch);
            updateVisitor = new UpdateVisitor(spriteBatch);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            previousState = mouseState;
            mouseState = Mouse.GetState();
            mousePosition = new Vector2(mouseState.Position.X, mouseState.Position.Y);

            while (iterator.HasNext())
                updateVisitor.Visit(iterator.Next());

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            while (iterator.HasNext()) {
                drawVisitor.Visit(iterator.Next());
            }

            base.Draw(gameTime);
        }
    }
}

using GuiApplication.Adapters;
using GuiApplication.Adapters.InputAdapters;
using GuiApplication.Factories;
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
        public static MouseState mouseState;
        public static MouseState previousState;

        public static KeyboardState keyboardState;

        private IVisitor drawVisitor;
        private IVisitor updateVisitor;

        private GuiElementCollection mainWindowCollection;
        private GuiElementCollection labelWindowCollection;
        private GuiElementCollection inputfieldWindowCollection;

        private IIterator mainWindowIterator;
        private IIterator labelWindowIterator;
        private IIterator inputfieldIterator;

        private IDrawAdapter drawAdapter;
        private IWindowFactory windowFactory;

        private IInputAdapter inputAdapter;

        public static GameStates states;

        public Game1() {
            inputAdapter = new InputAdapter();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            mouseState = inputAdapter.GetMouseState();
            keyboardState = inputAdapter.GetKeyboardState();
            windowFactory = new WindowFactory();
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

            mainWindowCollection = windowFactory.CreateMainWindowCollection();
            mainWindowIterator = mainWindowCollection.Iterator();

            labelWindowCollection = windowFactory.CreateLabelWindowCollection();
            labelWindowIterator = labelWindowCollection.Iterator();

            inputfieldWindowCollection = windowFactory.CreateInputFieldWindowCollection();
            inputfieldIterator = inputfieldWindowCollection.Iterator();

            states = GameStates.MainWindow;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            font = Content.Load<SpriteFont>("default");
            spriteBatch = new SpriteBatch(GraphicsDevice);

            drawAdapter = new MonogameAdapter(spriteBatch);

            drawVisitor = new DrawVisitor(drawAdapter);
            updateVisitor = new UpdateVisitor(drawAdapter);

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
            mouseState = inputAdapter.GetMouseState();
            mousePosition = new Vector2(mouseState.Position.X, mouseState.Position.Y);

            keyboardState = inputAdapter.GetKeyboardState();

            switch (states) {
                case GameStates.MainWindow:
                    while (mainWindowIterator.HasNext())
                        updateVisitor.Visit(mainWindowIterator.Next());
                break;
                case GameStates.LabelWindow:
                    while (labelWindowIterator.HasNext())
                        updateVisitor.Visit(labelWindowIterator.Next());
                break;
                case GameStates.InputFieldWindow:
                    while (inputfieldIterator.HasNext())
                        updateVisitor.Visit(inputfieldIterator.Next());
                break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            switch (states) {
                case GameStates.MainWindow:
                while (mainWindowIterator.HasNext())
                    drawVisitor.Visit(mainWindowIterator.Next());
                break;
                case GameStates.LabelWindow:
                while (labelWindowIterator.HasNext())
                    drawVisitor.Visit(labelWindowIterator.Next());
                break;
                case GameStates.InputFieldWindow:
                while (inputfieldIterator.HasNext())
                    drawVisitor.Visit(inputfieldIterator.Next());
                break;
            }

            base.Draw(gameTime);
        }
    }
}

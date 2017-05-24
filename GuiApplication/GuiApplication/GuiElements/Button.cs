using GuiApplication.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GuiApplication.GuiElements {
    class Button: IGuiElement {

        public string Label { get; private set; }
        public Vector2 Position { get; private set; }
        public Vector2 WidthHeight { get; private set; }
        public Color Color { get; private set; }
        public Color OnOverColor { get; private set; }
        public Color OnClickColor { get; private set; }
        public GameStates StateToGo { get; set; }

        public Button(string label, Vector2 position, Vector2 widthHeight, Color color, Color onOver, Color onClick, GameStates stateToGo) {
            Label = label;
            Position = position;
            WidthHeight = widthHeight;
            Color = color;
            OnOverColor = onOver;
            OnClickColor = onClick;
            StateToGo = stateToGo;
        }
        public void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Begin();
            Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, (int)WidthHeight.X, (int)WidthHeight.Y);

            Color[] colorData = new Color[rect.Width * rect.Height];

            for (int i = 0; i < rect.Height * rect.Width; i++) {
                colorData[i] = Color;
            }

            rect.SetData(colorData);

            spriteBatch.Draw(rect, new Rectangle((int)Position.X, (int)Position.Y, (int)WidthHeight.X, (int)WidthHeight.Y), Color);

            ScaleTextToButton(rect, spriteBatch);
            spriteBatch.End();
        }

        public void Update(SpriteBatch spriteBatch) {
            Color newColor;

            if (IsMouseOverButton()) {
                newColor = OnOverColor;
                if (Game1.previousState.LeftButton == ButtonState.Released && Game1.mouseState.LeftButton == ButtonState.Pressed) {
                    Game1.states = StateToGo;
                    newColor = OnClickColor;
                }
            }
            else
                newColor = Color;
        }

        private void ScaleTextToButton(Texture2D button, SpriteBatch spriteBatch) {
            Vector2 size = Game1.font.MeasureString(Label);

            float xScale = (button.Width / size.X);
            float yScale = (button.Height / size.Y);

            float scale = Math.Min(xScale, yScale);

            Vector2 stringDimensions = new Vector2((int)Math.Round(size.X * scale), (int)Math.Round(size.Y * scale));
            
            Vector2 stringPosition = new Vector2(Position.X + (button.Width / 2) - (stringDimensions.X / 2), Position.Y + (button.Height / 2) - (stringDimensions.Y / 2));
            spriteBatch.DrawString(Game1.font, Label, stringPosition, Color.Black, 0.0f, new Vector2(), scale, new SpriteEffects(), 0.0f);
        }

        private bool IsMouseOverButton() {
            int xMinBoundary = (int) Position.X;
            int xMaxBoundary = (int) Position.X + (int) WidthHeight.X;
            int yMinBoundary = (int) Position.Y;
            int yMaxBoundary = (int) Position.Y + (int)WidthHeight.Y;

            return (Game1.mousePosition.X > xMinBoundary && Game1.mousePosition.X < xMaxBoundary
                    && Game1.mousePosition.Y > yMinBoundary && Game1.mousePosition.Y < yMaxBoundary);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.GuiElements;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GuiApplication.Adapters {
    class MonogameAdapter: IAdapter {
        private SpriteBatch spriteBatch;
        private int counter = 0;

        public MonogameAdapter(SpriteBatch spriteBatch) {
            this.spriteBatch = spriteBatch;
            this.counter = 0;
        }
        public void Draw(Label label) {
            spriteBatch.Begin();
            spriteBatch.DrawString(Game1.font, label.Text, label.Position, label.Color);
            spriteBatch.End();
        }

        public void Draw(Button button) {
            spriteBatch.Begin();
            Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, (int)button.WidthHeight.X, (int)button.WidthHeight.Y);

            Color[] colorData = new Color[rect.Width * rect.Height];

            for (int i = 0; i < rect.Height * rect.Width; i++) {
                colorData[i] = button.Color;
            }

            rect.SetData(colorData);

            spriteBatch.Draw(rect, new Rectangle((int)button.Position.X, (int)button.Position.Y, (int)button.WidthHeight.X, (int)button.WidthHeight.Y), button.Color);

            ScaleTextToButton(rect, button, spriteBatch);
            spriteBatch.End();
        }

        private void ScaleTextToButton(Texture2D rect, Button button, SpriteBatch spriteBatch) {
            Vector2 size = Game1.font.MeasureString(button.Label);

            float xScale = (rect.Width / size.X);
            float yScale = (rect.Height / size.Y);

            float scale = Math.Min(xScale, yScale);

            Vector2 stringDimensions = new Vector2((int)Math.Round(size.X * scale), (int)Math.Round(size.Y * scale));

            Vector2 stringPosition = new Vector2(button.Position.X + (rect.Width / 2) - (stringDimensions.X / 2), button.Position.Y + (rect.Height / 2) - (stringDimensions.Y / 2));
            spriteBatch.DrawString(Game1.font, button.Label, stringPosition, Color.Black, 0.0f, new Vector2(), scale, new SpriteEffects(), 0.0f);
        }

        public void Draw(InputField inputField) {
            spriteBatch.Begin();
            Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, inputField.Width, 20);
            Color[] colorData = new Color[rect.Width * rect.Height];

            for (int i = 0; i < rect.Height * rect.Width; i++) {
                colorData[i] = Color.White;
            }

            rect.SetData(colorData);

            spriteBatch.Draw(rect, new Rectangle((int)inputField.Position.X, (int)inputField.Position.Y, rect.Width, rect.Height), Color.White);
            spriteBatch.DrawString(Game1.font, CharsToString(inputField.Content), inputField.Position, Color.Black);
            spriteBatch.End();
        }

        private string CharsToString(List<char> content) {
            string resultString = "";
            foreach (char item in content) {
                resultString += item;
            }
            return resultString;
        }

        public void Update(Label label) {
            throw new NotImplementedException();
        }

        public void Update(Button button) {
            if (IsMouseOver(button)) {
                if (Game1.previousState.LeftButton == ButtonState.Released && Game1.mouseState.LeftButton == ButtonState.Pressed) {
                    Game1.states = button.StateToGo;
                }
            }
        }

        private bool IsMouseOver(Button button) {
            int xMinBoundary = (int)button.Position.X;
            int xMaxBoundary = (int)button.Position.X + (int)button.WidthHeight.X;
            int yMinBoundary = (int)button.Position.Y;
            int yMaxBoundary = (int)button.Position.Y + (int)button.WidthHeight.Y;

            return (Game1.mousePosition.X > xMinBoundary && Game1.mousePosition.X < xMaxBoundary
                    && Game1.mousePosition.Y > yMinBoundary && Game1.mousePosition.Y < yMaxBoundary);

        }

        public void Update(InputField inputField) {
            counter++;
            Keys[] pressedKeys = Game1.keyboardState.GetPressedKeys();
            if (counter > 3) {
                if (pressedKeys.Length > 0)
                    if (pressedKeys[0].ToString() == "Space")
                        inputField.Content.Add(' ');
                    else if (pressedKeys[0].ToString() == "Back") {
                        if (inputField.Content.Count > 0)
                            inputField.Content.RemoveAt(inputField.Content.Count - 1);
                    }
                    else
                        inputField.Content.Add(pressedKeys[0].ToString().ToLower().ToCharArray()[0]);

                counter = 0;
            }
        }
    }
}

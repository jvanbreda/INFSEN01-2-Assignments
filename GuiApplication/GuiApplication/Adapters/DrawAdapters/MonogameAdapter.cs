using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.GuiElements;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using GuiApplication.Decorators;

namespace GuiApplication.Adapters {
    class MonogameAdapter: IDrawAdapter {
        private SpriteBatch spriteBatch;
        private int counter = 0;

        public MonogameAdapter(SpriteBatch spriteBatch) {
            this.spriteBatch = spriteBatch;
            this.counter = 0;
        }
        public void Draw(LabelDecorator label) {
            spriteBatch.Begin();
            spriteBatch.DrawString(Game1.font, label.Text, label.GetPosition(), label.Color);
            spriteBatch.End();
        }

        public void Draw(ClickableDecorator button) {
            spriteBatch.Begin();
            Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, (int)button.WidthHeight.X, (int)button.WidthHeight.Y);

            Color[] colorData = new Color[rect.Width * rect.Height];

            for (int i = 0; i < rect.Height * rect.Width; i++) {
                colorData[i] = button.Color;
            }

            rect.SetData(colorData);

            spriteBatch.Draw(rect, new Rectangle((int)button.GetPosition().X, (int)button.GetPosition().Y, (int)button.WidthHeight.X, (int)button.WidthHeight.Y), button.Color);
            spriteBatch.End();
        }

        public void Draw(InputDecorator inputField) {
            spriteBatch.Begin();
            Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, inputField.Width, 20);
            Color[] colorData = new Color[rect.Width * rect.Height];

            for (int i = 0; i < rect.Height * rect.Width; i++) {
                colorData[i] = Color.White;
            }

            rect.SetData(colorData);

            spriteBatch.Draw(rect, new Rectangle((int)inputField.GetPosition().X, (int)inputField.GetPosition().Y, rect.Width, rect.Height), Color.White);
            spriteBatch.DrawString(Game1.font, CharsToString(inputField.Content), inputField.GetPosition(), Color.Black);
            spriteBatch.End();
        }

        private string CharsToString(List<char> content) {
            string resultString = "";
            foreach (char item in content) {
                resultString += item;
            }
            return resultString;
        }

        public void Update(ClickableDecorator button) {
            if (IsMouseOver(button)) {
                if (Game1.previousState.LeftButton == ButtonState.Released && Game1.mouseState.LeftButton == ButtonState.Pressed) {
                    Game1.states = button.StateToGo;
                }
            }
        }

        private bool IsMouseOver(ClickableDecorator button) {
            int xMinBoundary = (int)button.GetPosition().X;
            int xMaxBoundary = (int)button.GetPosition().X + (int)button.WidthHeight.X;
            int yMinBoundary = (int)button.GetPosition().Y;
            int yMaxBoundary = (int)button.GetPosition().Y + (int)button.WidthHeight.Y;

            return (Game1.mousePosition.X > xMinBoundary && Game1.mousePosition.X < xMaxBoundary
                    && Game1.mousePosition.Y > yMinBoundary && Game1.mousePosition.Y < yMaxBoundary);

        }

        public void Update(InputDecorator inputField) {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.Visitors;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GuiApplication.GuiElements {
    class InputField: IGuiElement {

        public Vector2 Position { get; set; }
        public int Width { get; set; }
        public List<char> Content { get; set; }

        private int counter;

        public InputField(Vector2 position, int width, List<char> content) {
            Position = position;
            Width = width;
            Content = content;
            counter = 0;
        }

        public void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Begin();
            Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, Width, 20);
            Color[] colorData = new Color[rect.Width * rect.Height];

            for (int i = 0; i < rect.Height * rect.Width; i++) {
                colorData[i] = Color.White;
            }

            rect.SetData(colorData);

            spriteBatch.Draw(rect, new Rectangle((int)Position.X, (int)Position.Y, rect.Width, rect.Height), Color.White);
            spriteBatch.DrawString(Game1.font, CharsToString(), Position, Color.Black);
            spriteBatch.End();
        }

        public void Update(SpriteBatch spriteBatch) {
            counter++;

            Keys[] pressedKeys = Game1.keyboardState.GetPressedKeys();
            if (counter > 3) {
                if (pressedKeys.Length > 0)
                    if (pressedKeys[0].ToString() == "Space")
                        Content.Add(' ');
                    else if (pressedKeys[0].ToString() == "Back") {
                        if (Content.Count > 0)
                            Content.RemoveAt(Content.Count - 1);
                    }
                    else
                        Content.Add(pressedKeys[0].ToString().ToLower().ToCharArray()[0]);

                counter = 0;
            }
        }

        private string CharsToString() {
            string resultString = "";
            foreach (char item in Content) {
                resultString += item;
            }
            return resultString;
        }
    }
}

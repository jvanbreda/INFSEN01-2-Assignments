using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.Visitors;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using GuiApplication.Adapters;

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

        public void Draw(IAdapter adapter) {
            adapter.Draw(this);
        }

        public void Update(IAdapter adapter) {
            adapter.Update(this);
        }
    }
}

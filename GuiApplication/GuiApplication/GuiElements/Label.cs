using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.Visitors;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GuiApplication.Adapters;

namespace GuiApplication.GuiElements {
    class Label: IGuiElement {

        public string Text { get; private set; }
        public Vector2 Position { get; private set; }
        public Color Color { get; private set; }

        public Label(string text, Vector2 position, Color color) {
            Text = text;
            Position = position;
            Color = color;
        }
        public void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }

        public void Draw(IAdapter adapter) {
            adapter.Draw(this);
        }

        public void Update(IAdapter adapter) {}
    }
}

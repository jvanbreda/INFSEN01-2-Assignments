using GuiApplication.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using GuiApplication.Adapters;

namespace GuiApplication.GuiElements {
    class Button: IGuiElement {

        public string Label { get; private set; }
        public Vector2 Position { get; private set; }
        public Vector2 WidthHeight { get; private set; }
        public Color Color { get; private set; }
        public GameStates StateToGo { get; set; }

        public Button(string label, Vector2 position, Vector2 widthHeight, Color color, GameStates stateToGo) {
            Label = label;
            Position = position;
            WidthHeight = widthHeight;
            Color = color;
            StateToGo = stateToGo;
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

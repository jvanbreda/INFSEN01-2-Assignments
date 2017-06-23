using GuiApplication.GuiElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.Visitors;
using Microsoft.Xna.Framework;
using GuiApplication.Adapters;

namespace GuiApplication.Decorators {
    class RootGuiElement: IGuiElement {
        public Vector2 Position { get; set; }

        public RootGuiElement(Vector2 position) {
            Position = position;
        }
        public void Accept(IVisitor visitor) {}

        public Vector2 GetPosition() {
            return Position;
        }

        public void Draw(IDrawAdapter adapter) {}

        public void Update(IDrawAdapter adapter) {}
    }
}

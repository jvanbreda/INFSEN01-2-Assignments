using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.Adapters;
using GuiApplication.GuiElements;
using Microsoft.Xna.Framework;
using GuiApplication.Visitors;

namespace GuiApplication.Decorators {
    class ClickableDecorator: GuiElementDecorator {
        public Vector2 WidthHeight { get; private set; }
        public Color Color { get; private set; }
        public GameStates StateToGo { get; set; }
        public ClickableDecorator(IGuiElement element, Vector2 widthHeight, Color color, GameStates stateToGo) : base(element) {
            WidthHeight = widthHeight;
            Color = color;
            StateToGo = stateToGo;
        }

        public override void Draw(IAdapter adapter) {
            Element.Draw(adapter);
            adapter.Draw(this);
        }

        public override void Update(IAdapter adapter) {
            Element.Update(adapter);
            adapter.Update(this);
        }
    }
}

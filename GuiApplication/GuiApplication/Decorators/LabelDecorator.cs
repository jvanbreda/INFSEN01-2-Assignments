using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.Adapters;
using GuiApplication.GuiElements;
using GuiApplication.Visitors;
using Microsoft.Xna.Framework;

namespace GuiApplication.Decorators {
    class LabelDecorator: GuiElementDecorator {
        public string Text { get; private set; }
        public Color Color { get; private set; }
        public LabelDecorator(IGuiElement element, string text, Color color) : base(element) {
            Text = text;
            Color = color;
        }

        public override void Accept(IVisitor visitor) {
            Element.Accept(visitor);
            visitor.Visit(this);
        }
    }
}

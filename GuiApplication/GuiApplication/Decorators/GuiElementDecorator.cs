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
    abstract class GuiElementDecorator: IGuiElement {
        protected IGuiElement Element { get; set; }

        public GuiElementDecorator(IGuiElement element) {
            Element = element;
        }
        public virtual void Accept(IVisitor visitor) {
            visitor.Visit(Element);
        }

        public Vector2 GetPosition() {
            return Element.GetPosition();
        }

        public abstract void Draw(IDrawAdapter adapter);
        public abstract void Update(IDrawAdapter adapter);
    }
}

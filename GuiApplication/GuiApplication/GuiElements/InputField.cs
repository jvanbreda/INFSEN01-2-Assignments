using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.Visitors;
using Microsoft.Xna.Framework.Graphics;

namespace GuiApplication.GuiElements {
    class InputField: IGuiElement {
        public void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }

        public void Draw(SpriteBatch spriteBatch) {
            throw new NotImplementedException();
        }

        public void Update(SpriteBatch spriteBatch) {
            throw new NotImplementedException();
        }
    }
}

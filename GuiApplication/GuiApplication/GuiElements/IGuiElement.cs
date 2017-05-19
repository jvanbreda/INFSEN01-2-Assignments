using GuiApplication.Visitors;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApplication.GuiElements {
    interface IGuiElement {

        void Accept(IVisitor visitor);
        void Draw(SpriteBatch spriteBatch);
        void Update(SpriteBatch spriteBatch);
    }
}

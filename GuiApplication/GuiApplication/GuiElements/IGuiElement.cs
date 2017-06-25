using GuiApplication.Adapters;
using GuiApplication.Visitors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApplication.GuiElements {
    interface IGuiElement {

        Vector2 GetPosition();
        void Accept(IVisitor visitor);
    }
}

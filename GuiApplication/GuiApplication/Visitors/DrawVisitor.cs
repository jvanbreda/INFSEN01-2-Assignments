using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.GuiElements;
using Microsoft.Xna.Framework.Graphics;
using GuiApplication.Adapters;

namespace GuiApplication.Visitors {
    class DrawVisitor: IVisitor {

        private IAdapter adapter;
        public DrawVisitor(IAdapter adapter) {
            this.adapter = adapter;
        }
        public void Visit(IGuiElement guiElement) {
            guiElement.Draw(adapter);
        }
    }
}

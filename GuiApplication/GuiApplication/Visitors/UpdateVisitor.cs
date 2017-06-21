using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.GuiElements;
using Microsoft.Xna.Framework.Graphics;
using GuiApplication.Adapters;

namespace GuiApplication.Visitors {
    class UpdateVisitor: IVisitor {

        private IAdapter adapter;
        public UpdateVisitor(IAdapter adapter) {
            this.adapter = adapter;
        }
        public void Visit(IGuiElement guiElement) {
            guiElement.Update(adapter);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.GuiElements;
using Microsoft.Xna.Framework.Graphics;

namespace GuiApplication.Visitors {
    class UpdateVisitor: IVisitor {
        public SpriteBatch SpriteBatch { get; private set; }

        public UpdateVisitor(SpriteBatch spriteBatch) {
            SpriteBatch = spriteBatch;
        }
        public void Visit(IGuiElement guiElement) {
            guiElement.Update(SpriteBatch);
        }
    }
}

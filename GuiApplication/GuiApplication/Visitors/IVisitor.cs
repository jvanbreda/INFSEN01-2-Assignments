using GuiApplication.GuiElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApplication.Visitors {
    interface IVisitor {
        void Visit(IGuiElement guiElement);
    }
}

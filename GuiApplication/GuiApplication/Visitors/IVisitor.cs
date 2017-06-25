using GuiApplication.Decorators;
using GuiApplication.GuiElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApplication.Visitors {
    interface IVisitor {
        void Visit(LabelDecorator label);
        void Visit(ClickableDecorator button);
        void Visit(InputDecorator input);
    }
}

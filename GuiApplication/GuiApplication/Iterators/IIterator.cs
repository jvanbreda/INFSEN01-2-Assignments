using GuiApplication.GuiElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApplication.Iterators {
    interface IIterator {

        IGuiElement Next();
        bool HasNext();

    }
}

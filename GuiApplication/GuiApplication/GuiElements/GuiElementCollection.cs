using GuiApplication.Iterators;
using GuiApplication.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApplication.GuiElements {
    class GuiElementCollection {

        public List<IGuiElement> Elements { get; private set; } = new List<IGuiElement>();

        public GuiElementCollection(List<IGuiElement> elements) {
            Elements = elements;
        }

        public IIterator Iterator() {
            return new GuiElementIterator(Elements);
        }
    }
}

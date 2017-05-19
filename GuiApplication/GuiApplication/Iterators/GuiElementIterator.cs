using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.GuiElements;

namespace GuiApplication.Iterators {
    class GuiElementIterator: IIterator {

        public List<IGuiElement> Elements { get; private set; }
        private int counter;

        public GuiElementIterator(List<IGuiElement> elements) {
            Elements = elements;
            counter = -1;
        }

        public bool HasNext() {
            if(!(counter < Elements.Count() - 1)) {
                counter = -1;
                return false;
            }
            return true;
        }

        public IGuiElement Next() {
            counter++;
            return Elements[counter];
        }
    }
}

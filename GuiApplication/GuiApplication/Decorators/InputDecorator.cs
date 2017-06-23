using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.Adapters;
using GuiApplication.GuiElements;
using GuiApplication.Visitors;

namespace GuiApplication.Decorators {
    class InputDecorator: GuiElementDecorator {
        public int Width { get; set; }
        public List<char> Content { get; set; }
        public InputDecorator(IGuiElement element, int width, List<char> content) : base(element) {
            Width = width;
            Content = content;
        }

        public override void Draw(IAdapter adapter) {
            Element.Draw(adapter);
            adapter.Draw(this);
        }

        public override void Update(IAdapter adapter) {
            Element.Update(adapter);
            adapter.Update(this);
        }
    }
}

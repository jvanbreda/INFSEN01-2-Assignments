using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.GuiElements;
using Microsoft.Xna.Framework.Graphics;
using GuiApplication.Adapters;
using GuiApplication.Decorators;

namespace GuiApplication.Visitors {
    class DrawVisitor: IVisitor {

        private IDrawAdapter adapter;
        public DrawVisitor(IDrawAdapter adapter) {
            this.adapter = adapter;
        }

        public void Visit(LabelDecorator label) {
            adapter.Draw(label);
        }

        public void Visit(ClickableDecorator button) {
            adapter.Draw(button);
        }

        public void Visit(InputDecorator input) {
            adapter.Draw(input);

        }
    }
}

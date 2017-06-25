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
    class UpdateVisitor: IVisitor {

        private IDrawAdapter adapter;
        public UpdateVisitor(IDrawAdapter adapter) {
            this.adapter = adapter;
        }

        public void Visit(LabelDecorator label) {}

        public void Visit(ClickableDecorator button) {
            adapter.Update(button);
        }

        public void Visit(InputDecorator input) {
            adapter.Update(input);
        }
    }
}

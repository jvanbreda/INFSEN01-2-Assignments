using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.Decorators;
using GuiApplication.GuiElements;

namespace GuiApplication.Adapters {
    class JavaFxAdapter: IDrawAdapter {
        public void Draw(LabelDecorator label) {
            throw new NotImplementedException();
        }

        public void Draw(ClickableDecorator button) {
            throw new NotImplementedException();
        }

        public void Draw(InputDecorator inputField) {
            throw new NotImplementedException();
        }

        public void Update(ClickableDecorator button) {
            throw new NotImplementedException();
        }

        public void Update(InputDecorator inputField) {
            throw new NotImplementedException();
        }
    }
}

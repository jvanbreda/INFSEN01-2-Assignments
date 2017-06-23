using GuiApplication.Decorators;
using GuiApplication.GuiElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApplication.Adapters {
    interface IAdapter {

        void Draw(LabelDecorator label);
        void Draw(ClickableDecorator button);
        void Draw(InputDecorator inputField);
        void Update(ClickableDecorator button);
        void Update(InputDecorator inputField);
    }
}

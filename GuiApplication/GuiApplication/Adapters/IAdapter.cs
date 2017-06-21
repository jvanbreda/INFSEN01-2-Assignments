using GuiApplication.GuiElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApplication.Adapters {
    interface IAdapter {

        void Draw(Label label);
        void Draw(Button button);
        void Draw(InputField inputField);
        void Update(Label label);
        void Update(Button button);
        void Update(InputField inputField);
    }
}

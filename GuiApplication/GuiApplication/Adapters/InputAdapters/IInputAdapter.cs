using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiApplication.Adapters.InputAdapters {
    interface IInputAdapter {
        KeyboardState GetKeyboardState();
        MouseState GetMouseState();
    }
}

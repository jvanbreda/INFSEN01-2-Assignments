using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace GuiApplication.Adapters.InputAdapter {
    class InputAdapter: IInputAdapter {
        public KeyboardState GetKeyboardState() {
            return Keyboard.GetState();
        }

        public MouseState GetMouseState() {
            return Mouse.GetState();
        }
    }
}

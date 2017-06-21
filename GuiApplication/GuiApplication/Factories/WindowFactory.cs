using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.GuiElements;
using Microsoft.Xna.Framework;

namespace GuiApplication.Factories {
    class WindowFactory: IWindowFactory {
        private List<IGuiElement> guiElements = new List<IGuiElement>();

        public GuiElementCollection CreateInputFieldWindowCollection() {
            guiElements = new List<IGuiElement> {
                new InputField(new Vector2(10, 10), 100, new List<char>{ 'a', 'b', 'c' }),
                new Button("Back to main window", new Vector2(100, 100), new Vector2(100, 50), Color.Pink, GameStates.MainWindow)
            };
            return new GuiElementCollection(guiElements);
        }

        public GuiElementCollection CreateLabelWindowCollection() {
            guiElements = new List<IGuiElement> {
                new Label("I am a label :)", new Vector2(10, 10), Color.Black),
                new Button("Back to main window", new Vector2(100, 100), new Vector2(100, 50), Color.Pink, GameStates.MainWindow)
            };
            return new GuiElementCollection(guiElements);
        }

        public GuiElementCollection CreateMainWindowCollection() {
            guiElements = new List<IGuiElement> {
                new Button("Label window", new Vector2(100, 100), new Vector2(100, 50), Color.Pink, GameStates.LabelWindow),
                new Button("Input window", new Vector2(300, 100), new Vector2(100, 50), Color.Pink, GameStates.InputFieldWindow)
            };
            return new GuiElementCollection(guiElements);

        }
    }
}

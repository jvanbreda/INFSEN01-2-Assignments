using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApplication.GuiElements;
using Microsoft.Xna.Framework;
using GuiApplication.Decorators;

namespace GuiApplication.Factories {
    class WindowFactory: IWindowFactory {
        private List<IGuiElement> guiElements = new List<IGuiElement>();

        public GuiElementCollection CreateInputFieldWindowCollection() {
            guiElements = new List<IGuiElement> {
                new InputDecorator(new RootGuiElement(new Vector2(10, 10)), 100, new List<char>{ 'a', 'b', 'c'}),
                new LabelDecorator(new ClickableDecorator(new RootGuiElement(new Vector2(100, 100)), new Vector2(100, 50), Color.Pink, GameStates.MainWindow), "Back", Color.Black),
            };
            return new GuiElementCollection(guiElements);
        }

        public GuiElementCollection CreateLabelWindowCollection() {
            guiElements = new List<IGuiElement> {
                new LabelDecorator(new RootGuiElement(new Vector2(10, 10)), "I am a Label!", Color.Black),
                new LabelDecorator(new ClickableDecorator(new RootGuiElement(new Vector2(100, 100)), new Vector2(100, 50), Color.Pink, GameStates.MainWindow), "Back", Color.Black),
            };
            return new GuiElementCollection(guiElements);
        }

        public GuiElementCollection CreateMainWindowCollection() {
            guiElements = new List<IGuiElement> {
                new LabelDecorator(new ClickableDecorator(new RootGuiElement(new Vector2(100, 100)), new Vector2(100, 50), Color.Pink, GameStates.InputFieldWindow), "Input", Color.Black),
                new LabelDecorator(new ClickableDecorator(new RootGuiElement(new Vector2(300, 100)), new Vector2(100, 50), Color.Pink, GameStates.LabelWindow), "Label", Color.Black),
            };
            return new GuiElementCollection(guiElements);

        }
    }
}

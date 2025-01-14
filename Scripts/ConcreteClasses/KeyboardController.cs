using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SprintZero.Interfaces;

namespace SprintZero.ConcreteClasses {
    public class KeyboardController : IController {
        public Dictionary<object, Delegate> dict { get; set; }
        private KeyboardState prevState;
        public KeyboardController(Dictionary<object, Delegate> dict) {
            this.dict = dict;
            prevState = Keyboard.GetState();
        }
        public void Update() {
            KeyboardState state = Keyboard.GetState();

            foreach (Keys key in state.GetPressedKeys()) {
                if(state.IsKeyDown(key) && !prevState.IsKeyDown(key)) {
                    if (dict.ContainsKey(key)) {
                        dict[key].DynamicInvoke();
                    }
                }
            }
            prevState = state;
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SprintZero.Interfaces;

namespace SprintZero.ConcreteClasses {
    public class MouseController : IController {
        public Dictionary<object, Delegate> dict { get; set; }
        public MouseController(Dictionary<object, Delegate> dict) {
            this.dict = dict;
        }
        private bool hasPressed = false;

        public void Update() {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed) {
                if (!hasPressed)
                {
                    hasPressed = true;
                    foreach (object rects in dict.Keys) {
                        if(rects is Rectangle) {
                            Rectangle rect = (Rectangle)rects;
                            if (rect.Contains(Mouse.GetState().Position)) {
                                dict[rect].DynamicInvoke();
                            }
                        }
                    }
                }
            }
            else {
                hasPressed = false;
            }

        }
    }
}
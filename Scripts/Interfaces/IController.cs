using System;
using System.Collections.Generic;

namespace SprintZero.Interfaces
{
    public interface IController
    {
        public Dictionary<object, Delegate> dict { get; set; }
    }
}
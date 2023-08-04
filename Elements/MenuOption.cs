using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestHive.ToolKit.Elements
{
    public struct MenuOption
    {
        public string Label { get; }
        private Action? _actionCB; // CB: callback to execute when option is selected

        public MenuOption(string label, Action? actionCB = null)
        {
            this.Label= label;
            this._actionCB = actionCB;
        }

        public void Execute()
        {
            _actionCB?.Invoke();
        }
    }
}

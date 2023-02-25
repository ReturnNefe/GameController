using Microsoft.AspNetCore.Components;
using GameController.Global;
using SharpHook.Native;

namespace GameController.Global.Helper
{
    internal class InputHelper
    {
        internal enum KeyMode
        {
            KeyDown,
            KeyUp
        }

        static internal Action<string?, KeyMode> PressKey = (key, mode) =>
        {
            try
            {
                var keyCode = Enum.Parse<KeyCode>(key?.Trim() ?? "");
                switch (mode)
                {
                    case KeyMode.KeyDown:
                        {
                            AppInfo.EventSimulator.SimulateKeyPress(keyCode);
                            break;
                        }

                    case KeyMode.KeyUp:
                        {
                            AppInfo.EventSimulator.SimulateKeyRelease(keyCode);
                            break;
                        }
                }
            }
            catch { }
        };
    }
}
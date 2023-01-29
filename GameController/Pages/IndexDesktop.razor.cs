using Microsoft.AspNetCore.Components;
using GameController.Global;
using SharpHook;
using SharpHook.Native;

namespace GameController.Pages
{
    public class IndexDesktopBase : ComponentBase
    {
        protected enum KeyMode
        {
            KeyDown,
            KeyUp
        }

        protected Action<string?, KeyMode> PressKey = (key, mode) =>
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
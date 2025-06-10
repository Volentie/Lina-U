using UnityEngine;
using Lina.Player.Input;

namespace Lina.State.Player.Mouse
{
    [RequireComponent(typeof(InputProvider))]
    public class MouseModeManager : MonoBehaviour, IMouseModeProvider
    {
        public MouseMode CurrentMode { get; private set; } = MouseMode.FreeLook;
        //public event Action<MouseMode> OnModeChanged;

        public void SetMode(MouseMode mode)
        {
            if (mode == CurrentMode) return;
            CurrentMode = mode;
            //OnModeChanged?.Invoke(mode);
        }
    }
}

namespace Lina.State.Player.Mouse
{
    /// <summary>
    /// Exposes current mouse mode and a change event.
    /// </summary>
    public interface IMouseModeProvider
    {
        MouseMode CurrentMode { get; }
        //event Action<MouseMode> OnModeChanged;
        void SetMode(MouseMode mode);
    }
}
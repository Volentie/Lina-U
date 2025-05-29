namespace Lina.Player.Mouse
{
	using UnityEngine;
	public class MouseSetting : MonoBehaviour, IMouseSetting
	{
		public void HideMouseCursor()
		{
			Cursor.visible = false;
		}
		public void LockMouseCenter()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}
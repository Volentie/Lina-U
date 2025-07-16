namespace Lina.Player.Sound
{
	public interface IFootstepController
	{
		void TryPlayWalking();
		void TryPlayRunning();
		void TryStop();
	}
}
namespace Lina.Player.Sound
{
	public interface IFootstepController : IBaseSoundController
	{
		void TryPlayWalking();
		void TryPlayRunning();
	}
}
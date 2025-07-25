namespace Lina.Player.Sound
{
	public interface IFootstepProvider : IBaseSoundProvider
	{
		void TryPlayWalking();
		void TryPlayRunning();
	}
}
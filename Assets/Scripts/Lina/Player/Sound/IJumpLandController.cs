namespace Lina.Player.Sound
{
	public interface IJumpLandController : IBaseSoundController
	{
		void TryPlayJumping();
		void TryPlayLanding();
	}
}
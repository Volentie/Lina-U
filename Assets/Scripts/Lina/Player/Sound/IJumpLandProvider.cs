namespace Lina.Player.Sound
{
	public interface IJumpLandProvider : IBaseSoundProvider
	{
		void TryPlayJumping();
		void TryPlayLanding();
	}
}
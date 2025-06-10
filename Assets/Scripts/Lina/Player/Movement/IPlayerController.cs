namespace Lina.Player.Movement
{
	public interface IPlayerController
	{
		float Speed { get; }
		void HandleMovement();
	}
}
namespace Lina.State.Player
{
	public enum PlayerMoveState
	{
		Idle,
		Walking,
		Running,
		Jumping
	}
	
	public interface IPlayerMoveStateProvider : IStateProvider<PlayerMoveState> { }
}
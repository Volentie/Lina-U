namespace Lina.State.Player
{
	public enum PlayerMoveState
	{
		Idle,
		Walking,
		Running
	}
	
	public interface IPlayerMoveStateProvider : IStateProvider<PlayerMoveState> { }
}
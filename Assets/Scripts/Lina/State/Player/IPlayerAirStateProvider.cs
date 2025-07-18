namespace Lina.State.Player
{
	public enum PlayerAirState
	{
		Grounded,
		Jumping,
		Landing,
		OnAir
	}

	public interface IPlayerAirStateProvider : IStateProvider<PlayerAirState> { };
}
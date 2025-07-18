namespace Lina.State.Player
{
	public enum PlayerGeneralState
	{
		Free,
		InDialogue
	}
	
	public interface IPlayerGeneralStateProvider : IStateProvider<PlayerGeneralState> { };
}
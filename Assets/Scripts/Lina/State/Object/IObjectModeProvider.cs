namespace Lina.State.Object
{
	public enum ObjectMode
	{
		Default,
		Hold,
		Rotate,
	}
	public interface IObjectModeProvider : IStateProvider<ObjectMode> { }
}
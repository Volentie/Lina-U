namespace Lina.Player.Object
{
	interface IPickObject
	{
		void TryPickOrRelease();
		void ApplyHoldPhysics();
	}
}
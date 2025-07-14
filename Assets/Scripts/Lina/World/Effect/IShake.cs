namespace Lina.World.Effect
{
    public interface IShake
    {
        float ShakeSpeed { get; }
        float ShakeMagnitude { get; }

        void StartShake(ShakeType type);
        void StopShake();
    }
}
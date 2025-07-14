using UnityEngine;

[CreateAssetMenu(fileName = "NewPitchShake", menuName = "Lina/Shake Types/Pitch Shake")]
public class PitchShake : ShakeType
{
    public override Vector3 GetShakeVector(float speed, float magnitude)
    {
        float shakeValue = Mathf.Sin(Time.time * speed) * magnitude;
        return new Vector3(shakeValue, 0, 0); // Rotates on X-axis
    }
}
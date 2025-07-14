using UnityEngine;

public abstract class DialogueType : ScriptableObject
{
	public abstract string[] DialogueLines { get; }
}
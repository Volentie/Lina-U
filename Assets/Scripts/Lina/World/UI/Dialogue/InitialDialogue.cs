using UnityEngine;

namespace Lina.World.UI.Dialogue
{
	[CreateAssetMenu(fileName = "InitialDialogue", menuName = "Lina/Dialogue/Initial Dialogue")]
	public class InitialDialogue : DialogueType
	{
		public override string[] DialogueLines => new string[] {
			"Leo...?",
			"I'm so sorry."
		};
	}
}

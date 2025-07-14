using UnityEngine;

namespace Lina.World.UI.Dialogue
{
    [CreateAssetMenu(fileName = "NewDialogue", menuName = "Lina/Dialogue/Simple Dialogue")]
    public class InitialDialogue : DialogueType
    {
        [Header("Conteúdo do Diálogo")]
        [Tooltip("As falas do diálogo que serão exibidas em ordem.")]
        [TextArea(3, 10)]
        [SerializeField]
        private string[] _dialogueLines;

        public override string[] DialogueLines => _dialogueLines;
    }
}
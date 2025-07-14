using UnityEngine;
using Lina.Player.Input;
using TMPro;

namespace Lina.World.UI
{
	public class DialoguePlayer : MonoBehaviour
	{
		[Header("UI References")]
		[SerializeField] private GameObject _dialogueBox;
		[SerializeField] private TMP_Text _textField;

		[Header("Dependencies")]
		[SerializeField] private GameObject _playerController;

		private IInputProvider _inputProvider;
		private string[] _dialogues;
		private int _line = 0;
		void Awake()
		{
			if (_playerController != null)
				_inputProvider = _playerController.GetComponent<IInputProvider>();
			else
				Debug.LogError("Missing PlayerController");
			if (_inputProvider == null)
				Debug.LogError("Missing InputProvider from PlayerController");
		}
		void Update()
		{
			if (!_dialogueBox.activeSelf || _inputProvider == null)
				return;

			if (_line < _dialogues.Length)
			{
				_textField.text = _dialogues[_line];
				if (_inputProvider.GetInteractPressed())
				{
					_line++;
				}
			}
			else
				_dialogueBox.SetActive(false);
		}
		public void PlaySequential(DialogueType dialogue)
		{
			if (dialogue == null || dialogue.DialogueLines.Length == 0)
				return;

			_line = 0;
			_dialogues = dialogue.DialogueLines;
			_dialogueBox.SetActive(true);
		}
	}
}
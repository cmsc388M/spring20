using TMPro;
using UnityEngine;

namespace CSharpDelegatesVersion
{
    public class MessageChanger : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;

        void Start()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            PlayerEvents.OnWin += SetWinText;
            PlayerEvents.OnLose += SetLoseText;
        }

        private void OnDisable()
        {
            PlayerEvents.OnWin -= SetWinText;
            PlayerEvents.OnLose -= SetLoseText;
        }

        private void SetWinText()
        {
            textMesh.text = "Yay! You won.";
        }

        private void SetLoseText()
        {
            textMesh.text = "Better luck next time...";
        }
    }
}

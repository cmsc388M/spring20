using TMPro;
using UnityEngine;

namespace UnityEventsVersion
{
    public class MessageChanger : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;

        void Start()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
        }

        public void SetWinText()
        {
            textMesh.text = "Yay! You won.";
        }

        public void SetLoseText()
        {
            textMesh.text = "Better luck next time...";
        }
    }
}

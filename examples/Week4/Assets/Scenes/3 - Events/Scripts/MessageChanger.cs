using TMPro;
using UnityEngine;

public class MessageChanger : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
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

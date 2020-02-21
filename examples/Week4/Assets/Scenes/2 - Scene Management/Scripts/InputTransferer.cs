using TMPro;
using UnityEngine;

public class InputTransferer : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public PlayerInfo playerInfo;

    public void SetPlayerName()
    {
        if (!string.IsNullOrEmpty(textMesh.text))
        {
            playerInfo.playerName = textMesh.text;
        }
    }
}

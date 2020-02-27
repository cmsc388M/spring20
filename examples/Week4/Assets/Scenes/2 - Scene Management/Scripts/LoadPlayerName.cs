using UnityEngine;
using TMPro;

public class LoadPlayerName : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    // We cannot set a reference to this in the Inspector because there is no
    // Player Info Manager in this scene. Thus, we must get the reference to it
    // dynamically at runtime.
    public PlayerInfo playerInfoManager;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        playerInfoManager = FindObjectOfType<PlayerInfo>();

        textMesh.text = playerInfoManager.playerName;
    }
}

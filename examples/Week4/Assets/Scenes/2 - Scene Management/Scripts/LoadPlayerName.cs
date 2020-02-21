using UnityEngine;
using TMPro;

public class LoadPlayerName : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = FindObjectOfType<PlayerInfo>().playerName;
    }
}

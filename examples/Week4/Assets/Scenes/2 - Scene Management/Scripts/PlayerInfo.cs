using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public string playerName = "";

    // Start is called before the first frame update
    void Start()
    {
        // This will make the GameObject that this component is attached to
        // persist between scenes.
        DontDestroyOnLoad(gameObject);
    }
}

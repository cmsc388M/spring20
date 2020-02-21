using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GoToRaceScene()
    {
        SceneManager.LoadScene("Example 2 - Race Scene");
    }
}

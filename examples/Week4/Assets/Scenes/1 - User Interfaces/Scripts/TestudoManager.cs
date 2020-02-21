using UnityEngine;
using TMPro;

public class TestudoManager : MonoBehaviour  
{
    public TextMeshProUGUI counterText;
    private int rubCount = 0;
  
    public void RubNose()
    {
        rubCount++;
        counterText.text = "Nose rubbed " + rubCount.ToString() + " times...";
    }
}

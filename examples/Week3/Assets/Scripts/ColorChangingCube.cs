using UnityEngine;

public class ColorChangingCube : MonoBehaviour
{
    public Material defaultMaterial, redGlowMaterial, yellowGlowMaterial;
    private MeshRenderer render;

    private void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Write your code here


}

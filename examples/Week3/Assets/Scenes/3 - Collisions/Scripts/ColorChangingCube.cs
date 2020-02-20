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
    #region Example Student Implementation

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            render.material = yellowGlowMaterial;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            render.material = redGlowMaterial;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            render.material = defaultMaterial;
        }
    }

    #endregion
}

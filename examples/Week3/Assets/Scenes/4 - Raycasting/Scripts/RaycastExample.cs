using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    public Material blueMat;

    // Update is called once per frame
    private void Update()
    {
        // Write your code here
        #region Example Student Implementation

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("ColorChangeable"))
            {
                hit.collider.gameObject.GetComponent<MeshRenderer>().material = blueMat;
            }

            DrawRay(hit.distance);
        }
        else
        {
            DrawRay(10000);
        }

        #endregion
    }

    // Helper Method
    void DrawRay(float distance) {
        Debug.DrawRay(transform.position, transform.forward * distance, Color.green);
    }
}

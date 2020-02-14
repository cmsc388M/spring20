using UnityEngine;

public class RayCastExample : MonoBehaviour
{
    public Material blueMat;

    // Update is called once per frame
    private void Update()
    {
        // Write your code here


    }

    void DrawRay(float distance) {
        Debug.DrawRay(transform.position, transform.forward * distance, Color.green);
    }
}

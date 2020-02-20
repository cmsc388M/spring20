using UnityEngine;

public class TransformMovement : MonoBehaviour
{
    public float walkSpeed;
    public float rotateSpeed;

    // Update is called once per frame
    void Update() {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
    }
}

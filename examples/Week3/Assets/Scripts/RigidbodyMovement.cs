using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    public float forceAmount;
    private Rigidbody rb;
    private float horizontalAxisValue, verticalAxisValue;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxisValue = Input.GetAxis("Horizontal");
        verticalAxisValue = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.AddForce(horizontalAxisValue * forceAmount, 0, verticalAxisValue * forceAmount);
    }
}

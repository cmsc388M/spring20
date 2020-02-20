using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;

    // Write your code here
    #region Example Student Implementation

    private void OnTriggerEnter(Collider other)
    {
        OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        CloseDoor();
    }

    #endregion

    // Helper Methods
    public void OpenDoor() {
        anim.SetTrigger("Open");
    }

    public void CloseDoor() {
        anim.SetTrigger("Exit");
    }
}

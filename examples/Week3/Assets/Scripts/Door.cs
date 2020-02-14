using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;

    // Write your code here


    // Helper Methods
    public void OpenDoor() {
        anim.SetTrigger("Open");
    }

    public void CloseDoor() {
        anim.SetTrigger("Exit");
    }
}

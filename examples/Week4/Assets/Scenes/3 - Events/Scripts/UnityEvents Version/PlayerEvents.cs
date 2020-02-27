using UnityEngine;
using UnityEngine.Events;

namespace UnityEventsVersion
{
    public class PlayerEvents : MonoBehaviour
    {
        public UnityEvent OnWin;
        public UnityEvent OnLose;

        private bool actionComplete;

        // Start is called before the first frame update
        void Start()
        {
            actionComplete = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (!actionComplete)
            {
                if (transform.position.y < -1)
                {
                    OnLose.Invoke();
                    actionComplete = true;
                }
                else if (transform.position.z > 30)
                {
                    OnWin.Invoke();
                    actionComplete = true;
                }
            }
        }
    }
}
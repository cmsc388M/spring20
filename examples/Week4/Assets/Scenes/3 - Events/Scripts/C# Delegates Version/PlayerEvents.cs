using UnityEngine;

namespace CSharpDelegatesVersion
{
    public class PlayerEvents : MonoBehaviour
    {
        public delegate void WinAction();
        public static event WinAction OnWin;

        public delegate void LoseAction();
        public static event LoseAction OnLose;

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
                    OnLose();
                    actionComplete = true;
                }
                else if (transform.position.z > 30)
                {
                    OnWin();
                    actionComplete = true;
                }
            }
        }
    }
}

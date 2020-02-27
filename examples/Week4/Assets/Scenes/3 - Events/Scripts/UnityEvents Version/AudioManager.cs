using UnityEngine;

namespace UnityEventsVersion
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource[] sounds;
        private AudioSource cheering;
        private AudioSource loseSound;

        // Start is called before the first frame update
        void Start()
        {
            sounds = GetComponents<AudioSource>();
            cheering = sounds[0];
            loseSound = sounds[1];
        }

        public void PlayWinSound()
        {
            cheering.Play();
        }

        public void PlayLoseSound()
        {
            loseSound.Play();
        }
    }
}

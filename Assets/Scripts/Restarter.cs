using UnityEngine;

namespace PlatformEngine
{
    public class Restarter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
                Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
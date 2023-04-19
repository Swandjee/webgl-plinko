using UnityEngine;

namespace Gameplay
{
    public class SpinningBlock : MonoBehaviour
    {
        public bool rotateClockwise = true;
        public float rotationSpeed = 1f;
        private Vector3 rotationDirection = new Vector3(0, 0, 1);
        void Update()
        {
            transform.Rotate((rotateClockwise ? -rotationDirection : rotationDirection) * rotationSpeed * Time.deltaTime);
        }
    }
}

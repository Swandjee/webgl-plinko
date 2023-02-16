using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class Ball : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public SpriteRenderer spriteRenderer;
        [Range(0, 5)]
        public float positionVariationIntensity;
        public UnityEvent onCollisionDetected;
        private void Start()
        {
            rigidbody.simulated = false;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.isTrigger)
            {
                return;
            };
            onCollisionDetected.Invoke();
        }

        public void UpdateImage(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }

        public Vector2 GetRandomPointAroundBall()
        {
            var x = Random.Range(transform.position.x - positionVariationIntensity, transform.position.x + positionVariationIntensity);
            return new Vector2(x, transform.position.y);
        }
    }

}

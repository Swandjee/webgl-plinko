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
		public AudioClip[] ballHit;
        public AudioSource audioSource;
        public TrailRenderer trail;
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

        public void PlayRandomHitSound()
        {
            if(GameManager.Instance.isGamePaused)
            {
                return;
            }
            var randomClipIndex = Random.Range(0, ballHit.Length);
            var randomClip = ballHit[randomClipIndex];
            audioSource.PlayOneShot(randomClip);
        }
    }

}

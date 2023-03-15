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

        private float timeBeforeDebugNudge = 5f;
        private float timeElapsedForDebug = 0f;
        private Vector2 debugThreshold = new Vector2(0.1f, 0.1f);
		private void Start()
        {
            rigidbody.simulated = false;
        }

		private void Update()
		{
            
			if (rigidbody.velocity.x < debugThreshold.x && rigidbody.velocity.y < debugThreshold.y)
			{
                timeElapsedForDebug += Time.deltaTime;
			} else
			{
                if (timeElapsedForDebug != 0) timeElapsedForDebug = 0f;
			}
            if(timeElapsedForDebug >= timeBeforeDebugNudge)
			{
                var randomDirection = new Vector2(Random.Range(-0.2f, 0.201f), 0);
                rigidbody.AddForce(randomDirection);
			}
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

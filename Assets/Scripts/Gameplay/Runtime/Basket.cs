using Gameplay;
using SaveSystem;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    [System.Serializable]
    public class Basket : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public string Label;
        [Tooltip("Points in days")]
        public int Points;
        public int Priority;
        public BasketType BasketType;
        public BasketTypeIntensity BasketTypeIntensity;
        public bool IsEndBasket;
        public bool isInstaLossBasket;
        public BasketData Data;
        public AudioClip[] audioClips;
        public AudioSource audioSource;
        public ParticleSystem particles;
        
        public Basket(string _label, int _points, BasketType _basketType, bool _isEndBasket)
        {
            Label = _label;
            Points = _points;
            BasketType = _basketType;
            IsEndBasket = _isEndBasket;
        }
        private void Start()
        {
            UpdateLabel(Label);
			if (isInstaLossBasket)
			{
                UpdateLabel(UIManager.Instance.instaLossLabel);
			}
            UpdatePoints(Points);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (GameManager.Instance.isGamePaused) return;
            if(collision.gameObject.layer == (int)CollisionLayers.Ball)
            {
                PlayRandomClip();
                PlayParticles();
                GameManager.Instance.onBallEnteredBasket?.Invoke(this);
            }
        }

        public void UpdateLabel(string label)
        {
            Label = label;
        }

        public void UpdatePoints(int points)
        {
            Points = points;
        }

        public void UpdateSprite(Sprite sprite)
        {
            SpriteRenderer.sprite = sprite;
        }

        public BasketData ToBasketData()
        {
            var _basketData = new BasketData(Label, Points, BasketType, BasketTypeIntensity, IsEndBasket, transform.position);
            return _basketData;
        }

        public void ApplyBasketData(BasketData data)
        {
            Label = data.Label;
            Points = data.Points;
            BasketType = data.BasketType;
            BasketTypeIntensity = data.BasketTypeIntensity;
            IsEndBasket = data.IsEndBasket;
            transform.position = data.Position;
        }
        private void PlayParticles()
		{
            particles.Play();
		}
        private void PlayRandomClip()
		{
            PlayRandomSound(audioClips);
		}

        private void PlayRandomSound(AudioClip[] clips)
        {
            var randomClipIndex = Random.Range(0, clips.Length);
            var randomClip = clips[randomClipIndex];
            audioSource.PlayOneShot(randomClip);
        }
    }
}
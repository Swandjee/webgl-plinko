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
        public TextMeshProUGUI DisplayLabel;
        public TextMeshProUGUI DisplayPoints;
        public SpriteRenderer SpriteRenderer;
        public string Label;
        [Tooltip("Points in days")]
        public int Points;
        public int Priority;
        public BasketType BasketType;
        public BasketTypeIntensity BasketTypeIntensity;
        public bool IsEndBasket;
        public bool isPermaBasket;
        public BasketData Data;
        
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
            UpdatePoints(Points);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.layer == (int)CollisionLayers.Ball)
            {
                GameManager.Instance.onBallEnteredBasket?.Invoke(this);
            }
        }

        private string GetPointsWithOperator(int points)
        {
            switch (BasketType)
            {
                case BasketType.Increase:
                    return $"+{points}";
                case BasketType.Decrease:
                    return $"-{points}";
                default:
                    break;
            }
            return $"";
        }

        public void UpdateLabel(string label)
        {
            DisplayLabel.text = label;
            Label = label;
        }

        public void UpdatePoints(int points)
        {
            DisplayPoints.text = GetPointsWithOperator(points);
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
    }
}
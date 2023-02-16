using Gameplay;
using UnityEngine;

namespace SaveSystem
{
    public class BasketData
    {
        public BasketData(string label, int points, BasketType basketType, BasketTypeIntensity basketTypeIntensity, bool isEndBasket, Vector2 position)
        {
            Label = label;
            Points = points;
            BasketType = basketType;
            BasketTypeIntensity = basketTypeIntensity;
            IsEndBasket = isEndBasket;
            Position = position;
        }
        public string Label;
        public int Points;
        public BasketType BasketType;
        public BasketTypeIntensity BasketTypeIntensity;
        public bool IsEndBasket;
        public Vector2 Position;
    }

}

using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public enum CollisionLayers
    {
        Ball = 10,
    }
    public enum BasketType
    {
        Increase,
        Decrease
    }

    public enum BasketTypeIntensity
    {
        Low,
        Mid,
        High,
        Highest
    }
    [System.Serializable]
    public class BasketEvent: UnityEvent<Basket> { }
    public class GameManager : MonoBehaviour
    {
        public BasketEvent onBallEnteredBasket;
        public UnityEvent onGameEnd;

        private int _currentScore;

        [Header("Resources")]
        public Ball ball;
        public Transform[] ballOriginPoint;
        public Sprite BasketNormalSprite;
        public Sprite BasketEndSprite;
        private void Start()
        {
            if(FindObjectsOfType<GameManager>().Length > 1)
            {
                Debug.LogWarning("Found more than one GameManager, destroying.");
                DestroyImmediate(this);
            }
            var randomPoint = Random.Range(0, ballOriginPoint.Length);
            ball.transform.position = ballOriginPoint[randomPoint].position;
            ball.GetRandomPointAroundBall();
        }

        public void EvaluateBasket(Basket basket)
        {
            _currentScore += basket.BasketType == BasketType.Increase ? basket.Points : -basket.Points;
            if (basket.IsEndBasket)
            {
                EndGame();
            }
        }

        public void StartGame()
        {

        }

        public void EndGame()
        {
            onGameEnd.Invoke();
        }

        public int GetScore()
        {
            return _currentScore;
        }

        private GameManager _instance
        {
            get
            {
                return this;
            }
        }
        public static GameManager Instance { 
            get{
                var manager = FindObjectOfType<GameManager>();
                return manager._instance;
            } 
        }
        
    }
}

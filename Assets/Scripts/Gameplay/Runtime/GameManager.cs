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
        public UnityEvent onGameStarted;
        public UnityEvent onGameEnded;

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
        }

        public void EvaluateBasket(Basket basket)
        {
            _currentScore += basket.BasketType == BasketType.Increase ? basket.Points : -basket.Points;
            if (basket.IsEndBasket)
            {
                EndGame();
            }
        }

        public void SetupBall()
        {
            var randomPoint = Random.Range(0, ballOriginPoint.Length);
            ball.transform.position = ballOriginPoint[randomPoint].position;
            ball.GetRandomPointAroundBall();
            ball.rigidbody.simulated = true;
        }

        public void StartGame()
        {
            onGameStarted.Invoke();
        }

        public void EndGame()
        {
            onGameEnded.Invoke();
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

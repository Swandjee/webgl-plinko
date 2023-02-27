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
		public static GameManager Instance
		{
			get;
			private set;
		}
		public BasketEvent onBallEnteredBasket;
        public UnityEvent onGameStarted;
        public UnityEvent onGameEnded;
        public bool isGamePaused { get; private set; } = true;

        private int _currentScore;

        [Header("Resources")]
        public Ball ball;
        public Transform[] ballOriginPoint;
        public Sprite BasketNormalSprite;
        public Sprite BasketEndSprite;
        public bool permaBasketHit { get; private set; }
		private void Awake()
		{
			if(Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
		}

		public void EvaluateBasket(Basket basket)
        {
            _currentScore += basket.BasketType == BasketType.Increase ? basket.Points : -basket.Points;
            if(basket.isPermaBasket)
            {
                permaBasketHit = true;
            }
            if (basket.IsEndBasket || basket.isPermaBasket)
            {
                SoundManager.Instance.PlayRandomEndSound();
                EndGame();
                return;
            }
            SoundManager.Instance.PlayRandomBasketSound();
        }

        public void SetupBall()
        {
            ball.trail.enabled = false;
            var randomPoint = Random.Range(0, ballOriginPoint.Length);
            ball.transform.position = ballOriginPoint[randomPoint].position;
			ball.transform.position = ball.GetRandomPointAroundBall();
            ball.rigidbody.simulated = true;
            ball.trail.enabled = true;
        }

        public void StartGame()
        {
            _currentScore = 0;
            permaBasketHit = false;
            isGamePaused = false;
            onGameStarted.Invoke();
        }

        public void EndGame()
        {
            onGameEnded.Invoke();
            isGamePaused= true;
        }

        public int GetScore()
        {
            return _currentScore;
        }
    }
}

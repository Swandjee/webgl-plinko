using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance
        {
            get;
            private set;
        }
        [Header("Labels")]
        public string instaLossLabel = "NO POINTS";
        public string pointsName = "Points";
        [Header("Start Screen")]
        public RectTransform startScreen;
        [Header("End Screen")]
        public RectTransform endScreen;
        public TextMeshProUGUI scoreLabel;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }
        public void ShowStartScreen()
        {
            startScreen.gameObject.SetActive(true);
        }

        public void HideStartScreen()
        {
            startScreen.gameObject.SetActive(false);
        }

        public void ShowEndScreen()
        {
            endScreen.gameObject.SetActive(true);
        }

        public void HideEndScreen()
        {
            endScreen.gameObject.SetActive(false);
        }
        public void GoToMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void SetEndScreenScore()
        {
            if (GameManager.Instance.permaBasketHit)
            {
				scoreLabel.text = $"{instaLossLabel}";
                return;
			}
            scoreLabel.text = $"{GameManager.Instance.GetScore()} {pointsName}";
        }
    }
}
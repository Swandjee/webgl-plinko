using System.Collections;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class UIManager : MonoBehaviour
    {
        [Header("Start Screen")]
        public RectTransform startScreen;
        [Header("End Screen")]
        public RectTransform endScreen;
        public TextMeshProUGUI scoreLabel;

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

        public void SetEndScreenScore()
        {
            scoreLabel.text = GameManager.Instance.GetScore().ToString();
        }
    }
}
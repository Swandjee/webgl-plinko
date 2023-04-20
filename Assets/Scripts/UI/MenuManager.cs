using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
	public class MenuManager : MonoBehaviour
	{
		public GameObject tables;
		public GameObject mainBtn;
		public void GoToMainGame()
		{
			SceneManager.LoadScene(1);
		}

		public void GoToSecondTable()
		{
			SceneManager.LoadScene(2);
		}

		public void GoToThirdTable()
		{
			SceneManager.LoadScene(3);
		}

		public void GoToMenu()
		{
			SceneManager.LoadScene(0);
		}

		public void ShowTableSelect()
		{
			tables.gameObject.SetActive(true);
			mainBtn.SetActive(false);
		}

        private void OnDestroy()
        {
            if(tables != null)
			{
				tables.gameObject.SetActive(false);
				mainBtn.gameObject.SetActive(true);
			}
        }
    }
}

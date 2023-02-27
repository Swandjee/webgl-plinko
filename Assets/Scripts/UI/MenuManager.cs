using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
	public class MenuManager : MonoBehaviour
	{
		public void GoToMainGame()
		{
			SceneManager.LoadScene(1);
		}
	}
}

using UnityEngine;
namespace Gameplay
{

    public class BallOriginSubscriber : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Instance.AddToOrigins(this.transform);
        }
	}
}

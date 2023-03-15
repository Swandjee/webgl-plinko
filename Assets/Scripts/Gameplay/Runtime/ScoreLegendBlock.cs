using TMPro;
using UnityEngine;

namespace Gameplay
{
	public class ScoreLegendBlock : MonoBehaviour
	{
		public string PointsValue;
		public TextMeshProUGUI label;
		public bool isInstaLoss;

		private void Start()
		{
			var pointsName = UIManager.Instance.pointsName;
			label.text = isInstaLoss? UIManager.Instance.instaLossLabel : $"{PointsValue} {pointsName}";
		}
	}
}

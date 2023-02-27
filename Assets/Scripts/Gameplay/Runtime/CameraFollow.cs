using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gameplay
{
	public class CameraFollow : MonoBehaviour
	{
		public Transform Target;
		[Range(0,1)]
		public float SmoothSpeed = 0.125f;
		public Transform topBound;
		public Transform bottomBound;
		public Vector2 Offset;
		void FixedUpdate()
		{
			Vector2 targetedPosition = (Vector2)Target.position + Offset;
			Vector2 smoothedPosition = Vector2.Lerp(transform.position, targetedPosition, SmoothSpeed);
			transform.position = new Vector3(transform.position.x, Mathf.Clamp(smoothedPosition.y, bottomBound.position.y, topBound.position.y), -10);
		}
	}

}

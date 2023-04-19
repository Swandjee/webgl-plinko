using UnityEngine;

namespace Gameplay
{
    public enum MovingBlockDirection
	{
        Vertical,
        Horizontal
	}
	public class MovingBlock: MonoBehaviour
	{
        public MovingBlockDirection movingBlockDirection;
        public float movingDistance = 2f;
        public float movingSpeed = 1f;
		private Vector3 _startingPosition;
		[Header("Rotation")]
		public bool isRotating;
		public bool rotateClockwise = true;
		public float rotationSpeed = 0.5f;
		private Vector3 rotationDirection = new Vector3(0, 0, 1);

		private void Start()
		{
			_startingPosition = transform.position;
		}
		void Update()
        {
			if (isRotating)
			{
				Rotates();
			}
			Moves();
		}

		private void Moves()
		{
			float x = Mathf.Cos(Time.time * movingSpeed) * movingDistance;
			transform.position = _startingPosition + (movingBlockDirection == MovingBlockDirection.Vertical ? new Vector3(0, x, 0.0f) : new Vector3(x, 0, 0));
		}

		private void Rotates()
		{
			transform.Rotate((rotateClockwise ? -rotationDirection : rotationDirection) * rotationSpeed * Time.deltaTime);
		}
	}
}

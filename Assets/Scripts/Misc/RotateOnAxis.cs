using UnityEngine;

public class RotateOnAxis : MonoBehaviour
{
	[SerializeField] private Vector3 _rotationAxis = Vector3.zero;

	[SerializeField] private float _speed = 0f;


	private void Update()
	{
		float r = transform.rotation.eulerAngles.y + _speed * Time.deltaTime;
		transform.rotation = Quaternion.AngleAxis(r, _rotationAxis);
	}
}

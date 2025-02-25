using UnityEngine;

public class PickableObject : MonoBehaviour, IOnNotify
{
	private Rigidbody _rigidbody = null;
	private BoxCollider _collider = null;


	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_collider = GetComponent<BoxCollider>();
	}



	[SerializeField, ReadOnly] private bool isGrabbed = false;
	public void OnNotify()
	{
		isGrabbed = !isGrabbed;
		_rigidbody.isKinematic = isGrabbed;
		_collider.enabled = !isGrabbed;
	}
}

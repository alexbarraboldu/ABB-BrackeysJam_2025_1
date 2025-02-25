using UnityEngine;

public class PickableObject : MonoBehaviour, IOnNotify
{
	private Rigidbody _rigidbody = null;
	private BoxCollider _collider = null;

	[SerializeField] private LayerMask _machineLayer;


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

		//if (!isGrabbed)
		//{
		//	Ray ray = new Ray(transform.position, Vector3.down);

		//	if (Physics.SphereCast(ray, 1f, out RaycastHit hitInfo, 1f, _machineLayer))
		//	{
		//		transform.position = hitInfo.collider.transform.position + (Vector3.up * _collider.size.y / 2);
		//		transform.rotation = Quaternion.identity;
		//		_rigidbody.isKinematic = true;
		//	}
		//}
	}
}

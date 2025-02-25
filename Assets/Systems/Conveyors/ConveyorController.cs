using System.Collections.Generic;

using UnityEngine;

public class ConveyorController : MonoBehaviour
{
	private HashSet<Rigidbody> _objectsOnConveyor = new();

	[SerializeField] private float _force = 2f;
	[SerializeField] private float _maxV = 2f;


	private void FixedUpdate()
	{
		foreach (Rigidbody rigidbody in _objectsOnConveyor)
		{
			rigidbody.AddForce(transform.forward * _force, ForceMode.Force);

			Vector3 cV = rigidbody.velocity;
			rigidbody.velocity = new Vector3(Mathf.Clamp(cV.x, -_maxV, _maxV),/* Mathf.Clamp(cV.y, -_maxV, _maxV)*/rigidbody.velocity.y, Mathf.Clamp(cV.z, -_maxV, _maxV));
		}
	}

	private void OnTriggerStay(Collider other)
	{
		ApplyForce(other.gameObject);
		other.gameObject.layer = 0;
	}

	private void OnTriggerExit(Collider other)
	{
		RemoveForce(other.gameObject);
		other.gameObject.layer = LayerMask.NameToLayer("Object");
	}


	private void ApplyForce(GameObject collision)
	{
		if (collision.TryGetComponent(out Rigidbody component))
		{
			_objectsOnConveyor.Add(component);
		}
	}

	private void RemoveForce(GameObject collision)
	{
		if (collision.TryGetComponent(out Rigidbody component))
		{
			_objectsOnConveyor.Remove(component);
		}
	}
}

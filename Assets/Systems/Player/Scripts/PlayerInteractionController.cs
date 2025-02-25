using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Events;

using Utils;

public class PlayerInteractionController : MonoBehaviour
{
	[SerializeField] private LayerMask _objectMask = 0;
	[SerializeField] private LayerMask _interactableMask = 0;

	private GrabObject _grabObject;


	private void Awake()
	{
		_grabObject = GetComponentInChildren<GrabObject>();
	}

	private void Update()
	{
		Vector3 topFront = transform.position + Vector3.up + (transform.forward * 0.5f);
		Vector3 bottomFront = transform.position + (transform.forward * 0.5f);
		Vector3 midCenter = transform.position + (Vector3.up * 0.5f);

		if (Input.GetButtonDown("Jump"))
		{
			if (_grabObject.IsGrabbing) _grabObject.Grab(null);
			else Interact(topFront, bottomFront);
		}
	}


	private void Interact(Vector3 topFront, Vector3 bottomFront)
	{
		Collider[] colliders = Physics.OverlapCapsule(topFront, bottomFront, 1f, _interactableMask | _objectMask);
		if (colliders.LongLength > 0)
		{
			GameObject iGO = colliders.SelectFirstOrDefaultByLayers(new() { _objectMask, _interactableMask });
			if (iGO == null) return;

			iGO.TryGetComponent(out IOnNotify onNotify);

			if ((1 << iGO.layer) == _objectMask) _grabObject.Grab(iGO);
			else onNotify?.OnNotify();
		}
	}
}

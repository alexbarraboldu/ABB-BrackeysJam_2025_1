using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
	private Transform _grabTransform = null;

	public bool HasObject => _grabTransform != null;


	[SerializeField] private Transform _grabPoint = null;
	private float _objectSizeZ = 0;

	[Header("Animator")]
	[SerializeField] private Animator _animator = null;

	[Header("Effect Sounds")]
	[SerializeField] private List<AudioClip> _audioClips = new();


	private void Update()
	{
		if (HasObject)
		{
			_grabTransform.position = _grabPoint.position + (_grabTransform.forward * _objectSizeZ);
			_grabTransform.rotation = _grabPoint.rotation;
		}
	}


	public void SetGrabObject(Transform transform)
	{
		int isGrabing = transform != null ? 1 : 0;

		if (isGrabing == 0) _grabTransform.GetComponent<IOnNotify>().OnNotify();
		else
		{
			BoxCollider collider = transform.GetComponent<BoxCollider>();
 			_objectSizeZ = collider.size.z / 2f;
		}

		_grabTransform = transform;

		SoundEffectManager.Instance.PlaySoundClip(_audioClips[isGrabing], _grabPoint, 1f);

		_animator.SetLayerWeight(1, isGrabing);

	}
}

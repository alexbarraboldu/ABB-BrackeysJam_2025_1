using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
	private Transform _grabTransform = null;
	private IOnNotify _onNotify = null;

	public bool IsGrabbing => _grabTransform != null;


	[SerializeField] private Transform _grabPoint;

	[Header("Animator")]
	[SerializeField] private Animator _animator;

	[Header("Effect Sounds")]
	[SerializeField] private List<AudioClip> _audioClips = new();


	private void Update()
	{
		if (_onNotify != null)
		{
			_grabTransform.position = _grabPoint.position + (_grabTransform.forward * 0.5f);
			_grabTransform.rotation = _grabPoint.rotation;
		}
	}


	public void Grab(GameObject gObject)
	{
		if (_onNotify == null)
		{
			if (gObject.TryGetComponent(out IOnNotify component))
			{
				SetIsGrabing(component, gObject.transform);
			}
		}
		else
		{
			SetIsGrabing(null, null);
		}
	}

	private void SetIsGrabing(IOnNotify component, Transform transform)
	{
		bool isGrabing = component != null;

		if (isGrabing)
		{
			_onNotify = component;
			_onNotify.OnNotify();

			_grabTransform = transform;

			SoundEffectManager.Instance.PlaySoundClip(_audioClips[0], _grabPoint, 1f);
		}
		else
		{
			_onNotify.OnNotify();
			_onNotify = null;

			_grabTransform = null;

			SoundEffectManager.Instance.PlaySoundClip(_audioClips[1], _grabPoint, 1f);
		}

		_animator.SetLayerWeight(1, isGrabing ? 1f : 0f);
	}
}

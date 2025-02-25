using System.Collections;

using TMPro;

using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, IOnNotify
{
	private Animator _animator;

	[SerializeField] private AudioClip _buttonSound = null;

	public UnityAction IsPressed;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}


	private bool _isPressed = false;
	public void OnNotify()
	{
		if (!_isPressed)
		{
			_isPressed = true;
			IsPressed.Invoke();

			SoundEffectManager.Instance.PlaySoundClip(_buttonSound, transform, 1f);

			_animator.SetTrigger("Press");
			AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
			StartCoroutine(ResetPress(stateInfo.length));
		}
	}

	private IEnumerator ResetPress(float value)
	{
		yield return new WaitForSeconds(value);
		_isPressed = false;
	}
}

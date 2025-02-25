using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, IOnNotify
{
	private Animator _animator;

	public UnityAction IsPressed;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	public void OnNotify()
	{
		if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1f) return;

		IsPressed.Invoke();
		_animator.SetTrigger("Press");
	}
}

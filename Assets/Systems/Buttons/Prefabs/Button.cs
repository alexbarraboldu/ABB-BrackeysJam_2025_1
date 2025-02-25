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
		IsPressed.Invoke();
		_animator.SetTrigger("Press");
	}
}

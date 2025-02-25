using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
	[SerializeField] private List<AudioClip> _stepClips = new();

	Animator _animator;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	public void Step(int value)
	{
		if (_animator.GetFloat("InputMagnitude") < 0.1f) return;
		
		int rClip = Random.Range(0, _stepClips.Count);
		SoundEffectManager.Instance.PlaySoundClip(_stepClips[rClip], transform, 1f);
	}
}

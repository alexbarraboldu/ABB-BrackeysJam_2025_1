using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : BaseSingleton<SoundEffectManager>
{
	[SerializeField] private AudioSource _audioSource;

	public void PlaySoundClip(AudioClip clip, Transform transform, float volume)
	{
		AudioSource audioSource = Instantiate(_audioSource, transform.position, Quaternion.identity);

		audioSource.clip = clip;

		audioSource.volume = volume;

		audioSource.pitch = Random.Range(0.9f, 1.1f);

		audioSource.Play();

		float clipLength = audioSource.clip.length;

		Destroy(audioSource.gameObject, clipLength);
	}
}

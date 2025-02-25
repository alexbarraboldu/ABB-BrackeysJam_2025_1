using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering.Universal;

using Utils;

public abstract class Machine : MonoBehaviour
{
	protected Animator animator;

	protected Button button;

	///
	private DecalProjector decalProjector;
	[SerializeField] private List<Material> _materials;
	private int _currentMaterial = 0;

	protected Material CurrentMaterial => _materials[_currentMaterial];
	protected int MaterialIndex => _currentMaterial;


	protected void Awake()
	{
		animator = GetComponent<Animator>();
		button = GetComponentInChildren<Button>();
		decalProjector = GetComponentInChildren<DecalProjector>();

		button.IsPressed += OnButtonPressed;
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareLayer("Object"))
		{
			bool isKin = collision.gameObject.GetComponent<Rigidbody>().isKinematic;

			if (isKin)
			{
				PlayUseAnimation();
				OnMachineUse(collision.gameObject);
			}
		}
	}


	protected void OnButtonPressed()
	{
		_currentMaterial = ++_currentMaterial == _materials.Count ? 0 : _currentMaterial++;
		decalProjector.material = _materials[_currentMaterial];
	}

	protected virtual void PlayUseAnimation()
	{
		animator.SetTrigger("Use");
	}

	protected abstract void OnMachineUse(GameObject gameObject);
}

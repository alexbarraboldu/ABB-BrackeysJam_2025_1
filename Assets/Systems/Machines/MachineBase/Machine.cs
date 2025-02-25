using System.Collections.Generic;
using System.Collections;

using UnityEngine;
using UnityEngine.Rendering.Universal;

using Utils;

public abstract class Machine : MonoBehaviour
{
	[SerializeField] protected Transform objectPlacement;

	protected Animator animator;
	protected Button button;

	///
	private DecalProjector decalProjector;
	[SerializeField] private List<Material> _materials = new();
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

	private bool _canUseMachine = false;
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareLayer("Player"))
		{
			_canUseMachine = true;
		}

		if (collider.gameObject.CompareLayer("Object") && _canUseMachine)
		{
			if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
			{
				collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				collider.transform.position = objectPlacement.position;
				collider.transform.rotation = Quaternion.identity;

				PlayUseAnimation();
				OnMachineUse(collider.gameObject);

				StartCoroutine(OnAnimationEnd(animator.GetCurrentAnimatorStateInfo(0).length, collider.gameObject, collider.gameObject.layer));
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (GetComponent<Collider>().gameObject.CompareLayer("Player"))
		{
			_canUseMachine = false;
		}
	}


	private IEnumerator OnAnimationEnd(float length, GameObject gameObject, LayerMask layerMask)
	{
		gameObject.layer = 0;
		yield return new WaitForSeconds(length);
		gameObject.layer = layerMask;
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

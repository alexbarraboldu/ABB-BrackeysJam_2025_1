using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
	private Animator _animator;

	private CharacterController _characterController;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_characterController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		///	INPUT HANDLING
		float forwardInput = Input.GetAxis("Vertical");
		float horizontalInput = Input.GetAxis("Horizontal");

		Vector3 lookingDirection = new Vector3(horizontalInput, 0, forwardInput);
		float inputMagnitude = Mathf.Clamp01(lookingDirection.magnitude);

		///	ANIMATION
		_animator.SetFloat("InputMagnitude", inputMagnitude, 0.05f, Time.deltaTime);

		///	ROTAIION
		if (inputMagnitude > 0) transform.rotation = Quaternion.LookRotation(lookingDirection, Vector3.up);
	}

	private void OnAnimatorMove()
	{
		Vector3 velocity = _animator.deltaPosition;
		velocity.y = -9.8f * Time.deltaTime;

		_characterController.Move(velocity);
	}
}

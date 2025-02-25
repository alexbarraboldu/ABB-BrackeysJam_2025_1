using UnityEngine;
using UnityEngine.Events;

public class CollisionChecker : MonoBehaviour
{
	public UnityAction<Collision> onCollisionStay;
	public UnityAction<Collision> onCollisionEnter;
	public UnityAction<Collision> onCollisionExit;


	private void OnCollisionStay(Collision collision)
	{
		onCollisionStay?.Invoke(collision);
	}

	private void OnCollisionEnter(Collision collision)
	{
		onCollisionEnter?.Invoke(collision);
	}

	private void OnCollisionExit(Collision collision)
	{
		onCollisionExit?.Invoke(collision);
	}
}

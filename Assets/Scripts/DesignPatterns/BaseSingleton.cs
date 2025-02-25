using UnityEngine;

public abstract class BaseSingleton<T> : MonoBehaviour where T : Component
{
	private static T _instance;

	[SerializeField] private bool _isDestroyable = true;

	private static bool _isOnDestroy = false;

	protected bool Destroyable
	{
		get => _isDestroyable;
		set { _isDestroyable = value; }
	}


	public static T Instance
	{
		get
		{
			if (_instance == null && !_isOnDestroy)
			{
				_instance = FindObjectOfType<T>();

				if (_instance == null)
				{
					GameObject obj = new()
					{
						name = typeof(T).Name
					};
					_instance = obj.AddComponent<T>();
				}
			}

			return _instance;
		}
	}

	public static T Exist
	{
		get => _instance;
	}

	public virtual void Awake()
	{
		if (_instance == null)
		{
			_instance = this as T;

			if (!_isDestroyable) DontDestroyOnLoad(gameObject);
		}
		else
		{
			Debug.LogAssertion("Detroyed: " + gameObject.name);
			Destroy(gameObject);
		}
	}

	public virtual void OnDestroy()
	{
		_isOnDestroy = true;
	}
}

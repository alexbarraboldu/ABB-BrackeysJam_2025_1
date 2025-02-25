using UnityEngine;


public static class CursorOptions
{
	[SerializeField, ReadOnly] private static bool _isVisible = true;
	[SerializeField, ReadOnly] private static CursorLockMode _currentLockMode = CursorLockMode.None;

	public static void NextCursorOption()
	{
		_isVisible = !_isVisible;

		_currentLockMode = _isVisible ? CursorLockMode.None : CursorLockMode.Locked;

		Cursor.lockState = _currentLockMode;
		Cursor.visible = _isVisible;
	}

	internal static void SetCursorOption(bool isVisible)
	{
		_isVisible = !isVisible;
		NextCursorOption();
	}
}

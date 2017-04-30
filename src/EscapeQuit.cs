using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeQuit : MonoBehaviour
{
	public string lastSceneName;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (string.IsNullOrEmpty(this.lastSceneName))
			{
				Application.Quit();
			}
			else
			{
				SceneManager.LoadScene(this.lastSceneName);
			}
		}
	}
}

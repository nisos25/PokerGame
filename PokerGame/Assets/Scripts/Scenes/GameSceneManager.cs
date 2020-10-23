using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
	public void ChangeScene(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}

	public void ExitGame()
	{
		PlayerPrefs.SetInt("Score", 0);
		Application.Quit();
	}
}

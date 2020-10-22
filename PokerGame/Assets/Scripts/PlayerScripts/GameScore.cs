using System;
using UnityEngine;

public class GameScore : MonoBehaviour
{
	public int CurrentGameScore { get; private set; }

	private void Awake()
	{
		CurrentGameScore = PlayerPrefs.GetInt("Score");
	}

	public void UpdateScore(int scoreValue)
	{
		CurrentGameScore += scoreValue;
	}

	public void SaveScore()
	{
		PlayerPrefs.SetInt("Score", CurrentGameScore);
	}

	private void OnApplicationQuit()
	{
		//PlayerPrefs.SetInt("Score", 0);
	}
}

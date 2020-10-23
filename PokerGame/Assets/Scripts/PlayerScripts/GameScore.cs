using System;
using UnityEngine;

public class GameScore : MonoBehaviour
{
	public int CurrentGameScore { get; private set; }
	public string hand { get; private set; }
	
	private void Awake()
	{
		CurrentGameScore = PlayerPrefs.GetInt("Score");
	}

	public void UpdateScore(int scoreValue)
	{
		CurrentGameScore += scoreValue;
	}

	public void UpdateHand(string playerHand)
	{
		if (String.Compare(playerHand, "0", StringComparison.Ordinal) != 0)
		{
			hand = playerHand;	
			return;
		}
		
		hand = "No hand available";
	}
	
	public void SaveScore()
	{
		PlayerPrefs.SetInt("Score", CurrentGameScore);
	}

	private void OnApplicationQuit()
	{
		PlayerPrefs.SetInt("Score", 0);
	}
}

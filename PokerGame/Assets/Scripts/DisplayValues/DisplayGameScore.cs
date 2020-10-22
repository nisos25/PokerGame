using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayGameScore : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private GameScore gameScore;

	private void Start()
	{
		UpdateUI();
	}

	public void UpdateUI()
	{
		scoreText.text = "Score: " + gameScore.CurrentGameScore;
	}
}

using TMPro;
using UnityEngine;

public class DisplayGameScore : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private TextMeshProUGUI handText;
	
	[SerializeField] private GameScore gameScore;

	private void Start()
	{
		UpdateUI();
	}

	public void UpdateUI()
	{
		scoreText.text = "Score: " + gameScore.CurrentGameScore;
		handText.text = gameScore.hand;
	}
}

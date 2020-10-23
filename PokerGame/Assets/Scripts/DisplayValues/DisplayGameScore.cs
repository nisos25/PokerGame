using TMPro;
using UnityEngine;

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

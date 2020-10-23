using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
	[SerializeField] private PlayerController playerController;
	[SerializeField] private GameScore gameScore;
	[SerializeField] private GameEvent scoreChanged;
	public List<CardInfo> PlayerCards { get; set; } = new List<CardInfo>();
	public List<CardInfo> ExchangeCards { get; set; } = new List<CardInfo>();

	private void Awake()
	{
		playerController.CurrentDeck = PlayerCards;
	}

	public void StartGame()
	{
		PokerHands pokerHands = new PokerHands();

		PokerHand pokerHand = pokerHands.EvaluatePokerHand(PlayerCards); 
		
		gameScore.UpdateScore((int)pokerHand);
		gameScore.UpdateHand(pokerHand.ToString());

		scoreChanged.Raise();
	}

}
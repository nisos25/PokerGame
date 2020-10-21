using System.Collections.Generic;
using UnityEngine;

public class PokerHands : MonoBehaviour
{
	[SerializeField] private PlayerController playerController;

	public void CallQuick()
	{
		//OrderBySuit(playerController.CurrentDeck, 0, playerController.CurrentDeck.Count - 1);
		OrderByValue(playerController.CurrentDeck, 0, playerController.CurrentDeck.Count - 1);
	}

	private bool IsOnePair(List<CardInfo> hand)
	{
		OrderByValue(hand, 0, hand.Count - 1);

		bool h1 = hand[0].CardValue == hand[1].CardValue;
		bool h2 = hand[1].CardValue == hand[2].CardValue;
		bool h3 = hand[2].CardValue == hand[3].CardValue;
		bool h4 = hand[3].CardValue == hand[4].CardValue;


		return h1 || h2 || h3 || h4;
	}

	private bool IsTwoPair(List<CardInfo> hand)
	{


		return true;
	}

	public void OrderBySuit(List<CardInfo> cardInfo, int low, int high)
	{
		if (low < high)
		{
			int pi = PartitionSuit(cardInfo, low, high);

			OrderBySuit(cardInfo, low, pi - 1);
			OrderBySuit(cardInfo, pi + 1, high);
		}
	}

	private int PartitionSuit(List<CardInfo> cardInfo, int low, int high)
	{
		int pivot = (int) cardInfo[high].CardSuit;

		int i = (low - 1);
		for (int j = low; j < high; j++)
		{
			if ((int) cardInfo[j].CardSuit < pivot)
			{
				i++;

				CardInfo temp = cardInfo[i];
				cardInfo[i] = cardInfo[j];
				cardInfo[j] = temp;
			}
		}

		CardInfo temp1 = cardInfo[i + 1];
		cardInfo[i + 1] = cardInfo[high];
		cardInfo[high] = temp1;

		return i + 1;
	}

	public void OrderByValue(List<CardInfo> cardInfo, int low, int high)
	{
		if (low < high)
		{
			int pi = PartitionValue(cardInfo, low, high);

			OrderByValue(cardInfo, low, pi - 1);
			OrderByValue(cardInfo, pi + 1, high);
		}
	}

	private int PartitionValue(List<CardInfo> cardInfo, int low, int high)
	{
		int pivot = (int) cardInfo[high].CardValue;

		int i = (low - 1);
		for (int j = low; j < high; j++)
		{
			if ((int) cardInfo[j].CardValue < pivot)
			{
				i++;

				CardInfo temp = cardInfo[i];
				cardInfo[i] = cardInfo[j];
				cardInfo[j] = temp;
			}
		}

		CardInfo temp1 = cardInfo[i + 1];
		cardInfo[i + 1] = cardInfo[high];
		cardInfo[high] = temp1;

		return i + 1;
	}
}
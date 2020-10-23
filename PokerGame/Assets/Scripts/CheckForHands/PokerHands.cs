using System.Collections.Generic;

public enum PokerHand
{
	Pair = 1,
	TwoPair = 3,
	ThreeOfAKind = 5,
	Straight = 10,
	Flush = 13,
	FullHouse = 15,
	FourOfAKind = 20,
	StraightFlush = 50,
	RoyalFlush = 100
}

public class PokerHands
{
	private bool IsOnePair(List<CardInfo> hand)
	{
		OrderByValue(hand);

		bool h1 = hand[0].CardValue == hand[1].CardValue;
		bool h2 = hand[1].CardValue == hand[2].CardValue;
		bool h3 = hand[2].CardValue == hand[3].CardValue;
		bool h4 = hand[3].CardValue == hand[4].CardValue;


		return h1 || h2 || h3 || h4;
	}

	private bool IsTwoPair(List<CardInfo> hand)
	{
		OrderByValue(hand);

		bool h1 = hand[0].CardValue == hand[1].CardValue && hand[2].CardValue == hand[3].CardValue;
		bool h2 = hand[0].CardValue == hand[1].CardValue && hand[3].CardValue == hand[4].CardValue;
		bool h3 = hand[1].CardValue == hand[2].CardValue && hand[3].CardValue == hand[4].CardValue;

		return h1 || h2 || h3;
	}

	private bool IsThreeOfAKind(List<CardInfo> hand)
	{
		OrderByValue(hand);

		if (IsFourOfAKind(hand) || IsFullHouse(hand))
		{
			return false;
		}

		bool h1 = hand[0].CardValue == hand[2].CardValue;

		bool h2 = hand[1].CardValue == hand[3].CardValue;

		bool h3 = hand[2].CardValue == hand[4].CardValue;


		return h1 || h2 || h3;
	}

	private bool IsStraight(List<CardInfo> hand)
	{
		OrderByValue(hand);

		bool h1 = hand[0].CardValue == hand[1].CardValue - 1 &&
		          hand[1].CardValue == hand[2].CardValue - 1 &&
		          hand[2].CardValue == hand[3].CardValue - 1;

		bool h2 = hand[3].CardValue == hand[4].CardValue - 1 ||
		          hand[4].CardValue == Value.Ace && hand[0].CardValue == Value.Two;

		return h1 && h2;
	}

	private bool IsFourOfAKind(List<CardInfo> hand)
	{
		OrderByValue(hand);

		bool h1 = hand[0].CardValue == hand[3].CardValue && hand[3].CardValue != hand[4].CardValue;
		bool h2 = hand[1].CardValue == hand[4].CardValue && hand[0].CardValue != hand[1].CardValue;

		return h1 || h2;
	}

	private bool IsFlush(List<CardInfo> hand)
	{
		OrderBySuit(hand);

		return hand[0].CardSuit == hand[4].CardSuit;
	}

	private bool IsStraightFlush(List<CardInfo> hand)
	{
		return IsStraight(hand) && IsFlush(hand);
	}

	private bool IsRoyalFlush(List<CardInfo> hand)
	{
		OrderByValue(hand);
		return hand[0].CardValue == Value.Ten && IsStraightFlush(hand);
	}

	private bool IsFullHouse(List<CardInfo> hand)
	{
		OrderByValue(hand);

		bool h1 = hand[0].CardValue == hand[2].CardValue &&
		          hand[2].CardValue != hand[3].CardValue &&
		          hand[3].CardValue == hand[4].CardValue;

		bool h2 = hand[0].CardValue == hand[1].CardValue &&
		          hand[1].CardValue != hand[2].CardValue &&
		          hand[2].CardValue == hand[4].CardValue;

		return h1 || h2;
	}

	private void OrderBySuit(List<CardInfo> cardInfo)
	{
		OrderBySuit(cardInfo, 0, cardInfo.Count - 1);
	}

	private void OrderByValue(List<CardInfo> cardInfo)
	{
		OrderByValue(cardInfo, 0, cardInfo.Count - 1);
	}

	private void OrderBySuit(List<CardInfo> cardInfo, int low, int high)
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

	private void OrderByValue(List<CardInfo> cardInfo, int low, int high)
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

	public PokerHand EvaluatePokerHand(List<CardInfo> hand)
	{
		if (IsRoyalFlush(hand))
		{
			return PokerHand.RoyalFlush;
		}

		if (IsStraightFlush(hand))
		{
			return PokerHand.StraightFlush;
		}

		if (IsFourOfAKind(hand))
		{
			return PokerHand.FourOfAKind;
		}

		if (IsFullHouse(hand))
		{
			return PokerHand.FullHouse;
		}

		if (IsFlush(hand))
		{
			return PokerHand.Flush;
		}

		if (IsStraight(hand))
		{
			return PokerHand.Straight;
		}

		if (IsThreeOfAKind(hand))
		{
			return PokerHand.ThreeOfAKind;
		}

		if (IsTwoPair(hand))
		{
			return PokerHand.TwoPair;
		}

		if (IsOnePair(hand))
		{
			return PokerHand.Pair;
		}

		return 0;
	}
}
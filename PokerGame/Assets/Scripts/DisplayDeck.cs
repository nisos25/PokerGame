using System.Collections.Generic;
using UnityEngine;

public class DisplayDeck : MonoBehaviour
{
	[SerializeField] private List<Sprite> values;
	[SerializeField] private List<Sprite> suits;
	[SerializeField] private PlayerController playerController;
	
	private SetCardIcon[] cardsIcon;
	
    private void Start()
    {
	    cardsIcon = FindObjectsOfType<SetCardIcon>();
	    UpdateCardsIcons();
    }

    private void UpdateCardsIcons()
    {
	    for (int i = 0; i < cardsIcon.Length; i++)
	    {
		    CardInfo cardInfo = cardsIcon[i].GetComponent<CardInfo>();
		    
		    Sprite tempSuit = suits[(int) cardInfo.CardSuit];
		    Sprite tempValue = values[(int) cardInfo.CardValue - 2];
			    
			    
		    cardsIcon[i].SetCardImage(tempValue,tempSuit);
	    }
    }
}

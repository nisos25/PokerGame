using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayExchanges : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI exchangeText;
	[SerializeField] private PlayerController playerController;
	
	private void Start()
	{
		UpdateUI();
	}

	public void UpdateUI()
	{
		exchangeText.text = "Exchanges: " + playerController.NumberOfChanges;
	}
}

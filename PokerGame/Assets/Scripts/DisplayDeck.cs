using System;
using UnityEngine;

public class DisplayDeck : MonoBehaviour
{
    [SerializeField] private Sprite[] values;
    [SerializeField] private Sprite[] suits;
    
    [SerializeField] private SpriteRenderer value;
    [SerializeField] private SpriteRenderer suit;

    [SerializeField] private PlayerStates playerStates;

    
}

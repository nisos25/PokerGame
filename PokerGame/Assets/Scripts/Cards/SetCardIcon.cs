using UnityEngine;

public class SetCardIcon : MonoBehaviour
{
	[SerializeField] private SpriteRenderer value;
	[SerializeField] private SpriteRenderer suit;

	public void SetCardImage(Sprite spriteValue, Sprite spriteSuit)
	{
		value.sprite = spriteValue;
		suit.sprite = spriteSuit;
	}
}
using UnityEngine;

public class CardAnimator : MonoBehaviour
{
	private CardInfo parent;
	private Animator animator;
	
	private void Awake()
	{
		animator = GetComponent<Animator>();
		parent = GetComponentInParent<CardInfo>();
	}

	private void Update()
	{
		animator.SetBool("Selected", parent.Selected);
	}
}
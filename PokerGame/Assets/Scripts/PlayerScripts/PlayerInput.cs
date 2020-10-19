using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	private PlayerController playerController;
	private Camera camera1;

	private void Awake()
	{
		camera1 = Camera.main;
		playerController = GetComponent<PlayerController>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			Ray ray = camera1.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
		
			if (Physics.Raycast(ray, out raycastHit))
			{
				CardInfo card = raycastHit.transform.GetComponent<CardInfo>();

				if (card != null)
				{
					playerController.SelectCard(card);
				}
			}
		}
	}
}

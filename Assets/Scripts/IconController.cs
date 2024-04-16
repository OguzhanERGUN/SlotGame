using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{
	[SerializeField] private Vector2 MoveVector;
	// Update is called once per frame

	private void OnEnable()
	{
		FreezeIcon();
	}
	void Update()
    {
        if (transform.position.y <= -5) Destroy(gameObject);
		if (GameManager.instance.IsRoll) { MoveIcon(); }
    }


	private void FreezeIcon()
	{

	}

	private void MoveIcon()
	{
		transform.Translate(MoveVector * Time.deltaTime);
	}
}

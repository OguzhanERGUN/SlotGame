using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{
	[SerializeField] private Vector2 MoveVector;
	[SerializeField] private Animator animator;
	// Update is called once per frame

	private void Start()
	{
		GameManager.instance.PressedSpinButton += PlayIconStartAnim;
	}



	void Update()
	{
		if (transform.position.y <= -5) Destroy(gameObject);
		if (GameManager.instance.IsRoll) { MoveIcon(); }
	}




	private void MoveIcon()
	{
		transform.Translate(MoveVector * Time.deltaTime);
	}


	private void FreezeIcon()
	{
		GameManager.instance.ChangeIsRollingStatus(false);
	}

	public void UnFreezeIcon()
	{
		Debug.Log("unfreze olduk");
		animator.SetBool("FallingAnim", false);
		GameManager.instance.ChangeIsRollingStatus(true);
	}



	private void PlayIconStartAnim(object sender, System.EventArgs e)
	{
		PlayStartAnim();
	}


	private void PlayStartAnim()
	{
		animator.SetBool("FallingAnim", true);
	}




}

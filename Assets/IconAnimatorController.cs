using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconAnimatorController : MonoBehaviour
{
	private Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}
	public void UnFreezeIcon()
	{
		Debug.Log("unfreze olduk");
		animator.SetBool("FallingAnim", false);
		GameManager.instance.ChangeIsRollingStatus(true);
	}
}

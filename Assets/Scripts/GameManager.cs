using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Transform[] SlotWindowTransforms;
	[SerializeField] private List<SlotSO> SlotItemList;



	public event EventHandler PressedSpinButton;



	private void Awake()
	{
		if (PressedSpinButton == null) PressedSpinButton += SpawnRandomSlotItem;

	}

	private void SpawnRandomSlotItem(object sender, EventArgs e)
	{
		for (int i = 0; i < 15; i++)
		{
			int randomNumber = UnityEngine.Random.Range(0, 8);
			Debug.Log(randomNumber);
			Transform randomSlot = SlotItemList[randomNumber].Prefab;
			Instantiate(randomSlot, SlotWindowTransforms[i].position, Quaternion.identity, SlotWindowTransforms[i]);
		}
	}




	public void Spin()
	{
		PressedSpinButton?.Invoke(this, EventArgs.Empty);

	}
}

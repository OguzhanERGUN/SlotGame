using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private float Timer;
	[SerializeField] private float TimerBorder;
	public bool IsRoll;
	public Transform[] SlotWindowTransforms;
	[SerializeField] private List<SlotSO> SlotItemList;
	public static GameManager instance;


	public event EventHandler PressedSpinButton;



	private void Awake()
	{
		instance = this;
		if (PressedSpinButton == null) PressedSpinButton += SpawnRandomSlotItem;

	}

	private void Start()
	{
		IsRoll = false;
		StartRandomIcons();
	}

	private void Update()
	{
		if (!IsRoll) return;
		Timer += Time.deltaTime;
		if (Timer >= TimerBorder)
		{
			SpawnRandomSlotItem(this, EventArgs.Empty);
			Timer = 0f;
		}
	}

	private void SpawnRandomSlotItem(object sender, EventArgs e)
	{
		for (int i = 0; i < 5; i++)
		{
			int randomNumber = UnityEngine.Random.Range(0, 8);
			Debug.Log(randomNumber);
			Transform randomSlot = SlotItemList[randomNumber].Prefab;
			Instantiate(randomSlot, SlotWindowTransforms[i].position, Quaternion.identity, SlotWindowTransforms[i]);
		}
	}


	private void StartRandomIcons()
	{
		for (int i = 0; i < SlotWindowTransforms.Length; i++)
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public bool IsRoll { get { return _isRoll; } }
	[SerializeField] private bool _isRoll;


	private float _timer;
	[SerializeField] private float _timerBorder;
	

	public Transform[] SlotWindowTransforms;
	[SerializeField] private List<SlotSO> _slotItemList;



	public event EventHandler PressedSpinButton;


	public static GameManager instance;
	private void Awake()
	{
		instance = this;
		if (PressedSpinButton == null) PressedSpinButton += SpawnRandomSlotItem;

	}

	private void Start()
	{
		ChangeIsRollingStatus(false);
		StartRandomIcons();
	}

	private void Update()
	{
		Debug.Log(IsRoll);
		if (!IsRoll) return;
		_timer += Time.deltaTime;
		if (_timer >= _timerBorder)
		{
			SpawnRandomSlotItem(this, EventArgs.Empty);
			_timer = 0f;
		}
	}

	private void SpawnRandomSlotItem(object sender, EventArgs e)
	{
		for (int i = 0; i < 5; i++)
		{
			int randomNumber = UnityEngine.Random.Range(0, 8);
			Transform randomSlot = _slotItemList[randomNumber].Prefab;
			Instantiate(randomSlot, SlotWindowTransforms[i].position, Quaternion.identity, SlotWindowTransforms[i]);
		}
	}


	private void StartRandomIcons()
	{
		for (int i = 0; i < SlotWindowTransforms.Length; i++)
		{
			int randomNumber = UnityEngine.Random.Range(0, 8);
			Transform randomSlot = _slotItemList[randomNumber].Prefab;
			Instantiate(randomSlot, SlotWindowTransforms[i].position, Quaternion.identity, SlotWindowTransforms[i]);
		}
	}

	public void Spin()
	{
		PressedSpinButton?.Invoke(this, EventArgs.Empty);
	}


	public void ChangeIsRollingStatus(bool value)
	{
		_isRoll = value;
	}
}

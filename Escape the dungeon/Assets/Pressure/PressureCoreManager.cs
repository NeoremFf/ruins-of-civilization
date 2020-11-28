﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureCoreManager : MonoBehaviour
{
    [SerializeField]
    private DoorController door = null;

    [SerializeField]
    private PressureItemController[] pressureItems = null;
    private int currentPressedItem = 0;
    private int maxId = -1;

    private int prevId = -1;

    private bool isTruePressed = true;

    private void Start()
    {
        maxId = pressureItems.Length;
    }

    public bool PlayerPressed(int id = 0)
    {
        Debug.Log("Player Pressed");
        ++currentPressedItem;
        isTruePressed = id == prevId + 1;
        prevId = id;
        Debug.Log("isTruePressed = " + isTruePressed);
        if (currentPressedItem >= maxId)
        {
            if (isTruePressed)
                door.OpenDoor();
            else
                ResetPressStateOfAllPressureItems();
            return isTruePressed;
        }
        return isTruePressed;
    }

    private void ResetPressStateOfAllPressureItems()
    {
        prevId = -1;
        currentPressedItem = 0;
        foreach (var item in pressureItems)
        {
            item.ResetPressState();
        }
    }
}

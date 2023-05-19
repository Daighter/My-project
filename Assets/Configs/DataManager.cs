using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public UnityAction <int> OnShootChanged;

    [SerializeField] private int shootCount;

    public void AddShootCount(int count)
    {
        shootCount += count;

        OnShootChanged?.Invoke(shootCount);
    }
}

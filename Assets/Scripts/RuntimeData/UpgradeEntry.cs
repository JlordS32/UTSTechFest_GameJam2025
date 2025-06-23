using System;
using UnityEngine.Events;
using UnityEngine;

public class UpgradeEntry
{
    public string Name;
    public Func<string> GetRate;
    public UnityAction UpgradeLogic;
    public UpgradeUI UIRef;
}
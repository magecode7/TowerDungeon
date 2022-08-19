using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

public enum InputType
{
    None,
    Left,
    Right,
    Jump,
    Attack,
    Ability,
    Interact
}

public class InputEvent 
{
    public UnityEvent
        OnDown = new UnityEvent(),
        OnPress = new UnityEvent(),
        OnUp = new UnityEvent();
    public bool
        down,
        pressed,
        up;
}


public class PlayerInput
{
    static InputEvent[] events = new InputEvent[7];

    public static InputEvent GetEvent(InputType type)
    {
        if (events[(int)type] == null) events[(int)type] = new InputEvent();
        return events[(int)type];
    }

    public static bool GetDown(InputType type)
    {
        return GetEvent(type).down;
    }

    public static bool Get(InputType type)
    {
        return GetEvent(type).pressed;
    }

    public static bool GetUp(InputType type)
    {
        return GetEvent(type).up;
    }
}

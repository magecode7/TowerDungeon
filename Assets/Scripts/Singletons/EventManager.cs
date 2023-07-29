using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager I;

    private void Awake()
    {
        I = this;
    }

    #region Actions
    public Action onPlayerDied;
    #endregion

    #region Public methods
    public void CallPlayerDied()
    {
        Debug.Log("Died");
        onPlayerDied?.Invoke();
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCHide : MonoBehaviour
{
    private void Awake()
    {
        if (!Application.isMobilePlatform) GetComponent<Image>().enabled = false;
    }
}

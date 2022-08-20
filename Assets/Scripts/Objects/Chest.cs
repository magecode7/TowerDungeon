using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractive
{
    [SerializeField] private Dropper dropper;
    private Animator animator;

    private bool opened = false;

    public void OnInteract(Entity entity)
    {
        if (!opened)
        {
            dropper.RealizeDrop();
            opened = true;
        }
        animator.SetBool("Opened", opened);
    }

    private void Awake()
    {
        if (!dropper) dropper = GetComponent<Dropper>();
        animator = GetComponent<Animator>();
    }
}

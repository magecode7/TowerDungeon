using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractive
{
    [SerializeField] private bool opened = true;
    [SerializeField] private Transform point = null;

    Animator animator;

    public Room Room { get; set; }
    public Door Another { get; set; }

    void Awake()
    {
        animator = GetComponent<Animator>();

        SetOpened(opened);
    }

    public void SetPath(Door door)
    {
        if (Another != door)
        {
            Another = door;
            Another.SetPath(this);
        }
    }

    public void SetOpened(bool open)
    {
        opened = open;

        animator.SetBool("Opened", opened);
    }

    public void OnInteract(Entity entity)
    {
        if (opened && Another)
        {
            entity.transform.position = Another.point.position;
        }
    }
}

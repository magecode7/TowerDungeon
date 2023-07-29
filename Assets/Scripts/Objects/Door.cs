using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractive
{
    [SerializeField] private bool opened = true;
    [SerializeField] private Transform point = null;
    [SerializeField] private Door another = null;

    Animator animator;

    public Room Room { get; set; }

    void Awake()
    {
        animator = GetComponent<Animator>();

        SetOpened(opened);
    }

    public void SetPath(Door door)
    {
        if (another != door)
        {
            another = door;
            another.SetPath(this);
        }
    }

    public void SetOpened(bool open)
    {
        opened = open;

        animator.SetBool("Opened", open);
    }

    public void OnInteract(Entity entity)
    {
        if (opened && another)
        {
            entity.transform.position = another.point.position;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (another)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, another.transform.position);
        }
    }
}

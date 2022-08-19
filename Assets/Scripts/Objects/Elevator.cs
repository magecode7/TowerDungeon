using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour, IInteractive
{
    [SerializeField] private bool opened = true;
    [SerializeField] private Transform point = null;

    Collider2D coll;
    Animator animator;

    public Room Room { get; set; }

    void Awake()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

        SetOpened(opened);
    }

    public void SetOpened(bool open)
    {
        opened = open;
        animator.SetBool("Opened", opened);
    }

    public void Up()
    {
        SetOpened(false);
        animator.SetTrigger("Up");
    }

    public void Down()
    {
        SetOpened(false);
        animator.SetTrigger("Down");
    }

    public void OnInteract(Entity entity)
    {
        if (opened && coll.OverlapPoint(entity.transform.position))
        {
            StartCoroutine(Interaction(entity));
        }
    }

    IEnumerator Interaction(Entity entity)
    {
        entity.Movement.Stun(4.2f);
        entity.RB.velocity = Vector2.zero;
        Renderer renderer = entity.GetComponent<SpriteRenderer>();
        int order = renderer.sortingOrder;
        renderer.sortingOrder = 0;
        int layer = entity.gameObject.layer;
        entity.gameObject.layer = 0;

        Up();

        yield return new WaitForSeconds(1);

        Room next = RoomsGenerator.I.GenerateNextRoom();
        GameCamera.I.Move(next.transform.position, 2);
        next.elevator.Up();
        entity.transform.position = next.elevator.point.position;

        yield return new WaitForSeconds(2);

        next.elevator.SetOpened(true);

        yield return new WaitForSeconds(1);

        renderer.sortingOrder = order;
        entity.gameObject.layer = layer;

        Destroy(Room.gameObject);
        next.CheckEnemies();

        yield break;
    }
}

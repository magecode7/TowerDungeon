using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public KeyCode altKey;
    public InputType inputType;
    public InputEvent inputEvent;
    private bool
        pointerDown,
        pointerUp;

    void Awake()
    {
        inputEvent = PlayerInput.GetEvent(inputType);
    }

    void FixedUpdate()
    {
        if (pointerDown) Down();
        else if (inputEvent.down) inputEvent.down = false;
        if (pointerUp) Up();
        else if (inputEvent.up) inputEvent.up = false;
        
        if (inputEvent.pressed) inputEvent.OnPress.Invoke();
    }

    void Update()
    {
        if (Input.GetKeyDown(altKey)) pointerDown = true;
        if (Input.GetKeyUp(altKey)) pointerUp = true;
    }

    public void Down()
    {
        pointerDown = false;
        inputEvent.down = true;
        inputEvent.pressed = true;
        inputEvent.OnDown.Invoke();
    }

    public void Up()
    {
        pointerUp = false;
        inputEvent.up = true;
        inputEvent.pressed = false;
        inputEvent.OnUp.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData) => pointerDown = true;

    public void OnPointerUp(PointerEventData eventData) => pointerUp = true;
}

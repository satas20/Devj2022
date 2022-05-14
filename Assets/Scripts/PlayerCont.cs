using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerCont : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashSpeed;
    
    private Rigidbody2D playerRb;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction firstAction;
    private InputAction secondAction;
    private InputAction thirdAction;
    private InputAction forthAction;
    private Vector2 inputVector;
    private Vector2 moveVector;
    private int lookingRight;
    private float dashDurationCounter;
    private float dashCooldownCounter;
    private bool isDashing;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        firstAction = playerInput.actions["Action1"];
        secondAction = playerInput.actions["Action2"];
        thirdAction = playerInput.actions["Action3"];
        forthAction = playerInput.actions["Action4"];
    }

    private void OnEnable()
    {
        forthAction.performed += PlayerDash;
        thirdAction.performed += PlayerSkill;
    }

    private void OnDisable()
    {
        forthAction.performed -= PlayerDash;
        thirdAction.performed -= PlayerSkill;
    }

    private void Start()
    {
        lookingRight = 1;
        dashCooldownCounter = 0;
    }

    private void Update()
    {
        inputVector = moveAction.ReadValue<Vector2>();
        moveVector = inputVector;

        if (isDashing) moveVector = Vector2.zero;

        if (inputVector.x < 0 && lookingRight == 1) FlipCharacter();
        else if (inputVector.x > 0 && lookingRight == -1) FlipCharacter();

        if (dashCooldownCounter > 0)
        {
            dashCooldownCounter -= Time.deltaTime;
        }

        if (dashDurationCounter > 0)
        {
            dashDurationCounter -= Time.deltaTime;
        }
        else
        {
            isDashing = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 current = new Vector2(transform.position.x, transform.position.y);
        playerRb.MovePosition(current + moveVector * moveSpeed * Time.fixedDeltaTime);
        

        if (isDashing)
        {
            playerRb.MovePosition(current + inputVector * dashSpeed * Time.fixedDeltaTime);
            dashCooldownCounter = dashCooldown;
        }
    }

    private void FlipCharacter()
    {
        lookingRight *= -1;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void PlayerDash(InputAction.CallbackContext ctx)
    {
        if (dashCooldownCounter <= 0)
        {
            dashDurationCounter = dashDuration;
            isDashing = true;
        }
    }

    private void PlayerSkill(InputAction.CallbackContext ctx)
    {

    }
}

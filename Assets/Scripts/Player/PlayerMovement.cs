using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private static readonly int State = Animator.StringToHash("state");

    [Header("Player Settings")]
    [SerializeField] private PlayerSettingsSO playerSettings;
    [SerializeField] private AudioClip clipJump;
    [SerializeField] private PlayerAnimatorEnum playerAnimatorEnum;

    [Header("Keys Movement Configuration")]
    [SerializeField] private KeyCode KeyJump = KeyCode.Space;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isJumping = false;

    private bool isInvencible = false;

    public bool IsInvencible => isInvencible;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.SetInteger(State, (int)playerAnimatorEnum);
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetInteger(State, (int)PlayerAnimatorEnum.Walk);
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("Enemy") && !isInvencible)
            animator.SetInteger(State, (int)PlayerAnimatorEnum.Die);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
            collision.GetComponent<IPowerUp>().ApplyPowerUp();
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyJump))
            MoveAxisY(Vector2.up);
    }

    private void MoveAxisY(Vector2 axisY)
    {
        if (isJumping)
            return;

        isJumping = true;
        animator.SetInteger(State, (int)PlayerAnimatorEnum.Jump);
        AudioController.Instance.PlaySoundEffect(clipJump);
        rb.AddForce(playerSettings.JumpForce * Time.fixedDeltaTime * axisY, ForceMode2D.Impulse);
    }

    public void PlayerHasDied()
    {
        GameStateManager.Instance.SetGameState(GameState.GAME_OVER);
    }

    public void SwitchPlayerInvencible()
    {
        isInvencible = !isInvencible;
    }
}

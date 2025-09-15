using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] PlayerSettingsSO playerSettings;
    [SerializeField] AudioClip clipJump;

    [Header("Keys Movement Configuration")]
    [SerializeField] private KeyCode KeyJump = KeyCode.Space;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isJumping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyJump))
            MoveAxisY(Vector2.up);
    }

    private void MoveAxisY(Vector2 axisY)
    {
        if(isJumping)
            return;

        AudioController.Instance.PlaySoundEffect(clipJump);
        rb.AddForce(playerSettings.JumpForce * Time.fixedDeltaTime * axisY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", true);
            isJumping = true;
        }
    }
}

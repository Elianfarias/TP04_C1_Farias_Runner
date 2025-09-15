using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] EnemySettingsSO enemySettings;
    [Header("Player")]
    [SerializeField] GameObject player;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = enemySettings.SpeedMovement * Time.fixedDeltaTime * Vector2.left;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameStateManager.Instance.SetGameState(GameState.GAME_OVER);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LimitMap"))
            gameObject.SetActive(false);
    }
}

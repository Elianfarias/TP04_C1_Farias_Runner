using System.Collections;
using UnityEngine;

public class PowerUpInmune : MonoBehaviour, IPowerUp
{
    [SerializeField] private float speed;
    [SerializeField] private float duration;
    [Header("Sound")]
    [SerializeField] private AudioClip powerUpSound;

    public bool isActive = false;
    private Rigidbody2D rb;
    private GameObject player;
    private PlayerMovement playerMovement;
    private bool hasPicked;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (hasPicked)
            transform.position = Vector3.up * 2 + player.transform.position;
        else
            rb.velocity = speed * Time.fixedDeltaTime * Vector2.left;
    }

    public bool IsActive()
    {
        return isActive;
    }

    public void ApplyPowerUp()
    {
        AudioController.Instance.PlaySoundEffect(powerUpSound);
        isActive = true;
        StartCoroutine(nameof(ApplyInvencible));
    }

    private IEnumerator ApplyInvencible()
    {
        hasPicked = true;
        playerMovement.SwitchPlayerInvencible();
        yield return new WaitForSeconds(duration);
        playerMovement.SwitchPlayerInvencible();
        gameObject.SetActive(false);
        hasPicked = false;
        isActive = false;
    }
}
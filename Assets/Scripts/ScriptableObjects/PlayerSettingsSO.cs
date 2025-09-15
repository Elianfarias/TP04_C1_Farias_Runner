using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/PlayerSettings")]
public class PlayerSettingsSO : ScriptableObject
{
    [SerializeField] private string playerName;
    [SerializeField] private float jumpForce;

    public string PlayerName { get { return playerName; } }

    public void SetPlayerName(string playerName)
    {
        this.playerName = playerName;
    }

    public float JumpForce { get { return jumpForce; } }

    public void SetJumpForce (float jumpForce)
    {
        this.jumpForce = jumpForce;
    }
}

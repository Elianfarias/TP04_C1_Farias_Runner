using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/PlayerSettings")]
public class PlayerSettingsSO : ScriptableObject
{
    [SerializeField] private string playerName;
    [SerializeField] private float jumpForce;
    [SerializeField] private float volumeMusic;
    [SerializeField] private float volumeSFX;

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

    public float VolumeMusic { get { return volumeMusic; } }

    public void SetVolumeMusic(float volumeMusic)
    {
        this.volumeMusic = volumeMusic;
    }

    public float VolumeSFX { get { return volumeSFX; } }

    public void SetVolumeSFX(float volumeSFX)
    {
        this.volumeSFX = volumeSFX;
    }
}

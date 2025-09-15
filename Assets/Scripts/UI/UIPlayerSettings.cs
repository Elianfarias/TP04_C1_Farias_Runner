using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPlayerSettings : MonoBehaviour
{
    [SerializeField] private GameObject panelSettings;

    [Header("Settings Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerSettingsSO playerSettings;
    [SerializeField] private TMP_InputField inputName;

    [Header("Buttons Setting")]
    [SerializeField] private Button btnSave;
    [SerializeField] private Button btnBack;

    [Header("Settings Audio")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private TMP_Text txtMusicValue;
    [SerializeField] private Slider sliderSFX;
    [SerializeField] private TMP_Text txtSFXValue;


    private void Awake()
    {
        btnBack.onClick.AddListener(OnBackPause);
        btnSave.onClick.AddListener(OnSaveClicked);
        sliderMusic.onValueChanged.AddListener(OnValueChangeMusic);
        sliderSFX.onValueChanged.AddListener(OnValueChangeSFX);
    }

    private void Start()
    {
        inputName.text = playerSettings.PlayerName;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "InGame")
            panelSettings.SetActive(false);
    }

    private void OnDestroy()
    {
        btnBack.onClick.RemoveAllListeners();
        btnSave.onClick.RemoveAllListeners();
    }

    private void OnBackPause()
    {
        panelSettings.SetActive(false);
        UIMainMenu.Instance.ToggleUIMainMenu();
    }

    private void OnSaveClicked()
    {
        playerSettings.SetPlayerName(inputName.text);

        OnBackPause();
    }

    private void OnValueChangeMusic(float v)
    {
        float normalized = (v / 80);
        float percentage = normalized * 100f;

        txtMusicValue.text = Mathf.Repeat(percentage, 80).ToString("0");
        audioMixer.SetFloat("VolumeMusic", v);
    }

    private void OnValueChangeSFX(float v)
    {
        float normalized = (v - 80) / (0 - 80);
        float percentage = normalized * 100f;
        txtSFXValue.text = Mathf.Repeat(percentage, 80).ToString("0");
        audioMixer.SetFloat("VolumeSFX", v);
    }
}

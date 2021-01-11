using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class GameSettingsControllerUI : GameSettingsController
{
    [Header("UI Elements")]
    public TMP_Dropdown resolutionSelector;
    public Toggle isFullScreen;
    public Toggle isMute;
    public Slider soundVolume;

    public TMP_Text languageLabel;

    [Header("Buttons")]
    public Button saveButton;
    public Button previousLanguage;
    public Button nextLanguage;

    [Header("Sound")]
    public AudioSource audioSource;

    [Header("Text to translate")]
    public List<TMP_Text> textForTranslate = new List<TMP_Text>();

    private int currentLanguageIndex;

    private void Start()
    {
        SetupResolutions();
        LoadLanguageSettings();
        LoadSoundSettings();

        if (saveButton != null)
        {
            saveButton.onClick.AddListener(delegate { SaveSettings(); });
        }

        if(previousLanguage != null)
        {
            previousLanguage.onClick.AddListener(delegate { ChangeLanguage(-1); });
        }

        if (nextLanguage != null)
        {
            nextLanguage.onClick.AddListener(delegate { ChangeLanguage(1); });
        }
    }


    private void LoadLanguageSettings()
    {
        if(languageLabel != null && defaultSettings != null)
        languageLabel.text = defaultSettings.language.ToString();

        LoadLocalText();
    }


    private void LoadLocalText()
    {
        LocalizationCore.LoadLocaleText(languageLabel.text);

        foreach (var item in textForTranslate)
        {
            item.text = LocalizationCore.GetTextById(item.name);
        }
    }

    private void LoadSoundSettings()
    {
        soundVolume.value = defaultSettings.musicVolume;
        isMute.isOn = defaultSettings.muteMusic;

        audioSource.volume = soundVolume.value;
    }

    private void SetupResolutions()
    {
        if (resolutions != null)
        {
            List<string> res = new List<string>();

            foreach (var item in resolutions)
            {
                res.Add(string.Format("{0} x {1}", item.width, item.height));
            }

            resolutionSelector.AddOptions(res);
        }

        //Если разрешение сохранено то пытаемся его выставить, иначе ставим максимальное доступное разрешение
        if (defaultSettings != null && defaultSettings.resolution.x != 0)
        {
            Resolution savedResolution = GetSavedResolution();
            int index = GetResolutionIndex(savedResolution);

            if (index > -1)
            {
                resolutionSelector.value = index;
            }
            else
            {
                resolutionSelector.value = resolutions.Length - 1;
            }
        }
        //Иначе ставим минимальное разрешение
        else
        {
            resolutionSelector.value = 0;
        }

        isFullScreen.isOn = defaultSettings.isFullScreen;
    }

    private void SaveSettings()
    {
        defaultSettings.SaveResolution(resolutions[resolutionSelector.value]);
        defaultSettings.language = (Languages)currentLanguageIndex;
        defaultSettings.isFullScreen = isFullScreen.isOn;
        defaultSettings.muteMusic = isMute.isOn;
        defaultSettings.musicVolume = soundVolume.value;

        audioSource.volume = soundVolume.value;
        audioSource.mute = isMute.isOn;
        Screen.SetResolution(defaultSettings.resolution.x, defaultSettings.resolution.y, defaultSettings.isFullScreen, defaultSettings.refreshRate);
    }

    private void ChangeLanguage(int direction)
    {
        currentLanguageIndex = TryChangeLanguage(currentLanguageIndex, direction);

        languageLabel.text = ((Languages)currentLanguageIndex).ToString();

        LoadLocalText();
    }
}

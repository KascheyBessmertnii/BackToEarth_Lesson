using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameSettingsController : MonoBehaviour
{
    //При запуске скрипта загружаем настройки
    public GameSettings defaultSettings;

    //При запуске получаем список доступных разрешений
    protected Resolution[] resolutions;

    private void Awake()
    {
        resolutions = Screen.resolutions;
    }
    //При изменении разрешения, проверяем можно ли его установить

    protected Resolution GetSavedResolution()
    {
        Resolution saved = new Resolution();
        saved.height = defaultSettings.resolution.y;
        saved.width = defaultSettings.resolution.x;
        saved.refreshRate = defaultSettings.refreshRate;

        return saved;
    }

    protected int GetResolutionIndex(Resolution res)
    {
        for (int i = 0; i < resolutions.Length; i++)
        {
            if(resolutions[i].height == res.height && resolutions[i].width == res.width)
            {
                return i;
            }
        }

        return -1;
    }

    protected int TryChangeLanguage(int currentIndex, int direction)
    {
        if (currentIndex + direction < 0)
        {
            return 0;
        }
        else if(currentIndex + direction > typeof(Languages).GetEnumNames().Length - 1)
        {
            return typeof(Languages).GetEnumNames().Length - 1;
        }
        else
        {
            return currentIndex + direction;
        }
    }
}

/*Загрузка локализованного текста из Resources/Locale и хранение его в словаре
 *Создано в рамках стрима для начинающих на дискорд канале изучаем Unity совместно. 
 *Этот скрипт реализует поддержку любого количества языков локализации, однако в данном примере всего два языка.
 *Если Вам необходимо большее количество языков то вам надо их добавить в Languages в конце этого скрипта
 *После этого вам необходимо добавить в папку Resources/Locale текстовый файл (расширение должно быть .txt) с локализованным текстом.
 *Название файла должно совпадать с названием добавленного в Languages языка.
 *Каждая строка в файле представляет из себя пару значений для одного элемента - идентификатор текста = локализованный текст 
*/
using System.Collections.Generic;
using UnityEngine;

public static class LocalizationCore
{
    private static Dictionary<string, string> localeText = new Dictionary<string, string>();

    private static void Load(string language)
    {
        //Если вы хотите использовать другой путь для хранения файлов локализации 
        //то замените "Locale/" на необходимый вам путь.
        TextAsset text = Resources.Load<TextAsset>("Locale/" + language);

        if(text!=null)
        {
            string[] strings = text.text.Replace("\r\n", "|").Split('|');

            if(strings.Length > 0)
            {
                localeText.Clear();

                foreach (var item in strings)
                {
                    //Если вы хотите использовать другой сепаратор то замените = на нужное вам значение
                    string[] currentString = item.Split('=');

                    localeText.Add(currentString[0].Trim(), currentString[1]);
                }
                
            }
        }
    }

    /// <summary>
    /// Возвращает локализованный текст по идентификатору
    /// </summary>
    /// <param name="ID">Идентификатор локализуемого текста</param>
    /// <returns>Локализованный текст или идентификатор текста если для него нет перевода</returns>
    public static string GetTextById(string ID)
    {
        if(localeText.ContainsKey(ID))
        {
            return localeText[ID];
        }

        return ID;
    }

    public static void LoadLocaleText(int languageId)
    {
        Load(((Languages)languageId).ToString());
    }

    public static void LoadLocaleText(string languageName)
    {
        Load(languageName);
    }

    public static void LoadLocaleText(Languages language)
    {
        Load(language.ToString());
    }
}

//В это поле необходимо добавлять дополнительные необходимые вам языки
public enum Languages { Русский, English}
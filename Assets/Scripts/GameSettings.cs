using UnityEngine;

[CreateAssetMenu(menuName = "My Game/Settings")]
public class GameSettings : ScriptableObject
{
    public Languages language = Languages.Русский;
    public Vector2Int resolution;
    public int refreshRate;
    public bool isFullScreen = false;
    [Range(0, 1)]
    public float musicVolume = 0.5f;
    public bool muteMusic = false;

    public void SaveResolution(Resolution res)
    {
        resolution.x = res.width;
        resolution.y = res.height;
        refreshRate = res.refreshRate;
    }
}

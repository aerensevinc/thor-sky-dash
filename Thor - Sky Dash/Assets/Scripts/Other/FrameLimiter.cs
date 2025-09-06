using UnityEngine;

public class FrameLimiter : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.vSyncCount = 0;    
        Application.targetFrameRate = 120;   
    }
}
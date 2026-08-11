using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicCallbacks : MonoBehaviour
{
    public AK.Wwise.Event musicEvent;

    public Light beatLight;

    public float pulseIntesity = 5f;
    public float fadeSpeed = 8f;

    private float beatLightTarget = 0f;
    private Color colorTarget = Color.white;

    [SerializeField] private Material daySkybox;
    [SerializeField] private Material nightSkybox;

    // DynamicGI.UpdateEnvironment()


    private void Start()
    {

        musicEvent.Post(gameObject, 
            (uint)(AkCallbackType.AK_MusicSyncBeat | AkCallbackType.AK_MusicSyncUserCue), 
            OnMusicCallback
            );

    }
    void OnMusicCallback(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info)
    {
        if(in_type == AkCallbackType.AK_MusicSyncBeat)
        {
            beatLightTarget = pulseIntesity;
        }
        if (in_type == AkCallbackType.AK_MusicSyncUserCue)
        {
           AkMusicSyncCallbackInfo info = (AkMusicSyncCallbackInfo) in_info;
            string cueName = info.userCueName;

            switch (cueName)
            {
                case "change_color_red":
                    colorTarget = Color.red;
                    RenderSettings.skybox = nightSkybox;
                    DynamicGI.UpdateEnvironment();
                    break;
                case "change_color_green":
                    colorTarget = Color.green;
                    break;
                default:
                    colorTarget = Color.white;
                    RenderSettings.skybox = daySkybox;
                    DynamicGI.UpdateEnvironment();
                    break;
            }
        }
    }

    private void Update()
    {
        beatLight.intensity = Mathf.Lerp(beatLight.intensity, beatLightTarget, fadeSpeed * Time.deltaTime);
        beatLightTarget = Mathf.Lerp( beatLightTarget, 0f, fadeSpeed * Time.deltaTime );
        beatLight.color = colorTarget;
    }
}

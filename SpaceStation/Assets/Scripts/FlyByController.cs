using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyByController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PlayFlyBy", 20.0f, 20f);
    }

    public void PlayFlyBy()
    {
        AkSoundEngine.PostEvent("Play_FlyBy", this.gameObject);
    }

}

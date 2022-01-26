using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorAmbiant : MonoBehaviour
{
    public bool IsXPositive = true;

    void OnTriggerEnter(Collider other)
    {
    }

    void OnTriggerExit(Collider other)
    {
        var pos = other.transform.position;

        if (IsXPositive)
        {
            if (pos.x < gameObject.transform.position.x)
            {
                AkSoundEngine.SetRTPCValue("PlayerInside", 80);
            }
            else
            {
                AkSoundEngine.SetRTPCValue("PlayerInside", 1);
            }
        }
        else
        {
            if (pos.x > gameObject.transform.position.x)
            {
                AkSoundEngine.SetRTPCValue("PlayerInside", 80);
            }
            else
            {
                AkSoundEngine.SetRTPCValue("PlayerInside", 1);
            }
        }
    }
}

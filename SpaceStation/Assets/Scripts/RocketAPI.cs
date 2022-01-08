using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAPI : MonoBehaviour
{
    public GameObject Player;

    public void Land()
    {
        AkSoundEngine.PostEvent("Play_Rocket_Stop", this.gameObject);
    }

    public void Lunch()
    {

        AkSoundEngine.PostEvent("Play_Rocket_Start", this.gameObject);
    }

    public void ShakeCamera()
    {
        if (Vector3.Distance(Player.transform.position, transform.position) < 80f)
        {
            FindObjectOfType<CameraShaker>().Shake(3f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientController : MonoBehaviour
{
    public string Ambient;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //AkSoundEngine.PostEvent("Play_Door", this.gameObject);
            Debug.Log("Start Ambient");
            //AkSoundEngine.PostEvent(string.Format("Play_{0}", Ambient), this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //AkSoundEngine.PostEvent("Play_Door", this.gameObject);
            Debug.Log("Stop Ambient");
            //AkSoundEngine.PostEvent(string.Format("Play_{0}", Ambient), this.gameObject);
        }
    }
}

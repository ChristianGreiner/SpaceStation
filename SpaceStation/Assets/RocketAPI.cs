using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAPI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Land()
    {
        AkSoundEngine.PostEvent("Play_Rocket_Stop", this.gameObject);
    }

    public void Lunch()
    {

        AkSoundEngine.PostEvent("Play_Rocket_Start", this.gameObject);
    }
}

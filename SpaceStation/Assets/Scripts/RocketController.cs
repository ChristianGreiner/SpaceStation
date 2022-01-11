using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public GameObject Rocket;

    private Animator rocketAnimator;
    private bool isFying;
    private bool canInteract;

    // Start is called before the first frame update
    void Start()
    {
       this.rocketAnimator = Rocket.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && this.rocketAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            this.rocketAnimator.SetTrigger("RocketStart");

            // player
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player)
                AkSoundEngine.PostEvent("Play_Interact", player.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        this.canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        this.canInteract = false;
    }
}

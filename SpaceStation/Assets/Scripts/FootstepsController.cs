using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsController : MonoBehaviour
{
    private CharacterController character;

    // Start is called before the first frame update
    private void Start()
    {
        this.character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (this.character.isGrounded && this.character.velocity.magnitude > 0.25f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 5f))
            {
                //Debug.Log(hit.transform.gameObject.name);
                var target = hit.transform.gameObject;
                if (target.tag == "Metal")
                {
                    // play metal sounds
                }
                else if (target.tag == "Gravel")
                {
                    // play sand sounds
                }
                else
                {
                }
            }
        }
    }
}
using System.Collections;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject Portal;
    public GameObject ForceField;
    public float TweenDuration = 1.0f;

    private bool canInteract;
    private bool isDirty;
    private bool isOn = true;
    private float startRange;
    private Vector3 startScale;

    // Start is called before the first frame update
    void Start()
    {
        var light = this.Portal.GetComponent<Light>();
        this.startRange = light.range;

        this.startScale = ForceField.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && !this.isDirty)
        {
            if (isOn)
            {
                Off();
            }
            else
            {
                On();
            }

            // player
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player)
                AkSoundEngine.PostEvent("Play_Interact", player.gameObject);
        }
    }

    public void On()
    {
        var light = this.Portal.GetComponent<Light>();
        StartCoroutine(TweenLightning(light, this.startRange));
        StartCoroutine(TweenScale(ForceField, startScale));
        isOn = true;

        AkSoundEngine.PostEvent("Play_Portal", this.Portal);
    }

    public void Off()
    {
        var light = this.Portal.GetComponent<Light>();
        StartCoroutine(TweenLightning(light, 0f));
        StartCoroutine(TweenScale(ForceField, new Vector3(startScale.x, 0f, 0f)));
        isOn = false;

        AkSoundEngine.PostEvent("Stop_Portal", this.Portal);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        this.canInteract = false;
    }

    IEnumerator TweenLightning(Light light, float targetRange)
    {
        this.isDirty = true;
        float previousRange = light.range;
        float time = 0.0f;
        do
        {
            //Add the deltaTime to the time variable
            time += Time.deltaTime;
            light.range = Mathf.Lerp(previousRange, targetRange, Mathf.SmoothStep(0.0f, 1.0f, time / this.TweenDuration));
            yield return 0;
        } while (time < this.TweenDuration);

        this.isDirty = false;
    }

    IEnumerator TweenScale(GameObject portal, Vector3 targetScale)
    {
        this.isDirty = true;
        Vector3 previousScale = portal.transform.localScale;
        float time = 0.0f;
        do
        {
            //Add the deltaTime to the time variable
            time += Time.deltaTime;
            portal.transform.localScale = Vector3.Lerp(previousScale, targetScale, Mathf.SmoothStep(0.0f, 1.0f, time / this.TweenDuration));
            yield return 0;
        } while (time < this.TweenDuration);
        this.isDirty = false;
    }
}

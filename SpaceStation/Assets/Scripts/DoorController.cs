using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    public float MoveDuration = 1.0f;
    public Vector3 TargetDirection;

    private bool isDirty;
    private Vector3 startPosition;
    private bool isOpen;
    private bool canInteract;

    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = this.Door.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && !this.isDirty)
        {
            if (isOpen)
            {
                Close();
            } else
            {
                Open();
            }
        }
    }

    public void Open()
    {
        var pos = this.Door.transform.position + TargetDirection;
        StartCoroutine(TweenPosition(this.Door, pos));
        isOpen = true;
    }

    public void Close()
    {
        var pos = startPosition;
        StartCoroutine(TweenPosition(this.Door, pos));
        isOpen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        this.canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        this.canInteract = false;
    }

    IEnumerator TweenPosition(GameObject target, Vector3 targetPosition)
    {
        this.isDirty = true;
        Vector3 previousPosition = target.transform.position;
        float time = 0.0f;
        do
        {
            time += Time.deltaTime;
            target.transform.position = Vector3.Lerp(previousPosition, targetPosition, Mathf.SmoothStep(0.0f, 1.0f, time / this.MoveDuration));
            yield return 0;
        } while (time < this.MoveDuration);
        this.isDirty = false;
    }
}

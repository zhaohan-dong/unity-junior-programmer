using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float interval;
    private bool ready = true;

    // Update is called once per frame
    void Update()
    {
        if(ready)
        {
            sendDog(interval);
        }
        
    }

    void sendDog(float waitTime)
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            ready = false;
            StartCoroutine(DelayAction(waitTime));
        }
    }

    IEnumerator DelayAction(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ready = true;
    }
}

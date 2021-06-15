using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObject : MonoBehaviour
{
    // using SerializeField instead of public means the variables are still in the inspector BUT are not visible to other classes
    [SerializeField] float BouncePeriod = 1f;
    [SerializeField] float BounceHeight = 1f;

    // using the {get; private set; } syntax makes this a property that can be READ externally but only WRITTEN within this class
    // properties are variables that can do extra logic when reading or writing them
    // properties are NOT visible in the inspector
    public bool CanBounce { get; private set; } = false;

    Vector3 InitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;

        // register ourselves with the bounce manager
        FindObjectOfType<BounceManager>().RegisterObject(this);
    }

    void OnDestroy()
    {
        // deregister ourselves with the bounce manager
        // using ?. means only run the function (DeregisterObject) if we found the bounce manager
        // on exiting the level the bounce manage may have already been cleaned up
        FindObjectOfType<BounceManager>()?.DeregisterObject(this);
    }

    // Update is called once per frame
    void Update()
    {
        // this is equivalent to saying if (CanBounce == false)
        if (!CanBounce)
            return;

        // calculate the bounce offset (use ping pong so it wraps with time)
        float bounceOffset = BounceHeight * Mathf.PingPong(Time.time, BouncePeriod) / BouncePeriod;

        // update the position
        transform.position = InitialPosition + new Vector3(0, bounceOffset, 0);
    }

    public void EnableBouncing()
    {
        CanBounce = true;
    }
}

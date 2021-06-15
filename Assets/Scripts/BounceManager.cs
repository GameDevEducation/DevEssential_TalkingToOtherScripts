using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceManager : MonoBehaviour
{
    // Method 1 for talking to other objects - manually linked data
    [SerializeField] List<BounceObject> TargetObjects;

    // Method 2 for talking to other objects - finding at runtime
    BounceObject[] FoundObjects;

    // Method 3 for talking to other objects - registration at runtime
    List<BounceObject> RegisteredObjects = new List<BounceObject>();

    // Start is called before the first frame update
    void Start()
    {
        // search for all objects of type BounceObject
        FoundObjects = FindObjectsOfType<BounceObject>();        
    }

    // Update is called once per frame
    void Update()
    {
        //Update_Method1();

        //Update_Method2();

        Update_Method3();
    }

    public void RegisterObject(BounceObject toRegister)
    {
        Debug.Log("Registering " + toRegister.gameObject.name);

        RegisteredObjects.Add(toRegister);
    }

    public void DeregisterObject(BounceObject toDeregister)
    {
        RegisteredObjects.Remove(toDeregister);
    }

    void Update_Method3()
    {
        ///////////////////////////////////////////////////////////////////////
        // Method 3 for talking to other objects
        ///////////////////////////////////////////////////////////////////////

        // make the objects bounce
        foreach(var target in RegisteredObjects)
        {
            target.EnableBouncing();
        }
    }

    void Update_Method2()
    {
        ///////////////////////////////////////////////////////////////////////
        // Method 2 for talking to other objects
        ///////////////////////////////////////////////////////////////////////

        // make the objects bounce
        foreach(var target in FoundObjects)
        {
            target.EnableBouncing();
        }
    }

    void Update_Method1()
    {
        ///////////////////////////////////////////////////////////////////////
        // Method 1 for talking to other objects
        ///////////////////////////////////////////////////////////////////////

        // make the objects bounce
        foreach(var target in TargetObjects)
        {
            if (target == null)
            {
                Debug.LogError("One of the TargetObjects is null. Check data setup");
            }

            target.EnableBouncing();
        }
    }
}

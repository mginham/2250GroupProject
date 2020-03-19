using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic creation of base class for any Singelton to use
/// </summary>

public class SingletonGeneric<T> : MonoBehaviour where T : MonoBehaviour
{
    //Check to see if we're about to be destroyed
    private static bool singShuttingDown = false;
    private static object singLock = new object();
    private static T singInstance;

    /// <summary>
    /// Access singleton instance through this property.
    /// </summary>
    
    public static T Instance
    {
        get
        {
            if (singShuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance  '" + typeof(T) + " ' already destryed. Returning null. ");
                return null;
            }

            //Lock allows for one thread to access the code below
            //While a thread is in here no other thread may access this area.
            lock (singLock)
            {
                if (singInstance == null)
                {
                    //Search for existing instance of gameObject
                    singInstance = (T)FindObjectOfType(typeof(T));

                    //Create new instance if one doesn't already exist.
                    //If no instance of the object exists then we will create a new instance of it 
                    if (singInstance == null)
                    {
                        //Need to create a new GameObject to attach the singleton to.
                        var singletonObject = new GameObject();
                        singInstance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";

                        //Preserves an Object when transitionin from one scene to another
                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return singInstance;

            }
        }
    }

    private void OnApplicationQuit()
    {
        singShuttingDown = true;
    }

    private void OnDestroy()
    {
        singShuttingDown = true;
    }

}

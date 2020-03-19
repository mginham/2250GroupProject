using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPlayer : SingletonGeneric<SingletonPlayer>
{
    protected SingletonPlayer() { }
    //To access any of the properties or methods from the generic class use
    //<ClassName>.Instance

    [HideInInspector]
    public Vector3 lastPlayerPosition;
}

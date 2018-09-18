using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionData : MonoBehaviour
{
    private object collisionInfo;

    public object CollisionInfo
    {
        get
        {
            return collisionInfo;
        }

        set
        {
            collisionInfo = value;
        }
    }
}

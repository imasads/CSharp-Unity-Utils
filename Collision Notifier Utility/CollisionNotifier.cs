using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(CollisionData))]
public class CollisionNotifier : MonoBehaviour
{
    private CollisionData collisionData;

    [Header("OnTrigger Events")]
    public UnityEvent OnTriggerEnterEvent;
    public UnityEvent OnTriggerExitEvent;

    [Header("OnCollision Events")]
    public UnityEvent OnCollisionEnterEvent;
    public UnityEvent OnCollisionExitEvent;

    void Awake()
    {
        collisionData = GetComponent<CollisionData>();
    }

    void OnTriggerEnter(Collider other)
    {
        collisionData.CollisionInfo = other;

        if (OnTriggerEnterEvent != null)
        {
            OnTriggerEnterEvent.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        collisionData.CollisionInfo = other;

        if (OnTriggerExitEvent != null)
        {
            OnTriggerExitEvent.Invoke();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        collisionData.CollisionInfo = collision;

        if (OnCollisionEnterEvent != null)
        {
            OnCollisionEnterEvent.Invoke();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        collisionData.CollisionInfo = collision;

        if (OnCollisionExitEvent != null)
        {
            OnCollisionExitEvent.Invoke();
        }
    }
}

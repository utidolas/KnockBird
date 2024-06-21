using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivatePlayerWithAnimation : MonoBehaviour
{
    [SerializeField]
    private UnityEvent whenFinishAnimation;
    public void ActivatePlayerRb()
    {
        whenFinishAnimation.Invoke();
    }
}

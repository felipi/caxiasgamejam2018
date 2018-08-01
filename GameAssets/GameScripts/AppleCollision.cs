using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AppleCollision : MonoBehaviour
{
    [System.Serializable]
    public class TransferEvent : UnityEvent<MonoBehaviour> { }
    public GameEvent OnCollision;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Worm") {
            MonoBehaviour apple = gameObject.GetComponent<AppleMechanics>();// as MonoBehaviour;
            WormMechanics worm = coll.gameObject.GetComponent<WormMechanics>();

            if (apple && worm.parentApple != apple) {
                OnCollision.Raise(apple);
            }
        }
    }
}

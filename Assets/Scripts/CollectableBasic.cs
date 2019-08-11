using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBasic : MonoBehaviour {


    private void OnTriggerEnter(Collider Hit) {
        if (Hit.tag == "Player") {
            Singleton.Instance.Collectables += 1;
            Destroy(gameObject);
        }
    }
}

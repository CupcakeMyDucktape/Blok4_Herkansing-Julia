using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBasic : MonoBehaviour {

    public UIScript UI;

    private void OnTriggerEnter(Collider Hit) {
        if (Hit.tag == "Player") {
            UI.CollectedSomething();
            Singleton.Instance.Collectables += 1;
            Destroy(gameObject);
        }
    }
}

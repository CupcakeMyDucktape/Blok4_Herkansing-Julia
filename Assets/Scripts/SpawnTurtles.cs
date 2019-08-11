using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurtles : MonoBehaviour {

    //Zelf geschreven door te kijken naar de andere scripts.
    //En met dev's die zeuren dat het op de Start moet en niet op Awake :^)

    public GameObject Turtle;

	void Start () {
        for (int i = 0; i < Singleton.Instance.Collectables; i++) {
            Instantiate(Turtle, transform.position + new Vector3(0, i, 0), transform.rotation);
        }
    }
}

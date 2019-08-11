using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

    //Tutorial used for this; https://www.youtube.com/watch?v=CPKAgyp8cno&t=41s

    public static Singleton Instance { get; private set; }

    public int Collectables = 0;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        
    }
}

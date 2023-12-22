using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour{
    private float speed {get; set;} //atribut 1

    private Transform playerTransform;

    // Start is called before the first frame update
    public void Start(){
        playerTransform = GetComponent<Transform>();
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update(){
        playerTransform.position += new Vector3(0, speed, 0);
    }
}

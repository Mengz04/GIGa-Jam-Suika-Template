using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour{
    [SerializeField] private int ballLevel;
    [SerializeField] private float ballScale;
    [SerializeField] private GameObject[] ballPrefab;

    public bool expandOnSpawn = false;
    public int GetBallLevel(){
        return this.ballLevel;
    }
   
    void Start(){
        Debug.Log("Spawning");
        //if(expandOnSpawn) ExpandOnSpawn();
    }


    void OnCollisionEnter2D(Collision2D collision){
        if(this.ballLevel == 5){return;}
        if(collision.gameObject.GetComponent<BallScript>() != null){
            Debug.Log("no ball skip");
            if(collision.gameObject.GetComponent<BallScript>().GetBallLevel() == this.ballLevel){
                if(this.gameObject.GetInstanceID() > collision.gameObject.GetInstanceID()){
                    GameObject ballTemp = Instantiate(ballPrefab[this.ballLevel], (this.gameObject.transform.position + collision.gameObject.transform.position)/2f, Quaternion.identity);
                    Debug.Log("Mark here");
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    IEnumerator Wait(float seconds){
        yield return new WaitForSeconds(seconds);
    }
}

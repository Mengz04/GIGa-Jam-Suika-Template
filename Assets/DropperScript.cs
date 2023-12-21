using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperScript : MonoBehaviour{
    [SerializeField] private GameObject[] ballPrefab;
    [SerializeField] private RandomizerScript randomizerScript;
    private int curBallLevel;

    public void SetCurBallLevel(int level){
        this.curBallLevel = level;
    }

    void Update(){
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(worldPosition.x > -4.2f && worldPosition.x < 4.2f){
            transform.position = new Vector3(worldPosition.x, transform.position.y, transform.position.z);
        }
        if(Input.GetButtonDown("Fire1")){
            Instantiate(ballPrefab[randomizerScript.GetNextSpawn()], this.gameObject.transform.position, Quaternion.identity);
            randomizerScript.Gacha();
        }
    }
}

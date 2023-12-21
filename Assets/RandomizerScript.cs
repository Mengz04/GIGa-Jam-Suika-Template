using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class RandomizerScript : MonoBehaviour{
    private int nextSpawn;
    [SerializeField] private Image nextImg;
    [SerializeField] private GameObject[] ballPrefab;
    public int GetNextSpawn(){
        return this.nextSpawn;
    }
    void Start(){
        Gacha();
    }

    public void Gacha(){
        nextSpawn = Random.Range(0, 3);
        nextImg.color = ballPrefab[nextSpawn].GetComponent<SpriteRenderer>().color;
    }
}

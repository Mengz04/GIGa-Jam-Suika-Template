using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ScoreScript : MonoBehaviour{
    public static ScoreScript instance{ get; private set;}
    [SerializeField] private TMP_Text scoreTxt;
    private int curScore;

    private void Awake() {
        if(instance == null){
            instance = this;
        }else{
            Destroy(this);
        }
    }

    void Start(){
        curScore = 0;
        UpdateScore();
    }

    public void AddScore(int addition){
        curScore += addition;
        UpdateScore();
    }

    public void UpdateScore(){
        scoreTxt.text = curScore.ToString();
    }
}

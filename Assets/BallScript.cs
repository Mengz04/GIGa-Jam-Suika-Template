using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private int ballLevel;
    private ScoreScript scoreScript;

    private bool checkY;
    [SerializeField] private GameObject[] ballPrefab;
    public int GetBallLevel()
    {
        return this.ballLevel;
    }

    void Start()
    {
        checkY = false;
        scoreScript = ScoreScript.instance;
        StartCoroutine(Wait(2.0f));
    }

    void Update(){
        if(checkY == true){
            if(this.transform.position.y > 2.1f){
                Debug.Log("kalah");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.ballLevel == 5) { return; }
        if (collision.gameObject.GetComponent<BallScript>() != null)
        {
            if (collision.gameObject.GetComponent<BallScript>().GetBallLevel() == this.ballLevel)
            {
                if (this.gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
                {
                    scoreScript.AddScore(this.ballLevel * 50);

                    Instantiate(ballPrefab[this.ballLevel], (this.gameObject.transform.position + collision.gameObject.transform.position) / 2f, Quaternion.identity);
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        checkY = true;
    }
}

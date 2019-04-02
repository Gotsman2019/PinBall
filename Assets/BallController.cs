using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    private float visiblePosZ = -6.5f;
    private GameObject gameoverText;
    private GameObject scoreText;
   
    private int p;
    public int score = 0;

    int Point(int s)
    {
        int ss;
        ss = s + 10;
        return ss;
    }
    int ScoreAdd(int z)
    {
        int zz;
        zz = z + score;
        return zz;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
     
      this.scoreText.GetComponent<Text>().text ="得点　"+ score ;


        if (this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";

        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            p = Point(10);
        }

        else if (other.gameObject.tag == "LargeStartag")
        {
            p = Point(25);
        }
        else if (other.gameObject.tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            p = Point(100);
        }
        else
        {
            p = 0;
        }


        score = ScoreAdd(p);

       //Debug.Log(score);
    }
}

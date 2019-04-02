using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    int width = Screen.width;
    int height = Screen.height;

    private HingeJoint myHingeJoint;
    private float defaultAngle = 20;
    private float flickAngle = -20;
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);

    }

    // Update is called once per frame
    void Update()
     { 
        Touch[] myTouchs = Input.touches;

        for (int i = 0; i < Input.touchCount; i++)
        {


            //タッチしたらフリッパー動かす
            if (myTouchs[i].phase == TouchPhase.Began && tag == "LeftFripperTag" && myTouchs[i].position.x <= width / 2)
            {
                SetAngle(this.flickAngle);
            }
            if (myTouchs[i].phase == TouchPhase.Began && tag == "RightFripperTag" && myTouchs[i].position.x > width / 2)
            {
                SetAngle(this.flickAngle);
            }
            //タッチしたらフリッパ元に戻す
            if (myTouchs[i].phase == TouchPhase.Ended && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
            if (myTouchs[i].phase == TouchPhase.Ended && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
        }
    }
}

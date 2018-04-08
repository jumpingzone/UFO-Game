using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	
    void Update () {    //void更新() 每秒執行約60次
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);   //一秒鐘轉幾度
        //變形.旋轉(新 3維向量(0, 0, 45)) * 時間.時間變化
        //每一秒以Z軸為中心轉45度

        //
	}
}

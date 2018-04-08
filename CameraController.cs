using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [Header("玩家物件")]
    public GameObject player;

    [Header("相對位移")]
    public Vector3 offset;//宣告成public可以即時修改數值

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        //相對位移 ＝ 攝像機的座標 - 玩家的座標
	}
	
	// Update is called once per frame
	void LateUpdate () {    //通常放置攝影機跟著玩家跑的方法
        transform.position = player.transform.position + offset;//隨時改變
        //攝影機的座標 = 玩家的座標 + 相對位移
	}
}

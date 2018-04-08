using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [Header("水平方向")]//提示用途，方便知道變數的意思
    public float moveX;
    [Header("垂直方向")]
    public float moveY;
    [Header("推力")]
    public float push;

    Rigidbody2D rb2D; //剛體 以便可以被施壓

    [Header("分數文字UI")]
    public Text CountText;  //不是String字串！！
    [Header("過關文字UI")]
    public Text WinText;

    int score;  //分數

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>(); //遊戲一開始告知取同一遊戲物件裡組建的剛體;所以只會控制腳本所屬的物件
        //rb2D = 取得組件<剛體>()

        WinText.text = "";
        //清空過關文字的內容
        setScoreText();
        //顯示目前分數0
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {   //通常放置物理運動的方法，為Unity的特定方法名稱，每秒會執行很多次，隨時進行案件偵測（50次/秒）
        moveX = Input.GetAxis("Horizontal");    //Horizontal & Vertical 為不可變更字樣  
        //水平移動 = 輸入.取得軸向("水平")
        //接收鍵盤輸入的方向

        moveY = Input.GetAxis("Vertical");
        //吹直移動 = 輸入.取得軸向("垂直")

        Vector2 movement = new Vector2(moveX, moveY);
        //2維向量 移動方向 ＝ 新2維方向(水平方向，垂直方向)

        rb2D.AddForce(push * movement);
        //rb2D.施加壓力(推力 * 移動方向);
	}

	private void OnTriggerEnter2D(Collider2D other) //當玩家物件碰到其他碰撞器時，會有的反應
	{
        Debug.Log(name + "觸發了" + other.name);   //玩家物件觸發了其他物件的名字
        if (other.CompareTag("PickUp")) {   //黃金進入到其他觸發器時，會有的反應
            //其他.比較標籤("PickUp")
            other.gameObject.SetActive(false);  //關掉物件
            //提他.遊戲物件.設定活躍狀態(否)
            score++;
            setScoreText();
        }
	}

    void setScoreText(){
        CountText.text = "目前分數：" + score.ToString(); 
        //計分文字UI.文字 ＝ "目前分數：" + 分數.轉字串

        if (score >= 12)    //分數大於12
        {
            WinText.text = "你贏了";
            //過關文字.UI
        }

    }
   
}

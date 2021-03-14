using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{


    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimater;
    //Unityちゃんを移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;
    //前方向の速度
    private float velocityZ = 16f;
    //横方向の速度
    private float velocityX = 10f;
    //上方向の速度
    private float velocityY = 10f;//10
    //左右の移動できる範囲
    private float movableRange = 3.4f;
    //減速係数
    private float coefficient = 0.99f;
    //ゲーム終了の判定
    private bool isEnd = false;
    //ゲーム終了時に表示するテキスト
    private GameObject stateText;
    //スコアを表示するテキスト
    private GameObject scoreText;
    //得点
    private int score = 0;

    //左ボタンの押下判定
    private bool isLButtonDown = false;
    //右ボタンの押下判定
    private bool isRButtonDown = false;
    //ジャンプボタンの押下判定
    private bool isJButtonDown = false;


    // Start is called before the first frame update
    void Start()
    {
        //Animatorコンポーネントを取得
        this.myAnimater = GetComponent<Animator>();

        //走るアニメーションを開始(第二引数を0.2fにしたら歩くようになった)
        this.myAnimater.SetFloat("Speed", 1);

        //RigitBodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();

        //シーン中のstateTextオブジェクトを取得
        this.stateText = GameObject.Find("GameResultText");

        //シーン中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {

        //ゲーム終了ならUnityちゃんの動きを減衰する
        if(this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimater.speed *= this.coefficient;
        }

        //横方向の入力による速度
        float inputVelosityX = 0;
        //上方向の入力による速度
        float inputVelocityY = 0;

        //Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる
        if((Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown) && -this.movableRange < this.transform.position.x)
        {
            //左方向への速度を代入
            inputVelosityX = -this.velocityX;
            
        }
        else if((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown) && this.transform.position.x < this.movableRange)
        {
            //右方向への速度を代入
            inputVelosityX = this.velocityX;
        }

        //ジャンプしていないときにスペースが押されたらジャンプする
        if((Input.GetKeyDown(KeyCode.Space) || this.isJButtonDown) && this.transform.position.y < 0.5)
        {
            //ジャンプアニメを再生
            this.myAnimater.SetBool("Jump", true);
            //上方向への速度を代入
            inputVelocityY = this.velocityY;
        }
        else
        {
            //現在のY軸の速度を代入
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        //Jumpステートの場合はJunpにfalseをセットする
        if(this.myAnimater.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimater.SetBool("Jump", false);
        }

        //Unityちゃんに速度を与える
        this.myRigidbody.velocity = new Vector3(inputVelosityX, inputVelocityY, this.velocityZ);
    }

    //トリガーモードで他のオブジェクトと接触した場合の処理
    void OnTriggerEnter(Collider other)
    {
        //障害物に衝突した場合(車、コーン)
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            //ゲームを終了する処理を行う
            this.isEnd = true;
            //stateTextにゲームオーバー表示
            this.stateText.GetComponent<Text>().text = "GAME OVER";
        }
        //ゴールに到達した場合
        if(other.gameObject.tag == "GoalTag")
        {
            //ゲームを終了する処理を行う
            this.isEnd = true;
            //stateTextにクリアを表示
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
        }
        //コインに衝突した場合
        if(other.gameObject.tag =="CoinTag")
        {
            //スコアを加算
            this.score += 10;

            //scoreTextに獲得した点数を表示
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";

            //パーティクルを再生
            GetComponent<ParticleSystem> ().Play ();
            //接触したコインのオブジェクトを破棄
            Destroy(other.gameObject);
        }
    }
    //ジャンプボタンを押した場合の処理
    public void GetMyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }
    //ジャンプボタンを離した場合の処理
    public void GetMyJumpButtonUp()
    {
        this.isJButtonDown = false;
    }

    //左ボタンを押し続けた場合の処理
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    //左ボタンを離した場合の処理
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    //右ボタンを押し続けた場合の処理
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    //右ボタンを離した場合の処理
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }

}

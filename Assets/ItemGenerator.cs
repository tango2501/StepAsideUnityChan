using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //各プレハブを入れる
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;

    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //Unityちゃん座標管理用
    private GameObject unitychan;
    private float unitychanpos;
    //生成場所決定用の指定座標
    private float anchorpos = 40;
 
    // Start is called before the first frame update
    void Start()
    {
        // unitychan
        unitychan = GameObject.Find("unitychan");
        unitychanpos = unitychan.transform.position.z;
        //anchorpos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        //unityちゃんの座標を追跡
        unitychanpos = unitychan.transform.position.z;
        //unityちゃんが指定座標を通り過ぎ、かつゴールより40m手前の時
        if(unitychanpos > anchorpos && unitychanpos < (goalPos-40))
        {
            Debug.Log(anchorpos);
            //次の指定座標を更新
            anchorpos += 15;
            //アイテム生成関数を呼び出す
            generator();
        }

        
    }


    //アイテム生成関数
    void generator()
    {
        //どのアイテムを出すのかをランダムに設定
        int num = Random.Range(1, 11);
        if (num <= 2)
        {
            //コーンをx軸方向に一色線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                //指定座標から40m前方に生成
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, anchorpos+40);
            }
        }
        else
        {
            //レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {
                //アイテムの種類を決める
                int item = Random.Range(1, 11);
                //アイテムを置くz座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);
                //60%コイン配置:30%車は一:10%何もなし
                if (1 <= item && item <= 6)
                {
                    //コインを生成
                    GameObject coin = Instantiate(coinPrefab);
                    //指定座標から40m前方に生成
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, (anchorpos+40) + offsetZ);//新規生成されたコインの位置情報
                }
                else if (7 <= item && item <= 9)
                {
                    //車を生成
                    GameObject car = Instantiate(carPrefab);
                    //指定座標から40m前方に生成
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, (anchorpos+40) + offsetZ);
                }
            }
        }
    }

















    /*
    void instantiate()
    {
        /*test
        GameObject coin = Instantiate(coinPrefab);
        coin.transform.position = new Vector3(0, 0, Random.Range(100,500));
        

        for (int i = anchorpos; i < (anchorpos += 50); i += 15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一色線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くz座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車は一:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);//新規生成されたコインの位置情報
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
    }
    */
}






//
/*一定の距離ごとにアイテムを生成
for (int i = startPos; i < goalPos; i += 15)
{
    //どのアイテムを出すのかをランダムに設定
    int num = Random.Range(1, 11);
    if (num <= 2)
    {
        //コーンをx軸方向に一色線に生成
        for (float j = -1; j <= 1; j += 0.4f)
        {
            GameObject cone = Instantiate(conePrefab);
            cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
        }
    }
    else
    {
        //レーンごとにアイテムを生成
        for (int j = -1; j <= 1; j++)
        {
            //アイテムの種類を決める
            int item = Random.Range(1, 11);
            //アイテムを置くz座標のオフセットをランダムに設定
            int offsetZ = Random.Range(-5, 6);
            //60%コイン配置:30%車は一:10%何もなし
            if (1 <= item && item <= 6)
            {
                //コインを生成
                GameObject coin = Instantiate(coinPrefab);
                coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);//新規生成されたコインの位置情報
            }
            else if (7 <= item && item <= 9)
            {
                //車を生成
                GameObject car = Instantiate(carPrefab);
                car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
            }
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    //カメラオブジェクトを格納
    private GameObject maincamera;

    //カメラ座標を格納
    private Vector3 camerapos;
    private new Renderer renderer;
    

    // Start is called before the first frame update
    void Start()
    {
        //回転を開始する角度を設定
        this.transform.Rotate(0, Random.Range(0, 360), 0);
        //カメラをシーン中から探す
        maincamera = GameObject.Find("Main Camera");
        //test
        renderer = GetComponentInChildren<MeshRenderer>();
        renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //回転
        this.transform.Rotate(0, 3, 0);

        //カメラ座標を検出
        camerapos.z = maincamera.transform.position.z;
        
        //このオブジェクトよりもカメラが奥に行ったとき
        if(this.gameObject.transform.position.z < camerapos.z )
        {
            //このオブジェクトをDestroyする
            Destroy(this.gameObject);
            Debug.Log("Des");
        }

        
    }
    //test
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("WW");
            renderer.enabled = true;
        }
    }


}

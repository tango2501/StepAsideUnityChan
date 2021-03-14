using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    //カメラオブジェクトを格納
    private GameObject maincamera;

    //カメラ座標を格納
    private Vector3 camerapos;

    // Start is called before the first frame update
    void Start()
    {
        //カメラをシーン中から探す
        maincamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //カメラ座標を検出
        camerapos.z = maincamera.transform.position.z;

        //このオブジェクトよりもカメラが奥に行ったとき
        if (this.gameObject.transform.position.z < camerapos.z)
        {
            //このオブジェクトをDestroyする
            Destroy(this.gameObject);
            Debug.Log("Des");
        }
    }
}

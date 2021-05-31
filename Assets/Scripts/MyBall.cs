using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigid;
    public float jumpPower;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update(){
        if(Input.GetButtonDown("Jump")){
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate(){
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h, 0, v);

        rigid.AddForce(vec, ForceMode.Impulse);
    }

    private void OnTriggerStay(Collider other){
        if(other.name == "Cube"){
            rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
    }
}

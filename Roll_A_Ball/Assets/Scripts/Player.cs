using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Rigidbody body;
    public int force = 5;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        body.AddForce(new Vector3(h, 0, v)*force);
        //float step = 0.2f;
        //Vector3 orgPos = transform.localPosition;
        //if (Input.GetKey(KeyCode.A))
        //    transform.localPosition = new Vector3(orgPos.x - step, orgPos.y, orgPos.z);

        //if (Input.GetKey(KeyCode.D))
        //    transform.localPosition = new Vector3(orgPos.x + step, orgPos.y, orgPos.z);
	}
}

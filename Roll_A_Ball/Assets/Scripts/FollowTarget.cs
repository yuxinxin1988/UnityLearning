using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

    public Transform playerTrans;

    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - playerTrans.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = playerTrans.position + offset;
	}
}

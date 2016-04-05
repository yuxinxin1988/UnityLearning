using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

	public GameObject[] outwallArray;
	public GameObject[] floorArray;

	public int rows = 10;
	public int columns = 10;
	// Use this for initialization
	void Start () {
		InitMap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//初始化地图
	void InitMap()
	{
		for (int x = 0; x < columns; x++) 
		{
			for (int y = 0; y < rows; y++) 
			{
				if (x == 0 || y == 0 || x == columns - 1 || y == rows - 1) {
					GameObject curObj = outwallArray [Random.Range (0, outwallArray.Length)];
					GameObject.Instantiate (curObj, new Vector3 (x, y, 0), Quaternion.identity);
				} else {
					GameObject curObj = floorArray [Random.Range (0, floorArray.Length)];
					GameObject.Instantiate (curObj, new Vector3 (x, y, 0), Quaternion.identity);
				}
			}
		}
	}
}

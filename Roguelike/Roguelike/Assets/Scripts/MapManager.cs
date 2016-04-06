using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour {

	public GameObject[] outwallArray;
	public GameObject[] floorArray;
	public GameObject[] wallArray;
	public GameObject[] foodArray;
	public GameObject[] enermyArray;
	public GameObject exitObj;

	public int rows = 10;
	public int columns = 10;

	private Transform mapHolder;
	private List<Vector2> posList = new List<Vector2> ();

	private int minWallCount = 1;
	private int maxWallCount = 10;

	private GameManager gameManager;

	// Use this for initialization
	void Awake () {
		gameManager = this.GetComponent<GameManager> ();
		InitMap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//初始化地图
	void InitMap()
	{
		mapHolder = new GameObject ("Map").transform;
		//创建外围墙和地板
		for (int x = 0; x < columns; x++) 
		{
			for (int y = 0; y < rows; y++) 
			{
				if (x == 0 || y == 0 || x == columns - 1 || y == rows - 1) {
					Vector2 pos = new Vector2 (x,y);
					RandomPrefab (outwallArray, pos);
				} else {
					Vector2 pos = new Vector2 (x, y);
					RandomPrefab (floorArray, pos);
				}
			}
		}

		//存储items位置信息
		posList.Clear ();
		for (int x = 2; x < columns - 2; x++) {
			for (int y = 2; y < rows - 2; y++) {
				posList.Add (new Vector2(x,y));
			}		
		}

		//生成障碍物
		int wallCnt = Random.Range(minWallCount, maxWallCount+1); 
		GenGameItems (wallCnt, wallArray);

		//生成食物 2~level*2
		int foodCnt = Random.Range(2, gameManager.curLevel*2 + 1);
		GenGameItems (foodCnt, foodArray);

		//生成敌人 level/2 
		int enermyCnt = gameManager.curLevel/2 + 1;
		GenGameItems (enermyCnt, enermyArray);

		//exit
		GameObject go = GameObject.Instantiate(exitObj, new Vector3(columns-2, rows-2), Quaternion.identity) as GameObject;
		go.transform.SetParent (mapHolder);
	}

	//生成游戏元素
	private void GenGameItems(int cnt, GameObject[] array)
	{
		for (int i = 0; i < cnt; i++) {
			Vector2 pos = RandomItemPos ();
			RandomPrefab (array, pos);
		}
	}

	//随机生成Item位置
	private Vector2 RandomItemPos()
	{
		int posIndex = Random.Range(0, posList.Count);
		Vector2 pos = posList [posIndex];
		posList.RemoveAt (posIndex);
		return pos;
	}

	//随机生成预设
	private GameObject RandomPrefab(GameObject[] array, Vector2 pos)
	{
		GameObject curObj = array [Random.Range (0, array.Length)];
		GameObject go = GameObject.Instantiate (curObj, new Vector3(pos.x,pos.y,0), Quaternion.identity) as GameObject;
		go.transform.SetParent (mapHolder);
		return go;
	}
}

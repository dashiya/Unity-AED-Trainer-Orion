//フラグ管理用のクラス
//テラシュールブログ
//http://tsubakit1.hateblo.jp/entry/20140530/1401380532  よりお借りしました。

using UnityEngine;
using System.Collections;

public class FlagManager : MonoBehaviour
{
	private static FlagManager instance = null;
	public static FlagManager Instance 
	{
		get{
			if( instance == null){
				instance = FindObjectOfType<FlagManager>();

				if( instance == null )
				{
					instance = new GameObject("FlagManager").AddComponent<FlagManager>();
				}
			}
			return instance;
		}
	}

	void Awake()
	{
		if( Instance == this )
		{
			DontDestroyOnLoad(gameObject);
		}else{
			Destroy (gameObject);
		}
	}

	public bool[] flags = new bool[128];

	[ContextMenu("ResetFlags")]
	public void ResetFlags()
	{
		flags = new bool[flags.Length];
	}
}
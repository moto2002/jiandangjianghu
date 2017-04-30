using LuaFramework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
	public Dictionary<int, GameObject> buffs = new Dictionary<int, GameObject>();

	public List<int> buff_ids = new List<int>();

	public int lastStatusEff
	{
		get;
		set;
	}

	private void Awake()
	{
		this.lastStatusEff = 0;
	}

	private void OnDisable()
	{
		for (int i = 0; i < this.buff_ids.Count; i++)
		{
			this.RemoveBuff(this.buff_ids[i]);
		}
		this.buff_ids.Clear();
		this.buffs.Clear();
		this.lastStatusEff = 0;
	}

	public void AddBuff(int buff_id, int buffEffId)
	{
		GameObject gameObject = null;
		if (buffEffId > 0)
		{
			GameObject original = Util.LoadPrefab("Prefab/skill/buff/" + buffEffId);
			gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
		}
		if (gameObject != null)
		{
			if (buffEffId == 0)
			{
				this.buffs[buff_id] = gameObject;
			}
			else
			{
				this.buffs[buff_id] = gameObject.GetComponent<Buff>().StartBuff(base.gameObject);
			}
		}
		this.buff_ids.Add(buff_id);
	}

	public void RemoveBuff(int buff_id)
	{
		if (this.buffs.ContainsKey(buff_id))
		{
			UnityEngine.Object.Destroy(this.buffs[buff_id]);
			this.buffs.Remove(buff_id);
		}
		if (this.buff_ids.Contains(buff_id))
		{
			this.buff_ids.Remove(buff_id);
		}
	}
}

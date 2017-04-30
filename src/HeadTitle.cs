using LuaFramework;
using System;
using System.Collections.Generic;
using ThirdParty;
using UnityEngine;

public class HeadTitle : MonoBehaviour
{
	private const int FACE_WH = 32;

	private const int BASELINEWIDTH = 58;

	private const int MAXWIDTH = 330;

	private const int X_OFFSET = 68;

	private const int Y_OFFSET = 64;

	public UITable uiTable;

	public UILabel nameLab;

	public UILabel extendLab;

	public UISprite beautyTitleSpr;

	public HeadBloodScript blood;

	public UIPlayTween bubbleTween;

	public UILabel bubbleMsgLab;

	public UISprite bubbleBg;

	private Vector3 offset = new Vector3(0f, 0.1f, 0f);

	private Camera uiCamera;

	private string[] playerNameColors = new string[]
	{
		"[bdf2ff]",
		"[ffeb66]",
		"[ff3e24]"
	};

	private List<Vector3> _eList = new List<Vector3>();

	private string space = "      ";

	public string objName
	{
		get;
		set;
	}

	public Transform Head
	{
		get;
		set;
	}

	public SceneEntity self
	{
		get;
		set;
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void ResetYOffset()
	{
		if (this.self.GetValueByKey("headNameYoffset") != null)
		{
			this.offset.y = Convert.ToSingle(this.self.GetValueByKey("headNameYoffset"));
		}
		else
		{
			this.offset.y = 0.1f;
		}
	}

	public void ShowHideHeadTitle()
	{
		this.blood.self = this.self;
		if (this.self.entityType == RoleManager.EntityType.EntityType_Monster || this.self.entityType == RoleManager.EntityType.EntityType_Lingqi || this.self.entityType == RoleManager.EntityType.EntityType_Partner || this.self.entityType == RoleManager.EntityType.EntityType_Pet)
		{
			base.gameObject.SetActive(false);
			return;
		}
		this.blood.gameObject.SetActive(this.self.entityType != RoleManager.EntityType.EntityType_Npc && this.self.entityType != RoleManager.EntityType.EntityType_Beauty && this.self.entityType != RoleManager.EntityType.EntityType_XunLuo);
		this.LateUpdate();
	}

	private void LateUpdate()
	{
		if (this.uiCamera == null)
		{
			this.uiCamera = GameObject.FindGameObjectWithTag("GuiCamera").GetComponent<Camera>();
		}
		if (this.Head != null)
		{
			base.transform.position = this.WorldToUI(this.Head.position + this.offset);
		}
	}

	public void UpdateHp()
	{
		if (this.blood != null && this.self.maxhp > 0)
		{
			this.blood.updateHp((float)this.self.hp / (float)this.self.maxhp);
		}
	}

	public Vector3 WorldToUI(Vector3 point)
	{
		Vector3 position = Singleton<RoleManager>.Instance.mainCamera.WorldToScreenPoint(point);
		Vector3 result = this.uiCamera.ScreenToWorldPoint(position);
		result.z = 0f;
		return result;
	}

	public void UpdateMood()
	{
		if (this.blood == null)
		{
			return;
		}
		this.blood.UpdateMood();
	}

	public void SetEntityName(string name, int colorType = 0)
	{
		this.objName = name;
		if (this.self.entityType == RoleManager.EntityType.EntityType_Npc)
		{
			this.nameLab.fontSize = 32;
			this.nameLab.text = string.Format("[21f7ff]{0}[-]", name);
		}
		else if (this.self.entityType == RoleManager.EntityType.EntityType_Self)
		{
			this.nameLab.fontSize = 30;
			if (colorType == 0 || colorType == 1)
			{
				this.nameLab.text = string.Format("[ffffff]{0}[-]", name);
			}
			else
			{
				this.nameLab.text = string.Format("{0}{1}[-]", this.playerNameColors[colorType], name);
			}
			if (!string.IsNullOrEmpty(this.self.husongTitle))
			{
				this.SetHusongSprite(this.self.husongTitle);
			}
		}
		else if (this.self.entityType == RoleManager.EntityType.EntityType_Role)
		{
			this.nameLab.fontSize = 30;
			this.nameLab.text = string.Format("{0}{1}[-]", this.playerNameColors[colorType], name);
			if (!string.IsNullOrEmpty(this.self.husongTitle))
			{
				this.SetHusongSprite(this.self.husongTitle);
			}
		}
		else if (this.self.entityType == RoleManager.EntityType.EntityType_Beauty)
		{
			this.nameLab.fontSize = 32;
			this.nameLab.text = string.Format("[21f7ff]{0}[-]", name);
		}
		else if (this.self.entityType == RoleManager.EntityType.EntityType_XunLuo)
		{
			this.nameLab.fontSize = 32;
			this.nameLab.text = string.Format("[21f7ff]{0}[-]", name);
		}
	}

	public void UpdateExtendInfo()
	{
		object valueByKey = this.self.GetValueByKey("clubname");
		if (valueByKey == null || valueByKey.ToString().Length == 0)
		{
			this.extendLab.gameObject.SetActive(false);
		}
		else
		{
			this.extendLab.gameObject.SetActive(true);
			object valueByKey2 = this.self.GetValueByKey("clubpost");
			if (valueByKey2 == null || valueByKey2.ToString().Length == 0)
			{
				this.extendLab.text = string.Format("[63FF97]{0}[-]", valueByKey);
			}
			else
			{
				this.extendLab.text = string.Format("[63FF97]{0}  {1}[-]", valueByKey.ToString(), valueByKey2);
			}
		}
		this.uiTable.repositionNow = true;
	}

	public void SetHusongSprite(string name)
	{
		Util.SetUISprite(this.beautyTitleSpr, "Atlas/husong/husong", name);
	}

	public void ClearHusongTitle()
	{
		this.beautyTitleSpr.spriteName = null;
	}

	public void ShowBubble(string msg)
	{
		this.bubbleTween.gameObject.SetActive(true);
		this.bubbleTween.Play(true);
		this.bubbleMsgLab.text = msg;
		this.bubbleMsgLab.UpdateNGUIText();
		msg = this.ReplaceFace(msg);
		this.bubbleMsgLab.text = msg;
		int num = Mathf.RoundToInt(NGUIText.CalculatePrintedSize(msg, 330).x);
		if (num < 58)
		{
			num = 58;
		}
		this.bubbleMsgLab.width = Mathf.RoundToInt(NGUIText.CalculatePrintedSize(msg, 330).x);
		this.bubbleMsgLab.height = Mathf.RoundToInt(NGUIText.CalculatePrintedSize(msg, 330).y);
		this.bubbleBg.width = num + 68;
		this.bubbleBg.height = Mathf.RoundToInt(NGUIText.CalculatePrintedSize(msg, 330).y) + 64;
		this.DrawFace();
		this.bubbleMsgLab.transform.localPosition = new Vector3(0f, 6.6f, 0f);
		base.Invoke("DelayHideBubble", 2f);
	}

	private void DelayHideBubble()
	{
		this.bubbleTween.Play(false);
	}

	private string ReplaceFace(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		int num = 0;
		int num2 = 0;
		int length = text.Length;
		for (int i = 0; i < length; i++)
		{
			if (text[i] == '#' && i + 4 < length && text[i + 1] == 'e')
			{
				string s = text.Substring(i + 2, 3);
				int num3 = 0;
				Vector3 zero = Vector3.zero;
				if (int.TryParse(s, out num3))
				{
					text = text.Remove(i, 5);
					text = text.Insert(i, this.space);
					length = text.Length;
					int num4 = Mathf.RoundToInt(NGUIText.CalculatePrintedSize(text.Substring(num2, i - num2), 330).x);
					if (num4 + 32 > 302)
					{
						float x = 0f;
						num++;
						num2 = i;
						zero.x = x;
						zero.y = (float)num;
						zero.z = (float)num3;
					}
					else
					{
						float x = (float)num4;
						zero.x = x;
						zero.y = (float)num;
						zero.z = (float)num3;
					}
				}
				if (num3 != 0)
				{
					this._eList.Add(zero);
				}
			}
			else if (i - num2 >= 0)
			{
				float num5 = (float)Mathf.RoundToInt(NGUIText.CalculatePrintedSize(text.Substring(num2, i - num2 + 1), 362).x);
				if (num5 > 330f)
				{
					num2 = i + 1;
					num++;
				}
			}
		}
		return text;
	}

	private void DrawFace()
	{
		int count = this._eList.Count;
		UIAtlas atlas = Util.loadAtlas("Atlas/chat/emotion");
		for (int i = 0; i < count; i++)
		{
			GameObject gameObject = new GameObject("e" + i);
			gameObject.layer = 5;
			UISprite uISprite = gameObject.AddComponent<UISprite>();
			uISprite.atlas = atlas;
			uISprite.spriteName = string.Format("e{0}{1}", this._eList[i].z.ToString("000"), "_01");
			uISprite.width = 32;
			uISprite.height = 32;
			uISprite.depth = this.bubbleMsgLab.depth + 1;
			gameObject.transform.SetParent(this.bubbleMsgLab.transform);
			gameObject.transform.localScale = Vector3.one;
			uISprite.pivot = UIWidget.Pivot.TopLeft;
			gameObject.transform.localPosition = new Vector3(this._eList[i].x, -this._eList[i].y * 32f, 0f);
		}
	}
}

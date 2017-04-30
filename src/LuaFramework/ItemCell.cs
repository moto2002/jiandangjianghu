using System;
using ThirdParty;
using UnityEngine;

namespace LuaFramework
{
	public class ItemCell : MonoBehaviour
	{
		public Transform mParentTrans;

		public static int index;

		public int itemId;

		public bool isChange;

		private Transform mTrans;

		private EndlessScroller table;

		private int width;

		private int height;

		private void Awake()
		{
			this.mTrans = base.transform;
			Transform transform = this.mTrans.FindChild("bg");
			this.width = transform.GetComponent<UIWidget>().width;
			this.height = transform.GetComponent<UIWidget>().height;
			ItemCell.index++;
		}

		private void UpdateTableItem()
		{
			if (this.mParentTrans == null)
			{
				return;
			}
			if (this.table == null)
			{
				this.table = this.mParentTrans.GetComponent<EndlessScroller>();
			}
			Vector3 vector = this.mParentTrans.localPosition + this.mTrans.localPosition;
			if (vector.y > this.table.cellHeight * 4f || vector.y < this.table.cellHeight * -6f || this.isChange)
			{
				base.gameObject.Recycle();
				Util.CallMethod("ITEMLOGIC", "OnBagItemRemoved", new object[]
				{
					this.itemId
				});
			}
		}

		private void Update()
		{
			this.UpdateTableItem();
		}

		public bool IsPointOverItemCell(Vector3 point)
		{
			Vector3 vector = UICamera.currentCamera.WorldToScreenPoint(this.mTrans.position);
			return point.x >= vector.x - (float)this.width * 0.4f && point.x <= vector.x + (float)this.width * 0.4f && point.y >= vector.y - (float)this.height * 0.4f && point.y <= vector.y + (float)this.height * 0.4f;
		}

		private void OnClick()
		{
			Util.CallMethod("ITEMLOGIC", "OnClickItemInfo", new object[]
			{
				this.itemId
			});
		}
	}
}

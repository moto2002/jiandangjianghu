using System;
using UnityEngine;

namespace LuaFramework
{
	public class EndlessScroller : MonoBehaviour
	{
		private Transform mTrans;

		private bool mIsDragging;

		private int mDragTime;

		private Vector3 mDragStartPosition;

		private Vector3 mDragPosition;

		private Vector3 mStartPosition;

		public float mCheckTime;

		public float mDeltaScrollY;

		public float totalHeight;

		public float cellHeight = 135f;

		public float windowHeight = 1000f;

		private Transform emptyTrans;

		private void Awake()
		{
			this.mTrans = base.transform;
		}

		private void Start()
		{
			GameObject gameObject = new GameObject("EmptyObject");
			this.emptyTrans = gameObject.transform;
			this.emptyTrans.parent = base.transform.parent;
		}

		private void Update()
		{
			if (Mathf.Abs(this.mDeltaScrollY) > 0f)
			{
				float num = this.mDeltaScrollY * 0.1f;
				Vector3 vector = this.mTrans.localPosition;
				this.mDeltaScrollY -= num;
				vector -= Vector3.up * num;
				this.mTrans.localPosition = vector;
				this.SetPosition();
			}
		}

		private void SetPosition()
		{
			Vector3 localPosition = this.mTrans.localPosition;
			if (localPosition.y < 0f)
			{
				localPosition.y = 0f;
			}
			float num = (this.totalHeight >= this.windowHeight) ? (this.totalHeight - this.windowHeight) : 0f;
			if (localPosition.y > num)
			{
				localPosition.y = num;
			}
			this.mTrans.localPosition = localPosition;
		}

		private void Drop()
		{
			this.SetPosition();
		}

		private void OnDragEvent()
		{
			this.emptyTrans.position = this.mDragPosition;
			Vector3 localPosition = this.emptyTrans.localPosition;
			this.emptyTrans.position = this.mDragStartPosition;
			Vector3 localPosition2 = this.emptyTrans.localPosition;
			Vector3 vector = localPosition - localPosition2;
			float num = Time.time - this.mCheckTime;
			if (num > 0f)
			{
				this.mDeltaScrollY = vector.y * 0.5f / num;
			}
		}

		private void OnClickEvent()
		{
			ItemCell[] componentsInChildren = base.GetComponentsInChildren<ItemCell>();
			ItemCell itemCell = null;
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].IsPointOverItemCell(UICamera.lastTouchPosition))
				{
					itemCell = componentsInChildren[i];
					break;
				}
			}
			if (itemCell != null)
			{
				itemCell.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
			}
		}

		private void OnDrag(Vector2 delta)
		{
			this.mDragTime++;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.lastTouchPosition);
			float distance = 0f;
			Vector3 point = ray.GetPoint(distance);
			if (UICamera.currentTouchID == -1 || UICamera.currentTouchID == 0)
			{
				if (!this.mIsDragging)
				{
					this.mIsDragging = true;
					this.mDragPosition = point;
				}
				else
				{
					Vector3 vector = this.mStartPosition - (this.mDragStartPosition - point);
					Vector3 position = new Vector3(this.mTrans.position.x, vector.y, this.mTrans.position.z);
					if (position.y < -1E-10f)
					{
						position.y = 0f;
					}
					this.mTrans.position = position;
					if (this.mTrans.localPosition.y >= this.totalHeight - this.windowHeight)
					{
						Vector3 localPosition = new Vector3(this.mTrans.localPosition.x, this.totalHeight - this.windowHeight, this.mTrans.localPosition.z);
						this.mTrans.localPosition = localPosition;
					}
				}
			}
		}

		private void OnPress(bool isPressed)
		{
			if (isPressed)
			{
				this.mDragTime = 0;
			}
			this.mIsDragging = false;
			Collider component = base.GetComponent<Collider>();
			if (component != null)
			{
				Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.lastTouchPosition);
				float distance = 0f;
				this.mDragStartPosition = ray.GetPoint(distance);
				this.mStartPosition = this.mTrans.position;
				component.enabled = !isPressed;
			}
			if (!isPressed)
			{
				if (this.mDragTime == 1)
				{
					this.OnClickEvent();
					this.mDragTime = 0;
				}
				else
				{
					this.OnDragEvent();
				}
			}
			else
			{
				this.mDeltaScrollY = 0f;
				this.mCheckTime = Time.time;
			}
			if (!isPressed)
			{
				this.Drop();
			}
		}
	}
}

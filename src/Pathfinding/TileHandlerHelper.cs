using Pathfinding.Util;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_tile_handler_helper.php")]
	public class TileHandlerHelper : MonoBehaviour
	{
		private TileHandler handler;

		public float updateInterval;

		private float lastUpdateTime = -999f;

		private readonly List<Bounds> forcedReloadBounds = new List<Bounds>();

		public void UseSpecifiedHandler(TileHandler handler)
		{
			this.handler = handler;
		}

		private void OnEnable()
		{
			NavmeshCut.OnDestroyCallback += new Action<NavmeshCut>(this.HandleOnDestroyCallback);
		}

		private void OnDisable()
		{
			NavmeshCut.OnDestroyCallback -= new Action<NavmeshCut>(this.HandleOnDestroyCallback);
		}

		public void DiscardPending()
		{
			List<NavmeshCut> all = NavmeshCut.GetAll();
			for (int i = 0; i < all.Count; i++)
			{
				if (all[i].RequiresUpdate())
				{
					all[i].NotifyUpdated();
				}
			}
		}

		private void Start()
		{
			if (UnityEngine.Object.FindObjectsOfType(typeof(TileHandlerHelper)).Length > 1)
			{
				Debug.LogError("There should only be one TileHandlerHelper per scene. Destroying.");
				UnityEngine.Object.Destroy(this);
				return;
			}
			if (this.handler == null)
			{
				if (AstarPath.active == null || AstarPath.active.astarData.recastGraph == null)
				{
					Debug.LogWarning("No AstarPath object in the scene or no RecastGraph on that AstarPath object");
				}
				this.handler = new TileHandler(AstarPath.active.astarData.recastGraph);
				this.handler.CreateTileTypesFromGraph();
			}
		}

		private void HandleOnDestroyCallback(NavmeshCut obj)
		{
			this.forcedReloadBounds.Add(obj.LastBounds);
			this.lastUpdateTime = -999f;
		}

		private void Update()
		{
			if (this.updateInterval == -1f || Time.realtimeSinceStartup - this.lastUpdateTime < this.updateInterval || this.handler == null)
			{
				return;
			}
			this.ForceUpdate();
		}

		public void ForceUpdate()
		{
			if (this.handler == null)
			{
				throw new Exception("Cannot update graphs. No TileHandler. Do not call this method in Awake.");
			}
			this.lastUpdateTime = Time.realtimeSinceStartup;
			List<NavmeshCut> all = NavmeshCut.GetAll();
			if (this.forcedReloadBounds.Count == 0)
			{
				int num = 0;
				for (int i = 0; i < all.Count; i++)
				{
					if (all[i].RequiresUpdate())
					{
						num++;
						break;
					}
				}
				if (num == 0)
				{
					return;
				}
			}
			bool flag = this.handler.StartBatchLoad();
			for (int j = 0; j < this.forcedReloadBounds.Count; j++)
			{
				this.handler.ReloadInBounds(this.forcedReloadBounds[j]);
			}
			this.forcedReloadBounds.Clear();
			for (int k = 0; k < all.Count; k++)
			{
				if (all[k].enabled)
				{
					if (all[k].RequiresUpdate())
					{
						this.handler.ReloadInBounds(all[k].LastBounds);
						this.handler.ReloadInBounds(all[k].GetBounds());
					}
				}
				else if (all[k].RequiresUpdate())
				{
					this.handler.ReloadInBounds(all[k].LastBounds);
				}
			}
			for (int l = 0; l < all.Count; l++)
			{
				if (all[l].RequiresUpdate())
				{
					all[l].NotifyUpdated();
				}
			}
			if (flag)
			{
				this.handler.EndBatchLoad();
			}
		}
	}
}

using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Utils
{
	public static class Util
	{
		public static bool CompareLayer(this RaycastHit raycastHit, string layerName)
		{
			return raycastHit.collider.gameObject.layer.Equals(LayerMask.NameToLayer(layerName));
		}

		public static bool CompareLayer(this GameObject gameObject, string layerName)
		{
			return gameObject.layer.Equals(LayerMask.NameToLayer(layerName));
		}

		public static bool CompareLayer(this Collider collider, string layerName)
		{
			return collider.gameObject.layer.Equals(LayerMask.NameToLayer(layerName));
		}

		public static GameObject SelectFirstOrNullByLayers(this Collider[] colliders, List<LayerMask> layerMasks)
		{
			GameObject result = null;
			for (int i = 0; i < layerMasks.Count; i++)
			{
				for (int j = 0; j < colliders.Length; j++)
				{
					if (1 << colliders[j].gameObject.layer == layerMasks[i])
					{
						return colliders[j].gameObject;
					}
				}
			}
			return result;
		}
	}
}

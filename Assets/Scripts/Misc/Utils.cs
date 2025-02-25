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

		public static GameObject SelectFirstOrDefaultByLayers(this Collider[] colliders, List<LayerMask> layerMasks)
		{
			GameObject result = null;
			for (int i = 0; i < colliders.Length; i++)
			{
				for (int j = 0; j < layerMasks.Count; j++)
				{
					if (1 << colliders[i].gameObject.layer == layerMasks[j])
					{
						return colliders[i].gameObject;
					}
				}
			}
			return result;
		}
	}
}

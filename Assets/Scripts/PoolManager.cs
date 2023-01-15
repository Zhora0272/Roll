using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    private static List<MeshFilter> meshFilters;

    static PoolManager()
    {
        meshFilters = new List<MeshFilter>();
    }
    public static MeshFilter GetMashFilter(MeshFilter prefab, Transform parent = null)
    {
        /* foreach (var item in meshFilters)
         {
             if(!item.gameObject.activeInHierarchy)
             {
                 return item;
             }
         }
 */
        var meshFilter = GameObject.Instantiate(prefab, parent);
        meshFilters.Add(meshFilter);
        return meshFilter;
    }
}


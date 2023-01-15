using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SpiralPointGenerate : MonoBehaviour
{
    [SerializeField] List<Transform> cubePoints;

    [SerializeField] private MeshFilter meshFilter;

    private Mesh mesh;

    public List<Vector3> vertecs;
    public int[] triangles;

    private void Update()
    {
        mesh = new Mesh();
        meshFilter.mesh = mesh;

        GenerateMesh();
        UpdateMesh();
    }

    private void GenerateMesh()
    {
        vertecs.Clear();

      /*  for (int i = 1; i < 15; i++)
        {
            vertecs.Add(new Vector3(0, 0, 0) * i);
            vertecs.Add(new Vector3(0, 0, 1) * i);
            vertecs.Add(new Vector3(1, 0, 0) * i);
            vertecs.Add(new Vector3(1, 0, 1) * i);
        }*/

        vertecs.Add(new Vector3(0, 0, 0));
        vertecs.Add(new Vector3(0, 0, 1)); 
        vertecs.Add(new Vector3(0, 0, 2)); 

        vertecs.Add(new Vector3(1, 0, 0));
        vertecs.Add(new Vector3(1, 0, 1)); 
        vertecs.Add(new Vector3(1, 0, 2));

        triangles = new int[]
        {
           0,1,3,  
           1,4,3
        };
    }

    private void UpdateMesh()
    {
        mesh.vertices = vertecs.ToArray();
        mesh.triangles = triangles;
    }
}

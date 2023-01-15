using UnityEngine;

public class CloseMeshOpenZones : MonoBehaviour
{
    [SerializeField] private Transform[] transform;
    private Vector3[] vertecs;
    private int[] triangles;
    [SerializeField] private MeshFilter _prefab;
    private Mesh mesh;

    private void GenerateMesh()
    {
        var meshFilter = Instantiate(_prefab);
        mesh = new Mesh();
        meshFilter.mesh = mesh;

        vertecs = new Vector3[]
        {
            transform[0].position,
            transform[1].position,
            transform[2].position,
            transform[3].position,
        };

        triangles = new int[]
        {
            2,1,0,
            3,2,0
        };
    }

    private void Start()
    {
        GenerateMesh();
        UpdateMesh();
    }

    private void UpdateMesh()
    {
        mesh.vertices = vertecs;
        mesh.triangles = triangles;
    }
}

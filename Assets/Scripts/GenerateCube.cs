using UnityEngine;

public class GenerateCube : MonoBehaviour
{
    [SerializeField] private PoolManager poolManager;
    [SerializeField] private float _spaceFix;
    [SerializeField] private Transform LB;
    [SerializeField] private Transform RB;

    private int _index = 1;
    private Vector3 LastLB;
    private Vector3 LastRB;

    [SerializeField] private Transform _parent;
    [SerializeField] private MeshFilter prefab;
    private MeshFilter LastObjectPrefab;
    private MeshFilter currentMeshFilter;

    private Mesh mesh;

    public Vector3[] vertecs;
    public Vector2[] uvs;
    public int[] triangles;

    private void Awake()
    {
        LastLB = LB.position - _parent.position;
        LastRB = RB.position - _parent.position;
    }

    private void GenerateMesh()
    {
        if (currentMeshFilter)
        {
            LastObjectPrefab = currentMeshFilter;
            LastLB = LastObjectPrefab.transform.localPosition + LastObjectPrefab.mesh.vertices[0];
            LastRB = LastObjectPrefab.transform.localPosition + LastObjectPrefab.mesh.vertices[3];
        }

        currentMeshFilter = PoolManager.GetMashFilter(prefab, _parent);//Instantiate(prefab, _parent);
        mesh = new Mesh();
        currentMeshFilter.mesh = mesh;

        vertecs = new Vector3[]
        {
            LB.position - _parent.position,
            LastLB,
            LastRB,
            RB.position - _parent.position,
        };

        triangles = new int[]
        {
            2,1,0,
            3,2,0
        };

        uvs = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0),
        };
    }

    private void Update()
    {
        GenerateMesh();
    }

    private void LateUpdate()
    {
        UpdateMesh();
    }

    private void UpdateMesh()
    {
        mesh.vertices = vertecs;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }
}

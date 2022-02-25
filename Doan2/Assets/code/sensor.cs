using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour
{
    public float distance = 10;
    public float angle = 30;
    public float height = 1.0f;
    public Color meshcolor = Color.green;

    Mesh mesh;
    // Update is called once per frame
    void Update()
    {
        
    }
    Mesh CreateMesh()
    {
  
        Mesh mesh = new Mesh();
        int numTriangles = 8;
        int numVertices = numTriangles * 3;
        Vector3[] vertices =new Vector3[numVertices];
         int[] triangles = new int[numTriangles];

        Vector3 bottomcenter = Vector3.zero;
        Vector3 bottomleft =Quaternion.Euler(0, -angle, 0)*Vector3.forward*distance;
        Vector3 bottomright = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

        Vector3 topcenter = bottomcenter + Vector3.up * height;
        Vector3 topright = bottomright + Vector3.up * height;
        Vector3 topleft = bottomleft +Vector3.up * height;
        int vert = 0;

        //left

        vertices[vert++] = bottomcenter;
        vertices[vert++] = bottomleft;
        vertices[vert++] = topleft;

        vertices[vert++] = topleft;
        vertices[vert++] = topcenter;
        vertices[vert++] = bottomcenter;

        //right

        vertices[vert++] = bottomcenter;
        vertices[vert++] = topcenter;
        vertices[vert++] = topright;

        vertices[vert++] = topright;
        vertices[vert++] = bottomright;
        vertices[vert++] = bottomcenter;


        
        //far side
        vertices[vert++] = bottomleft;
        vertices[vert++] = bottomright;
        vertices[vert++] = topright;

        vertices[vert++] = topright;
        vertices[vert++] = topleft;
        vertices[vert++] = bottomleft;
        //top 

        vertices[vert++] = topcenter;
        vertices[vert++] = topleft;
        vertices[vert++] = topright;
        //bottom
        vertices[vert++] = bottomcenter;
        vertices[vert++] = bottomright;
        vertices[vert++] = bottomleft;

        for (int i = 0; i < numVertices; i++)
        {
            triangles[i] = i;
            
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();



        return mesh;
    }
    private void OnValidate()
    {
        mesh = CreateMesh();
    }
    private void OnDrawGizmos()
    {
        if (mesh)
        {
            Gizmos.color = meshcolor;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);

        }
    }
}
        

using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public partial class Cube : MeshInstance3D
{

    List<Vector3> quadVertices;
    List<int> quadIndices;
    Dictionary<Vector3, int> dictQuadVerts;
    const float CUBE_SIZE = 0.5f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // TODO colors
        quadVertices = new List<Vector3>();
        quadIndices = new List<int>();
        dictQuadVerts = new Dictionary<Vector3, int>();

        var st = new SurfaceTool();
        st.Begin(Mesh.PrimitiveType.Triangles);

        var vert_north_topright = new Vector3(-CUBE_SIZE, CUBE_SIZE, CUBE_SIZE);
        var vert_north_topleft = new Vector3(CUBE_SIZE, CUBE_SIZE, CUBE_SIZE);
        var vert_north_bottomleft = new Vector3(CUBE_SIZE, CUBE_SIZE, -CUBE_SIZE);
        var vert_north_bottomright = new Vector3(-CUBE_SIZE, CUBE_SIZE, -CUBE_SIZE);

        var vert_south_topright = new Vector3(-CUBE_SIZE, -CUBE_SIZE, CUBE_SIZE);
        var vert_south_topleft = new Vector3(CUBE_SIZE, -CUBE_SIZE, CUBE_SIZE);
        var vert_south_bottomleft = new Vector3(CUBE_SIZE, -CUBE_SIZE, -CUBE_SIZE);
        var vert_south_bottomright = new Vector3(-CUBE_SIZE, -CUBE_SIZE, -CUBE_SIZE);

        AddQuad(vert_south_topright, vert_south_topleft, vert_south_bottomleft, vert_south_bottomright);
        AddQuad(vert_north_topright, vert_north_bottomright, vert_north_bottomleft, vert_north_topleft);

        AddQuad(vert_north_bottomleft, vert_north_bottomright, vert_south_bottomright, vert_south_bottomleft);
        AddQuad(vert_north_topleft, vert_south_topleft, vert_south_topright, vert_north_topright);

        AddQuad(vert_north_topright, vert_south_topright, vert_south_bottomright, vert_north_bottomright);
        AddQuad(vert_north_topleft, vert_north_bottomleft, vert_south_bottomleft, vert_south_topleft);

        foreach (var vertex in quadVertices)
        {
            st.AddVertex(vertex);
        }

        foreach (var index in quadIndices)
        {
            st.AddIndex(index);
        }

        st.Commit(this.Mesh as ArrayMesh);
        Debug.WriteLine("Mesh generated {0}", Newtonsoft.Json.JsonConvert.SerializeObject(this.Mesh.GetFaces()));
    }

    private void AddQuad(Vector3 point_1, Vector3 point_2, Vector3 point_3, Vector3 point_4)
    {
        var vertex_index_one = AddVertexAndGetIndex(point_1);
        var vertex_index_two = AddVertexAndGetIndex(point_2);
        var vertex_index_three = AddVertexAndGetIndex(point_3);
        var vertex_index_four = AddVertexAndGetIndex(point_4);

        quadIndices.Add(vertex_index_one);
        quadIndices.Add(vertex_index_two);

        quadIndices.Add(vertex_index_three);

        quadIndices.Add(vertex_index_one);

        quadIndices.Add(vertex_index_three);
        quadIndices.Add(vertex_index_four);
    }

    private int AddVertexAndGetIndex(Vector3 vertex)
    {
        if (dictQuadVerts.ContainsKey(vertex))
        {
            return dictQuadVerts[vertex];
        }
        else
        {
            quadVertices.Add(vertex);

            dictQuadVerts[vertex] = quadVertices.Count - 1;
            return quadVertices.Count - 1;
        }
    }
}

using Godot;
using System.Diagnostics;

public partial class TriangleFan : MeshInstance3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var st = new SurfaceTool();
		
		st.Begin(Mesh.PrimitiveType.Triangles);

        st.AddTriangleFan(new Vector3[]
        {
            new(0, 0, 0),
            new(-1, 0, 0),
            new(-0.5f, -1, 0),
            new(0.5f, -1, 0),
            new(1, 0, 0),
            new(0.5f, 1, 0),
            new(-0.5f, 1, 0),
            new(-1, 0, 0)

        }, null,
        new Color[]
        {
            new(0, 0, 1, 1),
            new(1, 0, 0, 1),
            new(0, 1, 0, 1),
            new(0, 0, 1, 1),
            new(1, 0, 1, 1),
            new(1, 1, 0, 1),
            new(1, 1, 1, 1),
            new(0, 1, 1, 1)
        },null,
        new Vector3[]
        {
            new(0, 0, -1),
            new(0, 0, -1),
            new(0, 0, -1),
            new(0, 0, -1),
            new(0, 0, -1),
            new(0, 0, -1),
            new(0, 0, -1),
            new(0, 0, -1)
        });

		st.Commit(this.Mesh as ArrayMesh);
		Debug.WriteLine("Mesh generated {0}", Newtonsoft.Json.JsonConvert.SerializeObject(this.Mesh.GetFaces()));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

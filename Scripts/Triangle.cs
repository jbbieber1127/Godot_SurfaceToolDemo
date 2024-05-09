using Godot;
using System.Diagnostics;

public partial class Triangle : MeshInstance3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var st = new SurfaceTool();
		
		st.Begin(Mesh.PrimitiveType.Triangles);

		//st.SetUV(new Vector2(0, 1));
		
		st.SetNormal(new Vector3(0, 0, -1));
		st.SetColor(new Color(0, 0, 1, 1));
		st.AddVertex(new Vector3(-1, 2, 1));

		st.SetNormal(new Vector3(0, 0, -1));
		st.SetColor(new Color(1, 0, 0, 1));
		st.AddVertex(new Vector3(-1, 0, 1));

		st.SetNormal(new Vector3(0, 0, -1));
		st.SetColor(new Color(1, 0, 0, 1));
		st.AddVertex(new Vector3(1, 0, -1));


		st.AddIndex(0);
		st.AddIndex(1);
		st.AddIndex(2);


		st.Commit(this.Mesh as ArrayMesh);
		Debug.WriteLine("Mesh generated {0}", Newtonsoft.Json.JsonConvert.SerializeObject(this.Mesh.GetFaces()));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

using UnityEngine;
using System.Collections;
using Giverspace; // Needed to get access to logging

[RequireComponent (typeof(MatrixBlender))]
public class PerspectiveSwitcher : Ability
{
	Camera camera;
	private Matrix4x4   ortho,
	perspective;
	public float        
	fov     = 60f,
	near    = .3f,
	far     = 1000f,
	orthographicSize = 50f;
	private float       aspect;
	private MatrixBlender blender;
	private bool        orthoOn;
	
	void Start()
	{
		camera = GetComponent<Camera>();
		aspect = (float) Screen.width / (float) Screen.height;
		ortho = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, near, far);
		perspective = Matrix4x4.Perspective(fov, aspect, near, far);
		camera.projectionMatrix = ortho;
		orthoOn = true;
		blender = (MatrixBlender) GetComponent(typeof(MatrixBlender));
	}
	
	public void switchPerspective(){
		if(true)
		{
			orthoOn = !orthoOn;
			powerTracker.power[0] = !orthoOn;
			if (orthoOn){

				blender.BlendToMatrix(ortho, 3f, true);
			}
			else{
				blender.BlendToMatrix(perspective, 3f, false);
			}
		}

		else{
			Debug.Log("Button is not ready yet");
		}
	}

    public override void Activate()
    {
        switchPerspective();
    }
}
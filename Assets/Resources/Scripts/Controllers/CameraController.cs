using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 MovementSpeed = new Vector3(1, 1, 1);
    public Vector2 LookSpeed = new Vector2(1, 1);

    public float LookMinY = -80.0f;
    public float LookMaxY = 80.0f;

    public Camera Camera;

    private CameraControls m_controls;


	// Use this for initialization
	void Start ()
    {
		m_controls = new CameraControls();
    }
	
	void FixedUpdate ()
	{
	    var movement = new Vector3();

	    movement += MovementSpeed.x * m_controls.MoveXZ.X * Camera.transform.right;
	    movement += MovementSpeed.y * m_controls.MoveY.Value * Camera.transform.up;
	    movement += MovementSpeed.z * m_controls.MoveXZ.Y * Camera.transform.forward;
        
	    transform.position += movement;

        transform.Rotate(transform.up, LookSpeed.x * m_controls.Look.X);

        var vertAngle = Camera.transform.eulerAngles.x;
        vertAngle += m_controls.Look.Y * LookSpeed.y;

        if (vertAngle <= 180.0f && vertAngle > -LookMinY)
        {
            vertAngle = -LookMinY;
        }

        if (vertAngle >= 180.0f && vertAngle < (360 - LookMaxY))
        {
            vertAngle = 360 - LookMaxY;
        }

        Camera.transform.rotation = Quaternion.Euler(new Vector3(vertAngle, Camera.transform.eulerAngles.y, Camera.transform.eulerAngles.z));
    }
}

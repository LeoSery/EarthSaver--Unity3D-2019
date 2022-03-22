using UnityEngine;
//
#pragma warning disable 0108
#pragma warning disable 0649
//
public class Chair : MonoBehaviour
{
	public Vector3 target;
	public float speed = 0.5f;
	public GameObject explosion;

	Rigidbody rigidbody;
	Camera camera;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		camera = GetComponentInChildren<Camera>();
	}

	private void FixedUpdate()
	{
		rigidbody.AddForce((target - transform.position) * speed);
		transform.LookAt(target);
    }

	private void OnCollisionEnter(Collision other)
	{
		Destroy(this.gameObject, 0.05f);

		Vector3 dir = (target - transform.position).normalized;

		RaycastHit hit;
		Ray ray = new Ray(transform.position, dir * 1000);

		if(Physics.Raycast(ray, out hit, 1000))
		{
			Color color = Color.black;
			Camera cam = camera;

			RenderTexture rdT = RenderTexture.active;

			RenderTexture newRdt = new RenderTexture(1, 1, 16, RenderTextureFormat.ARGB32);
			newRdt.Create();
			cam.targetTexture = newRdt;

			RenderTexture.active = cam.targetTexture;
			OnPreCull();
			cam.Render();
			OnPostRender();

			Texture2D image = new Texture2D(cam.targetTexture.width, cam.targetTexture.height);
			image.ReadPixels(new Rect(0, 0, cam.targetTexture.width, cam.targetTexture.height), 0, 0);
			image.Apply();

			image.ReadPixels(new Rect(0, 0, cam.targetTexture.width, cam.targetTexture.height), 0, 0);
			image.Apply();

			RenderTexture.active = rdT;

			color = image.GetPixel(image.width / 2, image.height / 2);

			if(color.r != 0.00f)
			{
				GameObject g = Instantiate(explosion, transform.position, Quaternion.identity);
			    g.transform.parent = (other.transform.GetChild(0).transform);
				GameObject.Find("LifeManager").GetComponent<LifeManager>().TakeDamage(5);
			}
		}
	}
	

	 void OnPreCull()
	 {
         GameObject earth = GameObject.FindGameObjectWithTag("Earth");
		 GameObject sea = earth.transform.GetChild(0).gameObject;
		 Shader unlitShader = Shader.Find("Unlit/Color");

		 earth.GetComponent<Renderer>().material.shader = unlitShader;
		 sea.GetComponent<Renderer>().material.shader = unlitShader;

     }
     
     void OnPostRender()
	 {
         GameObject earth = GameObject.FindGameObjectWithTag("Earth");
		 GameObject sea = earth.transform.GetChild(0).gameObject;
		 Shader litShader = Shader.Find("Standard");

		 earth.GetComponent<Renderer>().material.shader = litShader;
		 sea.GetComponent<Renderer>().material.shader = litShader;
     }
}

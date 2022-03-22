using UnityEngine;
//
#pragma warning disable 0108
#pragma warning disable 0649
//
public class PlanetRotator : MonoBehaviour
{
     public float MouseSensitivity;
     public float KeyboardSensitivity;
     private Vector3 _mouseReference;
     private Vector3 _mouseOffset;
     private Vector3 _rotation;
     private bool _isRotating;
     public static bool GameIsRun = false;
     private Animation EarthRotation;
     public Menu Menu;

    void Start ()
     {
        EarthRotation = GetComponent<Animation>();
         _rotation = Vector3.zero;
     }
     
     void Update()
     {
        if (Camera.main.transform.position.z == -4)
            GameIsRun = true;

        if (GameIsRun == false)
        {
            EarthRotation.Play();
        }
        else
        {
            EarthRotation.Stop();
            if (Menu.IsGameOver == false && Menu.GameIsPaused == false)
            {
                if (_isRotating)
                {
                    _mouseOffset = (Input.mousePosition - _mouseReference);

                    _rotation.y = -(_mouseOffset.x) * MouseSensitivity * 0.3f;
                    _rotation.x = (_mouseOffset.y) * MouseSensitivity * 0.3f;

                    _rotation.y += Input.GetAxisRaw("Horizontal") * KeyboardSensitivity * 0.3f;
                    _rotation.x += Input.GetAxisRaw("Vertical") * KeyboardSensitivity * 0.3f;
                    transform.Rotate(_rotation, Space.World);

                    _mouseReference = Input.mousePosition;
                }
                else
                {
                    _rotation.y = -Input.GetAxisRaw("Horizontal") * KeyboardSensitivity * 0.3f;
                    _rotation.x = Input.GetAxisRaw("Vertical") * KeyboardSensitivity * 0.3f;
                    transform.Rotate(_rotation, Space.World);
                }
            }
        }
     }
     
     void OnMouseDown()
     {
         _isRotating = true;
         _mouseReference = Input.mousePosition;
     }
     
     void OnMouseUp()
     {
         _isRotating = false;
     }
}

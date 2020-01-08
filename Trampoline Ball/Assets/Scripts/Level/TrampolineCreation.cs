using System;
using UnityEngine;

namespace Level
{
    
    public class TrampolineCreation : MonoBehaviour
    {
        
        private Vector3 _startingPosition = new Vector3(0,0,0);

        private GameObject _currentCube;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var pos = Input.mousePosition;
                pos.z = 10;
                pos = Camera.main.ScreenToWorldPoint(pos);
                _startingPosition = pos;

                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.localScale = new Vector3(cube.transform.localScale.x, (float) 0.25, cube.transform.localScale.z);
                cube.transform.position = pos;
                cube.SetActive(false);
                _currentCube = cube;
            }
            else if (Input.GetMouseButton(0))
            {
                
                var pos = Input.mousePosition;
                pos.z = 10;
                pos = Camera.main.ScreenToWorldPoint(pos);

                if (pos != _startingPosition)
                {
                    var cube = _currentCube;
                    cube.transform.position = pos;

                    double angle = Mathf.Atan(pos.x - _startingPosition.x / pos.y - _startingPosition.y) *
                                   Mathf.Rad2Deg;
                    cube.transform.rotation = Quaternion.Euler(0, 0, (float) angle);

                    var between = pos - _startingPosition;
                    var distance = between.magnitude;
                    cube.transform.localScale =
                        new Vector3(cube.transform.localScale.x, cube.transform.localScale.y, distance);
                    cube.transform.position = _startingPosition + (between / (float) 2.0);
                    cube.transform.LookAt(pos);
                    cube.SetActive(true);
                }
            }else if (Input.GetMouseButtonUp(0))
            {
                var cube = _currentCube;
                DestroyImmediate(cube.GetComponent<BoxCollider>());
                Rigidbody2D cubeRigidbody2D = cube.AddComponent<Rigidbody2D>();
                cubeRigidbody2D.bodyType = RigidbodyType2D.Static;
                BoxCollider2D cubeCollider = cube.AddComponent<BoxCollider2D>();
                ;
            }
        }
    }
}

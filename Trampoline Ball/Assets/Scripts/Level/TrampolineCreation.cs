using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Level
{
    
    public class TrampolineCreation : MonoBehaviour
    {
        
        private Vector3 _startingPosition = new Vector3(0,0,-1);

        public PhysicsMaterial2D trampMaterial;
        

        private GameObject _currentCube;

        private LevelHandler lvlHandler;

        private List<BoxCollider2D> tramps = new List<BoxCollider2D>();
        // Start is called before the first frame update
        void Start()
        {
            lvlHandler = GetComponent<LevelHandler>();
        }

        // Update is called once per frame
        void Update()
        {
            if (lvlHandler.deletionEnabled)
            {
                
                if (Input.GetMouseButton(0))
                {
                    
                    var pos = Input.mousePosition;
                    pos.z = 9;
                    pos = Camera.main.ScreenToWorldPoint(pos);
                   // Debug.Log("Mouse Position: "+pos);
                    foreach (var tramp in tramps)
                    {
                       // Debug.Log("Tramp Bounds: "+tramp.bounds);
                        if (tramp.bounds.Contains(pos))
                        {
                            Debug.Log("Hit a tramp in deletion mode. Tramp Pos: "+ tramp.bounds + " Mouse Pos: " + pos);
                            tramps.Remove(tramp);
                            Destroy(tramp.gameObject);
                            break;

                        }
                    }
                }
        }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var pos = Input.mousePosition;
                    pos.z = 10;
                    pos = Camera.main.ScreenToWorldPoint(pos);
                    _startingPosition = pos;

                    var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.localScale = new Vector3(cube.transform.localScale.x, (float) 0.25,
                        cube.transform.localScale.z);
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

                        double angle = Mathf.Atan2(pos.y - _startingPosition.y, pos.x - _startingPosition.x) *
                                       Mathf.Rad2Deg;
                        cube.transform.rotation = Quaternion.Euler(0, 0, (float) angle);

                        var between = pos - _startingPosition;
                        var distance = between.magnitude;
                        cube.transform.localScale =
                            new Vector3(distance, cube.transform.localScale.y, cube.transform.localScale.z);
                        cube.transform.position = _startingPosition + (between / (float) 2.0);
                        cube.SetActive(true);
                    }
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    var cube = _currentCube;
                    DestroyImmediate(cube.GetComponent<BoxCollider>());
                    var cubeRigidbody2D = cube.AddComponent<Rigidbody2D>();
                    cubeRigidbody2D.bodyType = RigidbodyType2D.Static;
                    var cubeCollider = cube.AddComponent<BoxCollider2D>();
                    cube.GetComponent<BoxCollider2D>().sharedMaterial = trampMaterial;
                    //var collSize = new Vector2(cube.transform.localScale.z, cube.transform.localScale.y);
                    //cubeCollider.size = collSize;
                    cube.AddComponent<TrampCollisionHandler>();
                    cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y, -1);
                    
                    tramps.Insert(0, cubeCollider);
                    Debug.Log(tramps.Count);
                }
            }
        }
    }
}

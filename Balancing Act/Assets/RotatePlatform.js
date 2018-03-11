#pragma strict

var speed : float; //how fast the object should rotate
 
  function Update(){
      transform.Rotate(Vector3(-Input.GetAxis("Mouse Y"), 0.0, Input.GetAxis("Mouse X")) * Time.deltaTime * speed, Space.World);
  }
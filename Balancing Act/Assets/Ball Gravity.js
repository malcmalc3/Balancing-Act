#pragma strict

var jumpSpeed : float;
var thrust : float;
var isFalling : boolean=true;
var gravityX : float;
var gravityZ : float;

function Start()
{
    ChangeGravity();
}

function ChangeGravity()
{
    yield WaitForSeconds(5);
    gravityX += (Random.value * 2) - 1;
    gravityZ += (Random.value * 2) - 1;
    Physics.gravity = new Vector3(gravityX,-10f,gravityZ);
}

function Update()
{
    var controller : CharacterController = GetComponent.<CharacterController>();
    
    
    if(Input.GetButtonDown("Jump") && !isFalling)
    {
        GetComponent.<Rigidbody>().velocity.y=jumpSpeed;
    }
    isFalling = true;

    GetComponent.<Rigidbody>().AddForce(transform.forward * thrust);

}

function OnCollisionStay(collisionInfo : Collision) 
    {
        //we are on something
        isFalling=false;
    }
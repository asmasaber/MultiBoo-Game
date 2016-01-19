using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class player8controoler : MonoBehaviour {
	[HideInInspector]
	public bool facingRight = true;
	public float speed;
	public GUIText counterText2 ;
	public Texture btnTexture   ;
	
	
	
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	//Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	
	private int Count ;
	public GUIText CountText2;
	public GUIText WinText2 ;
	public GUIStyle CurrentStart;
	string[] EQ = new string[9] {" 9*1 " , " 9*2 " , " 9*3 " , " 9*4 " , "9*5" ,"9*6" , "9*7" , "9*8" , "9*9" };
	
	int[] result =new int[] { 9*1 , 9*2, 9*3 , 9*4 , 9*5 , 9*6 , 9*7 ,9*8 ,9*9 };

	int i = 0 ;
	
	void Awake ()
	{
		// Create a layer mask for the floor layer.
		//floorMask = LayerMask.GetMask ("Floor");
		
		// Set up references.
		//anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}
	
	
	// Use this for initialization
	void Start ()
	{
		
		counterText2.text = " ";
		WinText2.text = "";
		CountText2.text = EQ [i];
		Count = 0;
		//StartCount ();
	}
	void OnGUI () {
		
		// Make the second button.
		if(GUI.Button(new Rect(Screen.width-300 ,10,300,150), btnTexture)) {
			checkresult() ;
		}
		
		
	}
	void Update ()
	{
				if (Input.GetKeyDown ("escape")) {//When a key is pressed down it see if it was the escape key if it was it will execute the code
						Application.Quit (); // Quits the game
				}
		}
	void FixedUpdate ()
	{
		WinText2.text = " ";
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		//Vector3 movement=new Vector3( moveHorizontal , 0.0f ,moveVertical);
		
		//rigidbody.velocity = movement * speed;
		// Move the player around the scene.
		Move (moveHorizontal,moveVertical);
		// Turn the player to face the mouse cursor.
		//Turning ();
		// Animate the player.
		//Animating (moveHorizontal,moveVertical);
		
		
	}
	void OnTriggerEnter ( Collider other  ) 
	{
		WinText2.text = " ";
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			Count= Count+1;
			//StartCount ();
			counterText2.text = "Count : " + Count.ToString ();
			
		}
	}
	
	void checkresult()
	{
		WinText2.text = " ";
		if (Count == result [i]) {
			WinText2.text = "YOU WIN";
			
			Count = 0;
			i++;
			next ();
			
		} else {
			WinText2.text = "Try Again";
			
			Count = 0;
		}
		
	}
	
	
	void next ()
	{
		
		counterText2.text = "Count : " + Count.ToString ();
		CountText2.text = EQ [i];
		if ( i == 9)
		{
			WinText2.text = "con";
			// load new level
			if (GUI.Button (new Rect (150, 300 , 130, 70), " Table 8  ")) {
				Application.LoadLevel ("8");
			}
			
		}
	}
	void Move (float h, float v)
	{
		// Set the movement vector based on the axis input.
		movement.Set (h, 0f, v);
		
		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;
		
		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);
	}
	
	
	/*void Animating (float h, float v)
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		bool walking = h != 0f || v != 0f;
		
		// Tell the animator whether or not the player is walking.
		anim.SetBool ("IsWalking", walking);
	}*/
}
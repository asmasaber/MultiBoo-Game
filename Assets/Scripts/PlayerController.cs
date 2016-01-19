using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	[HideInInspector]
	public bool facingRight = true;
	public float speed;
	public GUIText counterText ;
	public Texture btnTexture   ;
	public Texture rtrueTexture   ;
	public Texture rfalseTexture   ;


	Vector3 movement;                   // The vector to store the direction of the player's movement.
	//Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.

	private int Count ;
	public GUIText CountText;
	public GUIText WinText ;
	public GUIStyle CurrentStart;
	string[] EQ = new string[9] {" 2*1 " , " 2*2 " , " 2*3 " , " 2*4 " , "2*5" ,"2*6" , "2*7" , "2*8" , "2*9" };
	
	int[] result = new int[] {2 , 4 , 6 , 8 , 10 , 12 ,14 ,16 ,18 };
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

		counterText.text = " ";
		WinText.text = "";
		CountText.text = EQ [i];
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
		WinText.text = " ";
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
		WinText.text = " ";
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			Count= Count+1;
			//StartCount ();
			counterText.text = "Count : " + Count.ToString ();

		}
	}

	void checkresult()
	{
		WinText.text = " ";
		if (Count == result [i]) {
			WinText.text = "YOU WIN";
			GUI.Button(new Rect(Screen.width-300 ,10,300,150), rtrueTexture );
			Count = 0;
			i++;
			next ();

		} else {
			WinText.text = "Try Again";
			GUI.Button(new Rect(Screen.width-700  ,70,300,150), rfalseTexture ) ;
			Count = 0;
		}

	}


	void next ()
	{

		counterText.text = "Count : " + Count.ToString ();
		CountText.text = EQ [i];
		if ( i == 9)
		{

			WinText.text = "con";
			// load new level
			if (GUI.Button (new Rect (150, 300 , 130, 70), " Table 3  ")) {
				Application.LoadLevel ("2");
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

using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {
	public Texture2D baTexture;

	// Use this for initialization
	void Start () {
	
	}
		void OnGUI()
		{
			
				
			
			
				//Display Game Logo
				GUI.Label (new Rect (Screen.width / 2 - baTexture.width / 2, 20, baTexture.width, baTexture.height), baTexture);
				//Display buttons
		if (GUI.Button (new Rect (100, 200 , 130, 70), "2  لودـــج  ")) {
			             Application.LoadLevel ("1");
				}
		if (GUI.Button (new Rect (100, 300 , 130, 70), "   3  لودـــج   ")) {
			Application.LoadLevel ("2");
		}
		if (GUI.Button (new Rect (100, 400 , 130, 70), "  4  لودـــج  ")) {
			Application.LoadLevel ("3");
		}


		if (GUI.Button (new Rect (500, 200 , 130, 70), " 5  لودـــج   ")) {
			Application.LoadLevel ("4");
		}
		if (GUI.Button (new Rect (500, 300 , 130, 70), " 6  لودـــج")) {
			Application.LoadLevel ("5");
		}
		if (GUI.Button (new Rect (500, 400 , 130, 70), "7  لودـــج")) {
			Application.LoadLevel ("6");
		}

		if (GUI.Button (new Rect (500, 500 , 130, 70), " Exit ! ")) {
			Application.Quit ();
		}

		if (GUI.Button (new Rect (850, 200 , 130, 70), "8  لودـــج")) {
			Application.LoadLevel ("7");
		}
		if (GUI.Button (new Rect (850, 300 , 130, 70), "9  لودـــج")) {
			Application.LoadLevel ("8");
		}

						
						

			
				
		}
				

	
	// Update is called once per frame
	void Update () {
	
	}
}

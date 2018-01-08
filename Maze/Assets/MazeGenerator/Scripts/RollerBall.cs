using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


//<summary>
//Ball movement controlls and simple third-person-style camera
//</summary>
public class RollerBall : MonoBehaviour {

	public GameObject ViewCameraContainer = null;
    public GameObject ViewCamera = null;
    public GameObject RSPCamera = null;
	public AudioClip JumpSound = null;
	public AudioClip HitSound = null;
	public AudioClip CoinSound = null;

	private Rigidbody mRigidBody = null;
	private AudioSource mAudioSource = null;
	private bool mFloorTouched = false;

    void Start()
    {
        mRigidBody = GetComponent<Rigidbody>();
        mAudioSource = GetComponent<AudioSource>();
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            if (Input.GetJoystickNames()[i] != "")
            {
                Debug.Log(Input.GetJoystickNames()[i]);
            }
        }
    }

	void FixedUpdate () {
        
        if (MazeSpawner.getNumberOfCoins()==0) {
        	GameObject.Find("/AlbinoDragon/Canvas/Coins").GetComponent<Text>().text = "You have collected all the coins: THE GAME IS OVER!";
        }

        GameObject.Find("/AlbinoDragon/Canvas/Coins").GetComponent<Text>().text = MazeSpawner.getNumberOfCoins() + " coins left";

        if (mRigidBody != null) {
			
				mRigidBody.AddTorque(ViewCamera.transform.TransformDirection(Vector3.back  * Input.GetAxis("Horizontal") *10));
			
			
//				mRigidBody.transform.position = mRigidBody.transform.position + ViewCamera.transform.forward * 1f * Time.deltaTime;
				mRigidBody.AddTorque(ViewCamera.transform.TransformDirection(Vector3.right * Input.GetAxis("Vertical") *10));
			
			if (Input.GetButtonDown("Jump")) {
				if(mAudioSource != null && JumpSound != null){
					mAudioSource.PlayOneShot(JumpSound);
				}
				if(mFloorTouched)
					mRigidBody.AddForce(Vector3.up*200);
			}
		}
        Debug.Log(ViewCameraContainer);
		
	}
	// events once the rolling ball collides with the wall
	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag.Equals ("Floor")) {
			mFloorTouched = true;
			if (mAudioSource != null && HitSound != null && coll.relativeVelocity.y > .5f) {
				mAudioSource.PlayOneShot (HitSound, coll.relativeVelocity.magnitude);
			}
		} else {
			if (mAudioSource != null && HitSound != null && coll.relativeVelocity.magnitude > 2f) {
				mAudioSource.PlayOneShot (HitSound, coll.relativeVelocity.magnitude);
			}
		}
	}

	void OnCollisionExit(Collision coll){
		if (coll.gameObject.tag.Equals ("Floor")) {
			mFloorTouched = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Coin")) {
			if(mAudioSource != null && CoinSound != null){
				mAudioSource.PlayOneShot(CoinSound);
			}
			//Destroy the coin when you hit it with the ball
			//Update number of coins to capture/destroy
			Destroy(other.gameObject);

			//This line allows to transition from the current scene to another one ("New Scene")
			RSPCamera.SetActive(true);
			ViewCamera.SetActive (false);
			

		}
	}
}

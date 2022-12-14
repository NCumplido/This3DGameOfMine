using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int playerMaxHealth = 100;
    public int playerCurrentHealth;
    public int level;
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody rig;
    private bool isGrounded;
    public int coinCount;
    public UI userInterface;

    private void Start()
    {
        //FUTURE: Get saved health 
        playerCurrentHealth = playerMaxHealth;
        userInterface.healthBar.SetMaxHealth(playerMaxHealth);

        level = SceneManager.GetActiveScene().buildIndex;

        SetPlayerFromSaveState();
    }

    public static void SetPlayerFromSaveState()
    {
        var currentPlayerFromState = CurrentPlayerState.GetPlayerSaveState();
        //TODO: set the current player from player save data - https://gamedevbeginner.com/how-to-load-a-new-scene-in-unity-with-a-loading-screen/#pass_data_between_scenes_unity
    }

    // Update is called once per frame
    void Update()
    {
        //Get x and z inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed;//A & D or left arrow and right arrow movement
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //Set the velocity based on our inputs
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        //This is to prevent the character from falling forward
        Vector3 vel = rig.velocity;
        vel.y = 0;

        //Only look in the direction that we are moving when the character is moving
        if(vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //I'm only really going to need Force and impulse (Force = gradual force, Impulse = instant velocity)
        }

        if(transform.position.y < -10)
        {
            GameOver();
        }

        //TODO: finish sprint
        //if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded) 
        //{
        //    moveSpeed *= (float)1.5;
        //}
        //if (!Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        //{
        //    moveSpeed = PhysicsConstants.MoveSpeed;
        //}

        //TODO: Implement pause/player menu
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    SceneManager.GetSceneByName();
        //}

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision?.contacts[0].normal == Vector3.up)//Are we in contact with the ground, 'normal' is (perpendicular?) line from surface/collider/capsule
        {
            isGrounded = true;
        }
    }

    public void HitByBox(Transform box)
    {
        //FUTURE: Add player knockback - transform.TransformVector = box.transform.TransformVector;  TODO: move player in direction that box is travelling/knockback player on box hit
        playerCurrentHealth -= 20;

        userInterface.healthBar.SetHealth(playerCurrentHealth);
        
        if(playerCurrentHealth <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//load current scene that we are in now
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        userInterface.SetScoreText("Coins: " + coinCount); 
    }
}

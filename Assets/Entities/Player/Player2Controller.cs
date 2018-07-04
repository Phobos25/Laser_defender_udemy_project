using UnityEngine;
using System.Collections;


public class Player2Controller : MonoBehaviour {

    #region Variables
    public LevelManager levelManager;
    //speed of the player's space ship
    public float speed = 5f;
    //the smallest distance between boundaries of the screen and space ship
    public float padding = 1f;
    //prefab of the projectile. Add from the editor
    public GameObject projectile;
    //speed of the projectiles
    public float projectileSpeed;
    //firing speed
    public float firingRate = 0.2f;
    //position of projectiles to spawn. Add from the editor
    public Transform firePoint;
    //amount of health of the player
    public float health;
    //keeps health amount between scenes
    public static float maxHealth = 50f;
    private ShootSoundController shootSound;
    //boundaries of the screen. Calculated in the Start() method
    float xmin;
    float xmax;

    private HealthKeeper healthKeeper;
    #endregion

    #region Unity Methods

    // Use this for initialization
    void Start ()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f,0f, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1F, 0f, distance));

        //set the borders of the restains of movements
        xmin = leftmost.x + padding ;
        xmax = rightmost.x - padding;
        //get current health from static variable
        health = maxHealth;

        healthKeeper = GameObject.Find("Health2").GetComponent<HealthKeeper>();
        healthKeeper.DisplayHealth(health);

        shootSound = GetComponent<ShootSoundController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        MovementsControl();

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            InvokeRepeating("Shoot", 0.000001f, firingRate);            
        }
        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            CancelInvoke("Shoot");
        }
	}
	
	#endregion

    //Method that handles shooting of the space ship
    void Shoot()
    {
        //instantiate beam at the position of fire point
        GameObject beam = (GameObject)Instantiate(projectile, firePoint.position, Quaternion.identity);
        beam.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
        //play sound effect of shooting
        shootSound.PlaySoundEffect();
    }

    //Method that handles movement
    void MovementsControl()
    {       
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }  
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);}    
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);}

        //restrict the movenet of the ship on OX axis
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        Projectile projectile = col.gameObject.GetComponent<Projectile>();

        if (projectile)
        {
            //Damage the player
            health -= projectile.GetDamage();
            //display health of the player ship
            HealthUpdate(health);
            //Destroy projectile 
            projectile.Hit();
            
            //Check if the player has been destroyed
            if (health <= 0)
            {
                Die();                
            }
        }

    }

    public void HealthUpdate(float health)
    {
        healthKeeper.DisplayHealth(health);
    }

    void Die()
    {
        //levelManager.LoadLevel("_Lose");
        Destroy(gameObject);
    }

    public void AddDamage(float _damage)
    {
        // camera shake
    }
}

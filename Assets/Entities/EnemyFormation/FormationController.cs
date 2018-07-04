using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class FormationController : MonoBehaviour {

    #region Variables
    public LevelManager levelManager;
    public GameObject[] enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 1f;
    public float spawnDelay = 0.5f;
    //current number of enemies on the field. Starts as 0
    public int currentEnemyNumber;

    private bool moveReverse = false;
    private float xmin, xmax;
    //number of enemies on the field
    private int maxEnemyNumber;
    public int currentWaveNumber = 0;    
	#endregion

	#region Unity Methods

	// Use this for initialization
	void Start ()
    {
        if (!levelManager)
        {
            Debug.LogError("Level manager was not found");
        }

        maxEnemyNumber = transform.childCount;        
        currentEnemyNumber = 0;
        currentWaveNumber = 1;
        //for each Transform type in the game object
        SpawnUntilFull();
        CalculateBoundaries();
	}
	
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

	// Update is called once per frame
	void Update ()
    {
        if (!moveReverse)
            transform.position += Vector3.left * speed * Time.deltaTime;
        else
            transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x <= xmin)
            moveReverse = true;
        else if (transform.position.x >= xmax)
            moveReverse = false;

        if (AllMembersDead())
        {
            currentEnemyNumber = 0;
            CheckWinConditon();
            SpawnUntilFull();            
        }
    }
	
	#endregion

    //CHeck if the win condition has been achieved
    void CheckWinConditon()
    {
        currentWaveNumber++;
        //check if current wave number is higher than max waves
        if (currentWaveNumber > ScoreKeeper.waveNumbers)
        {
            if (Data.instance.StageNumber == 3)
            {
                levelManager.LoadLevel("_Win");
            }
            //if true then load next level or win screen
            levelManager.LoadLevel("_Middle_of_Nowhere");
        }
    }

    void CalculateBoundaries()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1F, 0f, distance));

        float padding = width / 2;
        //set the borders of the restains of movements
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;

      
    }

    //currently this method never used
    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            //choose randomly between prefabs
            int i = (int)Random.Range(0f, enemyPrefab.Length);
            GameObject enemy = (GameObject)Instantiate(enemyPrefab[i], child.position, Quaternion.identity);
            //set the parent of the instantiated game object to Transform child
            enemy.transform.parent = child;
        }
    }

    void SpawnUntilFull()
    {
        //Get free position to spawn. If it's free
        Transform freePosition = NextFreePosition();

        if (freePosition & currentEnemyNumber < maxEnemyNumber)
        {
            //choose randomly between prefabs
            int i = (int)Random.Range(0f, enemyPrefab.Length);
            GameObject enemy = (GameObject)Instantiate(enemyPrefab[i], freePosition.position, Quaternion.identity);
            enemy.transform.parent = freePosition;
            currentEnemyNumber++;
            //call the function again after delay = spawn delay
            Invoke("SpawnUntilFull", spawnDelay);
        }
       
    }

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObjects in transform)
        {
            if (childPositionGameObjects.childCount == 0)
            {
                return childPositionGameObjects;
            }
        }

        return null;
    }

    bool AllMembersDead()
    {
        //we are using transform because this scripts attached to 
        //EnemyFormation. Positions are children of this game object
        foreach (Transform childPositionGameObjects in transform)
        {
            if (childPositionGameObjects.childCount > 0)
            {
                return false;
            }
        }

        return true;
    }
}

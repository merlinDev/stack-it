using System.Collections;
using UnityEngine;

public class SpawnDrop : MonoBehaviour
{
    public GameObject tile;
    public float spawnTime = 1.0f;
    private Vector2 bounds;

    public float camSpeed;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TileLoop());
    }


    private void Spawn()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        GameObject tileObject = Instantiate(tile) as GameObject;
          
        tileObject.transform.position = new Vector2(Random.Range(-bounds.x + 0.8f, bounds.x - 0.8f) , bounds.y);
        
    }

    IEnumerator TileLoop() {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Spawn();
        }
    }
}

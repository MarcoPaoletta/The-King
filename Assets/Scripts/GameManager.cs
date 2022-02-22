using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // to restart the scene

public class GameManager : MonoBehaviour
{
    public GameObject start_menu;
    public GameObject game_over_menu;
    public GameObject column;
    public GameObject rock_1;
    public GameObject rock_2;

    public List<GameObject> columns;
    public List<GameObject> rocks;

    public bool game_over = false;
    public bool start = false;

    public float velocity;

    public Renderer background;

    void Start()
    {
        createColumns();
        createRocks();
    }

    void Update()
    {
        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (start == true && game_over == true)
        {
            game_over_menu.SetActive(true);

            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start == true && game_over == false)
            {
                start_menu.SetActive(false);
                moveBackground();
                moveColumns();
                moveRocks();
            }
    }

    private void createColumns()
    {
        for (int i = 0; i < 21; i++) // create 20 columns
        {
            columns.Add(Instantiate(column, new Vector2(-10 + i, -3), Quaternion.identity));
        }
    }

    private void createRocks()
    {
        rocks.Add(Instantiate(rock_1, new Vector2(14, -2), Quaternion.identity));
        rocks.Add(Instantiate(rock_2, new Vector2(18, -2), Quaternion.identity));
    }

    private void moveBackground()
    {
        background.material.mainTextureOffset += new Vector2(0.2f, 0) * Time.deltaTime; // change the offset
    }

    private void moveColumns()
    {
        for (int i = 0; i < columns.Count; i++) // move colums depending on every column created
        {
            if (columns[i].transform.position.x <= -10) // if a column has reached the edge
            {
                columns[i].transform.position = new Vector3(10, -3, 0);
            }

            columns[i].transform.position += Time.deltaTime * velocity * new Vector3(-1, 0, 0);
        }
    }

    private void moveRocks()
    {
        for (int i = 0; i < rocks.Count; i++) // move rocks depending on every rock created
        {
            if (rocks[i].transform.position.x <= -10) // if a column has reached the edge
            {
                float random_position = Random.Range(11, 18);
                rocks[i].transform.position = new Vector3(random_position, -2, 0);
            }

            rocks[i].transform.position += Time.deltaTime * velocity * new Vector3(-1, 0, 0);
        }
    }
}

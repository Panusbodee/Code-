using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int score = 0;
    public float walkSpeed = 10.0f;
    public GameObject SpItem;
    public AudioClip coinSound;
    public DoorController door;
    public DoorController doora;


    public float eyeDistance = 10.0f;
    Ray ray;
    RaycastHit hitData;

    public Text msg;
    public int itemCount = 0;
    public GameObject itemToDropPrefab;
    public Text itemCountText;
    public GameObject endGameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        msg.gameObject.SetActive(false);
        UpdateItemCountText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            score++;
            AudioSource.PlayClipAtPoint(coinSound, transform.position);

            if (score == 5)
            {
                SpItem.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // ray.origin = transform.position;
        //ray.direction = transform.forward;
        Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);

        if (Physics.Raycast(ray, out hitData, eyeDistance))
        {
            switch (hitData.transform.gameObject.tag)
            {
                case "door":
                    msg.text = " Press F Open / Close ";
                    msg.transform.gameObject.SetActive(true);

                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.red);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        door.control();
                    }
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.red);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        door.control();
                    }
                    break;

                case "ban":
                    msg.text = " Left Mouse To Take buddha form Vilager  ";
                    msg.transform.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.yellow);

                    if (Input.GetMouseButtonDown(0))
                    {
                        
                        DropItem(hitData.transform.position);
                    }
                    break;

                case "Key":
                    msg.text = "Press E to get buddha";
                    msg.transform.gameObject.SetActive(true);
                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.green);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Destroy(hitData.transform.gameObject);
                        itemCount++;
                        UpdateItemCountText();

                        if (itemCount <= 5)
                        {
                            msg.text = itemCount + "Get Key";
                        }


                    }
                    break;

                case "door2":
                    msg.text = " Press F Open / Close ";
                    msg.transform.gameObject.SetActive(true);

                    Debug.DrawRay(ray.origin, ray.direction * eyeDistance, Color.red);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        door.control();
                    }
                    break;

                default:
                    msg.transform.gameObject.SetActive(false);
                    break;
            }

        }
        else
        {
            msg.gameObject.SetActive(false);
        }
        if (itemCount == 5)
        {
            LoadNextScene("End");
        }
        

        float moveForward = Input.GetAxis("Vertical") * walkSpeed;
        float moveSide = Input.GetAxis("Horizontal") * walkSpeed;

        moveForward *= Time.deltaTime;
        moveSide *= Time.deltaTime;

        transform.Translate(moveSide, 0, moveForward);
    }

    void UpdateItemCountText()
    {
        itemCountText.text = "Buddha : " + itemCount;
    }

    void DropItem(Vector3 position)
    {
        if (itemToDropPrefab != null)
        {
            Instantiate(itemToDropPrefab, position, Quaternion.identity);
        }
    }

    void EndGame()
    {

        if (endGameCanvas != null)
        {
            endGameCanvas.SetActive(true);
        }
        else
        {
            Debug.LogError("End Game Canvas is not assigned in the Inspector!");
        }
        Debug.Log("Game end");
        msg.text = "Game End";
    }

    private void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}

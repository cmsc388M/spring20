using UnityEngine;

// All components you create must extend MonoBehaviour
public class ExampleScript : MonoBehaviour
{
    // Public fields show up as properties of component in Inspector
    [Header("General Fields")]
    public string errorMessage;
    public string[] cities;
    public int favoriteNum;
    public float speed;
    public Color someColor;

    // You can even make fields out of other GameObjects, Components, & Assets
    [Header("References to Other Unity Stuff")]
    public GameObject otherGameObject;
    public MeshRenderer otherMeshRenderer;
    public Material someMaterial;

    // Private fields do not show up in Inspector
    private MeshRenderer myMeshRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        // Different levels of debug log messages
        Debug.Log("This is an example log.");
        Debug.LogWarning("This is an example warning");
        Debug.LogError(errorMessage);

        // Can use GetComponent method to get reference to other
        // components on same GameObject
        myMeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ////////////////////////////////////////////////
        //     IN-CLASS LAB PART ONE - MOVEMENT       //
        ////////////////////////////////////////////////

        // Comment and uncomment the lines of code to switch between iterations

        // Iteration 1
        // Move position up one meter per frame
        transform.position = transform.position + new Vector3(0, 1, 0);
        
        // Iteration 2
        // Move position up one meter per second
        // transform.position += new Vector3(0, 1 * Time.deltaTime, 0);

        // Iteration 3
        // Easily change speed (m/s) from speed variable in Inspector
        // transform.position += new Vector3(0, speed * Time.deltaTime, 0);



        ////////////////////////////////////////////////
        //    IN-CLASS LAB PART TWO - INTERACTIONS    //
        ////////////////////////////////////////////////

        // If user started left-clicking during this frame
        if (Input.GetMouseButtonDown(0))
        {
            // Toggle visibility of saloon
            otherGameObject.SetActive(!otherGameObject.activeInHierarchy);
        }

        // If user started right-clicking during this frame
        if (Input.GetMouseButtonDown(1))
        {
            // Change cube's material
            myMeshRenderer.material = someMaterial;

            // Change color of Potion Spawner's material
            otherMeshRenderer.material.SetColor("_BaseColor", someColor);
        }
    }
}

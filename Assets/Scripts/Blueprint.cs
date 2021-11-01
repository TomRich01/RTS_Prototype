using UnityEngine;

public class Blueprint : MonoBehaviour
{
    RaycastHit hit;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 300.0f))
        {

            transform.position = hit.point;


        }

        if (Input.GetMouseButton(0))
        {

            if (hit.transform.gameObject.layer == 7)
            {
                Instantiate(prefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }

        }
    }


}

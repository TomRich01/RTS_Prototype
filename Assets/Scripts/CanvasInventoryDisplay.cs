using TMPro;
using UnityEngine;

public class CanvasInventoryDisplay : MonoBehaviour
{
    [SerializeField] private ResourceInv resourceInv;
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI unitText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        woodText.text = "Wood: " + resourceInv.wood;
        foodText.text = "Food: " + resourceInv.food;
        stoneText.text = "Stone: " + resourceInv.stone;
        unitText.text = "Max Units: " + resourceInv.amountUnit + "/" + resourceInv.maxUnit;
    }
}

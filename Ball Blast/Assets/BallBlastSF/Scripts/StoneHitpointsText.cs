using UnityEngine;
using TMPro;

[RequireComponent(typeof(Destructible))]
public class StoneHitpointsText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hitpointText;

    private Destructible destructible;

    private void Awake()
    {
        destructible = GetComponent<Destructible>();

        destructible.ChangeHitPoints.AddListener(OnChangeHitPoint);
    }

    private void OnDestroy()
    {
        destructible.ChangeHitPoints.RemoveListener(OnChangeHitPoint);
    }

    private void OnChangeHitPoint()
    {
        int hitPoints = destructible.GetHitPoints();

        if (hitPoints >= 1000)
            hitpointText.text = hitPoints / 1000 + "K";
        else
            hitpointText.text = hitPoints.ToString();
    }
}
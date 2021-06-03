using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defenderPrefab;
    GameObject defendersParent;

    const string DEFENDERS_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefendersParent();
    }

    private void CreateDefendersParent()
    {
        defendersParent = GameObject.Find(DEFENDERS_PARENT_NAME);
        if (!defendersParent)
        {
            defendersParent = new GameObject(DEFENDERS_PARENT_NAME);
        }
    }

    public void SetDefenderPrefab(Defender defenderPrefab)
    {
        this.defenderPrefab = defenderPrefab;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defenderPrefab.GetStarCost();
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private void SpawnDefender(Vector2 gridPos)
    {
        Defender defender = Instantiate(defenderPrefab, gridPos, Quaternion.identity) as Defender;
        defender.transform.parent = defendersParent.transform;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 gridPosition = SnapToGrid(worldPosition);
        return gridPosition;
    }

    private Vector2 SnapToGrid(Vector2 worldPosition)
    {
        float newX = Mathf.RoundToInt(worldPosition.x);
        float newY = Mathf.RoundToInt(worldPosition.y);
        return new Vector2(newX, newY);
    }

    private void OnMouseDown()
    {
        if (defenderPrefab)
        {
            AttemptToPlaceDefenderAt(GetSquareClicked());
        }
    }
}

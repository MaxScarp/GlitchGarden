using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defenderPrefab;

    public void SetDefenderPrefab(Defender defenderPrefab)
    {
        this.defenderPrefab = defenderPrefab;
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
        Defender defender = Instantiate(defenderPrefab, GetSquareClicked(), Quaternion.identity) as Defender;
    }
}

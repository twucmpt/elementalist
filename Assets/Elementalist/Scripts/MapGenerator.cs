using System.Collections.Generic;
using UnityEngine;


public class MapGenerator : MonoBehaviour
{
    public Camera mainCamera;
    public List<GameObject> mapChunks;
    public int chunkSize = 64;

    private Dictionary<Vector2Int, GameObject> loadedChunks = new Dictionary<Vector2Int, GameObject>();
    
    void Update() {
        Vector2Int currentChunkPos = GetChunkPos(mainCamera.gameObject);

        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) {
                Vector2Int pos = new Vector2Int(x+currentChunkPos.x, y+currentChunkPos.y);
                if (!loadedChunks.ContainsKey(pos)) {
                    LoadChunk(pos);
                }
            }
        }

        List<Vector2Int> toRemove = new List<Vector2Int>();
        foreach (Vector2Int pos in loadedChunks.Keys) {
            if ((pos - currentChunkPos).magnitude > 2) {
                Destroy(loadedChunks[pos]);
                toRemove.Add(pos);
            }
        }
        foreach (Vector2Int pos in toRemove) {
            loadedChunks.Remove(pos);
        }

    }

    Vector2Int GetChunkPos(GameObject chunk) {
        int currentChunkX = Mathf.FloorToInt(chunk.transform.position.x / chunkSize);
        int currentChunkY = Mathf.FloorToInt(chunk.transform.position.y / chunkSize);
        return new Vector2Int(currentChunkX, currentChunkY);
    }

    Vector2 GetWorldPos(Vector2Int pos) {
        return new Vector2(pos.x * chunkSize, pos.y * chunkSize);
    }

    void LoadChunk(Vector2Int pos) {
        System.Random rand = new System.Random(pos.ToString().GetHashCode());
        int i = rand.Next(0, mapChunks.Count);
        Vector2 worldPod = GetWorldPos(pos);
        GameObject chunk = Instantiate(mapChunks[i], worldPod, Quaternion.identity);
        loadedChunks.Add(pos, chunk);
    }

}

using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int terrainSize = 129; // 地形のサイズ（2の累乗+1）
    public float terrainScale = 20f; // 地形の大きさ
    public float heightScale = 50f; // 高さのスケール

    private Terrain terrain;

    void Start()
    {
        terrain = GetComponent<Terrain>();
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        terrain.terrainData = GenerateTerrainData();
    }

    TerrainData GenerateTerrainData()
    {
        TerrainData terrainData = new TerrainData();
        terrainData.heightmapResolution = terrainSize;
        terrainData.size = new Vector3(terrainSize, heightScale, terrainSize);

        float[,] heightMap = new float[terrainSize, terrainSize];

        // Diamond-Squareアルゴリズムで高さマップを生成
        DiamondSquare(heightMap, 0, 0, terrainSize - 1, terrainSize - 1, heightScale);

        terrainData.SetHeights(0, 0, heightMap);
        terrainData.RefreshPrototypes();

        return terrainData;
    }

    void DiamondSquare(float[,] heightMap, int startX, int startZ, int endX, int endZ, float scale)
    {
        int size = endX - startX;
        int halfSize = size / 2;

        if (halfSize < 1)
            return;

        // Diamondステップ
        for (int x = startX + halfSize; x < endX; x += size)
        {
            for (int z = startZ + halfSize; z < endZ; z += size)
            {
                float average = (heightMap[x - halfSize, z - halfSize] +
                                 heightMap[x - halfSize, z + halfSize] +
                                 heightMap[x + halfSize, z - halfSize] +
                                 heightMap[x + halfSize, z + halfSize]) * 0.25f;

                heightMap[x, z] = average + Random.Range(-scale, scale);
            }
        }

        // Squareステップ
        for (int x = startX; x <= endX; x += halfSize)
        {
            for (int z = startZ + halfSize; z <= endZ; z += size)
            {
                float average = GetSquareAverage(heightMap, x, z - halfSize, size, scale);
                heightMap[x, z] = average + Random.Range(-scale, scale);
            }
        }

        for (int x = startX + halfSize; x <= endX; x += size)
        {
            for (int z = startZ; z <= endZ; z += halfSize)
            {
                float average = GetSquareAverage(heightMap, x - halfSize, z, size, scale);
                heightMap[x, z] = average + Random.Range(-scale, scale);
            }
        }

        // 再帰呼び出し
        DiamondSquare(heightMap, startX, startZ, startX + halfSize, startZ + halfSize, scale * 0.5f);
        DiamondSquare(heightMap, startX + halfSize, startZ, endX, startZ + halfSize, scale * 0.5f);
        DiamondSquare(heightMap, startX, startZ + halfSize, startX + halfSize, endZ, scale * 0.5f);
        DiamondSquare(heightMap, startX + halfSize, startZ + halfSize, endX, endZ, scale * 0.5f);
    }
    float GetSquareAverage(float[,] heightMap, int x, int z, int size, float scale)
    {
        int halfSize = size / 2;

        float average = (heightMap[WrapIndex(x - halfSize, heightMap.GetLength(0)), z] +
                         heightMap[WrapIndex(x + halfSize, heightMap.GetLength(0)), z] +
                         heightMap[x, WrapIndex(z - halfSize, heightMap.GetLength(1))] +
                         heightMap[x, WrapIndex(z + halfSize, heightMap.GetLength(1))]) * 0.25f;

        return average;
    }

    int WrapIndex(int index, int length)
    {
        return (index + length) % length;
    }
}

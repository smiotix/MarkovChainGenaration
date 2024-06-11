using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen2 : MonoBehaviour
{
    public int mapSize = 129; // 地形のサイズ（2^n + 1）
    public float roughness = 0.7f; // 地形の粗さ

    private float[,] terrainMap;
    [SerializeField]
    private Terrain terrain;
    private TerrainData TData;
    private float[,] zeroheights;

    void Start()
    {
        TData = terrain.GetComponent<Terrain>().terrainData;
        GenerateTerrain();
        for(int i = 0;i< TData.heightmapResolution; i++)
        {
            for(int j = 0; j < TData.heightmapResolution; j++)
            {
                zeroheights[i, j] = 0;
            }
        }
        TData.SetHeights(0, 0, zeroheights);
        //TData.SetHeights(0, 0, terrainMap);
        //Debug.Log(TData.);
    }

    void GenerateTerrain()
    {
        mapSize = TData.heightmapResolution;
        terrainMap = new float[mapSize, mapSize];
        zeroheights = new float[mapSize,mapSize];
        // 初期頂点の高さを設定
        terrainMap[0, 0] = 0f;
        terrainMap[0, mapSize - 1] = 0f;
        terrainMap[mapSize - 1, 0] = 0f;
        terrainMap[mapSize - 1, mapSize - 1] = 0f;

        float heightRange = 1f;

        // Diamond-Squareアルゴリズムの実行
        DiamondSquare(0, 0, mapSize - 1, mapSize - 1, heightRange);

        // 生成された地形に基づいてメッシュを作成などの処理を行う
        // ...

    }

    void DiamondSquare(int x1, int y1, int x2, int y2, float range)
    {
        int halfSize = (x2 - x1) / 2;

        if (halfSize < 1)
            return;

        float scale = range * roughness;

        // ダイヤモンドステップ
        for (int y = y1 + halfSize; y < y2; y += 2 * halfSize)
        {
            for (int x = x1 + halfSize; x < x2; x += 2 * halfSize)
            {
                float average = (terrainMap[x - halfSize, y - halfSize] +
                                 terrainMap[x + halfSize, y - halfSize] +
                                 terrainMap[x - halfSize, y + halfSize] +
                                 terrainMap[x + halfSize, y + halfSize]) * 0.25f;

                terrainMap[x, y] = average + Random.Range(-scale, scale);
            }
        }

        // スクエアステップ
        for (int y = y1; y < y2; y += halfSize)
        {
            for (int x = x1; x < x2; x += halfSize)
            {
                if (x + halfSize >= x2 || y + halfSize >= y2)
                    continue;

                float average = (terrainMap[x, y] +
                                 terrainMap[x + halfSize, y] +
                                 terrainMap[x, y + halfSize] +
                                 terrainMap[x + halfSize, y + halfSize]) * 0.25f;

                terrainMap[x + halfSize, y + halfSize] = average + Random.Range(-scale, scale);
            }
        }

        // 再帰的にDiamondSquare関数を呼び出し
        DiamondSquare(x1, y1, x1 + halfSize, y1 + halfSize, range / 2f); // 左上
        DiamondSquare(x1 + halfSize, y1, x2, y1 + halfSize, range / 2f); // 右上
        DiamondSquare(x1, y1 + halfSize, x1 + halfSize, y2, range / 2f); // 左下
        DiamondSquare(x1 + halfSize, y1 + halfSize, x2, y2, range / 2f); // 右下
    }
}


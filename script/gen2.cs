using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gen2 : MonoBehaviour
{
    public int mapSize = 129; // �n�`�̃T�C�Y�i2^n + 1�j
    public float roughness = 0.7f; // �n�`�̑e��

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
        // �������_�̍�����ݒ�
        terrainMap[0, 0] = 0f;
        terrainMap[0, mapSize - 1] = 0f;
        terrainMap[mapSize - 1, 0] = 0f;
        terrainMap[mapSize - 1, mapSize - 1] = 0f;

        float heightRange = 1f;

        // Diamond-Square�A���S���Y���̎��s
        DiamondSquare(0, 0, mapSize - 1, mapSize - 1, heightRange);

        // �������ꂽ�n�`�Ɋ�Â��ă��b�V�����쐬�Ȃǂ̏������s��
        // ...

    }

    void DiamondSquare(int x1, int y1, int x2, int y2, float range)
    {
        int halfSize = (x2 - x1) / 2;

        if (halfSize < 1)
            return;

        float scale = range * roughness;

        // �_�C�������h�X�e�b�v
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

        // �X�N�G�A�X�e�b�v
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

        // �ċA�I��DiamondSquare�֐����Ăяo��
        DiamondSquare(x1, y1, x1 + halfSize, y1 + halfSize, range / 2f); // ����
        DiamondSquare(x1 + halfSize, y1, x2, y1 + halfSize, range / 2f); // �E��
        DiamondSquare(x1, y1 + halfSize, x1 + halfSize, y2, range / 2f); // ����
        DiamondSquare(x1 + halfSize, y1 + halfSize, x2, y2, range / 2f); // �E��
    }
}


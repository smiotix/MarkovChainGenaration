using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class Gen : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Prefabs;
    private int[][] maps = new int[16][];
    private int[][] hmaps = new int[2][];
    // Start is called before the first frame update
    private async UniTask Start()
    {
        await Generator();
    }

    // Update is called once per frame
    private async UniTask Update()
    {

    }
    private async UniTask Generator()
    {
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        for (int i = 0; i < 16; i++)
        {
            maps[i] = new int[16];
        }
        for (int i = 0; i < 2; i++)
        {
            hmaps[i] = new int[2];
        }
        int dice = 0;
        dice = UnityEngine.Random.Range(0, 12);
        if (dice < 6)
        {
            hmaps[0][0] = 1;
        }
        else if (dice < 10 && dice > 6)
        {
            hmaps[0][0] = 2;
        }
        else
        {
            hmaps[0][0] = 0;
        }
        if (hmaps[0][0] == 1)
        {
            dice = UnityEngine.Random.Range(0, 12);
            if (dice < 8)
            {
                hmaps[0][1] = 2;
            }
            else if (dice < 10)
            {
                hmaps[0][1] = 1;
            }
            else
            {
                hmaps[0][1] = 0;
            }
        }
        else if (hmaps[0][0] == 2)
        {
            dice = UnityEngine.Random.Range(0, 12);
            if (dice < 10)
            {
                hmaps[0][1] = 1;
            }
            else
            {
                hmaps[0][1] = 2;
            }
        }
        else
        {
            dice = UnityEngine.Random.Range(0, 12);
            if (dice < 10)
            {
                hmaps[0][1] = 1;
            }
            else
            {
                hmaps[0][1] = 0;
            }
        }
        if (hmaps[0][0] == 0 && hmaps[0][1] == 0)
        {
            hmaps[1][0] = 1;
            dice = UnityEngine.Random.Range(0, 12);
            if (dice < 8)
            {
                hmaps[1][1] = 2;
            }
            else
            {
                hmaps[1][1] = 1;
            }
        }
        else if (hmaps[0][0] == 0 && (hmaps[1][0] == 1 || hmaps[1][0] == 2) && hmaps[0][1] == 1)
        {
            dice = UnityEngine.Random.Range(0, 12);
            if (dice < 8)
            {
                hmaps[1][0] = 2;
                dice = UnityEngine.Random.Range(0, 12);
                if (dice < 9)
                {
                    hmaps[1][1] = 1;
                }
                else
                {
                    hmaps[1][1] = 2;
                }
            }
            else
            {
                hmaps[1][0] = 1;
                dice = UnityEngine.Random.Range(0, 12);
                if (dice < 9)
                {
                    hmaps[1][1] = 1;
                }
                else
                {
                    hmaps[1][1] = 2;
                }
            }
        }
        else
        {
            dice = UnityEngine.Random.Range(0, 12);
            if (dice < 9)
            {
                hmaps[1][0] = 1;
            }
            else
            {
                hmaps[1][0] = 2;
            }
            dice = UnityEngine.Random.Range(0, 12);
            if (dice < 9)
            {
                hmaps[1][1] = 2;
            }
            else
            {
                hmaps[1][1] = 1;
            }
        }
        if (hmaps[0][0] == 0 && hmaps[0][1] == 0)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 8; j < 16; j++)
                {
                    maps[i][j] = 0;
                }
            }
        }
        else if (hmaps[0][0] == 1 && (hmaps[1][0] == 1 || hmaps[1][0] == 0) && hmaps[0][1] == 2)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i != 0 && j != 0)
                    {
                        if (maps[i - 1][j] == 2 || maps[i][j - 1] == 2)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 3;
                            }
                            else
                            {
                                maps[i][j] = 1;
                            }
                        }
                        else if (maps[i - 1][j] == 3 || maps[i][j - 1] == 3)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 2;
                            }
                            else
                            {
                                maps[i][j] = 3;
                            }
                        }
                        else if (dice < 9)
                        {
                            maps[i][j] = 1;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 1;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 8; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i != 0 && j != 0)
                    {
                        if (maps[i - 1][j] == 5)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 6;
                            }
                            else
                            {
                                maps[i][j] = 4;
                            }
                        }
                        else if (maps[i - 1][j] == 6 || maps[i][j - 1] == 6)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 5;
                            }
                            else
                            {
                                maps[i][j] = 6;
                            }
                        }
                        else if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                }
            }
        }
        else if ((hmaps[0][0] == 1 && hmaps[0][1] == 1 && hmaps[1][0] == 1) || (hmaps[0][0] == 1 && hmaps[0][1] == 0 && hmaps[1][0] == 1))
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i != 0 && j != 0)
                    {
                        if (maps[i - 1][j] == 2 || maps[i][j - 1] == 2)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 3;
                            }
                            else
                            {
                                maps[i][j] = 1;
                            }
                        }
                        else if (maps[i - 1][j] == 3 || maps[i][j - 1] == 3)
                        {
                            maps[i][j] = 2;
                        }
                        else
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 1;
                            }
                            else
                            {
                                maps[i][j] = 2;
                            }
                        }
                    }
                    else if (dice < 9)
                    {
                        maps[i][j] = 1;
                    }
                    else
                    {
                        maps[i][j] = 2;
                    }
                }
            }
        }
        else if (hmaps[0][0] == 0 && hmaps[0][1] == 1 && hmaps[1][0] == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    maps[i][j] = 0;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 8; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i != 0 && j != 0)
                    {
                        if (maps[i - 1][j] == 2 || maps[i][j - 1] == 2)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 3;
                            }
                            else
                            {
                                maps[i][j] = 1;
                            }
                        }
                        else if (maps[i - 1][j] == 3)
                        {
                            maps[i][j] = 2;
                        }
                        else
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 1;
                            }
                            else
                            {
                                maps[i][j] = 2;
                            }
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 1;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                }
            }
        }
        else if (hmaps[0][0] == 1 && hmaps[1][0] == 2 && hmaps[0][1] == 2)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i == 7 || j == 7)
                    {
                        maps[i][j] = 3;
                    }
                    else if (j > 0 && i > 0)
                    {                        
                        if (maps[i][j - 1] == 2)
                        {
                            maps[i][j] = 3;
                        }
                        else if (maps[i - 1][j] == 2)
                        {
                            maps[i][j] = 3;
                        }
                        else if (dice < 9)
                        {
                            maps[i][j] = 2;
                        }
                        else
                        {
                            maps[i][j] = 1;
                        }
                    }
                    else if(dice < 9)
                    {
                        maps[i][j] = 1;
                    }
                    else
                    {
                        maps[i][j] = 2;
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 8; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i != 0 && j != 0)
                    {
                        if (maps[i - 1][j] == 5)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 6;
                            }
                            else
                            {
                                maps[i][j] = 4;
                            }
                        }
                        else if (maps[i - 1][j] == 6 || maps[i][j - 1] == 6)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 5;
                            }
                            else
                            {
                                maps[i][j] = 6;
                            }
                        }
                        else if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                }
            }
        }
        else if (hmaps[0][0] == 2 && hmaps[1][0] == 1 && hmaps[0][1] == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i != 0 && j != 0)
                    {
                        if (maps[i - 1][j] == 5)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 6;
                            }
                            else
                            {
                                maps[i][j] = 4;
                            }
                        }
                        else if (maps[i - 1][j] == 6 || maps[i][j - 1] == 6)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 5;
                            }
                            else
                            {
                                maps[i][j] = 6;
                            }
                        }
                        else if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                }
                for (int j = 8; j < 16; j++)
                {
                    if (j == 8)
                    {
                        maps[i][j] = 3;
                    }
                    else
                    {
                        dice = UnityEngine.Random.Range(0, 12);
                        if (maps[i][j - 1] == 3)
                        {
                            maps[i][j] = 2;
                        }
                        else
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 1;
                            }
                            else
                            {
                                maps[i][j] = 2;
                            }
                        }
                    }
                }
            }
        }
        else if (hmaps[0][0] == 1 && hmaps[1][0] == 2 && hmaps[0][1] == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 7)
                    {
                        maps[i][j] = 3;
                    }
                    else if (i == 6)
                    {
                        dice = UnityEngine.Random.Range(0, 12);
                        if (dice < 9)
                        {
                            maps[i][j] = 2;
                        }
                        else
                        {
                            maps[i][j] = 1;
                        }
                    }
                    else
                    {
                        dice = UnityEngine.Random.Range(0, 12);
                        if (dice < 9)
                        {
                            maps[i][j] = 1;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                }
                for (int j = 8; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (maps[i][j] == 2)
                    {
                        if (dice > 9)
                        {
                            maps[i][j] = 3;
                        }
                        else
                        {
                            maps[i][j] = 1;
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 1;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                }
            }

        }
        else if (hmaps[0][0] == 2 && hmaps[1][0] == 2 && hmaps[0][1] == 2)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i != 0 && j != 0)
                    {
                        if (maps[i - 1][j] == 5 || maps[i][j-1] == 5)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 6;
                            }
                            else
                            {
                                maps[i][j] = 4;
                            }
                        }
                        else if (maps[i - 1][j] == 6 || maps[i][j - 1] == 6)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 5;
                            }
                            else
                            {
                                maps[i][j] = 6;
                            }
                        }
                        else if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                }
            }
        }
        else if (hmaps[0][0] == 2 && (hmaps[1][0] == 2 || hmaps[1][0] == 0) && hmaps[0][1] == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (j == 7)
                    {                        
                        if (dice < 10)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }

                    }
                    else if (j != 0)
                    {
                        dice = UnityEngine.Random.Range(0, 12);
                        if (maps[i][j - 1] == 5)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 6;
                            }
                            else
                            {
                                maps[i][j] = 4;
                            }
                        }
                        else
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 4;
                            }
                            else
                            {
                                maps[i][j] = 5;
                            }
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                }
                for (int j = 8; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (j == 8)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 3;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                    else
                    {
                        if (maps[i][j - 1] == 3)
                        {
                            maps[i][j] = 2;
                        }
                        else if (dice < 9)
                        {
                            maps[i][j] = 1;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                }
            }
        }
        else if (hmaps[0][0] == 0 && (hmaps[1][0] == 1 || hmaps[1][0] == 2) && hmaps[0][1] == 2)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    maps[i][j] = 0;
                }
                for (int j = 8; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i == 7)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                    else
                    {
                        if (maps[i][j - 1] == 5)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 6;
                            }
                            else
                            {
                                maps[i][j] = 4;
                            }
                        }
                        else
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 4;
                            }
                            else
                            {
                                maps[i][j] = 5;
                            }
                        }
                    }
                }
            }
        }
        if ((hmaps[0][0] == 0 || hmaps[0][0] == 1) && hmaps[1][0] == 1 && hmaps[1][1] == 1)
        {
            for (int i = 8; i < 16; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i != 0 && j != 0)
                    {
                        if (maps[i - 1][j] == 2 || maps[i][j - 1] == 2)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 3;
                            }
                            else
                            {
                                maps[i][j] = 1;
                            }
                        }
                        else
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 1;
                            }
                            else
                            {
                                maps[i][j] = 2;
                            }
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 1;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                }
            }
        }
        else if ((hmaps[0][0] == 1 || hmaps[0][0] == 0) && hmaps[1][0] == 1 && hmaps[1][1] == 2)
        {
            for (int i = 8; i < 16; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (j == 7)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 3;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                    else if (j != 0)
                    {
                        if (maps[i - 1][j] == 2 || maps[i][j - 1] == 2)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 3;
                            }
                            else
                            {
                                maps[i][j] = 1;
                            }
                        }
                        else
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 1;
                            }
                            else
                            {
                                maps[i][j] = 2;
                            }
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 1;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                }
            }
        }
        else if (hmaps[0][0] == 2 && hmaps[1][0] == 1 && hmaps[1][1] == 2)
        {
            for (int i = 8; i < 16; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i == 8 || j == 7)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 3;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                    else if (j != 0)
                    {
                        if (maps[i - 1][j] == 2 || maps[i][j - 1] == 2)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 3;
                            }
                            else
                            {
                                maps[i][j] = 1;
                            }
                        }
                        else
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 1;
                            }
                            else
                            {
                                maps[i][j] = 2;
                            }
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 1;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                }
            }
        }
        else if ((hmaps[0][0] == 1 || hmaps[0][0] == 0) && hmaps[1][0] == 2 && hmaps[1][1] == 2)
        {
            for (int i = 8; i < 16; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i == 7)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                    else if (j != 0)
                    {
                        if (maps[i - 1][j] == 5 || maps[i][j - 1] == 5)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 6;
                            }
                            else
                            {
                                maps[i][j] = 4;
                            }
                        }
                        else
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 4;
                            }
                            else
                            {
                                maps[i][j] = 5;
                            }
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                }
            }
        }
        else if ((hmaps[0][0] == 0 || hmaps[0][0] == 1) && hmaps[1][0] == 2 && hmaps[1][1] == 1)
        {
            for (int i = 8; i < 16; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i == 8 || j == 7)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                    else if (j != 0)
                    {
                        if (maps[i - 1][j] == 5 || maps[i][j - 1] == 5)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 6;
                            }
                            else
                            {
                                maps[i][j] = 4;
                            }
                        }
                        else
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 4;
                            }
                            else
                            {
                                maps[i][j] = 5;
                            }
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                }
            }
        }
        else if (hmaps[0][0] == 2 && hmaps[1][0] == 2 && hmaps[1][1] == 2)
        {
            for (int i = 8; i < 16; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (j != 0)
                    {
                        if (maps[i - 1][j] == 5 || maps[i][j - 1] == 5)
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 6;
                            }
                            else
                            {
                                maps[i][j] = 4;
                            }
                        }
                        else
                        {
                            if (dice < 9)
                            {
                                maps[i][j] = 4;
                            }
                            else
                            {
                                maps[i][j] = 5;
                            }
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                }
            }
        }
        if (hmaps[1][0] == 1 && hmaps[1][1] == 2 && (hmaps[0][1] == 1 || hmaps[0][1] == 0))
        {
            for (int i = 8; i < 16; i++)
            {
                for (int j = 8; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i == 8 || j == 8)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                    else if (maps[i - 1][j] == 5 || maps[i][j - 1] == 5)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 6;
                        }
                        else
                        {
                            maps[i][j] = 4;
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                }
            }
        }
        else if (hmaps[1][0] == 1 && hmaps[1][1] == 1 && (hmaps[0][1] == 1 || hmaps[0][1] == 0))
        {
            for (int i = 8; i < 16; i++)
            {
                for (int j = 8; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (maps[i - 1][j] == 2 || maps[i][j - 1] == 2)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 3;
                        }
                        else
                        {
                            maps[i][j] = 1;
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 1;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                }
            }
        }
        else if (hmaps[1][0] == 1 && hmaps[1][1] == 2 && (hmaps[0][1] == 1 || hmaps[0][1] == 0))
        {
            for (int i = 8; i < 16; i++)
            {
                for (int j = 8; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i == 8 || j == 8)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                    else if (maps[i - 1][j] == 5 || maps[i][j - 1] == 5)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 6;
                        }
                        else
                        {
                            maps[i][j] = 4;
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                }
            }
        }
        else if (hmaps[1][0] == 2 && hmaps[1][1] == 2 && hmaps[0][1] == 2)
        {
            for (int i = 8; i < 16; i++)
            {
                for (int j = 8; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (maps[i - 1][j] == 5 || maps[i][j - 1] == 5)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 6;
                        }
                        else
                        {
                            maps[i][j] = 4;
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                }
            }
        }
        else if (hmaps[1][0] == 2 && hmaps[1][1] == 1 && hmaps[0][1] == 2)
        {
            for (int i = 8; i < 16; i++)
            {
                for (int j = 8; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i == 8 || j == 8)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 3;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                    else if (maps[i - 1][j] == 2 || maps[i][j - 1] == 2)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 3;
                        }
                        else
                        {
                            maps[i][j] = 1;
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 1;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                }
            }
        }
        else if (hmaps[1][0] == 2 && hmaps[1][1] == 1 && (hmaps[0][1] == 1 && hmaps[0][1] == 0))
        {
            for (int i = 8; i < 16; i++)
            {
                for (int j = 8; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i == 8)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 3;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                    else if (maps[i - 1][j] == 2 || maps[i][j - 1] == 2)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 3;
                        }
                        else
                        {
                            maps[i][j] = 1;
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 1;
                        }
                        else
                        {
                            maps[i][j] = 2;
                        }
                    }
                }
            }
        }
        else if (hmaps[1][0] == 1 && hmaps[1][1] == 2 && (hmaps[0][1] == 1 || hmaps[0][1] == 0))
        {
            for (int i = 8; i < 16; i++)
            {
                for (int j = 8; j < 16; j++)
                {
                    dice = UnityEngine.Random.Range(0, 12);
                    if (i == 8 || j == 8)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                    else if (maps[i - 1][j] == 5 || maps[i][j - 1] == 5)
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 6;
                        }
                        else
                        {
                            maps[i][j] = 4;
                        }
                    }
                    else
                    {
                        if (dice < 9)
                        {
                            maps[i][j] = 4;
                        }
                        else
                        {
                            maps[i][j] = 5;
                        }
                    }
                }
            }
        }
        for(int i = 0; i < 16; i++)
        {
            for(int j= 0; j < 16; j++)
            {
                float objectHeight = Prefabs[maps[i][j]].GetComponent<Renderer>().bounds.size.y;
Instantiate(Prefabs[maps[i][j]], new Vector3((float)i, objectHeight/2f, (float)j), Quaternion.identity);

            }
        }
    }
}
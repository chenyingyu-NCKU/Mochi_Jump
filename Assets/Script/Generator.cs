using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Camera 寬度:-14~14
    public GameObject platformPrefab; // 產生不會動的地板
    public GameObject platformOncePrefab; // 產生只能採一次的地板
    public GameObject platformMovingPrefab; // 產生會移動的地板
    public GameObject BigCoin; // *
    public GameObject SmallCoin; // *
    public GameObject Apple; // *
    public GameObject Enemy; // *    

    public Transform player; // Player物件

    float player_Y = 0f; // 紀錄Player最一開始的的X座標
    float player_X = 0f; // 紀錄Player最一開始的Y座標
    float playerNowPo = 0f; // 紀錄Player當下的Y座標
    float movingRange = 0f; // 紀錄移動地板產生的X座標    

    bool first = true; // 紀錄是不是第一次生成
    bool apple = false;
    public int mode = 0; // 紀錄生成的次數(當作模式的一種，數字越大越難)

    int appleDistance = 3; // *
    int numberOfPlatforms = 20; // 產生地板的數量
    int applePro = 0; // *
    int coinPro = 0; // *
    int enemyPro = 0; // *
    int enemyMaxPro = 20;
    public int probability = 95; // 產生採一次地板的機率
    public int proMoving = 1000; // 產生移動地板的機率

    private float levelWidth = 9.5f; // 產生地板的寬度
    [SerializeField] private float minY = 3f; // 產生地板的最小高度
    [SerializeField] private float maxY = 4f; // 產生地板的最大高度
    [SerializeField] private float generate = 40f; // 當距離大於這個，表示需要產生地板了
    public float testing = 0f; // 看數據OwO

    float height = 0; // 紀錄產生的地板中最高的


    void Start()
    {
        Camera camera = Camera.main; // Main Camera
        player_Y = player.position.y; // 紀錄Player最一開始的Y座標
        player_X = camera.transform.position.x; // 紀錄Camera的X座標
        GeneralPlatform(first); // 產生地板
        mode++;
        first = false; // 初始化第一次產生
    }


    void Update()
    {
        playerNowPo = player.position.y; // 紀錄Player當下的高度
        testing = playerNowPo - player_Y;
        if (playerNowPo - player_Y > generate)
        {
            mode++;
            player_Y = playerNowPo;
            if (mode <= 2) // *
            {
                GeneralPlatform(first);
            }
            else if (mode >= 3 && mode < 5) // 第二難度 // *
            {
                numberOfPlatforms = 10;
                minY = 6f; // *
                maxY = 8f; // *
                generate = 60;
                GeneralPlatform(first);
            }
            else if (mode >= 5) // 第三難度 // *
            {
                enemyMaxPro = 10;
                appleDistance--; // *
                if (mode > 30) // 第四難度 // *
                    proMoving = 80;
                minY = 8f;
                maxY = 12f;
                generate = 80;
                GeneralPlatform(first);
            }
            if (appleDistance < 0) // *
                appleDistance = 0;
        }
    }

    void GeneralPlatform(bool first)
    {
        Vector3 spawnPosition = new Vector3();
        applePro = Random.Range(0, 15); // *
        enemyPro = Random.Range(3, enemyMaxPro); // *
        int moneyOrPlatform = Random.Range(1, 4); // *

        if (first) // 第一次生成時，生成的高度要跟Player一樣，不是第一次生成時，需要用目前最高的地板的高度
        {
            spawnPosition = player.position;
        }
        else
        {
            spawnPosition = new Vector3(0, height, 0);
        }

        if (moneyOrPlatform == 1 && !first) // *
        {
            spawnPosition.y += 3; // 生成地板的高度
            int moneyMode = Random.Range(1, 4);
            switch (moneyMode)
            {
                case 1: // Stairs 
                    for (int i = 0; i < 26; i++)
                    {
                        int bOS = Random.Range(1, 13);
                        if (bOS == 1)
                        {
                            if (i < 6)
                                Instantiate(BigCoin, new Vector3(14 - i * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                            else if (i < 11)
                                Instantiate(BigCoin, new Vector3(-8 + (i - 5) * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                            else if (i < 16)
                                Instantiate(BigCoin, new Vector3(14 - (i - 10) * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                            else if (i < 21)
                                Instantiate(BigCoin, new Vector3(-8 + (i - 15) * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                            else if (i < 26)
                                Instantiate(BigCoin, new Vector3(14 - (i - 20) * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                        }
                        else if (bOS == 2)
                        {
                            if (i < 6)
                                Instantiate(Apple, new Vector3(14 - i * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                            else if (i < 11)
                                Instantiate(Apple, new Vector3(-8 + (i - 5) * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                            else if (i < 16)
                                Instantiate(Apple, new Vector3(14 - (i - 10) * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                            else if (i < 21)
                                Instantiate(Apple, new Vector3(-8 + (i - 15) * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                            else if (i < 26)
                                Instantiate(Apple, new Vector3(14 - (i - 20) * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                        }
                        else
                        {
                            if (i < 6)
                                Instantiate(SmallCoin, new Vector3(14 - i * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                            else if (i < 11)
                                Instantiate(SmallCoin, new Vector3(-8 + (i - 5) * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                            else if (i < 16)
                                Instantiate(SmallCoin, new Vector3(14 - (i - 10) * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                            else if (i < 21)
                                Instantiate(SmallCoin, new Vector3(-8 + (i - 15) * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                            else if (i < 26)
                                Instantiate(SmallCoin, new Vector3(14 - (i - 20) * 4.4f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                        }
                        if (i == 25)
                        {
                            spawnPosition.y += i * 4;
                            height = spawnPosition.y;
                        }
                    }
                    break;
                case 2: // YA
                    for (int k = 0; k < 3; k++)
                    {
                        if(k != 2)
                            spawnPosition.y += 3;
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 16; j++)
                            {
                                int bOS = Random.Range(1, 101);
                                if (bOS == 1)
                                {
                                    switch (i)
                                    {
                                        case 5:
                                            if (j == 0 || j == 6 || j == 10)
                                                Instantiate(BigCoin, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 4:
                                            if (j == 1 || j == 5 || j == 9 || j == 11)
                                                Instantiate(BigCoin, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 3:
                                            if (j == 2 || j == 4 || j == 8 || j == 12)
                                                Instantiate(BigCoin, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 2:
                                            if (j == 3 || j == 7 || j == 9 || j == 11 || j == 13)
                                                Instantiate(BigCoin, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 1:
                                            if (j == 3 || j == 6 || j == 14)
                                                Instantiate(BigCoin, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 0:
                                            if (j == 3 || j == 5 || j == 15)
                                                Instantiate(BigCoin, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                    }
                                }
                                else if (bOS == 2)
                                {
                                    switch (i)
                                    {
                                        case 5:
                                            if (j == 0 || j == 6 || j == 10)
                                                Instantiate(Apple, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 4:
                                            if (j == 1 || j == 5 || j == 9 || j == 11)
                                                Instantiate(Apple, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 3:
                                            if (j == 2 || j == 4 || j == 8 || j == 12)
                                                Instantiate(Apple, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 2:
                                            if (j == 3 || j == 7 || j == 9 || j == 11 || j == 13)
                                                Instantiate(Apple, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 1:
                                            if (j == 3 || j == 6 || j == 14)
                                                Instantiate(Apple, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 0:
                                            if (j == 3 || j == 5 || j == 15)
                                                Instantiate(Apple, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (i)
                                    {
                                        case 5:
                                            if (j == 0 || j == 6 || j == 10)
                                                Instantiate(SmallCoin, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 4:
                                            if (j == 1 || j == 5 || j == 9 || j == 11)
                                                Instantiate(SmallCoin, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 3:
                                            if (j == 2 || j == 4 || j == 8 || j == 12)
                                                Instantiate(SmallCoin, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 2:
                                            if (j == 3 || j == 7 || j == 9 || j == 11 || j == 13)
                                                Instantiate(SmallCoin, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 1:
                                            if (j == 3 || j == 6 || j == 14)
                                                Instantiate(SmallCoin, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                        case 0:
                                            if (j == 3 || j == 5 || j == 15)
                                                Instantiate(SmallCoin, new Vector3(-8 + j * 1.35f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                            break;
                                    }
                                }
                            }
                            if (i == 5)
                            {
                                spawnPosition.y += i * 4;
                                height = spawnPosition.y;
                            }
                        }
                    }
                    break;
                case 3: // A lot of line.
                    for (int k = 0; k < 3; k++)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                int bOS = Random.Range(1, 26);
                                if (bOS == 1)
                                {
                                    Instantiate(BigCoin, new Vector3(-8 + j * 3.6f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                }
                                else if (bOS == 2)
                                {
                                    Instantiate(Apple, new Vector3(-8 + j * 3.6f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                }
                                else
                                {
                                    Instantiate(SmallCoin, new Vector3(-8 + j * 3.6f, spawnPosition.y + i * 4, 0), Quaternion.identity);
                                }
                            }
                            if (i == 2)
                            {
                                spawnPosition.y += i * 4;
                                height = spawnPosition.y;
                            }
                        }
                        if(k != 2)
                                spawnPosition.y += 7;
                    }
                    break;
            }
        }
        else
        {
            for (int i = 0; i < numberOfPlatforms; i++)
            {
                spawnPosition.y += Random.Range(minY, maxY); // 生成地板的高度
                if (i == numberOfPlatforms - 1) // 記憶生成物件的最高點
                    height = spawnPosition.y;
                spawnPosition.x = Random.Range(-levelWidth + player_X, levelWidth + player_X); // 生成地板的範圍
                movingRange = Random.Range(-levelWidth + player_X + 4, levelWidth + player_X - 4); // 生成地板的範圍(移動地板)
                int random = Random.Range(1, 101); // 機率
                if (random <= probability)
                {
                    Instantiate(platformOncePrefab, spawnPosition, Quaternion.identity);
                }
                else if (random <= proMoving + 5)
                {
                    spawnPosition.x = movingRange;
                    Instantiate(platformMovingPrefab, spawnPosition, Quaternion.identity);
                }
                else
                {
                    if (i == enemyPro && mode > 5)
                    {
                        int leftOrRight = Random.Range(1, 3);
                        int upOrDown = Random.Range(1, 3);
                        if (leftOrRight == 1) // left
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                Instantiate(platformPrefab, new Vector3(-6 + j * 6.5f, spawnPosition.y), Quaternion.identity);
                            }
                            if (upOrDown == 1) // Up
                                Instantiate(Enemy, new Vector3(-8, spawnPosition.y + 4), Quaternion.identity);
                            else if (upOrDown == 2 && !apple) // Down
                                Instantiate(Enemy, new Vector3(-8, spawnPosition.y - 4), Quaternion.identity);
                            else
                                Instantiate(Enemy, new Vector3(-8, spawnPosition.y + 4), Quaternion.identity);
                        }
                        else if (leftOrRight == 2) // right
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                Instantiate(platformPrefab, new Vector3(12 - j * 6.5f, spawnPosition.y), Quaternion.identity);
                            }
                            if (upOrDown == 1) // Up
                                Instantiate(Enemy, new Vector3(1, spawnPosition.y + 4), Quaternion.identity);
                            else if (upOrDown == 2 && !apple) // Down
                                Instantiate(Enemy, new Vector3(1, spawnPosition.y - 4), Quaternion.identity);
                            else
                                Instantiate(Enemy, new Vector3(1, spawnPosition.y + 4), Quaternion.identity);
                        }
                    }
                    else
                    {
                        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
                        if (i == applePro) // *
                        {
                            Instantiate(Apple, spawnPosition + new Vector3(0, 3, 0), Quaternion.identity);
                            spawnPosition.y += appleDistance;
                            apple = true;
                        }
                    }
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class tilescript : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    private Camera _camera;

    // タイルの位置関係を保持する配列
    private static Transform[] tiles;

    // Stringの3x5の二次元配列
    public static string[,] stringArray = {
        {"R1", "R3", "R5", "R6", "R4"},
        {"R0", "R4", "R5", "R3", "R5"},
        {"R5", "R6", "R3", "R5", "R5"},
    };

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;

        // タイルの位置を配列に保存
        tiles = GameObject.FindGameObjectsWithTag("Tile").Select(tile => tile.transform).ToArray();

        // debug
        // log stringArray
        // for (int i = 0; i < stringArray.GetLength(0); i++)
        // {
        //     for (int j = 0; j < stringArray.GetLength(1); j++)
        //     {
        //         Debug.Log(stringArray[i, j] + " " + i + " " + j);
        //     }
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit)
            {
                // "Tile" タグを持つオブジェクトとのみ当たり判定を行う
                if (hit.transform.CompareTag("Tile"))
                {
                    if (Vector2.Distance(emptySpace.position, hit.transform.position) < 3)
                    {
                        SwapTiles(emptySpace, hit.transform);

                        // Stringの3x5の二次元配列をSwapする例
                        // int row1 = 1;
                        // int col1 = 2;
                        // int row2 = 2;
                        // int col2 = 3;
                        // SwapStringArrayElements(stringArray, row1, col1, row2, col2);
                    }
                }
            }
        }
    }


    // タイルの位置を取得する静的な関数
    public static Transform[] GetTilePositions()
    {
        return tiles;
    }

    // タイルを交換する関数
    private void SwapTiles(Transform tile1, Transform tile2)
    {
        Vector2 lastEmptySpacePosition = emptySpace.position;
        emptySpace.position = tile2.position;
        tile2.position = lastEmptySpacePosition;

        // タイル1とタイル2の位置情報から対応する行と列を計算
        float posX1 = tile1.position.x + 1.35f;
        float posY1 = tile1.position.y + 1.35f;
        float posX2 = tile2.position.x + 1.35f;
        float posY2 = tile2.position.y + 1.35f;

        int row1, col1, row2, col2;
        TilePath.GetTileNumber(new Vector2(posX1, posY1), out col1, out row1);
        TilePath.GetTileNumber(new Vector2(posX2, posY2), out col2, out row2);

        bool isMoveSanta = CheckMoveSanta(col1, row1);
        bool isMoveGood = CheckMoveGood(col1, row1);
        bool isMoveBad = CheckMoveBad(col1, row1);
        Debug.Log("IsMoveSanta: " + isMoveSanta + " IsMoveGood: " + isMoveGood + " IsMoveBad: " + isMoveBad);
        if (isMoveSanta)
        {
            SantaPositionMove(col1, row1, col2, row2);
        }
        if (isMoveGood)
        {
            GoodPositionMove(col1, row1, col2, row2);
        }
        if (isMoveBad)
        {
            BadPositionMove(col1, row1, col2, row2);
        }

        // タイルの位置が変更された後、対応するstringArrayの要素も交換する
        SwapStringArrayElements(stringArray, row1, col1, row2, col2);
    }

    // Stringの2次元配列の要素を交換する関数
    private static void SwapStringArrayElements(string[,] array, int row1, int col1, int row2, int col2)
    {
        int numRows = array.GetLength(0);
        int numCols = array.GetLength(1);
        // Debug.Log("numRows: " + numRows + " numCols: " + numCols);
        // Debug.Log("row1: " + row1 + " col1: " + col1 + " row2: " + row2 + " col2: " + col2);
        if (row1 >= 0 && row1 < numRows && col1 >= 0 && col1 < numCols &&
            row2 >= 0 && row2 < numRows && col2 >= 0 && col2 < numCols)
        {
            string temp = array[row1, col1];
            array[row1, col1] = array[row2, col2];
            // Debug.Log("Converted " + array[row2, col2] + " to " + temp);
            array[row2, col2] = temp;
        }
    }

    // Stringの2次元配列内の要素を取得する関数
    public static string GetStringArrayElement(int col, int row)
    {
        // row = 2 - row;
        int numRows = stringArray.GetLength(0);
        int numCols = stringArray.GetLength(1);

        if (row >= 0 && row < numRows && col >= 0 && col < numCols)
        {
            return stringArray[row, col];
        }
        else
        {
            return null; // 配列外の場合はnullを返すか、エラー処理を追加してください。
        }
    }

    // サンタを移動させるか判断する関数
    public bool CheckMoveSanta(int nextCol, int nextRow)
    {
        // 現在位置のインデックスを取得
        int curCol = SantaController.posX;
        int curRow = SantaController.posY;

        // Debug.Log("Santa (Col, Row)" + curCol + " " + curRow + "  NextCol" + nextCol + " " + nextRow);

        int diffCol = Mathf.Abs(curCol - nextCol);
        int diffRow = Mathf.Abs(curRow - nextRow);
        // 判断
        if (diffCol + diffRow == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // サンタを移動させる関数
    public void SantaPositionMove(int nextCol, int nextRow, int curCol, int curRow)
    {
        int diffCol = - nextCol + curCol; // Y
        int diffRow = - nextRow + curRow; // X

        SantaController.posX += diffCol;
        SantaController.posY += diffRow;

        Vector3 diffMove = new Vector3(diffCol*2.7f, diffRow*2.7f, 0.0f);

        //FuckinSanta.curPos -= diffMove;
        // SantaController santaController = GetComponent<SantaController>(); // サンタのコントローラーを取得
        // santaController. += diffMove;
        SantaController.swapMove += diffMove;

        Debug.Log("Diff X, Y" + diffCol + " " + diffRow + " Diff move" + diffMove);
    }

    // 良い子を移動させるか判断する関数
    public bool CheckMoveGood(int nextCol, int nextRow)
    {
        Vector2 curGoodPos = GoodChildController.curPos;
        int curCol, curRow;
        TilePath.GetTileNumber(curGoodPos, out curCol, out curRow);

        int diffCol = Mathf.Abs(curCol - nextCol);
        int diffRow = Mathf.Abs(curRow - nextRow);
        // 判断
        if (diffCol + diffRow == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 良い子を移動させる関数
    public void GoodPositionMove(int nextCol, int nextRow, int curCol, int curRow)
    {
        int diffCol = - nextCol + curCol; // Y
        int diffRow = - nextRow + curRow; // X

        Vector3 diffMove = new Vector3(diffCol*2.7f, diffRow*2.7f, 0.0f);
        GoodChildController.swapMove += diffMove;

        Debug.Log("Diff X, Y" + diffCol + " " + diffRow + " Diff move" + diffMove);
    }


    // 悪い子を移動させるか判断する関数
    public bool CheckMoveBad(int nextCol, int nextRow)
    {
        Vector2 curGoodPos = BadChildController.curPos;
        int curCol, curRow;
        TilePath.GetTileNumber(curGoodPos, out curCol, out curRow);

        int diffCol = Mathf.Abs(curCol - nextCol);
        int diffRow = Mathf.Abs(curRow - nextRow);
        // 判断
        if (diffCol + diffRow == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // 悪い子を移動させる関数
    public void BadPositionMove(int nextCol, int nextRow, int curCol, int curRow)
    {
        int diffCol = - nextCol + curCol; // Y
        int diffRow = - nextRow + curRow; // X

        Vector3 diffMove = new Vector3(diffCol*2.7f, diffRow*2.7f, 0.0f);
        BadChildController.swapMove += diffMove;

        Debug.Log("Diff X, Y" + diffCol + " " + diffRow + " Diff move" + diffMove);
    }
}

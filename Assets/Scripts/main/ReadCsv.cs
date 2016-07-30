using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;
using System.IO;

using UnityEngine.Assertions;

public class ReadCsv : MonoBehaviour
{
    enum MapDataName
    {
        NONE = 0,
        WALL,

        CHILD_ONE_RIGHT,
        CHILD_ONE_UP,
        CHILD_ONE_LEFT,
        CHILD_ONE_DOWN,

        CHILD_TWO_RIGHT,
        CHILD_TWO_UP,
        CHILD_TWO_LEFT,
        CHILD_TWO_DOWN,

        ADULT_RIGHT,
        ADULT_UP,
        ADULT_LEFT,
        ADULT_DOWN
    }

    //現在０番が15、１番が25
    [SerializeField, Tooltip("現在はテスト中。決まり次第定数化")]
    private int[] dataElements;

    //CSVから読み込んだマップチップを格納
    //縦・横
    private int[,] mapChipData;

    public int[,] MapChipData
    {
        get { return mapChipData; }
    }

    void Start()
    {
        //これはのちのちランダムに選択する
        //Tips:読み込むCSVを決めるReadCsvもあとで作る
        string path = Application.dataPath + "/CSVDatas/stage/stage_15_map01.csv";
        //string path = Application.dataPath + "/CSVDatas/stage/stage_25_map01.csv";

        //CSVデータを読み込んで、行に分割
        string[] lines = ReadCsvData(path);

        //csvデータの初期化
        mapChipData = new int[lines.Length, dataElements[0]];

        //カンマ分けされたデータを仮格納する。その初期化
        string[] didCommaSeparationData = new string[lines.Length];

        //CSVデータを区切る文字
        char[] commaSpliter = { ',' };

        for (int y = 0; y < lines.Length; y++)
        {
            //カンマ分けされたデータを格納
            didCommaSeparationData = DataSeparation(lines[y],commaSpliter,lines.Length);
            
            for (int x = 0; x < dataElements[0]; x++)
            {
                mapChipData[y, x] = Convert.ToInt16(didCommaSeparationData[x]);

                Debug.Log(mapChipData[y,x]);
            }

            //Debug.Log(mapChipData);

        }
    }

    //第一引数…読み込むCSVデータファイルのパス　
    string[] ReadCsvData(string path_)
    {
        StreamReader sr = new StreamReader(path_);
        string strStream = sr.ReadToEnd();

        //カンマとカンマの間に何もなかったら格納しないことにする設定
        System.StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries;

        //行に分ける
        string[] lines = strStream.Split(new char[] { '\r', '\n' }, option);

        return lines;
    }

    //第一引数…ReadCsvData関数で一行にされたデータ
    //第二引数…渡されたデータを区切る文字
    //第三引数…第一引数のデータの要素数。for文の周回数
    string[] DataSeparation(string lines_, char[] spliter_, int trialNumber_)
    {
        //カンマとカンマの間に何もなかったら格納しないことにする設定
        System.StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries;

        //リターン値。カンマ分けしたデータを一行分格納する。
        string[] CommaSeparationData = new string[trialNumber_];

        for (int i = 0; i < trialNumber_; i++)
        {
            //１行にあるCsvDataの要素数分準備する
            string[] readStrData = new string[trialNumber_];
            //CsvDataを引数の文字で区切って1つずつ格納
            readStrData = lines_.Split(spliter_, option);
            //readStrDataをリターン値に格納
            CommaSeparationData[i] = readStrData[i];
        }

        return CommaSeparationData;
    }

    //MapDataName MapDataChecker(string dataNum_)
    //{
    //    if ()
    //    {
    //        return 
    //    }


    //};

}



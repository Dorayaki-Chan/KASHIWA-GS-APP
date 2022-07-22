using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace GSApp1
{
    internal class HandleCSV
    {
        //List<List<string>> cmdlists = new List<List<string>>()
        public struct Grid
        {
            public int num;
            public string system;
            public string command;
            public string detail;
            public Grid(int i_num, string i_system, string i_command, string i_detail)
            {
                num = i_num;
                system = i_system;
                command = i_command;
                detail = i_detail;
            }
        }
        public List<Grid> cmdlists = new List<Grid>();
        private Boolean flag = false;
        public HandleCSV()
        {
            Console.WriteLine("コンストラクタを実行しました。何もできないけど");
        }
        public void readCSV(string filename)
        {
            // 読み込みたいCSVファイルのパスを指定して開く
            using (StreamReader sr = new StreamReader(filename, Encoding.GetEncoding("Shift_JIS")))
            {
                int count = 0;
                // 末尾まで繰り返す
                while (!sr.EndOfStream)
                {
                    // CSVファイルの一行を読み込む
                    string line = sr.ReadLine();
                    // 読み込んだ一行をカンマ毎に分けて配列に格納する
                    string[] values = line.Split(',');

                    // 配列からリストに格納する
                    //List<string> lists = new List<string>();
                    //lists.AddRange(values);
                    cmdlists.Add(new Grid(count, values[0], values[1], values[2]));
                    //cmdlists.Add(lists);

                    // コンソールに出力する
                    /*
                    foreach (string list in lists)
                    {
                        System.Console.Write("{0} ", list);
                    }

                    System.Console.WriteLine();
                    */
                    count++;
                }
                //System.Console.Read();
            }
            this.flag = true;
            Console.WriteLine("テスト");
            foreach (Grid grid in cmdlists)
            {
                Console.Write(grid.num);
                Console.Write(grid.system);
                Console.Write(grid.command);
                Console.Write(grid.detail);
                Console.WriteLine("\n");
            }
        }
    }
    
}

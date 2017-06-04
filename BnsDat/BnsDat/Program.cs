using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProgressBarSolution;

namespace BnsDat
{
    class Program
    {
        static void Main(string[] args)
        {
            //无参数调用本程序
            if (args.Length != 2)
            {
                Usage();
                Console.ReadKey();
                return;
            }

            BNSDat bnsdat = new BNSDat();

            if (!File.Exists("Ionic.Zlib.dll"))
            {
                File.WriteAllBytes(Directory.GetCurrentDirectory()+ "\\Ionic.Zlib.dll", Resource_lib.Ionic_Zlib);
            }

            if (args[0] == "-e")
            {
                Console.Write("正在解包: ");
                ProgressBar progressBar = new ProgressBar(Console.CursorLeft, Console.CursorTop, 50, ProgressBarType.Multicolor);
                bnsdat.Extract(args[1], args[1].Contains("64"), progressBar.Dispaly);
                Console.WriteLine("  解包完成");
            }
            else if (args[0] == "-c")
            {
                Console.Write("正在打包: ");
                ProgressBar progressBar = new ProgressBar(Console.CursorLeft, Console.CursorTop, 50, ProgressBarType.Multicolor);
                bnsdat.Compress(args[1], args[1].Contains("64"), progressBar.Dispaly);
                Console.WriteLine("  打包完成");
            }
            else
            {
                Console.WriteLine("命令无效");
                Usage();
                return;
            }
            
            
        }
        public static void Usage()
        {
            Console.WriteLine("\n调用方法: bnsdat.exe [命令] [文件(夹)]\n");
            Console.WriteLine("命令：\n");
            Console.WriteLine("  -e 文件 \t解包 xml.dat/config.dat/xml64.dat/config64.dat 到相应文件夹，例如 xml.dat.files \n");
            Console.WriteLine("  -c 文件夹 \t打包 xml.dat.files/config.dat.files/xml64.dat.files/config64.dat.files 为相应文件，例如 xml.dat \n");
            Console.WriteLine("\nBy 烟寒: https://github.com/laoluan/bnsdat \n");
        }
    }

    

}

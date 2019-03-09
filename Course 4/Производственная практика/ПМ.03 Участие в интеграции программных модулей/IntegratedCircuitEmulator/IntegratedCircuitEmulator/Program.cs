using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace IntegratedCircuitEmulator
{
    class ICEmulator
    {
        byte[] DIY = new byte[8], DIX = new byte[8], DI = new byte[16], INS = new byte[3], DO = new byte[16];
        bool CX, CY, EH, EL;
        byte CRI8, CRI0;
        bool[] V = new bool[2], G = new bool[2];
        FileStream configFile, dataFile;
        string[] pinsplace, data;

        public void InputData()
        {
            if (InputFilePaths())
            {
                StreamReader reader = new StreamReader(configFile);
                string[] configData = reader.ReadToEnd().Split('=', '\n');
                pinsplace = new string[configData.Length / 2];
                int j = 0;
                //   Console.WriteLine(configData.Length);
                for (int i = 2; i < configData.Length; i++)
                {
                    if (configData[i].IndexOf("#") != -1)
                    {
                        configData[i] = configData[i].Substring(0, configData[i].IndexOf("#"));
                    }
                    if (i % 2 == 1)
                    {
                        pinsplace[j] = configData[i].Trim();
                        j++;
                    }
                }
                reader = new StreamReader(dataFile);
                data = reader.ReadToEnd().Split(',');
                data[0] = data[0].Substring(data[0].IndexOf('$'));
                data[0] = data[0].Substring(data[0].IndexOf(' ')); //trim the header 
                int k = 0;
                for (int i = 0; i < data.Length - 1; i++)
                {
                    data[i] = data[i].Substring(data[i].IndexOf('X'));
                    //  Console.WriteLine("\n" + data[i]);
                    k = 0;
                }
                reader.Close(); //закрываем поток
            }
        }

        private void GetData(int i)
        {
            int k = 0;
            for (byte n = 0; n < data[i].Length; n++)
            {

                if (data[i][n] != ' ')
                {
                    if (pinsplace[k].Contains("V"))
                    {
                        V[1 - Convert.ToByte(pinsplace[k][1].ToString())] = (data[i][n] == '1');
                    }
                    if (pinsplace[k].Contains("G"))
                    {
                        G[1 - Convert.ToByte(pinsplace[k][1].ToString())] = (data[i][n] == '1');
                    }
                    if (pinsplace[k].Contains("DIY"))
                    {
                        DIY[7 - Convert.ToByte(pinsplace[k][3].ToString())] = Convert.ToByte(data[i][n].ToString());
                    }
                    else
                    if (pinsplace[k].Contains("DIX"))
                    {
                        DIX[7 - Convert.ToByte(pinsplace[k][3].ToString())] = Convert.ToByte(data[i][n].ToString());
                    }
                    else
                    if (pinsplace[k].Contains("DI"))
                    {
                        byte ind = Convert.ToByte(pinsplace[k][2].ToString(), 16);
                        DI[15 - ind] = Convert.ToByte(data[i][n].ToString());
                    }
                    if (pinsplace[k].Contains("EH"))
                    {
                        EH = (data[i][n] == '1');
                    }
                    if (pinsplace[k].Contains("EL"))
                    {
                        EL = (data[i][n] == '1');
                    }
                    if (pinsplace[k].Contains("INS"))
                    {
                        INS[2 - Convert.ToByte(pinsplace[k][3].ToString())] = Convert.ToByte(data[i][n].ToString());
                    }
                    if (pinsplace[k].Contains("CRI8"))
                    {
                        CRI8 = Convert.ToByte(data[i][n].ToString());
                    }
                    if (pinsplace[k].Contains("CRI0"))
                    {
                        CRI0 = Convert.ToByte(data[i][n].ToString());
                    }
                    if (pinsplace[k].Contains("CX"))
                    {
                        CX = (data[i][n] == '1');
                    }
                    if (pinsplace[k].Contains("CY"))
                    {
                        CY = (data[i][n] == '1');
                    }
                    if (pinsplace[k].Contains("DO"))
                    {
                        byte ind = Convert.ToByte(pinsplace[k][2].ToString(), 16);
                        DO[ind] = n;
                    }
                    k++;
                }
            }
        }

        private bool InputFilePaths()
        {
            Console.WriteLine("Введите путь к файлу PINSPLACE");
            // string path = Console.ReadLine();
            string path = "C://Users/Nastya.delltouch/Desktop/Отчеты/ВР5/D5.pinsplace.txt";
            if (File.Exists(path))
            {
                this.configFile = new FileStream(path, FileMode.Open, FileAccess.Read);
            }
            else
            {
                Console.WriteLine("Файл PINSPLACE по указанному пути не найден");
                return false;
            }
            Console.WriteLine("Введите путь к файлу с данными");
            // path = Console.ReadLine();
            path = "C://Users/Nastya.delltouch/Desktop/Отчеты/ВР5/ФК 1 D5 0000.txt";
            if (File.Exists(path))
            {
                this.dataFile = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            }
            else
            {
                Console.WriteLine("Файл с данными по указанному пути не найден");
                return false;
            }
            return true;
        }

        public void Emulate()
        {
            InputData();
            for (int i = 0; i < data.Length - 1; i++)
            {//write here
                GetData(i);
                string result = "";
                if (CX && CY)
                {
                    switch (String.Join("", INS))
                    {
                        case "101": result = Multiplication(); break;
                        case "010": result = LogicalLeftShift(); break;
                        case "110": result = ArithmeticLeftShift(); break;
                    }
                    result =  result.PadLeft(16, '0');
                }
            }
        }

        private int ByteArrayToInt(byte[] s)
        {
            try
            {
                byte value;
                int result = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    value = s[i];

                    if (value == 1)
                        result += (int)Math.Pow(2, s.Length - 1 - i);

                    else if (value > 1)
                        throw new Exception("Invalid!");
                }
                return result;
            }
            catch
            {
                throw new Exception("Invalid!");
            }
        }

        private void OutputResult(int R)
        {

        }

        private void CountZeroes()
        {
            Console.WriteLine("CountZeroes");
        }

        private void MultiplyCodes()
        {
            Console.WriteLine("MultiplyCodes");
        }

        private string Multiplication()
        {

            int R = 0, x = ByteArrayToInt(DIX), y = ByteArrayToInt(DIY), s = ByteArrayToInt(DI);
            int l_pow = 1 << 15, p_pow = 1 << 16;
            if (!(V[0]) && (G[0] || G[1]))
            {
                R = x * y + s + CRI8 + CRI0;
            }
            if ((V[0] && !V[1]) && (G[0] || G[1]))
            {
                R = x * y + l_pow - 2 * Convert.ToByte(DIX[0]) * y - 128 + s + CRI8 + CRI0;
            }
            if ((V[0] && V[1]) && (G[0] || G[1]))
            {
                R = x * y + l_pow - 2 * Convert.ToByte(DIX[0]) * y + s + CRI8 + CRI0;
            }
            if (!(V[0] || V[1] || G[0] || G[1]))
            {
                R = x * y + l_pow - 2 * Convert.ToByte(DIY[0]) * x - 128 + s + CRI8 + CRI0;
            }
            if ((V[0] && !V[1]) && !(G[0] || G[1]))
            {
                R = x * y + p_pow + 4 * Convert.ToByte(DIX[0]) * Convert.ToByte(DIY[0]) - 2 * Convert.ToByte(DIX[0]) * y - 2 * Convert.ToByte(DIY[0]) * x - 256 + (Convert.ToInt32(DI.ToString().Substring(1, 15))) + CRI8 + CRI0;
            }
            if ((!V[0] && V[1]) && !(G[0] || G[1]))
            {
                R = x * y + l_pow - 2 * Convert.ToByte(DIY[0]) * x + s + CRI8 + CRI0;
            }
            if ((V[0] && V[1]) && !(G[0] || G[1]))
            {
                R = x * y + p_pow + 4 * Convert.ToByte(DIX[0]) * Convert.ToByte(DIY[0]) - 2 * Convert.ToByte(DIX[0]) * y - 2 * Convert.ToByte(DIY[0]) * x - 128 + (Convert.ToInt32(DI.ToString().Substring(1, 15))) + CRI8 + CRI0;
            }
            return Convert.ToString(R, 2);
        }

        private string LogicalLeftShift()
        { 
            int r, x = ByteArrayToInt(DIX), y = ByteArrayToInt(DIY), s = ByteArrayToInt(DI), k = DIY[2] + DIY[1] + DIY[0];
            int k_pow = 1 << k;

            if ((G[0] && G[1] && !Convert.ToBoolean(DIY[2]) && !Convert.ToBoolean(DIY[3])) ||
                (G[0] && !G[1] && !Convert.ToBoolean(DIY[2]) && Convert.ToBoolean(DIY[3])) ||
                (!G[0] && G[1] && Convert.ToBoolean(DIY[2]) && !Convert.ToBoolean(DIY[3])) ||
                (!G[0] && !G[1] && Convert.ToBoolean(DIY[2]) && Convert.ToBoolean(DIY[3])))
            {
                r = x * k_pow + CRI8 + CRI0 + s;
            }
            else
            {
                r = s + CRI8 + CRI0;
            }
            return Convert.ToString(r, 2);
        }

        private string ArithmeticLeftShift()
        {
            int r = 0, x = ByteArrayToInt(DIX), y = ByteArrayToInt(DIY), s = ByteArrayToInt(DI), k = DIY[2] + DIY[1] + DIY[0];
            int k_pow = 1 << k, l_pow = 1 << 15, p_pow = 1 << 16;
            if (V[0] && V[1])
            {
                if ((G[0] && G[1]) && (!Convert.ToBoolean(DIY[2]) && !Convert.ToBoolean(DIY[3])) ||
                     (G[0] && !G[1]) && (!Convert.ToBoolean(DIY[2]) && Convert.ToBoolean(DIY[3])) ||
                     (!G[0] && G[1]) && (Convert.ToBoolean(DIY[2]) && !Convert.ToBoolean(DIY[3])))
                {
                    r = x * k_pow + l_pow - 2 * x * k_pow + CRI8 + CRI0 + s;
                }
                if ((!G[0] && !G[1]) && (Convert.ToBoolean(DIY[2]) && Convert.ToBoolean(DIY[3])))
                {
                    r = x * k_pow + p_pow - 2 * x * k_pow + CRI8 + CRI0 + s;
                }
            }
            if (!V[0] && V[1])
            {
                if ((G[0] && G[1]) && (!Convert.ToBoolean(DIY[2]) && !Convert.ToBoolean(DIY[3])) ||
                     (G[0] && !G[1]) && (!Convert.ToBoolean(DIY[2]) && Convert.ToBoolean(DIY[3])) ||
                     (!G[0] && G[1]) && (Convert.ToBoolean(DIY[2]) && !Convert.ToBoolean(DIY[3])))
                {
                    r = x * k_pow + l_pow - (1 << 7) - 2 * x * k_pow + CRI8 + CRI0 + s;
                }
                if ((!G[0] && !G[1]) && (Convert.ToBoolean(DIY[2]) && Convert.ToBoolean(DIY[3])))
                {
                    r = x * k_pow + p_pow - (1 << 7) - 2 * x * k_pow + CRI8 + CRI0 + s;
                }
            }
            if (V[0] && !V[1])
            {
                if ((G[0] && G[1]) && (!Convert.ToBoolean(DIY[2]) && !Convert.ToBoolean(DIY[3])) ||
                     (G[0] && !G[1]) && (!Convert.ToBoolean(DIY[2]) && Convert.ToBoolean(DIY[3])) ||
                     (!G[0] && G[1]) && (Convert.ToBoolean(DIY[2]) && !Convert.ToBoolean(DIY[3])) ||
                     (!G[0] && !G[1]) && (Convert.ToBoolean(DIY[2]) && Convert.ToBoolean(DIY[3])))
                {
                    r = x * k_pow + CRI8 + CRI0 + s;
                }
            }
            if (V[0] && V[1])
            {
                if ((!G[0] && !G[1]) && (!Convert.ToBoolean(DIY[2]) && !Convert.ToBoolean(DIY[3])) ||
                    (!G[0] && !G[1]) && (!Convert.ToBoolean(DIY[2]) && Convert.ToBoolean(DIY[3])))
                {
                    r = p_pow + CRI8 + CRI0 + s;
                }
            }
            if (!V[0] && V[1])
            {
                if ((!G[0] && !G[1]) && (Convert.ToBoolean(DIY[2]) && !Convert.ToBoolean(DIY[3])))
                {
                    r = p_pow - (1 << 7) + CRI8 + CRI0 + s;
                }
            }
            if (!V[0] && !V[1])
            {
                r = l_pow + CRI8 + CRI0 + s;
            }
            if (V[0] && !V[1])
            {
                r = l_pow - (1 << 7) + CRI8 + CRI0 + s;
            }
            if (V[0] && V[1])
            {
                r = l_pow + CRI8 + CRI0;
            }
            return Convert.ToString(r, 2);
        }

        //------------------------------------------------------

        private string CodesMultiplication()
        {
            int R, x = ByteArrayToInt(DIX), y = ByteArrayToInt(DIY), s = ByteArrayToInt(DI);

            R = x * y + s + CRI8 + CRI0;

            return Convert.ToString(R, 2);
        }

        private string LogicalRightShift()
        {
            int R, x = ByteArrayToInt(DIX), y = ByteArrayToInt(DIY), s = ByteArrayToInt(DI), k = DIY[2] + DIY[1] + DIY[0];

            if (((!G[0] && !G[1] && !Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4])) ||
                (!G[0] && G[1] && !Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4])) ||
                (G[0] && !G[1] && Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4])) ||
                (G[0] && G[1] && Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4]))) && k != 0)

                R = x * (1 << (8 - k)) + CRI8 + CRI0 + s;

            else if ((!G[0] && !G[1] && !Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4])) && k == 0)

                R = x * (1 << 8) + CRI0 + (Convert.ToInt32(DI.ToString().Substring(8, 15)));

            else if (((!G[0] && !G[1] && !Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4])) ||
                (!G[0] && G[1] && Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4])) ||
                (G[0] && !G[1] && Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4]))) && k == 0)

                R = x + s + CRI8 + CRI0;

            else

                R = s + CRI8 + CRI0;

            return Convert.ToString(R, 2);
        }

        private string ArithmeticRightShift()
        {
            int R, x = ByteArrayToInt(DIX), y = ByteArrayToInt(DIY), s = ByteArrayToInt(DI), k = DIY[2] + DIY[1] + DIY[0];

            if (V[0] && V[1])
            {
                if (((G[0] && G[1] && Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4])) ||
                    (G[0] && !G[1] && Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4])) ||
                    (!G[0] && G[1] && !Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4]))) && k != 0)

                    R = x * (1 << (8 - k)) + (1 << 15) - 2 * x[0] * (1 << (8 - k)) + CRI8 + CRI0 + s;

                else if ((!G[0] && !G[1] && !Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4])) && k != 0)

                    R = x * (1 << (8 - k)) + (1 << 16) - 2 * x[0] * (1 << (8 - k)) + CRI8 + CRI0 + (Convert.ToInt32(DI.ToString().Substring(1, 15)));

            }

            if (!V[0] && V[1])
            {
                if (((G[0] && G[1] && Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4])) ||
                    (G[0] && !G[1] && Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4])) ||
                    (!G[0] && G[1] && !Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4]))) && k != 0)

                    R = x * (1 << (8 - k)) + (1 << 15) - (1 << 7) - 2 * x[0] * (1 << (8 - k)) + CRI8 + CRI0 + s;

                else if ((!G[0] && !G[1] && !Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4])) && k != 0)

                    R = x * (1 << (8 - k)) + (1 << 16) - (1 << 7) - 2 * x[0] * (1 << (8 - k)) + CRI8 + CRI0 + (Convert.ToInt32(DI.ToString().Substring(1, 15)));

            }

            if (!V[1])
            {
                if (((G[0] && G[1] && Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4])) ||
                    (G[0] && !G[1] && Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4])) ||
                    (!G[0] && G[1] && !Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4])) ||
                    (!G[0] && !G[1] && !Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4]))) && k != 0)

                    R = x * (1 << (8 - k)) + CRI8 + CRI0 + s;

            }

            if (V[0] && V[1])
            {
                if (!G[0] && !G[1] && (!Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4]) ||
                    Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4]) ||
                    Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4])) && k != 0)

                    R = (1 << 16) + (Convert.ToInt32(DI.ToString().Substring(1, 8))) + CRI8 + CRI0;

            }

            if (!V[0] && V[1])
            {
                if (!G[0] && !G[1] && (!Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4]) ||
                   Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4]) ||
                   Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4])) && k != 0)

                    R = (1 << 16) - (1 << 7) + (Convert.ToInt32(DI.ToString().Substring(1, 15))) + CRI8 + CRI0;

            }

            if ((!G[0] && !G[1] && !Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4])) && k == 0)

                R = x + (1 << 8) + CRI0 + (Convert.ToInt32(DI.ToString().Substring(8, 15)));

            if (V[0] && V[1])
            {
                if (((!G[0] && !G[1] && !Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4])) ||
                    (!G[0] && G[1] && Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4])) ||
                    (G[0] && !G[1] && Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4]))) && k == 0)

                    R = x + (1 << 15) - 2 * x[0] + CRI8 + CRI0 + s;

            }

            if (!V[0] && V[1])
            {
                if (((!G[0] && !G[1] && !Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4])) ||
                    (!G[0] && G[1] && Convert.ToBoolean(DIY[3]) && !Convert.ToBoolean(DIY[4])) ||
                    (G[0] && !G[1] && Convert.ToBoolean(DIY[3]) && Convert.ToBoolean(DIY[4]))) && k == 0)

                    R = x + (1 << 15) - 2 * x[0] - (1 << 7) + CRI8 + CRI0 + s;

            }

            if (V[0] && V[1])

                R = (1 << 15) + s + CRI8 + CRI0;

            if (!V[0] && V[1])

                R = (1 << 15) - (1 << 7) + s + CRI8 + CRI0;

            if (!V[1])

                R = s + CRI8 + CRI0;

            return Convert.ToString(R, 2);
        }

        //------------------------------------------------------

        public void ResultsOutput(int i) {
    
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            ICEmulator IC = new ICEmulator();
            IC.Emulate();
            Console.ReadKey();
        }
    }
}

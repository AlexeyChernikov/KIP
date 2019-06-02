using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.IO;
using System.Windows;

namespace CryptographicApplication
{
    class RSA
    {
        Alphabet alph = new Alphabet();

        //дописать функцию генерации ключей

        public string Encrypt(string sourcetext, string key_p, string key_q) //генерация ключа
        {
            StringBuilder code = new StringBuilder();

            long p = Convert.ToInt64(key_p);
            long q = Convert.ToInt64(key_q);

            if (IsTheNumberSimple(p) && IsTheNumberSimple(q))
            {
                long n = p * q;
                long fi = (p - 1) * (q - 1);
                long e = Calculate_e(fi);
                long d = Calculate_d(e, fi);

                List<string> result = RSA_Endoce(sourcetext, e, n);

                /*MessageBox.Show(Convert.ToString(e));
                MessageBox.Show(Convert.ToString(n));
                MessageBox.Show(Convert.ToString(d));
                MessageBox.Show(Convert.ToString(n));*/

                foreach (string item in result)
                    code.Append(item + "\n");
            }

            return code.ToString();
        }

        public string Decrypt(List<string> sourcetext, string key_d, string key_n)
        {
            StringBuilder code = new StringBuilder();

            long d = Convert.ToInt64(key_d);
            long n = Convert.ToInt64(key_n);

            string result = RSA_Dedoce(sourcetext, d, n);

            return result;
        } //изменить

        private List<string> RSA_Endoce(string sourcetext, long e, long n) //шифрование
        {
            List<string> result = new List<string>();

            BigInteger bi;

            for (int i = 0; i < sourcetext.Length; i++)
            {
                int index = Array.IndexOf(alph.lang, sourcetext[i]);

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger bn = new BigInteger((int)n);

                bi = bi % bn;

                result.Add(bi.ToString());
            }

            return result;
        }

        private string RSA_Dedoce(List<string> sourcetext, long d, long n) //дешифрование
        {
            string result = "";

            BigInteger bi;

            foreach (string item in sourcetext)
            {
                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger bn = new BigInteger((int)n);

                bi = bi % bn;

                int index = Convert.ToInt32(bi.ToString());

                if (index == -1)
                {
                    result += " ";
                }
                else
                {
                    result += alph.lang[index].ToString();
                }
            }

            return result;
        }

        private bool IsTheNumberSimple(long n) //является ли число простым
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (int i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        private long Calculate_e(long fi) //вычисление открытой экспоненты
        {
            long e = 2;

            for (int i = 2; i <= fi; i++)
                if ((fi % i == 0) && (e % i == 0) && e < fi) //если имеют общие делители
                {
                    e++;
                    i = 1;
                }

            return e;
        }

        private long Calculate_d(long e, long fi) //вычисление закрытой экспоненты 
        {
            long d = 2;

            while (true)
            {
                if ((d * e % fi == 1) && d != e)
                    break;
                else
                    d++;
            }

            return d;
        }
    }
}
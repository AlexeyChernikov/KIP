using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographicApplication
{
    class Vernam
    {
        Alphabet alph = new Alphabet();

        public string Encrypt_and_Decrypt(string sourcetext, string key)
        {
            StringBuilder code = new StringBuilder();
            int[] key_id = new int[key.Length];

            //поиск индексов букв ключа
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < alph.lang.Length; j++)
                {
                    if (key[i] == alph.lang[j])
                    {
                        key_id[i] = j;
                        break;
                    }
                }
            }

            for (int i = 0; i < sourcetext.Length; i++)
            {
                //поиск символа в алфавите
                for (int j = 0; j < alph.lang.Length; j++)
                {
                    //если символ найден
                    if (sourcetext[i] == alph.lang[j])
                    {
                        code.Append(alph.lang[(j ^ key_id[i] % 32) % alph.lang.Length]);
                        break;
                    }
                    //если символ не найден
                    else if (j == alph.lang.Length - 1)
                    {
                        code.Append(sourcetext[i]);
                    }
                }
            }

            return code.ToString();
        }
    }
}

/*StringBuilder code = new StringBuilder();
            string sourcetext = tb_SourceData.Text;
            string key = tb_Key.Text;
            int[] key_id = new int[key.Length];

            //поиск индексов букв ключа
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < lang.Length; j++)
                {
                    if (key[i] == lang[j])
                    {
                        key_id[i] = j;
                        break;
                    }
                }
            }

            for (int i = 0; i < sourcetext.Length; i++)
            {
                //поиск символа в алфавите
                for (int j = 0; j < lang.Length; j++)
                {
                    //если символ найден
                    if (sourcetext[i] == lang[j])
                    {
                        code.Append(lang[(j ^ key_id[i] % 33) % lang.Length]);
                        break;
                    }
                    //если символ не найден
                    else if (j == lang.Length - 1)
                    {
                        code.Append(sourcetext[i]);
                    }
                }
            }

            return code.ToString();*/
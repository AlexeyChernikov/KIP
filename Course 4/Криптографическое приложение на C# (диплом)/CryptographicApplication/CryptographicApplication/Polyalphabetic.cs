using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographicApplication
{
    class Polyalphabetic
    {
        Alphabet alph = new Alphabet();

        Random rnd = new Random();

        public string Rand_Key_Generation()
        {
            int value = rnd.Next(1, alph.lang.Length);
            return Convert.ToString(value);
        }

        public string Encrypt(string sourcetext, string key)
        {
            StringBuilder code = new StringBuilder();
            int[] key_id = new int[key.Length];
            int t = 0;

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
                            if (t > key.Length - 1)
                            {
                                t = 0;
                            }
                            code.Append(alph.lang[(j + key_id[t]) % alph.lang.Length]);
                            t++;
                            
                        break;
                    }
                    //если символ не найден
                    else if (j == alph.lang.Length - 1)
                    {
                        code.Append(sourcetext[i]);
                        t++;
                    }
                }
            }

            return code.ToString();
        }

        public string Decrypt(string sourcetext, string key)
        {
            StringBuilder code = new StringBuilder();
            int[] key_id = new int[key.Length];
            int t = 0;

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
                        if (t > key.Length - 1)
                        {
                            t = 0;
                        }
                        code.Append(alph.lang[(j + alph.lang.Length - key_id[t]) % alph.lang.Length]);
                        t++;
                        break;
                    }
                    //если символ не найден
                    else if (j == alph.lang.Length - 1)
                    {
                        code.Append(sourcetext[i]);
                        t++;
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
            int t = 0;

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
                        if (rb_Encryption.IsChecked == true) //Шифрование 
                        {
                            if (t > key.Length - 1)
                            {
                                t = 0;
                            }
                            code.Append(lang[(j + key_id[t]) % lang.Length]);
                            t++;
                        }
                        else if (rb_Decryption.IsChecked == true) //Дешифрование
                        {
                            if (t > key.Length - 1)
                            {
                                t = 0;
                            }
                            code.Append(lang[(j + lang.Length - key_id[t]) % lang.Length]);
                            t++;
                        }
                        break;
                    }
                    //если символ не найден
                    else if (j == lang.Length - 1)
                    {
                        code.Append(sourcetext[i]);
                        t++;
                    }
                }
            }

            return code.ToString();
*/
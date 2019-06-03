using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;


namespace CryptographicApplication
{
    class Functional
    {
        public void Clear_tb(TextBox a)
        {
            a.Text = "";
        }

        public void Font_Size(TextBox a, bool b)
        {
            if (b == true)
            {
                if (a.FontSize < 24)
                    a.FontSize++;
            }
            else
            {
                if (a.FontSize > 1)
                    a.FontSize--;
            }
        }

        public void Save_File(TextBox localFileName, TextBox TextToSave)
        {
            File.WriteAllText(localFileName.Text, TextToSave.Text, Encoding.Default);
        }

        public void Save_File_As(ComboBox cb, TextBox NewFileName, TextBox TextToSave, bool a)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();

            saveFileDlg.DefaultExt = ".txt";
            saveFileDlg.Filter = "Текстовый документ (.txt) | * .txt";
            saveFileDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (a == true)
            {
                saveFileDlg.FileName = "Новый текстовый документ";
            }
            else
            {
                saveFileDlg.FileName = "Зашифрованный файл (способ: " + cb.Text + ")";
            }

            Nullable<bool> result = saveFileDlg.ShowDialog();

            if (result == true)
            {
                NewFileName.Text = saveFileDlg.FileName;
                File.WriteAllText(saveFileDlg.FileName, TextToSave.Text, Encoding.Default);
            }
        }
    }
}

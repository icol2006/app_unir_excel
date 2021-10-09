using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppUnirExcel.Utilidades
{
    public static class FilesUtils
    {
        public static FileInfo[] GetFilesDirectoryByExtension(String path, String extension)
        {
            List<String> res = new List<string>();

            DirectoryInfo d = new DirectoryInfo(path); //Assuming Test is your Folder

            FileInfo[] Files = d.GetFiles("*."+ extension, SearchOption.TopDirectoryOnly); //Getting Text files

            return Files;
        }

        public static String AbrirDialogoDirectorio()
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            String res = "";

            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                res = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
            return res;
        }

        public static String AbrirDialogoArchivo()
        {
            string res = "";
            OpenFileDialog openFileDialog=new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                res = openFileDialog.FileName;        
            }
            return res;
        }
    }
}

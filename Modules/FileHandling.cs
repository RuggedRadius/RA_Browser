using ClosedXML.Excel;
using RA_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA_API.Connection
{
    class FileHandling
    {
        // Global Variables
        #region
        static IXLWorkbook myData;
        static string fileName_GlobalData = "GlobalData.dat";
        #endregion

        // Writing data to spreadsheet
        #region
        static void CreateWorkBook()
        {
            myData = new XLWorkbook();
        }
        static void SaveWorkBook()
        {
            myData.SaveAs("RetroAchievements Data.xlsx");
        }
        static void WriteSheet_GamesList(List<Game> games)
        {
            var sheetGames = myData.Worksheets.Add("Games");
            sheetGames.Cell(1, 1).Value = "Game ID";
            sheetGames.Cell(1, 2).Value = "Title";
            sheetGames.Cell(1, 3).Value = "Console ID";
            sheetGames.Cell(1, 4).Value = "Console Name";
            sheetGames.Cell(1, 5).Value = "Image Icon";
            for (int i = 0; i < games.Count; i++)
            {
                sheetGames.Cell(i + 1, 1).Value = games[i].ID;
                sheetGames.Cell(i + 1, 2).Value = games[i].Title;
                sheetGames.Cell(i + 1, 3).Value = games[i].ConsoleID;
                sheetGames.Cell(i + 1, 4).Value = games[i].ConsoleName;
                sheetGames.Cell(i + 1, 5).Value = games[i].ImageIcon;
            }
        }
        static void WriteSheet_Consoles(List<SupportedConsole> consoles)
        {
            var sheetConsoles = myData.Worksheets.Add("Supported Consoles");
            sheetConsoles.Cell(1, 1).Value = "Console ID";
            sheetConsoles.Cell(1, 2).Value = "Console Name";
            for (int i = 0; i < consoles.Count; i++)
            {
                sheetConsoles.Cell(i + 1, 1).Value = consoles[i].ID;
                sheetConsoles.Cell(i + 1, 2).Value = consoles[i].Name;
            }
        }
        #endregion

        public static bool DeleteAllData()
        {
            DialogResult dr = MessageBox.Show(
                "Are you sure you want to delete ALL local data?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation
                );

            if (dr == DialogResult.Yes)
            {
                Data.globalData = null;
                File.Delete(fileName_GlobalData);
                return true;
            }
            return false;
        }

        // File saving
        #region
        public static void SaveBinary_Games(List<Game> games)
        {
            if (games != null)
            {
                // Sort list
                //games.Sort();

                using (Stream stream = File.Open("Games_List.dat", FileMode.Create))
                {
                    var bf = new BinaryFormatter();
                    bf.Serialize(stream, games);
                }
            }
            else
            {
                MessageBox.Show(
                    "No games data to write.",
                    "No data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }
        public static void SaveAllData()
        {
            if (Data.globalData != null)
            {
                //using (Stream stream = File.Open(fileName_GlobalData, FileMode.Create))
                using (FileStream stream = new FileStream(fileName_GlobalData, FileMode.Create))
                {
                    var bf = new BinaryFormatter();
                    bf.Serialize(stream, Data.globalData);
                }
            }
            else
            {
                MessageBox.Show(
                    "No games data to write.",
                    "No data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }
        public static void LoadAllData()
        {
            if (File.Exists(fileName_GlobalData))
            {
                using (Stream stream = File.Open(fileName_GlobalData, FileMode.Open))
                {
                    var bf = new BinaryFormatter();
                    Data.globalData = (StoredData)bf.Deserialize(stream);
                }
            }
            else
            {
                Console.WriteLine("Could not find data file to load.");
            }

        }



        public void SaveBinary_SupportedConsoles(List<SupportedConsole> consoles)
        {
            if (consoles != null)
            {
                // Sort list
                consoles.Sort();

                using (Stream stream = File.Open("Consoles_List.dat", FileMode.Create))
                {
                    var bf = new BinaryFormatter();
                    bf.Serialize(stream, consoles);
                }
            }
            else
            {
                MessageBox.Show(
                    "No games data to write.",
                    "No data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }
        #endregion          

    }
}

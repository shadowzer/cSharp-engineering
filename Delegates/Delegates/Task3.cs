using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Task3
{
    public interface IObservable
    {
        void AddObserver(Observer obs);
        void RemoveObserver(Observer obs);
    }

    public interface IObserver
    {
        void Update(string obs);
    }

    public class Observer : IObserver
    {
        public void Update(string info)
        {
            Logger.Log(info);
        }
    }

    public class Logger
    {
        public static void Log(string msg, string path = "log.txt")
        {
            FileStream fs = new FileStream(path, FileMode.Append);
            string s = DateTime.Now.ToString() + "\t\t" + msg + "\n";
            fs.Write(Encoding.ASCII.GetBytes(s), 0, s.Length);
        }
    }

    public class Table : IObservable
    {
        private List<Observer> Observers = new List<Observer>();
        private int[,] TheTable;

        public Table(Observer obs = null)
        {
            TheTable = new int[0, 0];
            if (obs != null)
                AddObserver(obs);
        }

        public void AddObserver(Observer obs)
        {
            Observers.Add(obs);
        }
        // Action<Observer> AddObserver = obs => Observers.Add(obs);  ?товарищи проверяющие, как в этом анонимном делегате получить доступ к полю Observers?

        public void RemoveObserver(Observer obs)
        {
            Observers.Remove(obs);
        }
        
        private void Notify(string info)
        {
            foreach (var obj in Observers)
            {
                obj.Update(info);
            }
        }

        private bool IsCellExist(int row, int column)
        {
            return (row < TheTable.GetLength(0) || column < TheTable.GetLength(1)) ? true : false;
        }

        private bool IsValidIndex(int idx, int dimension)
        {
            return (idx < 0 || idx > TheTable.GetLength(dimension)) ? false : true;
        }

        private void UpdateTable(int[,] newTable)
        {
            for (int i = 0; i < TheTable.GetLength(0); i++)
            {
                for (int j = 0; j < TheTable.GetLength(1); j++)
                {
                    newTable[i, j] = TheTable[i, j];
                }
            }
            TheTable = newTable;
            
        }

        public void Put(int row, int column, int value) //- помещает значение в соответствующую ячейку
        {
            if (!IsCellExist(row, column))
                throw new Exception("Cell at row:" + row.ToString() + " column:" + column.ToString() + " does not exist");
            TheTable[row, column] = value;
            Notify("Puted " + value.ToString() + " to (" + row.ToString() + "; " + column.ToString() + ")");
        }

        public void InsertRow(int rowIndex) //- добавляет пустую строку по указанному индексу
        {
            if (!IsValidIndex(rowIndex, 0))
                throw new Exception("Row index is not valid");
            var NewTable = new int[rowIndex + 1, TheTable.GetLength(1)];
            UpdateTable(NewTable);
            Notify("Inserted row #" + (rowIndex + 1).ToString());
        }

        public void InsertColumn(int columnIndex) //- добавляет пустую колонку по указанному индексу
        {
            if (!IsValidIndex(columnIndex, 1))
                throw new ArgumentException("Column index is not valid");
            var NewTable = new int[TheTable.GetLength(0), columnIndex + 1];
            UpdateTable(NewTable);
            Notify("Inserted column #" + (columnIndex + 1).ToString());
        }

        public int Get(int row, int column) //- возвращает хранимое в таблице значение
        {
            if (!IsCellExist(row, column))
                throw new Exception("Cell at row:" + row.ToString() + " column:" + column.ToString() + " does not exist");
            Notify("Get " + TheTable[row, column].ToString() + " from (" + row.ToString() + "; " + column.ToString() + ")");
            return TheTable[row, column];
        }

    }
}

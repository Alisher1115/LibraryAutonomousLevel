using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создать базу данных локально на тему библиотека используя автономный уровень Ado.net
            DataSet dataSet = new DataSet("Library");

            #region Disciples
            DataTable disciples = new DataTable("Disciple");
            DataColumn discipleId = new DataColumn("Id");
            discipleId.DataType = typeof(int);
            discipleId.AllowDBNull = false;
            discipleId.AutoIncrement = true;
            discipleId.AutoIncrementSeed = 1;
            discipleId.AutoIncrementStep = 1;

            DataColumn discipleFullName = new DataColumn("FullName");
            discipleFullName.DataType = typeof(string);

            DataColumn discipleAge = new DataColumn("Age");
            discipleAge.DataType = typeof(int);

            disciples.Columns.Add(discipleId);
            disciples.Columns.Add(discipleFullName);
            disciples.Columns.Add(discipleAge);

            DataRow firstRow = disciples.NewRow();

            firstRow.BeginEdit();
            firstRow.ItemArray = new object[] { 1, "P.P.Kirsanov", 42 };
            firstRow.EndEdit();
            #endregion

            #region Librarians
            DataTable librarians = new DataTable("Librarian");
            DataColumn librarianId = new DataColumn("Id");
            librarianId.DataType = typeof(int);
            librarianId.AllowDBNull = false;
            librarianId.AutoIncrement = true;
            librarianId.AutoIncrementSeed = 1;
            librarianId.AutoIncrementStep = 1;

            DataColumn librarianFullName = new DataColumn("FullName");
            librarianFullName.DataType = typeof(string);

            DataColumn librarianAge = new DataColumn("Age");
            librarianAge.DataType = typeof(int);

            librarians.Columns.Add(librarianId);
            librarians.Columns.Add(librarianFullName);
            librarians.Columns.Add(librarianAge);
            #endregion

            #region TakenBooks
            DataTable takenBooks = new DataTable("TakenBooks");
            DataColumn takenBooksId = new DataColumn("Id");

            takenBooksId.DataType = typeof(int);
            takenBooksId.AllowDBNull = false;
            takenBooksId.AutoIncrement = true;
            takenBooksId.AutoIncrementSeed = 1;
            takenBooksId.AutoIncrementStep = 1;

            DataColumn takenBooksBooks = new DataColumn("Books");
            takenBooksBooks.DataType = typeof(IList<Book>);

            DataColumn takenBooksDiscipleId = new DataColumn("DiscipleId");
            takenBooksDiscipleId.DataType = typeof(int);

            DataColumn takenBooksLibrarianId = new DataColumn("LibrarianId");
            takenBooksLibrarianId.DataType = typeof(int);

            DataColumn takenBooksTakenDate = new DataColumn("TakenDate");
            takenBooksTakenDate.DataType = typeof(DateTime);

            takenBooks.Columns.Add(takenBooksId);
            takenBooks.Columns.Add(takenBooksBooks);
            takenBooks.Columns.Add(takenBooksDiscipleId);
            takenBooks.Columns.Add(takenBooksLibrarianId);
            takenBooks.Columns.Add(takenBooksTakenDate);

            DataRelation takenBooksDiscipleRelation = new DataRelation("takenBooks_Disciple", discipleId, takenBooksDiscipleId);
            DataRelation takenBooksLibrarianRelation = new DataRelation("takenBooks_Librarian", librarianId, takenBooksDiscipleId);
            #endregion

            dataSet.Tables.Add(disciples);
            dataSet.Tables.Add(librarians);
            dataSet.Tables.Add(takenBooks);
        }
    }
}

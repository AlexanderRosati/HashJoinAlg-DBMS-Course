using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashJoinInterface
{
    //description: class for an inner table.
    public class InnerTable
    {
        /*data memebers*******************************************************************************************/
        public Index[] indexes; //indexes for relation
        public string pathToFile; //path to file for relation
        public String[] innerTableFile; //whole file for relation in memory
        public int numRows; //number of rows in table
        public string relationName; //name of relation

        /*methods*******************************************************************************************/
        //description: constructor
        public InnerTable(string path, string name)
        {
            //local vars
            String[] atributes;

            //initialize pathToFile
            pathToFile = String.Copy(path);
            relationName = String.Copy(name);

            //load contents of file into sting array
            innerTableFile = File.ReadAllLines(pathToFile);

            //initialize numRows
            numRows = innerTableFile.Length - 1;

            //get attributes of relation
            atributes = innerTableFile[0].Split(',');

            //put array in indexes
            indexes = new Index[atributes.Length];

            //iterate through attirbutes
            for (int i = 0; i < atributes.Length; ++i)
            {
                //create index for current attribute
                indexes[i] = new Index(relationName, atributes[i], pathToFile, innerTableFile);
            }
        }
    }
}

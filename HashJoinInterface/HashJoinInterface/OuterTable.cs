using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashJoinInterface
{
    //Description: Class for an outer table.
    public class OuterTable
    {
        public String[] outerTableFile; //whole file for relation in memory
        public string pathToFile; //path to file for relation
        public int numRows; //number of rows in table
        public string relationName; //name of relation instance

        //Description: constructor
        public OuterTable(string path, string relName)
        {
            //initialize data members
            pathToFile = String.Copy(path);
            relationName = String.Copy(relName);

            //load file into sting array
            outerTableFile = File.ReadAllLines(path);

            //initialize numRows
            numRows = outerTableFile.Length - 1;
        }

        //Desciption: Joins an outer and inner table using the hash join algorithm.
        //Precondition: outerAttribute and innerAttribute must be valid attributes
        public string HashJoin(InnerTable innerTable, string outerAttribute, string innerAttribute)
        {
            //local vars
            String[] outerAttributes = outerTableFile[0].Split(','); //outer attributes
            String[] innerAttributes = innerTable.innerTableFile[0].Split(','); //inner attributes
            List<long> matchingRecords = new List<long>(); //contains matching records of current record in outer table
            StreamWriter joinFile = File.CreateText("../../../JOIN-FILE/JOIN-FILE.csv"); //file to avoid really long string
            string joinResult; //result of join
            int valueOfOutterAttribute = -1; //value for current record in outer table
            int outterAttrIndx = -1; //which attribute for outer table
            int innerAttrIndx = -1; //which attribute for inner table

            //determine outer table attribute
            for (int i = 0; i < outerAttribute.Length; ++i)
            {
                if (outerAttributes[i] == outerAttribute)
                {
                    outterAttrIndx = i;
                    break;
                }
            }
            
            //determine inner table attribute
            for (int i = 0; i < innerAttributes.Length; ++i)
            {
                if (innerAttributes[i] == innerAttribute)
                {
                    innerAttrIndx = i;
                    break;
                }
            }

            //write header of csv file
            joinFile.Write(outerTableFile[0].Substring(0, outerTableFile.Length - 1));
            joinFile.Write(innerTable.innerTableFile[0]);

            //iterate through rows of outer table
            for (int i = 1; i < outerTableFile.Length; ++i)
            {
                //get value of attribute we care about for current record
                valueOfOutterAttribute = Convert.ToInt32(outerTableFile[i].Split(',')[outterAttrIndx]);

                //search for matching records in inner table
                matchingRecords = innerTable.indexes[innerAttrIndx].Search(valueOfOutterAttribute);

                //write matches to join file
                foreach (long lineNumber in matchingRecords)
                {
                    //write current record in outer table
                    joinFile.Write(outerTableFile[i].Substring(0, outerTableFile.Length - 1));

                    //write comma
                    joinFile.Write(',');

                    //write matching record in inner table
                    joinFile.Write(innerTable.innerTableFile[lineNumber - 1]);
                }
            }

            //close connection
            joinFile.Close();

            //turn file into string
            joinResult = File.ReadAllText("../../../JOIN-FILE/JOIN-FILE.csv");

            //delete join file
            File.Delete("../../../JOIN-FILE/JOIN-FILE.csv");

            //return result of join
            return joinResult;
        }
    }
}
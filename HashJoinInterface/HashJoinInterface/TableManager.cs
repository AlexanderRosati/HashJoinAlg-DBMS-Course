using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashJoinInterface
{
    public class TableManager
    {
        /*data members******************************************************************************************/
        public List<OuterTable> outerTables;
        public List<InnerTable> innerTables;

        /*methods******************************************************************************************/
        public TableManager(string R1Dir, string R2Dir)
        {
            //local vars
            DirectoryInfo R1DirObj = new DirectoryInfo(R1Dir);
            DirectoryInfo R2DirObj = new DirectoryInfo(R2Dir);
            FileInfo[] R1Instances;
            FileInfo[] R2Instances;

            //initialize lists
            outerTables = new List<OuterTable>();
            innerTables = new List<InnerTable>();

            //get R1 instances
            R1Instances = R1DirObj.GetFiles("*.csv");
            R2Instances = R2DirObj.GetFiles("*.csv");

            //create OuterTable objects
            foreach (FileInfo file in R1Instances)
            {
                outerTables.Add(new OuterTable(file.FullName, file.Name));
            }

            //create InnerTable objects
            foreach (FileInfo file in R2Instances)
            {
                innerTables.Add(new InnerTable(file.FullName, file.Name));
            }
        }

        //Desciption: Joins the instance of R1 and the instance of R2
        //Precondition: Files must exist and be in the appropriate folders. Attributes must be valid.
        public string Join(string R1FileName, string R2FileName, string R1Attr, string R2Attr)
        {
            //local vars
            OuterTable outerTableForJoin = null;
            InnerTable innerTableForJoin = null;
            string joinResult;

            //iterate through R1 instances
            foreach (OuterTable outerTable in outerTables)
            {
                if (outerTable.relationName == R1FileName)
                {
                    outerTableForJoin = outerTable;
                    break;
                }
            }

            //iterate through R2 instances
            foreach (InnerTable innerTable in innerTables)
            {
                if (innerTable.relationName == R2FileName)
                {
                    innerTableForJoin = innerTable;
                    break;
                }
            }

            //do join
            joinResult = outerTableForJoin.HashJoin(innerTableForJoin, R1Attr, R2Attr);

            //return result
            return joinResult;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashJoinInterface
{
    public class Index
    {
        public string relation; //relation index is for
        public string attribute; //attribute index is on
        private string pathToTable; //path to table index is on
        private List<Tuple<int, long>>[] hashTable; //each tuples contains the value of the attribute and a ref to a record in a file
        private const int numberBuckets = 13; //number of buckets in hash table

        //Description: Constructor
        public Index(string rel, string attr, string path)
        {
            //local vars
            String[] records = null; //records of table in string format
            String[] attributes = null; //attributes of relation
            String[] record = null; //stores contents of a line
            int posOfAttribute = -1; //which attribute in CSV file
            int valueOfAttribute = -1; //value of attribute for current record
            int hashValue = -1; //hash of current record

            //initialize data members
            relation = String.Copy(rel);
            attribute = String.Copy(attr);
            pathToTable = String.Copy(path);

            //initialize hash table
            hashTable = new List<Tuple<int, long>>[numberBuckets];

            for (int i = 0; i < hashTable.Length; ++i)
            {
                hashTable[i] = new List<Tuple<int, long>>();
            }

            //load file into array of strings
            records = File.ReadAllLines(pathToTable);

            //get attributes for relation we are making index of
            attributes = records[0].Split(',');

            //determine which attribute in CSV we are indexing
            for (int i = 0; i < attributes.Length; ++i)
            {
                if (attributes[i] == attribute)
                {
                    posOfAttribute = i;
                }
            }

            //create index
            for (long i = 1; i < records.Length; ++i)
            {
                //split line by comma
                record = records[i].Split(',');

                //get value of attribute we're indexing
                valueOfAttribute = Convert.ToInt32(record[posOfAttribute]);

                //get hash value of record
                hashValue = HashFn(valueOfAttribute);

                //add entry to hash table that includes value of attribute and line number
                hashTable[hashValue].Add(new Tuple<int, long>(valueOfAttribute, i + 1));
            }
        }

        //Description: hash function for hash table.
        //Precondition: parameters must be value of attribute you are indexing
        //Postcondition: will return number between 0 and numBuckets - 1
        private int HashFn(int valueOfAttribute)
        {
            return valueOfAttribute % numberBuckets;
        }

        //Description: you give it the value of the attribute of the index and it returns the line numbers
        //where the record has that value for the attribute
        public List<long> Search(int valueOfAttribute)
        {
            //local vars
            int hashValue;
            List<long> lineNumbers;

            //initialize list of line numbers
            lineNumbers = new List<long>();

            //get hash value
            hashValue = HashFn(valueOfAttribute);

            //iterate through bucket 'hashValue'
            foreach (Tuple<int, long> t in hashTable[hashValue])
            {
                //add line number if line contains value we are looking for
                if (t.Item1 == valueOfAttribute)
                {
                    lineNumbers.Add(t.Item2);
                }
            }

            return lineNumbers;
        }
    }
}
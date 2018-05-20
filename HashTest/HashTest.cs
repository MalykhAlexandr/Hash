using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTable;


namespace HashTableTests
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void ThreeElementsTest()
        {
            //тест добавления и поиска трех элементов
            var threeElementsTable = new HashClass();
            int size = 3;
            threeElementsTable.HashTableCreate(size);
            threeElementsTable.PutPair(1905, "Челси");
            threeElementsTable.PutPair(1911, "ЦСКА");
            threeElementsTable.PutPair(1930, "Урал");
            
            var arrayKeys = new object[] { 1905, 1911, 1930 };
            var arrayValues = new object[] { "Челси", "ЦСКА", "Урал" };
            for (int i = 0; i < size; i++)
            {
                if (!(threeElementsTable.GetValueByKey(arrayKeys[i])).Equals(arrayValues[i]))
                    throw new Exception();
            }
        }

        [TestMethod]

        public void EqualValuesTest()
        {
            // тест на добавление одного и того же ключа дважды с разными значениями, которое сохраняет последнее добавленное значение
            var similarValuesTable = new HashClass();
            int size = 2;
            similarValuesTable.HashTableCreate(size);
            similarValuesTable.PutPair(1, " Ты");
            similarValuesTable.PutPair(1, "Я");
            int tableKey = 1;
            var tableValue = "Я";
            if (!(similarValuesTable.GetValueByKey(tableKey)).Equals(tableValue))
                throw new Exception();
        }

        [TestMethod]

        public void ManyElementsTest()
        {
            //тест на добавление 10000 элементов и поиск одного
            var bigArray = new HashClass();
            var size = 10000;
            bigArray.HashTableCreate(size);
            var tableKey = 1;
            var tableValue = "Number1";
            for (int i = 0; i < size; i++)
            {
                bigArray.PutPair(i, "Number" + i);
            }
            if (!(bigArray.GetValueByKey(tableKey)).Equals(tableValue))
                throw new Exception();
        }

        [TestMethod]

        public void MissedKeysTest()
        {
            //тест на добавление 10000 элементов и поиск 1000 недобавленных ключей. Возвращает null.
            var missedKeys = new HashClass();
            int size = 10000;
            missedKeys.HashTableCreate(size);
            for (int i = 0; i < size; i++)
            {
                missedKeys.PutPair(i, "v" + i);
            }
            for (int i = size; i < size + 1000; i++)
            {
                if (!(missedKeys.GetValueByKey(i)==null))
                    throw new Exception();
            }
        }
    }
}
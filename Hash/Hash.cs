using System.Collections.Generic;

namespace HashTable
{
    public class HashClass

    {
        public class Pair
        {
            public object key { get; set; }
            public object value { get; set; }
        }

        public static List <List<Pair>> hashTable;
        public static List <int> hashPair;

        //поиск индекса
        public int HashIndex(int bucket)
        {
            return hashPair.IndexOf(bucket);
        }

        //получение ключа
        public int HashKey(object key)
        {
            return key.GetHashCode();
        }

        //Конструктор контейнера
        public void HashTableCreate(int size)

        {
            hashTable = new List<List<Pair>>(size);
            hashPair = new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                hashTable.Add(new List<Pair>());
            }
        }

        //Метод складывающий пару ключ-значение в таблицу
        public void PutPair(object key, object value)
        {
            var hashCode = HashKey(key);
            var hashIndex = HashIndex(hashCode);
            var keyValue = new Pair { key = key, value = value };
            if (hashIndex == -1 && hashPair.Count < hashTable.Count)
            {
                hashPair.Add(HashKey(key));
                hashIndex = HashIndex(HashKey(key));
                hashTable[hashIndex].Add(keyValue);
                return;
            }
            foreach (var i in hashTable[hashIndex])
            {
                if (i.key.Equals(key))
                    i.value = value;
            }
        }
        //Поиск значения по ключу
        public object GetValueByKey(object key)
        {
            var hashCode = HashKey(key);
            var hashIndex = HashIndex(hashCode);
            if (hashIndex == -1)
                return null;

            foreach (var i in hashTable[hashIndex])
            {
                if (i.key.Equals(key))
                    return i.value;
            }
            return null;
        }

        public static void Main(string[] Args)
        {

        }
    }
}

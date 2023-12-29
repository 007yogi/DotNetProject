using Microsoft.AspNetCore.Mvc;

namespace LinqSample.Controllers
{
    public class LinqMethodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The Range() method returns a collection of IEnumerable<T> type
        /// with specified number of elements and sequential values starting from the first element.
        /// </summary>
        public void LinqRange()
        {
            var intCollection = Enumerable.Range(10, 10);
            Console.WriteLine("Total Count: {0} ", intCollection.Count());

            for (var i = 0; i < intCollection.Count(); i++)
            {
                Console.WriteLine("Value at index {0} : {1}", i, intCollection.ElementAt(i));

            }
        }

        /// <summary>
        /// The Distinct extension method returns a new collection of unique elements from the given collection.
        /// </summary>
        public void LinqDistinct()
        {
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Two", "Three" };
            IList<int> intList = new List<int>() { 1, 2, 3, 2, 4, 4, 3, 5 };

            var distictList1 = Enumerable.Distinct(strList);
            foreach (var str in distictList1)
            {
                Console.WriteLine($"{str}");
            }
            var distinctList2 = intList.Distinct();
            foreach (var i in distinctList2)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// The Except() method requires two collections. 
        /// It returns a new collection with elements from the first collection which do not exist in the second collection
        /// </summary>
        public void LinqExcept()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result = Enumerable.Except(strList1, strList2);
            foreach (var str in result)
            {
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// The Intersect extension method requires two collections.
        /// It returns a new collection that includes common elements that exists in both the collection.
        /// </summary>
        public void LinqIntersect()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };
            var result = Enumerable.Intersect(strList1, strList2);
            //var result2 = strList1.Intersect(strList2);
            foreach (var str in result)
            {
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// The Union extension method requires two collections 
        /// and returns a new collection that includes distinct elements from both the collections.
        /// </summary>
        public void LinqUnion()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "three", "Four" };
            IList<string> strList2 = new List<string>() { "Two", "THREE", "Four", "Five" };
            //var result = strList1.Union(strList2);
            var result2 = Enumerable.Union(strList1, strList2);
            foreach (var str in result2)
            {
                Console.WriteLine(str);
            }
        }

        /*Partitioning Operators.*/
        /* Partitioning operators split the sequence(collection) into two parts and return one of the parts.*/

        /// <summary>
        /// The Skip() method skips the specified number of element starting from first element and 
        /// returns rest of the elements.
        /// </summary>
        public void LinqSkip()
        {
            IList<string> strList1 = new List<String>() { "One", "Two", "Three", "Four", "Five" };
            var result = Enumerable.Skip(strList1, 2);
            foreach (var str in result)
            {
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// skip elements in the collection till the specified condition is true. 
        /// It returns a new collection that includes all the remaining elements once the specified condition becomes false.
        /// 
        /// Once it finds any element whose length is equal or more than 4 characters 
        /// then it will not skip any other elements even if they are less than 4 characters.
        /// 
        /// SkipWhile() does not skip any elements because the specified condition is false for the first element.
        /// </summary>
        public void LinqSkipWhile()
        {
            IList<string> strLlist1 = new List<string>() { "One", "Two", "Three", "Four", "Five", "Six" };
            var result = Enumerable.SkipWhile(strLlist1, s => s.Length < 4);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Take() extension method returns the specified number of elements starting from the first element.
        /// 
        /// </summary>
        public void LinqTake()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            var result = Enumerable.Take(strList1, 4);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public void LinqTakeWhile()
        {
            IList<string> strList1 = new List<string>() { "Three", "Four", "Five", "Hundred" };
            var result = Enumerable.TakeWhile(strList1, s => s.Length > 4);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}

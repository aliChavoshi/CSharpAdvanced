﻿using System;

namespace Lambda_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Example1

            //args => expression

            Func<int, int> square = number => number * number;

            square.Invoke(5);

            Console.WriteLine(square(5));

            #endregion

            #region Example2

            const int factor = 5;
            Func<int, int> multipler = n => n * factor;
            var result = multipler(5);
            Console.WriteLine(result);




            #endregion

            #region Example3
            var books = new BookRepository().GetBooks();

            //retuen bool
            //in Book
            Predicate<Book> expr = book => book.Price < 10;

            //var results = books.FindAll(book => IsCheaperThan10Dollars(book));
            //var results = books.FindAll(expr);
            var results = books.FindAll(book => book.Price < 10);


            foreach (var book in results)
            {
                Console.WriteLine(book.Title);
            }


            #endregion
        }

        static bool IsCheaperThan10Dollars(Book book)
        {
            return book.Price < 10;
        }

        //static int Square(int number) => number * number;
    }
}

# Library

Project "Library" with MS SQL DB, IoC.

Перед началом работы с приложением создайте базу данных в MS SQL, используя скрипт scr/BookLibraryScript.sql

Возможности:

1. Добавление книги в библиотеку .AddBook(Book)
2. Вывод списка всех книг: .ShowAllBooks()
3. Количество книг: .LibraryCount()
4. Поиск книги по буквам в названии или имени автора .FindBook()
5. Сортировка книг по названию .SortBy("Name") и по имени автора .SortBy("Avtor")
6. Удаление книги по номеру n в библиотеке .DeleteBook(n)

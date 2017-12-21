# :cat: :cat2: :cat: Лабораторные из института :cat2: :cat: :cat2:
Это не все лабораторные, но большинство. Все они за последний год, вроде бы. Да, в моем вузе любят c++ и c#.

## Навигация
[C++, C#](#c)  
[JavaScript](#JavaScript)

<a name="c"><h1>C++ или C#</h1></a>

## CellAutoMono
Клеточные автоматы...

## ConsoleApp123 (все ConsoleApp на c#, вроде)
1. Написать программу для расчета по формулам, данным в задании.
2. Написать программу для вычисления значения функции, заданной в виде графика. 
3.  *	Вычислить и вывести на экран в виде таблицы значения функции, заданной графически, на интервале от хнач до хкон с шагом dx. Интервал и шаг задать таким образом, чтобы проверить все ветви программы. Таблицу снабдить заголовком и шапкой.
    *	Для десяти выстрелов, координаты которых задаются с клавиатуры, вывести  текстовые сообщения о попадании в мишень.
    *	Вычислить и вывести в виде таблицы на экран значения функции, заданной с помощью ряда Тейлора, на интервале от хнач до хкон с шагом dx с точностью е. Таблицу снабдить заголовком и шапкой. Каждая строка таблицы должна содержать значение аргумента, значение функции и количество просуммированных членов ряда.

## ConsoleApp4
Составить описание класса прямоугольников со сторонами, параллельными осям координат. Предусмотреть возможность перемещения прямоугольников на плоскости, изменение размеров, построение наименьшего прямоугольника, содержащего два заданных прямоугольника, и прямоугольника, являющегося общей частью (пересечением) двух прямоугольников.
Написать программу, демонстрирующую все разработанные элементы класса.
Каждый разрабатываемый класс должен, как правило, содержать следующие элементы: скрытые поля, конструкторы с параметрами и без параметров, методы, свойства. Методы и свойства должны обеспечивать непротиворечивый, полный, минимальный и удобный интерфейс класса. При возникновении ошибок должны выбрасываться исключения.

## ConsoleApp5
В одномерном массиве, состоящем из n вещественных элементов, вычислить:
1.	Номер максимального элемента массива
2.  Сумму элементов массива, расположенных между первым и последним положительными элементами
Преобразовать массив таким образом, чтобы сначала располагались все элементы, равные нулю, а потом – все остальные.

## ConsoleApp6
Для заданной матрицы размером 8х8 найти такие k, при которых k-я строка матрицы совпадает с k-м столбцом.
Найти сумму элементов в тех строках, которые содержат хотя бы один отрицательный элемент.

## ConsoleApp7
Написать программу, которая считывает текст из файла и определяет, сколько в нем слов, состоящих не более чем из четырех букв.

## ConsoleApp8
Описать класс «записная книжка». Предусмотреть возможность работы с произвольным числом записей, поиска записи по какому-либо признаку (например, по фамилии, дате рождения или номеру телефона), добавления и удаления записей, сортировки по фамилии и доступа к записи по номеру.
Написать программу, демонстрирующую все разработанные элементы класса.
Каждый разрабатываемый класс должен, как правило, содержать следующие элементы: скрытые поля, конструкторы с параметрами и без параметров, методы, свойства. Методы и свойства должны обеспечивать непротиворечивый, полный, минимальный и удобный интерфейс класса. При возникновении ошибок должны выбрасываться исключения.

## ConsoleApp9
1.	Описать базовый класс Элемент.
Закрытые поля:
*	имя элемента (строка символов)
*	количество входов элемента
*	количество выходов элемента
Методы:
*	конструктор класса без параметров
*	конструктор, задающий имя и устанавливающий равным 1 количество входов и выходов
*	конструктор, задающий значения всех полей элемента
Свойства:
*	имя элемента (только чтение)
*	количество входов элемента
*	количество выходов элемента
2.	На основе класса Элемент описать производный класс Комбинационный, представляющий собой комбинационный элемент (двоичный вентиль), который может иметь несколько входов и один выход.
Поле -  массив значений выходов.
Методы:
*	конструкторы
*	метод, задающий значение на входах экземпляра класса
*	метод, позволяющий опрашивать состояние отдельного входа экземпляра класса
*	метод, вычисляющий значение выхода (по варианту задания)
3.	На основе класса Элемент описать производный класс Память, представляющий собой триггер. Триггер имеет входы, соответствующие типу триггера (см. далее вариант задания), и входы установки и сброса. Все триггеры считаются синхронными, сам синхровход в состав триггера не включается.
Поля:
*	массив значений входов объекта класса, в массиве учитываются все входы (управляющие и информационные)
*	состояние на прямом выходе триггера
*	состояние на инверсном выходе триггера
Методы:
*	конструктор (по умолчанию сбрасывает экземпляр класса)
*	конструктор копирования
*	метод, задающий значение на входах экземпляра класса
*	методы, позволяющие опрашивать состояния отдельного входа экземпляра класса
*	метод, вычисляющий состояние экземпляра класса (по варианту задания) в зависимости от текущего состояния и значений на входах
*	метод, переопределяющий операцию == для экземпляров класса
4.	Создать класс Регистр, используя класс Память как вложенный класс.
Поля:
*	состояние входа «Сброс» - один для экземпляра класса
*	состояние входа «Установка» - один для экземпляра класса
*	массив типа Память заданной в варианте размерности
*	массив (массивы), содержащий значения на соответствующих входах элементов массива типа Память.
Методы:
*	метод, задающий значение на входах экземпляра класса
*	метод, позволяющий опрашивать состояние отдельного выхода экземпляра класса
*	метод, вычисляющий значение нового состояния экземпляра класса
Все поля классов Элемент, Комбинационный и Память должны быть описаны с ключевым словом private. 
В задании перечислены только обязательные члены и методы класса. Можно задавать дополнительные члены и методы, если они не отменяют обязательные и обеспечивают дополнительные удобства при работе с данными классами, например, описать функции вычисления выхода/состояния как виртуальные.
5.	Для проверки функционирования созданных классов написать программу, использующую эти классы. В программе должны быть продемонстрированы все свойства созданных классов.
Вариант задания:
Комбинационный элемент – ИЛИ-НЕ, Число входов – 5, Триггер – JK, Разрядность регистра – 11.

## ConsoleApp10
Описать структуру с именем TRAIN, содержащую следующие поля:
*	название пункта назначения
*	номер поезда
*	время отправления
Написать программу, выполняющую следующие действия:
*	ввод с клавиатуры данных в массив, состоящий из восьми элементов типа TRAIN (записи должны быть размещены в алфавитном порядке по названиям пунктов назначения)
*	вывод на экран информации о поездах, отправляющихся после введенного с клавиатуры времени (если таких поездов нет, вывести соответствующее сообщение)

## ConsoleApp11
Выполнить задания лабораторной работы 9, используя для хранения экземпляров разработанных классов стандартные параметризованные коллекции. Во всех классах реализовать интерфейс IComparable и перегрузить операции отношения для реализации значимой семантики сравнения объектов по какому-либо полю на усмотрение студента.

## WindowsFormsApp12
1.	Диалоговые окна. Общая часть задания: написать Windows – приложение, заголовок главного окна которого содержит ФИО, группу и номер варианта. В программе должна быть предусмотрена обработка исключений, возникающих из-за ошибочного ввода пользователя.
Вариант: 
Создать меню с командами Begin, Help, About.
При выборе команды About открывается окно с информацией о разработчике. При выборе команды Begin открывается диалоговое окно, содержащее:
*	поле ввода типа TextBox с меткой input
*	метку типа Label для вывода результата
*	группу из трех переключателей (2, 8, 16) типа RadioButton
*	две кнопки типа Button – Do и OK.
Обеспечить возможность:
*	ввода числа в десятичной системе в поле input 
*	выбора режима преобразования с помощью переключателей: перевод в двоичную, восьмеричную или шестнадцатеричную систему счисления.
При щелчке на кнопке Do должен появляться результат перевода.
2.	Структуры и параметризованные коллекции. Описать структуру, соответствующую заданиям лабораторной работы 10. Создать параметризованную коллекцию для хранения описанной структуры. Вид коллекции выбрать самостоятельно. Написать Windows-приложение для работы с этой коллекцией, позволяющее выполнять:
*	добавление элемента в коллекцию с клавиатуры
*	считывание данных из файла
*	запись данных в тот же или указанный файл
*	сортировку данных по различным критериям
*	поиск элемента по заданному полю
*	вывод всех элементов, удовлетворяющих заданному условию
*	удаление элемента из коллекции
Приложение должно содержать меню и диалоговые окна и предусматривать обработку возможных ошибок пользователя с помощью исключений.
3.	Графика в Windows. Написать Windows-приложение, которое по заданным в файле исходным данным строит график или столбиковую диаграмму.
Создать меню с командами Input data, Choose, Line, Bar, Quit.
Команды Line и Bar недоступны. Команда Quit завершает работу приложения. При выборе команды Input data из файла читаются исходные данные (файл сформировать самостоятельно).
При команде Choose открывается диалоговое окно, содержащее:
*	список для выбора цвета графика типа ListBox
*	группу из двух переключателей (Line, Bar) типа RadioButton
*	кнопку типа Button
Обеспечить возможность ввода цвета и выбора режима: построение графика (Line) или столбиковой диаграммы (Bar). После указания параметров становится доступной соответствующая команда меню.
По команде Line или Bar в главном окне приложения выбранным цветом строится график или диаграмма. Окно должно содержать заголовок графика или диаграммы, наименование и градацию осей. Изображение должно занимать всё окно и масштабироваться при изменении размеров окна.

## omtmo2
Требуется с получить с помощью имитационного моделирования последовательность моментов времени, распределенных по вероятностному закону рекуррентного потока событий, для которого длительность интервала времени между событиями имеет функцию распределения `какую-то там`

## omtmo3
ИМИТАЦИОННАЯ МОДЕЛЬ ОДНОКАНАЛЬНОЙ СИСТЕМЫ МАССОВОГО ОБСЛУЖИВАНИЯ С ОЖИДАНИЕМ

## Sort.cpp
Реализовать сортировку массива чисел методом сортировки Шелла, методом пузырьковой сортировки и быстрой сортировкой. Сравнить время работы данных сортировок для массивов разных длин.
* Я бы не смогла без указателей сделать быструю...

<a name="JavaScript"><h1>JavaScript</h1></a>

## auto.js
Построить конечный автомат для заданной грамматики. В случае если он недетерминированный, привести его к детерминированному виду. Написать программу, проверяющую принадлежит ли цепочка символов на входе языку, представленному грамматикой. Вывести на экран все промежуточные состояния.
* Приведение к детерминированному в программу не входит

## BinaryTree
Реализовать программу хранения массива чисел в виде бинарного дерева. Предусмотреть возможность вывода элементов массива на экран и поиска элемента в бинарном дереве.
* Оно не совсем выглядит как дерево, ночь перед сдачей, все такое...

## FindStr
Написать программу поиска подстроки в строке с помощью алгоритмов Кнута, Морриса и Пратта.
* Серьезно, писать алгоритмы, это ж тупо копипаст...

## Ciphers
Страничка, на которой показаны некоторые виды кодов и 1 вид шифрования. Шифрование RSA - не мое, одногруппник написал аглоритм на с#, я его только перенесла на javascript


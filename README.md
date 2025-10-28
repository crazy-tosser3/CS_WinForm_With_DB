#  Как сделать простое приложение Windows Forms с базой данных (БД)

## Этап 1 — Создаём проект

1. Открываем **Visual Studio**
2. Жмём **Создать проект (Create a new project)**
3. Выбираем шаблон **Windows Forms App (.NET)**
   (иногда пишется просто **Windows Forms App**)

*Пример:*

**Главное окно VS**
![vsMain](/CreatePRJ/1.PNG)

**Создание проекта**
![createPRJ](/CreatePRJ/2.PNG)

4. Пишем имя проекта (например: `StudentsApp`)
5. Выбираем версию **.NET 8** (это современная версия, рекомендуется)

---

##  Этап 2 — Настраиваем и пишем приложение

### Включаем панель с элементами (ToolBox)

1. Наверху нажимаем **View → ToolBox**
2. В правой части экрана появится панель с элементами (кнопки, поля и т.д.)

 *Пример:*

<p align="center">
    <img style="width: 70%" src="How to create/1.PNG"/>
    <img style="width: 70%" src="How to create/2.PNG"/>
</p>

---

###  Устанавливаем библиотеку SQLite

SQLite — это простая встроенная база данных (всё хранится в одном файле).

1. Нажимаем **Project → Manage NuGet Packages**
2. Переходим на вкладку **Browse**
3. Пишем в поиск `Microsoft.Data.Sqlite`
4. Устанавливаем пакет и соглашаемся со всеми пунктами

*Примеры шагов:* <img style="width: 70%" src="How to create/3.PNG"/> <img style="width: 70%" src="How to create/5.PNG"/> <img style="width: 70%" src="How to create/6.PNG"/> <img style="width: 70%" src="How to create/7.PNG"/>

---

###  Добавляем элементы на форму

Через **ToolBox** добавь:

* 3 текстовых поля (TextBox)
* 1 кнопку для добавления данных
* 1 кнопку для показа данных
* 1 таблицу (DataGridView)

 *Пример:* <img style="width: 70%" src="How to create/8.PNG"/>

Сделай форму примерно так: <img style="width: 70%" src="How to create/9.PNG"/>

---

###  Переименовываем поля

| Что это           | Имя в коде   |
| ----------------- | ------------ |
| Поле для имени    | **ST_name**  |
| Поле для возраста | **ST_Age**   |
| Поле для класса   | **ST_Class** |

---

### Двойной клик по кнопке "Внести данные"

Visual Studio откроет окно с кодом (`Form1.cs`).
В это окно вставляем вот такой код

---

```cs
namespace WinFormsApp1
{
    using Microsoft.Data.Sqlite;
    using System.Data;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Этот метод срабатывает, когда форма загружается
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Кнопка "Внести данные"
        private void Submit_Click(object sender, EventArgs e)
        {
            // Строка подключения — где хранится база
            string conn_str = "Data Source=Students.db;";

            // Подключаемся к базе данных
            using (SqliteConnection conn = new SqliteConnection(conn_str))
            {
                conn.Open();

                // Создаём таблицу, если её ещё нет
                string sql = "CREATE TABLE IF NOT EXISTS Students (Name TEXT, Age TEXT, Class TEXT);";
                SqliteCommand command = new SqliteCommand(sql, conn);
                command.ExecuteNonQuery();

                // Добавляем данные из полей
                InsertUser(this.ST_name.Text, this.ST_Age.Text, this.ST_Class.Text);
            }

            // Сообщение об успехе
            MessageBox.Show("Данные успешно добавлены!");
        }

        // Кнопка "Показать данные"
        private void DisplayData_Click(object sender, EventArgs e)
        {
            // Загружаем данные из базы и показываем в таблице
            dataGridView1.DataSource = GetStudents();
        }

        // Метод добавления данных в таблицу
        private void InsertUser(string userName, string userAge, string userClass)
        {
            string conn_str = "Data Source=Students.db;";

            using (SqliteConnection connection = new SqliteConnection(conn_str))
            {
                connection.Open();

                // Добавляем новую строку в таблицу
                string sql = "INSERT INTO Students (Name, Age, Class) VALUES (@Name, @Age, @Class)";
                SqliteCommand command = new SqliteCommand(sql, connection);

                // Передаём данные из текстовых полей
                command.Parameters.AddWithValue("@Name", userName);
                command.Parameters.AddWithValue("@Age", userAge);
                command.Parameters.AddWithValue("@Class", userClass);

                command.ExecuteNonQuery();
            }

            MessageBox.Show("Студент успешно добавлен!");
        }

        // Метод для загрузки всех студентов
        private DataTable GetStudents()
        {
            DataTable dt = new DataTable();
            string conn_str = "Data Source=Students.db;";

            using (var connection = new SqliteConnection(conn_str))
            {
                connection.Open();
                string sql = "SELECT * FROM Students";
                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }

                return dt;
            }
        }
    }
}
```

---

##  Этап 3 — Проверяем файл `Program.cs`

В этом файле нужно подключить библиотеку и запустить форму:

```cs
using Microsoft.Data.Sqlite;

namespace WinFormsApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Настройка и запуск приложения
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
```

---

## Готово!

Теперь:

1. Запусти проект (**F5** или зелёная кнопка в верхнем тулбаре)
2. Введи данные (имя, возраст, класс)
3. Нажми "Внести данные"
4. Нажми "Показать данные"
5. Всё — данные сохраняются в `Students.db` и отображаются в таблице 

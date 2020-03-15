# UsersAndDepartments
Тестовое задание
Написать простое приложение, состоящее из:
- двух отдельных WebAPI, можно в одном проекте, которые
предоставляют данные по Пользователям и Отделам соответсвенно. Между
собой Пользователи и Отделы связаны по Id (DepId в таблице Users).
Пользователь обязательно должен относится хотя бы к одному отделу;
- в API Отделы должны быть реализованы методы для создания Отдела,
редактирования Отдела и удаления Отдела (с каскадным обновлением
пользователей).
- в API пользователи должны быть реализованы методы создания
пользователя и получеия списка пользователей (с учетом их отделов).
Можно использовать любые технологии. БД можно использовать In
Memory.
Дополнительным преймуществом будет реализация клиента. Для этого
можно использовать SPA, WPF или WinForm. Верстка и дизайн значения

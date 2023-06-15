# StarWarsAPI

## StarWarsAPI - это веб-приложение, предоставляющее API для работы с информацией о персонажах Star Wars.

Использование
Вы можете использовать StarWarsAPI для получения информации о персонажах Star Wars, а также для создания, обновления и удаления персонажей.

### Регистрация пользователя
Для использования некоторых функций API требуется регистрация пользователя. Вы можете зарегистрировать пользователя, отправив POST запрос на http://localhost:5000/api/characters/register с JSON телом следующего формата:


{
  "email": "your-email@example.com",
  "password": "your-password"
}

### Аутентификация
После регистрации вы можете аутентифицироваться, отправив POST запрос на http://localhost:5000/api/characters/login с JSON телом следующего формата:


{
  "email": "your-email@example.com",
  "password": "your-password"
}
Получив успешный ответ, вы будете авторизованы и сможете использовать защищенные роуты API.

### Получение информации о персонажах
Для получения информации о персонаже, отправьте GET запрос на http://localhost:5000/api/characters/{id}, где {id} - идентификатор персонажа.

### Создание персонажа
Для создания нового персонажа, отправьте POST запрос на http://localhost:5000/api/characters с JSON телом, содержащим данные о персонаже:


{
  "name": "Luke Skywalker",
  "birthDate": "2000-01-01",
  "planet": "Tatooine",
  "gender": "Male",
  "race": "Human",
  "height": 175,
  "hairColor": "Blond",
  "eyeColor": "Blue",
  "description": "The hero of the Star Wars saga.",
  "movies": [
    "A New Hope",
    "The Empire Strikes Back",
    "Return of the Jedi"
  ]
}
### Обновление персонажа
Для обновления существующего персонажа, отправьте PUT запрос на http://localhost:5000/api/characters/{id}, где {id} - идентификатор персонажа, и в JSON теле передайте обновленные данные о персонаже.

### Удаление персонажа
Для удаления персонажа, отправьте DELETE запрос на http://localhost:5000/api/characters/{id}, где {id} - идентификатор персонажа.

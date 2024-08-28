# LINQ 💪
## Task#1:
Отрефакторить [LoggerWrapper.cs](https://gist.github.com/Znoleg/645ca54d8897583c1be289eccf0696bc).
Необходимо раскомментировать строчки от 34 до 42. Их менять запрещено. 
Реализовать метод LogCollection, который будет в foreach пробегать по элементам коллекции и вызывать для них Log. 
Нужно чтобы работал со всеми тремя типами коллекций. Метод LogCollection может быть только один.

## Выполнение:
- [Main.cs](https://github.com/BashkaCoder/Unity_practice_4/blob/main/Main.cs)

## Итог:
Таска была выполнена. 

Теперь метод `LogCollection()` принимает аргумент `IEnumerable<string> strings` - то есть любую коллекцию, которая реализует интерфейс IEnumerable.
В данном конкретном случаем нас интересует `IEnumerable<>` от _**`string`**_.

## Преимущество решения
- ### Взаимодействие с различными коллекциями
    Метод ожидает в качестве аргумента любую коллкецию, что реализует интерфейс IEnumerable<string>. 
    Большинство встроенных коллекций реализуют этот интерфейс. Если же мы хотим передать кастомный класс для логирования - необходимо, чтобы это класс тоже реализовал интерфейс IEnumerable - что-то в духе:
    ```
    public class MyCollection : IEnumerable<int>
    {
      private int[] items;
  
      public MyCollection(int[] items)
      {
          this.items = items;
      }
  
      // Реализация метода GetEnumerator из интерфейса IEnumerable<int>
      public IEnumerator<int> GetEnumerator()
      {
          for (int i = 0; i < items.Length; i++)
          {
              yield return items[i];
          }
      }
  
      // Реализация метода IEnumerable.GetEnumerator (нужно для неуниверсальной коллекции)
      IEnumerator IEnumerable.GetEnumerator()
      {
          return GetEnumerator();
      }
    }
    ```
- ### Защита от записи
    Логгер подразумевает, что все данные мы хотим получать только на чтение. Аргумент типа IEnumerable гарантирует, что вызывающий код не имеет возможности перезаписать данные.

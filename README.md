# EN

### Task:

Simulate the growth and shedding of human scalp hair over a given period using a discrete time model.

#### Conditions:

* **Each hair is represented by two parameters:** its length (in mm) and its age (in days).
* **Growth:** Each day, the length of every hair increases by a random amount within a given range (e.g., 3–6 mm per day).
* **Aging:** The age of each hair increases by 1 each day.
* **Shedding:**

  * If a hair’s age exceeds a threshold (e.g., 60 days), it is considered “ready to shed.”
  * Each day, a random proportion of these “old” hairs is shed. The percentage is chosen randomly within a specified range (e.g., from 5% to 10%).
  * Additionally, every hair has a small independent chance of being shed unexpectedly each day (e.g., 1%), regardless of its age.
  * When a hair is shed, its length and age are reset to zero — representing the instant regrowth of a new hair at the same place.
* **There are N hairs in the simulation (e.g., 100,000). Each hair is simulated independently.**

#### Requirements:

1. **Implement a model of hair growth and shedding for N hairs over a specified number of days (e.g., 10,000).**
2. **Track the length and age of each hair throughout the simulation.**
3. **After the simulation, output:**

   * The length and age for at least the first 10 hairs (as an example);
   * (Optionally) Calculate and print the average hair length after the simulation.
4. **Investigate how the average hair length and shedding frequency change when varying parameters like growth rate, max age, and probability of shedding.**

---

**Note:**
All simulation parameters (growth range, shedding threshold, probabilities) can be easily adjusted via constants at the top of the code.

# RU

### Задача:

Смоделировать процесс роста и выпадения волос на голове человека на протяжении заданного числа дней, используя дискретную симуляцию.

#### Условия:

* **Каждый волос представлен числовыми параметрами: длина (в мм) и возраст (в днях).**
* **Рост:** Каждый день длина каждого волоса увеличивается на случайную величину в заданном диапазоне (например, 3–6 мм/день).
* **Старение:** Возраст волоса увеличивается на 1 каждый день.
* **Выпадение:**

  * Волос, чей возраст превышает пороговое значение (например, 60 дней), попадает в группу “готовых к выпадению”.
  * Ежедневно случайная часть таких “старых” волос выпадает. Процент выбирается случайно в указанном диапазоне (например, от 5% до 10%).
  * Дополнительно каждый волос может неожиданно выпасть с небольшой вероятностью (например, 1% в день), независимо от возраста.
  * При выпадении волоса его длина и возраст обнуляются — на этом месте сразу "вырастает" новый волос.
* **В симуляции участвует N волос (например, 100 000), каждый волос моделируется независимо.**

#### Требуется:

1. **Реализовать модель роста и выпадения для N волос в течение заданного количества дней (например, 10 000).**
2. **Вести учёт длины и возраста каждого волоса.**
3. **После завершения симуляции вывести:**

   * Длину и возраст хотя бы для первых 10 волос (для примера);
   * (Дополнительно) Посчитать и вывести среднюю длину волос после симуляции.
4. **Исследовать, как средняя длина волос и частота выпадения меняются при разных параметрах скорости роста, максимального возраста и вероятности выпадения.**

---

**Можно добавить:**
Параметры симуляции (скорость роста, возраст для выпадения, шанс выпадения) легко настраиваются через константы в начале кода.

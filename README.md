# Wireworld
## Курсовой проект

Wireworld — это клеточный автомат, который хорошо подходит для моделирования логических вентилей
Каждая клетка может находиться в одном из четырех состояний:
1. Пустой
2. Проводник
3. Голова сигнала
4. Хвост сигнала

Моделирование происходит шагами. На каждом шаге ячейки изменяются следующим образом:

- Пустая клетка всегда остаётся пустой
- Голова сигнала всегда превращается в хвост сигнала
- Хвост сигнала всегда превращается в проводник
- Проводник превращается в голову сигнала если одна или две соседние ячейки являются головами сигнала

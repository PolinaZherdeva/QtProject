#pragma once

#ifndef POWERSUPPLY_H
#define POWERSUPPLY_H

#include "PowerSupply_global.h"

#include "C:/Users/Lenovo/Documents/qt/PowerSupply/_Libs/visa.h"  // Подключаем заголовок VISA

#include <string>  // Подключаем библиотеку для работы с типом данных std::string
#include <fstream>  // Подключаем библиотеку для работы с файлами
#include <sstream>  // Подключаем библиотеку для работы с потоками строк (stringstream)
#include <iostream>  // Подключаем стандартную библиотеку для ввода/вывода

class POWERSUPPLY_EXPORT PowerSupply
{
public:
    // Конструктор, который принимает строковый параметр для идентификации устройства
    PowerSupply(const std::string& resource);
    // Деструктор, который автоматически вызывается при уничтожении объекта
    ~PowerSupply();

    // Метод для сброса устройства в исходное состояние
    void reset();
    // Метод для получения информации об устройстве (например, его идентификатор)
    //std::string identify();

    // Метод для установки выходного напряжения
    void setVoltage(float voltage, bool output);
    // Метод для установки ограничения тока
    void setCurrentLimit(float current_mA, bool output);
    // Метод для измерения выходного напряжения
    float measureVoltage(bool output);
    // Метод для измерения выходного тока
    float measureCurrent(bool output);
    // Метод для добавления разницы напряжений
    void addVoltageDifference(float limitU, bool output);
    // Метод для экстренного выключения устройства с сообщением
    void emergencyShutdown(const std::string& message);
    // Метод для обработки диапазона напряжений с применением шагов и оффсетов
    void processVoltageRange(float limitU_supply_min, float limitU_supply_max, float limitU_supply_step,
                             float limitI_supply, float limitU_offset, float limitI_offset,
                             const std::string& filePath, const std::string& fileName);

    // Новый метод для применения настроек из файла
    void applySettingsFromFile(const std::string& filePath, float powSup);

private:
    // Члены данных, которые хранят сессии для работы с VISA
    ViSession defaultRM = VI_NULL;  // Сессия для менеджера ресурсов
    ViSession vi = VI_NULL;         // Сессия для работы с источником питания

    // Приватный метод для проверки ошибок после выполнения команды
    void checkError(ViStatus status, const std::string& operation);
    // Приватный метод для отправки команды устройству
    void sendCommand(const std::string& command);
    // Приватный метод для чтения ответа от устройства
    std::string readResponse();
};

#endif // POWERSUPPLY_H

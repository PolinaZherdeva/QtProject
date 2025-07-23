#ifndef TESTBENCHDUALCHANNELAMPLIFIER_H
#define TESTBENCHDUALCHANNELAMPLIFIER_H

#include <string>
#include <vector>

using std::string;
using std::vector;

class TestbenchDualChannelAmplifier {
public:
    TestbenchDualChannelAmplifier();
    virtual ~TestbenchDualChannelAmplifier();

    // Методы
    virtual void PowerSupply() const;
    virtual void VNA() const;
    virtual void ThermalCamera() const;
    virtual void Multimeter() const;

    // Метод для сохранения файла с точкой компрессии
    void SaveFileWithCompressionPoint(string amp_diff_file, string outpFile, double freq_min, double freq_max, string powerSup);

protected:
    // Диапазон мощности
    int start_power = 0;
    int stop_power = 20;

    // Напряжения и токи
    string voltage_supply;
    string voltage_offset;
    string current_offset;

    // Выходной файл с компрессией
    string amp_diff_file;
    double amp_diff_power = 0.0;

    // Путь сохранения
    string result_path;

    // Диапазон частот
    double start_freq = 1.0; // например, в ГГц
    double stop_freq = 3.0;

    // Частоты и разница амплитуд
    vector<double> freqs; // список частот
    double amp_difference = 1.0; // допустимая разница усиления в dB
};

#endif // TESTBENCHDUALCHANNELAMPLIFIER_H

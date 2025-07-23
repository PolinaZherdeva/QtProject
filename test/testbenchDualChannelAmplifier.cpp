#include "testbenchDualChannelAmplifier.h"
#include <iostream>  // если используешь вывод в консоль

TestbenchDualChannelAmplifier::TestbenchDualChannelAmplifier() {
    // Конструктор
}

TestbenchDualChannelAmplifier::~TestbenchDualChannelAmplifier() {
    // Деструктор
}

void TestbenchDualChannelAmplifier::PowerSupply() const {
    std::cout << "PowerSupply from triple channel amplifier\n";
}

void TestbenchDualChannelAmplifier::VNA() const {
    SetupDevice();

    bool found = false;

    for (int power = start_power; power <= stop_power; ++power) {
        string filePath = SaveS2PFile(power, voltage_supply, voltage_offset, current_offset);
        CheckForCompressionPoint(filePath, power, found);
        if (found) break;
    }

    if (!found) {
        cout << "Couldn't find the compression point\n";
    }
    else {
        cout << "Compression file: " << amp_diff_file << " at power " << amp_diff_power << " dBm\n";
        SaveFileWithCompressionPoint(amp_diff_file, result_path, start_freq, stop_freq, voltage_supply);
    }

}

void TestbenchDualChannelAmplifier::ThermalCamera() const {
    std::cout << "ThermalCamera from triple channel amplifier\n";
}

void TestbenchDualChannelAmplifier::Multimeter() const {
    std::cout << "Multimeter from triple channel amplifier\n";
}


//---------------------------------- МЕТОДЫ ДЛЯ АНАЛИЗА S2P ФАЙЛОВ
// ? каие параметры указывать в методах
void  TestbenchDualChannelAmplifier::SaveFileWithCompressionPoint(string amp_diff_file, string outpFile, double freq_min, double freq_max, string powerSup) {

    // ---  читаем выбранный файл и записываем данные в новый файл
    ifstream selectedFile(amp_diff_file);
    // формирование файл для записи результата
    string fullpath = outpFile + "result_" + powerSup + "_V.csv";

    ofstream outputFile(fullpath); // открытие файла для записи

    // запись заголовка csv файла
    outputFile << "Frequency_GHz" << ";" << "Pin_dBm" << ";" << "Pout_dBm" << ";" << "S21_dB" << endl;

    if (selectedFile.is_open()) {
        string line;
        while (getline(selectedFile, line)) {
            if (line.empty() || line[0] == '!' || line[0] == '#')
                continue;

            stringstream ss(line);
            double frequency, s11_re, s11_im, s21_re, s21_im;

            if (ss >> frequency >> s11_re >> s11_im >> s21_re >> s21_im) {

                for (int f = freq_min; f <= freq_max; f++) {

                    double frequency_GHz = f * 1e9;

                    if (frequency == frequency_GHz) {
                        double Pout = s21_re + amp_diff_power;

                        outputFile << fixed << setprecision(0) << f << ";";
                        outputFile << amp_diff_power << ";";
                        outputFile << fixed << setprecision(10) << Pout << ";";
                        outputFile << s21_re << endl;
                    }
                }
            }
        }

        selectedFile.close();
        outputFile.close();

        std::cout << "Result saved in: " << fullpath << endl;

    }
    else {
        cerr << "Error: can not open result file" << endl;
    }
}


// Список частот сделать параметром класса
// const vector<double>& freqs
// amp_difference также передаётся в параметры класса

// основная логика нахождения файлов с точкой компрессии
void  VNA_Measurement::FindFileWithCompressionPoint(string voltage_supply, string voltage_offset, string current_offset) {

    // копируем список частот
    vector<double> remaining_freqs = freqs;
    // найдена ли хотя бы одна точка компрессии
    bool found_any = false;

    for (int power = start_power; power <= stop_power; ++power) {
        // метод для измерения s2p параметров из vna dll
        // сохранение пути к измеренному файлу
        string filePath = SaveS2PFile(power, voltage_supply, voltage_offset, current_offset);

        // используем итератор, чтобы можно было удалять элементы вектора
        for (auto it = remaining_freqs.begin(); it != remaining_freqs.end(); ) {
            // нашли ли точку компрессии на частоте
            bool found = false;
            // копируем текущую частоту в main_freq
            double main_freq = *it;

            CheckForCompressionPoint(filePath, power, main_freq, amp_difference, found);

            if (found) {
                cout << "Compression file: " << amp_diff_file << " at power " << amp_diff_power << " dBm\n";
                SaveFileWithCompressionPoint(amp_diff_file, result_path, start_freq, stop_freq, voltage_supply);
                it = remaining_freqs.erase(it);  // удаляем частоту из вектора, переходим к следующей частоте, цикл продолжается
                found_any = true;
            } else {
                ++it; // переходим к следующей частоте, если точка не найдена
            }
        }

        if (remaining_freqs.empty()) {
            cout << "Compression points found for all frequencies.\n";
            break;
        }
    }

    if (!found_any) {
        cout << "Could not find compression points for any frequency.\n";
    }
}

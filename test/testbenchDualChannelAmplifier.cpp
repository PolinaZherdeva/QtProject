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

// Проверка файла на разницу в 1 дБ (указанное значение) на списке частот main_freq
void TestbenchDualChannelAmplifier::CheckForCompressionPoint(const string& filePath, int power, bool& found) {
    Sleep(100); //?
    ifstream inputFile(filePath);
    if (!inputFile.is_open()) cout << "Error opening file with s2p parameters" << endl;

    string line;
    Sleep(700); // ?
    while (getline(inputFile, line)) {
        if (line.empty() || line[0] == '!' || line[0] == '#') continue;
        stringstream ss(line);
        double freq, s11_re, s11_im, s21_re, s21_im;
        if (ss >> freq >> s11_re >> s11_im >> s21_re >> s21_im) {
            if (freq == main_freq) {
                if (power == start_power) start_amp = s21_re;
                else {m
                    double diff = start_amp - s21_re;
                    cout << "Power: " << power << " Diff: " << diff << endl;

                    if ((diff >= amp_difference) && diff < best_diff) {m
                        best_diff = diff;
                        best_pow = power;
                        amp_diff_file = filePath;
                        amp_diff_power = power;
                        found = true;
                        break;
                    }
                }
            }
        }
    }
    inputFile.close();
}


void  TestbenchDualChannelAmplifier::SaveFileWithCompressionPoint(string amp_diff_file, string outpFile, double freq_min, double freq_max, string powerSup) {


    // --- теперь читаем выбранный файл и записываем данные в новый файл
    ifstream selectedFile(amp_diff_file);
    //ofstream outputFile("D:\\kalls\\result.txt");
    string fullpath = outpFile + "result_" + powerSup + "_V.csv";
    ofstream outputFile(fullpath); // файл для сохранения данных


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

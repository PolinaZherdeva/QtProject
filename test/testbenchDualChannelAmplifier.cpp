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
    std::cout << "VNA from triple channel amplifier\n";
}

void TestbenchDualChannelAmplifier::ThermalCamera() const {
    std::cout << "ThermalCamera from triple channel amplifier\n";
}

void TestbenchDualChannelAmplifier::Multimeter() const {
    std::cout << "Multimeter from triple channel amplifier\n";
}

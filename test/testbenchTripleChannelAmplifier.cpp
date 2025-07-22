#include "testbenchTripleChannelAmplifier.h"
#include <iostream> // если ты хочешь видеть вывод

TestbenchTripleChannelAmplifier::TestbenchTripleChannelAmplifier() {
    // Конструктор
}

TestbenchTripleChannelAmplifier::~TestbenchTripleChannelAmplifier() {
    // Деструктор
}

void TestbenchTripleChannelAmplifier::PowerSupply() const {
    std::cout << "PowerSupply from dual channel amplifier\n";
}

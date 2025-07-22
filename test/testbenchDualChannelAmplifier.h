#ifndef TESTBENCHDUALCHANNELAMPLIFIER_H
#define TESTBENCHDUALCHANNELAMPLIFIER_H

// Если ты используешь QObject и Qt слоты/сигналы, можешь добавить:
// #include <QObject>

// Класс без QObject:
class TestbenchDualChannelAmplifier {
public:
    TestbenchDualChannelAmplifier();
    virtual ~TestbenchDualChannelAmplifier();

    // Источник питания
    virtual void PowerSupply() const;

    // Векторный анализатор
    virtual void VNA() const;

    // Камера тепла и холода
    virtual void ThermalCamera() const;

    // Амперметр
    virtual void Multimeter() const;
};

#endif // TESTBENCHTRIPLECHANNELAMPLIFIER_H
